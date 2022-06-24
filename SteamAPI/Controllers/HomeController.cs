using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SteamAPI.Data;
using SteamAPI.Models;

namespace SteamAPI.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _context;
    
    public HomeController(ApplicationDbContext context, ILogger<HomeController> logger)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        if (_context.Group != null)
        {
            var items = await _context.Group.ToListAsync();
            ViewData["groups"] = items;
            ViewData["context"] = _context;
        }

        return View();
    }

    public RedirectToActionResult add_group_test(Group group)
    {
        Console.Write(group);
        // _context.Add(group);
        // _context.SaveChanges();
        return RedirectToAction(actionName: "Index", controllerName: "Home");
    }

   
   
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}