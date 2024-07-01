using Microsoft.AspNetCore.Mvc;
using test3.Entity;
using test3.TimeZoneDBContext;

namespace test3.Controllers
{
    [ApiController]
    [Route("")]
    public class TimeZone : Controller
    {
        private TimeZoreDBcontext _context { get; set; }
        public TimeZone(TimeZoreDBcontext context)
        {
            _context = context;

        }
        static List<String> timeZones = new List<String>();
        [HttpGet]
        public async Task FetchTimeZone()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(new Uri("https://timeapi.io/api/TimeZone/AvailableTimeZones"));
            var timezones = await response.Content.ReadAsStringAsync();
            var timeZones = timezones.Split(',').ToList();

           
            foreach (var country in timeZones)

            {
               
                await _context.timezones.AddAsync(new Countries() { CountryNames = country.ToString() });


            }



            await _context.SaveChangesAsync();
            Console.WriteLine(timeZones);



        }
        [HttpGet("PrintAllTimeZones")]
        public IActionResult GetTimeZone()
        {
            return Ok(timeZones);

        }
    }
}
