using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AdrasJRS.Data.DataContext;
using AdrasJRS.Data.Entities;
using AdrasJRS.Data.ViewModel;
using Microsoft.AspNetCore.Authorization;
using AdrasJRS.Common;
using X.PagedList;
using AdrasJRS.Data.Enums;
using System.Text.RegularExpressions;

namespace AdrasJRS.WebApp.Areas.Admin.Controllers;
[Area("Admin")]
[Route("admin/resource")]
[Authorize(Roles = "Admin")]
public class ResourceController : Controller
{
    private readonly DataDbContext _context;

    public ResourceController(DataDbContext context)
    {
        _context = context;
    }

    [Route("")]
    [Route("index")]
    public async Task<IActionResult> Index(int? page)
    {
        int pageSize = 10; //number of resources per page

        var resources = await _context.Resources
            .OrderByDescending(t => t.Id)
            .GroupBy(i => i.Key)
            .Select(i => new CreateResourceViewModel()
            {
                Key = i.Key,
                Value_EN = i.FirstOrDefault(j => j.CultureId == (int)CulturesEnum.English).Value,
                Value_RU = i.FirstOrDefault(j => j.CultureId == (int)CulturesEnum.Russian).Value,
                Value_UZ = i.FirstOrDefault(j => j.CultureId == (int)CulturesEnum.Uzbek).Value,
                Value_DE = i.FirstOrDefault(j => j.CultureId == (int)CulturesEnum.German).Value,
            }).ToListAsync();

        return View(resources.ToPagedList(page ?? 1, pageSize));
    }

    [Route("create")]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [Route("create")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateResourceViewModel model)
    {
        if (ModelState.IsValid)
        {
            Resource resource_EN = new Resource()
            {
                Key = model.Key,
                Value = model.Value_EN,
                CultureId = (int)CulturesEnum.English
            };
            _context.Resources.Add(resource_EN);

            Resource resource_RU = new Resource()
            {
                Key = model.Key,
                Value = model.Value_RU,
                CultureId = (int)CulturesEnum.Russian
            };
            _context.Resources.Add(resource_RU);

            Resource resource_UZ = new Resource()
            {
                Key = model.Key,
                Value = model.Value_UZ,
                CultureId = (int)CulturesEnum.Uzbek
            };
            _context.Resources.Add(resource_UZ);

            Resource resource_DE = new Resource()
            {
                Key = model.Key,
                Value = model.Value_DE,
                CultureId = (int)CulturesEnum.German
            };
            _context.Resources.Add(resource_DE);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(model);
    }

    [Route("update")]
    public async Task<IActionResult> Update(string key)
    {
        var resources = await _context.Resources
            .Where(t => t.Key == key)
            .OrderByDescending(t => t.Id)
            .GroupBy(i => i.Key)
            .Select(i => new UpdateResourceViewModel()
            {
                Key = i.Key,
                Value_EN = i.FirstOrDefault(j => j.CultureId == (int)CulturesEnum.English).Value,
                Value_RU = i.FirstOrDefault(j => j.CultureId == (int)CulturesEnum.Russian).Value,
                Value_UZ = i.FirstOrDefault(j => j.CultureId == (int)CulturesEnum.Uzbek).Value,
                Value_DE = i.FirstOrDefault(j => j.CultureId == (int)CulturesEnum.German).Value,
            }).ToListAsync();

        var resource = resources.FirstOrDefault();

        return View(resource);
    }

    [Route("update")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Update(string key, UpdateResourceViewModel model)
    {
        List<Resource> resources = await _context.Resources.Where(t => t.Key == key).ToListAsync();
        foreach (Resource resource in resources)
        {
            if (resource.CultureId == (int)CulturesEnum.English)
            {
                resource.Value = model.Value_EN;
            }
            else if (resource.CultureId == (int)CulturesEnum.Russian)
            {
                resource.Value = model.Value_RU;
            }
            else if (resource.CultureId == (int)CulturesEnum.Uzbek)
            {
                resource.Value = model.Value_UZ;
            }
            else if (resource.CultureId == (int)CulturesEnum.German)
            {
                resource.Value = model.Value_DE;
            }
        }
        await _context.SaveChangesAsync();
        return Redirect("/admin/resource");
    }

    [HttpGet("delete/{key}")]
    public IActionResult Delete(string key)
    {
        try
        {
            List<Resource> resources = _context.Resources.Where(t => t.Key == key).ToList();
            _context.Resources.RemoveRange(resources);
            _context.SaveChanges();
            return Redirect("/admin/resource");
        }
        catch (System.Exception)
        {
            return Redirect("/admin/resource");
        }
    }

    [HttpPost("delete-selected")]
    public async Task<IActionResult> DeleteSelected(string[] listDelete)
    {
        foreach (string key in listDelete)
        {
            List<Resource> resources = _context.Resources.Where(t => t.Key == key).ToList();
            _context.Resources.RemoveRange(resources);
        }
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
    }
}