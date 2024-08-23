using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAppAsset.Data;
using WebAppAsset.Models.Entities;

namespace WebAppAsset.Controllers
{
    [Authorize]
    public class MainCategoryController : Controller
    {
        private readonly AppDbContext _context;

        public MainCategoryController(AppDbContext context)
        {
            _context = context;
        }
        [AllowAnonymous]
        // GET: MainCategory
        public async Task<IActionResult> Index()
        {
            return View(await _context.MainCategories.ToListAsync());
        }
        [AllowAnonymous]
        // GET: MainCategory/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mainCategory = await _context.MainCategories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mainCategory == null)
            {
                return NotFound();
            }

            return View(mainCategory);
        }
        
        // GET: MainCategory/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MainCategory/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MainCategoryName,Description")] MainCategory mainCategory)
        {
            if (ModelState.IsValid)
            {
                var uid = User.Identity?.Name;
                mainCategory.CreatedBy = uid;
                mainCategory.CreateDate = DateTime.Now;
                _context.Add(mainCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mainCategory);
        }
     
        // GET: MainCategory/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mainCategory = await _context.MainCategories.FindAsync(id);
            if (mainCategory == null)
            {
                return NotFound();
            }
            return View(mainCategory);
        }

        // POST: MainCategory/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MainCategoryName,Description,Id,IsActive,IsDeleted")] MainCategory mainCategory)
        {
            if (id != mainCategory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var uid = User.Identity?.Name;
                    mainCategory.UpdatedBy = uid;
                    mainCategory.UpdateDate = DateTime.Now;
                    if(mainCategory.IsDeleted == false)
                    {
                        mainCategory.DeleteDate = null;
                        mainCategory.DeletedBy = null;
                        mainCategory.IsDeleted = false;
                    }
                    else
                    {                      
                        mainCategory.DeletedBy = uid;
                        mainCategory.DeleteDate = DateTime.Now;
                        mainCategory.IsDeleted = true;
                    }
                    _context.Update(mainCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MainCategoryExists(mainCategory.Id))
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
            return View(mainCategory);
        }

        // GET: MainCategory/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mainCategory = await _context.MainCategories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mainCategory == null)
            {
                return NotFound();
            }

            return View(mainCategory);
        }

        // POST: MainCategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mainCategory = await _context.MainCategories.FindAsync(id);
            if (mainCategory != null)
            {
                var uid = User.Identity?.Name;
                mainCategory.DeletedBy = uid;
                mainCategory.DeleteDate = DateTime.Now;
                mainCategory.IsDeleted = true;
                _context.Update(mainCategory);
                await _context.SaveChangesAsync();
                //_context.MainCategories.Remove(mainCategory);
            }

            //await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MainCategoryExists(int id)
        {
            return _context.MainCategories.Any(e => e.Id == id);
        }
    }
}
