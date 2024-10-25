using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class RoomTypeController : Controller
    {
        private readonly ApplicationDbContext _context;

//------------------------------------------------------------------------------

        public RoomTypeController(ApplicationDbContext context)
            {
                _context = context;
            }

//------------------------------------------------------------------------------

        public IActionResult Index()
            {
                var roomTypes = _context.RoomTypes.Include(rt => rt.Images).Include(rt => rt.Hotel).ToList();
                return View(roomTypes);
            }
    }