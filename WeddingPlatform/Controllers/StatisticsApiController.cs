using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeddingPlatform.Data;

namespace WeddingPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StatisticsApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetStatistics()
        {
            var totalGuests = await _context.Guests.CountAsync();

            var attendingGuests = await _context.Guests
                .CountAsync(g => g.WillAttend == true);

            var notAttendingGuests = await _context.Guests
                .CountAsync(g => g.WillAttend == false);

            var attendancePercentage =
                totalGuests == 0
                    ? 0
                    : (double)attendingGuests / totalGuests * 100;

            return Ok(new
            {
                totalGuests,
                attendingGuests,
                notAttendingGuests,
                attendancePercentage
            });
        }
    }
}


//{
//    "totalGuests": 25,
//  "attendingGuests": 18,
//  "notAttendingGuests": 4,
//  "attendancePercentage": 72
//}
