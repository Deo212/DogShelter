using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DogShelter.Entities;
using PriutZaKucheta.Data;

namespace DogShelter.Controllers
{
    public class RequestDogsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RequestDogsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RequestDogs
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.RequestDogs.Include(r => r.Adoptive).Include(r => r.Status);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: RequestDogs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requestDog = await _context.RequestDogs
                .Include(r => r.Adoptive)
                .Include(r => r.Status)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (requestDog == null)
            {
                return NotFound();
            }

            return View(requestDog);
        }

        // GET: RequestDogs/Create
        public IActionResult Create()
        {
            ViewData["AdoptiveId"] = new SelectList(_context.Adoptives, "Id", "FirstName");
            ViewData["StatusId"] = new SelectList(_context.Statuses, "Id", "Id");
            return View();
        }

        // POST: RequestDogs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DogId,AdoptiveId,CreatedOn,DateOfAdoption,StatusId")] RequestDog requestDog)
        {
            if (ModelState.IsValid)
            {
                _context.Add(requestDog);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AdoptiveId"] = new SelectList(_context.Adoptives, "Id", "FirstName", requestDog.AdoptiveId);
            ViewData["StatusId"] = new SelectList(_context.Statuses, "Id", "Id", requestDog.StatusId);
            return View(requestDog);
        }

        // GET: RequestDogs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requestDog = await _context.RequestDogs.FindAsync(id);
            if (requestDog == null)
            {
                return NotFound();
            }
            ViewData["AdoptiveId"] = new SelectList(_context.Adoptives, "Id", "FirstName", requestDog.AdoptiveId);
            ViewData["StatusId"] = new SelectList(_context.Statuses, "Id", "Id", requestDog.StatusId);
            return View(requestDog);
        }

        // POST: RequestDogs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DogId,AdoptiveId,CreatedOn,DateOfAdoption,StatusId")] RequestDog requestDog)
        {
            if (id != requestDog.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(requestDog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RequestDogExists(requestDog.Id))
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
            ViewData["AdoptiveId"] = new SelectList(_context.Adoptives, "Id", "FirstName", requestDog.AdoptiveId);
            ViewData["StatusId"] = new SelectList(_context.Statuses, "Id", "Id", requestDog.StatusId);
            return View(requestDog);
        }

        // GET: RequestDogs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requestDog = await _context.RequestDogs
                .Include(r => r.Adoptive)
                .Include(r => r.Status)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (requestDog == null)
            {
                return NotFound();
            }

            return View(requestDog);
        }

        // POST: RequestDogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var requestDog = await _context.RequestDogs.FindAsync(id);
            _context.RequestDogs.Remove(requestDog);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RequestDogExists(int id)
        {
            return _context.RequestDogs.Any(e => e.Id == id);
        }
    }
}
