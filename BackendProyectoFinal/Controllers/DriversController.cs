using BackendProyectoFinal.Domain;
using DriverApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackendProyectoFinal.Controllers
{
    [ApiController]
    [Route("api/drivers")]
    public class DriversController : Controller
    {
        private readonly DriverContext driverContext;

        public DriversController(DriverContext driverContext)
        {
            this.driverContext = driverContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDrivers()
        {
            var drivers = await driverContext.Drivers.ToListAsync();
            return Ok(drivers);
        }

        [HttpPost]
        public async Task<IActionResult> AddDriver([FromBody] Driver driverRequest)
        {
            await driverContext.Drivers.AddAsync(driverRequest);
            await driverContext.SaveChangesAsync();
            return Ok(driverRequest);
        }
        
    }
}
