using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ST10395938_CLDV6211_POEPart1.Models;

namespace ST10395938_CLDV6211_POEPart1.Controllers
{
    public class VenuesController : Controller
    {
        // The code was adapted from "MVC, Entity Framework & SQL Azure" by Adeol Adisa
        private readonly ApplicationDbContext _context;

        public VenuesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var venues = await _context.Venues.ToListAsync();
            return View(venues);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Venues venue)
        {
            if (ModelState.IsValid)
            {
                _context.Add(venue);

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(venue);
        }

        public async Task<IActionResult> Delete(int? venueId)
        {
            var venue = await _context.Venues.FirstOrDefaultAsync(m => m.VenueId == venueId);

            if (venue == null)
            {
                return NotFound();
            }
            return View(venue);
        }

        [HttpPost]

        public async Task<IActionResult> Delete(int venueId)
        {
            var venue = await _context.Venues.FindAsync(venueId);
            _context.Venues.Remove(venue);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VenuesExists(int venueId)
        {
            return _context.Venues.Any(e => e.VenueId == venueId);
        }

        public async Task<IActionResult> Edit(int? venueId)
        {
            if (venueId == null)
            {
                return NotFound();
            }

            var venue = await _context.Venues.FindAsync(venueId);
            if (venueId == null)
            {
                return NotFound();
            }
            return View(venue);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int venueId, Venues venue)
        {
            if (venueId != venue.VenueId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(venue);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VenuesExists(venue.VenueId))
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
            return View(venue);
        }

        public async Task<IActionResult> Details(int? venueId)
        {
            if (venueId == null)
            {
                return NotFound();
            }

            var venue = await _context.Venues
              
                .FirstOrDefaultAsync(b => b.VenueId == venueId);

            if (venue == null)
            {
                return NotFound();
            }

            return View(venue);  // Return the booking details to the view
        }

    }
}
