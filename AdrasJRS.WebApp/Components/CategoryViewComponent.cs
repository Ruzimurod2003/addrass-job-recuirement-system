﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AdrasJRS.Data.Entities;
using AdrasJRS.Data.DataContext;

namespace AdrasJRS.WebApp.Components;
public class CategoryViewComponent : ViewComponent
{
    private readonly DataDbContext _context;

    public CategoryViewComponent(DataDbContext context)
    {
        _context = context;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var random = new Random();

        //random categories - 4
        var categoryList = await _context.Categories.ToListAsync();
        List<Category> randomCategories = categoryList.OrderBy(c => random.Next()).Take(4).ToList();
        return View(randomCategories);
    }
}