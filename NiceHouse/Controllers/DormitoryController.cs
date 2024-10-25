using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NiceHouse.Models;

namespace NiceHouse.Controllers
    {
        public class DormitoryController : Controller
            {
                private readonly ApplicationDbContext _context;

                public DormitoryController(ApplicationDbContext context)
                    {
                        _context = context;
                    }

//------------------------------------------------------------------------------

                public async Task<IActionResult> Index(string address, string name, decimal? minPrice, decimal? maxPrice, string type)
                    {
                        var dormitories = _context.Dormitories.Include(d => d.Images).AsQueryable();

                        if (!string.IsNullOrEmpty(address))
                            {
                                dormitories = dormitories.Where(d => d.Address.Contains(address));
                            }

                        if (!string.IsNullOrEmpty(name))
                            {
                                dormitories = dormitories.Where(d => d.Name.Contains(name));
                            }

                        if (minPrice.HasValue)
                            {
                                dormitories = dormitories.Where(d => d.MinRoomPrice >= minPrice.Value);
                            }

                        if (maxPrice.HasValue)
                            {
                                dormitories = dormitories.Where(d => d.MaxRoomPrice <= maxPrice.Value);
                            }

                        if (!string.IsNullOrEmpty(type))
                            {
                                if (Enum.TryParse<DormitoryType>(type, out var dormitoryType))
                                    {
                                        dormitories = dormitories.Where(d => d.Type == dormitoryType);
                                    }
                                else
                                    {
                                        ModelState.AddModelError("", "Invalid Type !!!");
                                    }
                            }

                        return View(await dormitories.ToListAsync());
                    }

//------------------------------------------------------------------------------

                public async Task<IActionResult> Details(int? id)
                    {
                        if (id == null || _context.Dormitories == null)
                            {
                                return NotFound();
                            }

                        var dormitory = await _context.Dormitories.Include(d => d.Images).FirstOrDefaultAsync(m => m.Id == id);

                        if (dormitory == null)
                            {
                                return NotFound();
                            }

                        return View(dormitory);
                    }

//------------------------------------------------------------------------------

                public IActionResult Create()
                    {
                        return View();
                    }

//------------------------------------------------------------------------------

                [HttpPost]
                [ValidateAntiForgeryToken]
                public async Task<IActionResult> Create([Bind("Id, Name, Type, Address, Description, MaxRoomPrice, MinRoomPrice, NumberOfPeople")] Dormitory dormitory)
                    {
                        if (ModelState.IsValid)
                            {
                                _context.Add(dormitory);
                                await _context.SaveChangesAsync();
                                return RedirectToAction(nameof(Index));
                            }
                        return View(dormitory);
                    }

//------------------------------------------------------------------------------

                public async Task<IActionResult> Edit(int? id)
                    {
                        if (id == null || _context.Dormitories == null)
                            {
                                return NotFound();
                            }

                        var dormitory = await _context.Dormitories.FindAsync(id);

                        if (dormitory == null)
                            {
                                return NotFound();
                            }
                        return View(dormitory);
                    }

//------------------------------------------------------------------------------

                [HttpPost]
                [ValidateAntiForgeryToken]
                public async Task<IActionResult> Edit(int id, [Bind("Id, Name, Type, Address, Description, MaxRoomPrice, MinRoomPrice, NumberOfPeople")] Dormitory dormitory)
                    {
                        if (id != dormitory.Id)
                            {
                                return NotFound();
                            }

                        if (ModelState.IsValid)
                            {
                                try
                                    {
                                        _context.Update(dormitory);
                                        await _context.SaveChangesAsync();
                                    }
                                catch (DbUpdateConcurrencyException)
                                    {
                                        if (!DormitoryExists(dormitory.Id))
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
                        return View(dormitory);
                    }

//------------------------------------------------------------------------------

                public async Task<IActionResult> Delete(int? id)
                    {
                        if (id == null || _context.Dormitories == null)
                            {
                                return NotFound();
                            }

                        var dormitory = await _context.Dormitories.Include(d => d.Images).FirstOrDefaultAsync(m => m.Id == id);

                        if (dormitory == null)
                            {
                                return NotFound();
                            }

                        return View(dormitory);
                    }

//------------------------------------------------------------------------------

                [HttpPost, ActionName("Delete")]
                [ValidateAntiForgeryToken]
                public async Task<IActionResult> DeleteConfirmed(int id)
                    {
                        if (_context.Dormitories == null)
                            {
                                return Problem("Entity set 'ApplicationDbContext.Dormitories' is null.");
                            }

                        var dormitory = await _context.Dormitories.FindAsync(id);
                        if (dormitory != null)
                            {
                                _context.Dormitories.Remove(dormitory);
                            }

                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }

//------------------------------------------------------------------------------

                private bool DormitoryExists(int id)
                    {
                        return _context.Dormitories?.Any(e => e.Id == id) ?? false;
                    }
            }
    }