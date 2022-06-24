using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SteamAPI.Data;
using SteamAPI.Models;

namespace SteamAPI.Controllers
{
    public class UserInGroupController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserInGroupController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: UserInGroup
        public async Task<IActionResult> Index()
        {
              return _context.UserInGroup != null ? 
                          View(await _context.UserInGroup.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.UserInGroup'  is null.");
        }

        // GET: UserInGroup/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.UserInGroup == null)
            {
                return NotFound();
            }

            var userInGroup = await _context.UserInGroup
                .FirstOrDefaultAsync(m => m.ID == id);
            if (userInGroup == null)
            {
                return NotFound();
            }

            return View(userInGroup);
        }

        // GET: UserInGroup/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserInGroup/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,UserID,GroupID")] UserInGroup userInGroup)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userInGroup);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userInGroup);
        }

        // GET: UserInGroup/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.UserInGroup == null)
            {
                return NotFound();
            }

            var userInGroup = await _context.UserInGroup.FindAsync(id);
            if (userInGroup == null)
            {
                return NotFound();
            }
            return View(userInGroup);
        }

        // POST: UserInGroup/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,UserID,GroupID")] UserInGroup userInGroup)
        {
            if (id != userInGroup.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userInGroup);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserInGroupExists(userInGroup.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(userInGroup);
        }

        // GET: UserInGroup/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.UserInGroup == null)
            {
                return NotFound();
            }

            var userInGroup = await _context.UserInGroup
                .FirstOrDefaultAsync(m => m.ID == id);
            if (userInGroup == null)
            {
                return NotFound();
            }

            return View(userInGroup);
        }

        // POST: UserInGroup/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.UserInGroup == null)
            {
                return Problem("Entity set 'ApplicationDbContext.UserInGroup'  is null.");
            }
            var userInGroup = await _context.UserInGroup.FindAsync(id);
            if (userInGroup != null)
            {
                _context.UserInGroup.Remove(userInGroup);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserInGroupExists(int id)
        {
          return (_context.UserInGroup?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
