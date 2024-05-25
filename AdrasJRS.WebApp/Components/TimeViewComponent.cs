using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AdrasJRS.Data.Entities;
using AdrasJRS.Data.DataContext;

namespace AdrasJRS.WebApp.Components;
public class TimeViewComponent : ViewComponent
{
    private readonly DataDbContext _context;

    public TimeViewComponent(DataDbContext context)
    {
        _context = context;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        List<Time> timeList = await _context.Times.OrderBy(t => t.Id).ToListAsync();
        return View(timeList);
    }
}