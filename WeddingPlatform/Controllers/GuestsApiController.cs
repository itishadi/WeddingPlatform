using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeddingPlatform.Data;
using WeddingPlatform.ViewModels;

namespace WeddingPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestsApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GuestsApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<object>>> GetGuests()
        {
            var guests = await _context.Guests
                .Select(g => new
                {
                    g.Name,
                    g.Email,
                    g.WillAttend,
                    g.NumberOfAttendants
                })
                .ToListAsync();

            return Ok(guests);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGuest(int id)
        {
            var guest = await _context.Guests
                .Where(g => g.Id == id)
                .Select(g => new
                {
                    g.Name,
                    g.Email,
                    g.WillAttend,
                    g.NumberOfAttendants
                })
                .FirstOrDefaultAsync();

            if (guest == null)
                return NotFound();

            return Ok(guest);
        }
    }
}