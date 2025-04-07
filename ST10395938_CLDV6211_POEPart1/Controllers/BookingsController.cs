using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ST10395938_CLDV6211_POEPart1.Models;

namespace ST10395938_CLDV6211_POEPart1.Controllers
{
    public class BookingsController : Controller
    {
        // The code was adapted from "MVC, Entity Framework & SQL Azure" by Adeol Adisa
        private readonly ApplicationDbContext _context;
        public BookingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var bookings = await _context.Bookings
                .Include(i => i.Venues)
                .Include(i => i.Events)
                .ToListAsync();

            return View(bookings);
        }

        public IActionResult Create()
        {
            ViewBag.Venues = _context.Venues.ToList();
            ViewBag.Events = _context.Events.ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Bookings bookings)
        {
            if (ModelState.IsValid)
            {
                bookings.Venues = null;  // Prevent EF from thinking this is a new Venue object
                bookings.Events = null;

                _context.Add(bookings);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Venues = _context.Venues.ToList();
            ViewBag.Events = _context.Events.ToList();
            return View(bookings);
        }

        public async Task<IActionResult> Delete(int? bookingId)
        {
            if (bookingId == null)
            {
                return NotFound();
            }

            var bookings = await _context.Bookings
                .Include(f => f.Venues)
                .Include(f => f.Events)// Include related venue data
                .FirstOrDefaultAsync(e => e.BookingId == bookingId);

            if (bookings == null)
            {
                return NotFound();
            }

            return View(bookings);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int bookingId)
        {
            var bookings = await _context.Bookings.FindAsync(bookingId);

            if (bookings != null)
            {
                _context.Bookings.Remove(bookings);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? bookingId)
        {
            if (bookingId == null)
            {
                return NotFound();
            }

            var booking = await _context.Bookings
                .Include(f => f.Venues)   // Include related venue data
                .Include(f => f.Events)   // Include related event data
                .FirstOrDefaultAsync(b => b.BookingId == bookingId);

            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);  // Return the booking details to the view
        }

    }
}
