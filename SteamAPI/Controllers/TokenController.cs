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
    public class TokenController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TokenController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Token
        public async Task<IActionResult> Index()
        {
              return _context.Tokens != null ? 
                          View(await _context.Tokens.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Tokens'  is null.");
        }

        // GET: Token/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Tokens == null)
            {
                return NotFound();
            }

            var token = await _context.Tokens
                .FirstOrDefaultAsync(m => m.ID == id);
            if (token == null)
            {
                return NotFound();
            }

            return View(token);
        }

        // GET: Token/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Token/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,UserID,SteamToken")] Token token)
        {
            if (ModelState.IsValid)
            {
                _context.Add(token);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(token);
        }

        // GET: Token/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Tokens == null)
            {
                return NotFound();
            }

            var token = await _context.Tokens.FindAsync(id);
            if (token == null)
            {
                return NotFound();
            }
            return View(token);
        }

        // POST: Token/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,UserID,SteamToken")] Token token)
        {
            if (id != token.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(token);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TokenExists(token.ID))
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
            return View(token);
        }

        // GET: Token/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Tokens == null)
            {
                return NotFound();
            }

            var token = await _context.Tokens
                .FirstOrDefaultAsync(m => m.ID == id);
            if (token == null)
            {
                return NotFound();
            }

            return View(token);
        }

        // POST: Token/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Tokens == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Tokens'  is null.");
            }
            var token = await _context.Tokens.FindAsync(id);
            if (token != null)
            {
                _context.Tokens.Remove(token);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TokenExists(int id)
        {
          return (_context.Tokens?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
