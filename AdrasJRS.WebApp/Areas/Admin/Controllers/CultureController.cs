using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AdrasJRS.Data.DataContext;
using AdrasJRS.Data.Entities;
using AdrasJRS.Data.ViewModel;
using Microsoft.AspNetCore.Authorization;
using AdrasJRS.Common;
using X.PagedList;

namespace AdrasJRS.WebApp.Areas.Admin.Controllers;
[Area("Admin")]
[Route("admin/culture")]
[Authorize(Roles = "Admin")]
public class CultureController : Controller
{
    private readonly DataDbContext _context;

    public CultureController(DataDbContext context)
    {
        _context = context;
    }

    [Route("")]
    [Route("index")]
    public async Task<IActionResult> Index(int? page)
    {
        int pageSize = 10; //number of cultures per page

        var culture = await _context.Cultures.OrderBy(t => t.Name).ToListAsync();
        return View(culture.ToPagedList(page ?? 1, pageSize));
    }

    [Route("create")]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [Route("create")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateCultureViewModel model)
    {
        if (ModelState.IsValid)
        {
            Culture culture = new Culture()
            {
                Name = model.Name,
            };
            _context.Cultures.Add(culture);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(model);
    }

    [Route("update/{id}")]
    public IActionResult Update(int id)
    {
        var culture = _context.Cultures.Where(t => t.Id == id).First();
        return View(culture);
    }

    [Route("update/{id}")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Update(int id, UpdateCultureViewModel model)
    {
        Culture culture = _context.Cultures.Where(t => t.Id == id).First();
        culture.Name = model.Name;
        _context.Cultures.Update(culture);
        await _context.SaveChangesAsync();
        return Redirect("/admin/culture");
    }

    [HttpGet("delete/{id}")]
    public IActionResult Delete(int id)
    {
        try
        {
            Culture culture = _context.Cultures.Where(t => t.Id == id).First();
            _context.Cultures.Remove(culture);
            _context.SaveChanges();
            return Redirect("/admin/culture");
        }
        catch (System.Exception)
        {
            return Redirect("/admin/culture");
        }
    }

    [HttpPost("delete-selected")]
    public async Task<IActionResult> DeleteSelected(int[] listDelete)
    {
        foreach (int id in listDelete)
        {
            var culture = await _context.Cultures.FindAsync(id);
            _context.Cultures.Remove(culture);
        }
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
    }
}