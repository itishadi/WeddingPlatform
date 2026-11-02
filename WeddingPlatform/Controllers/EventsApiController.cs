using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeddingPlatform.Data;

namespace WeddingPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EventsApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetEvents()
        {
            var eventsList = await _context.Events
                .Select(e => new
                {
                    e.Id,
                    e.Title,
                    e.Location,
                    e.EventDate
                })
                .ToListAsync();

            return Ok(eventsList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEvent(int id)
        {
            var eventItem = await _context.Events
                .Where(e => e.Id == id)
                .Select(e => new
                {
                    e.Id,
                    e.Title,
                    e.Location,
                    e.EventDate,
                    e.Description
                })
                .FirstOrDefaultAsync();

            if (eventItem == null)
                return NotFound();

            return Ok(eventItem);
        }
    }
}