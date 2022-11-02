using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackendProyectoFinal.Domain;
using DriverApi.Models;
using System.Numerics;

namespace BackendProyectoFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriversController : ControllerBase
    {
        private readonly DriverContext _context;

        public DriversController(DriverContext context)
        {
            _context = context;
        }

        // GET: api/Drivers
        [HttpGet] 
        public async Task<ActionResult<IEnumerable<Driver>>> GetDrivers()
        {
            return await _context.Drivers.ToListAsync();
        }

        // GET: api/Drivers/5
        [HttpGet("{id}")] 
        public async Task<ActionResult<Driver>> GetDriver(Int32 id)
        {
            var driver = await _context.Drivers.FindAsync(id);

            if (driver == null)
            {
                return NotFound();
            }

            return driver;
        }

        // PUT: api/Drivers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDriver(Int32 id, Driver driver)
        {
            if (id != driver.driverId)
            {
                return BadRequest();
            }

            _context.Entry(driver).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DriverExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Drivers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Driver>> PostTodoItem(Driver driverItem)
        {
            _context.Drivers.Add(driverItem);
            Console.WriteLine(driverItem);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
            return CreatedAtAction(nameof(GetDriver), new { id = driverItem.driverId }, driverItem);
        }

        // DELETE: api/Drivers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDriver(Int32 id)
        {
            var driver = await _context.Drivers.FindAsync(id);
            if (driver == null)
            {
                return NotFound();
            }

            _context.Drivers.Remove(driver);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DriverExists(Int32 id)
        {
            return _context.Drivers.Any(e => e.driverId == id);
        }
    }
}
/*httprepl https://localhost:5136/api/Drivers
post -h Content-Type=application/json -c "{"driverId": 1,"nombre": "sebastian","direccion": "calle 44#41-36", "correo": "sebasrpg1232@gmail.com", "numero": 102030}"
 * 

connect https://localhost:5136/api/Drivers
get



public Int32 driverId { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set; }
        
        public string correo { get; set; }
        public int32 numero{ get; set; }
 */