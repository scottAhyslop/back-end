using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using back_end.Models;

using Microsoft.AspNetCore.Cors;
using System.Net;

namespace back_end.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevicesController : ControllerBase
    {
        private readonly DeviceContext _context;
       
        public DevicesController(DeviceContext context)
        {
            _context = context;
            
            
        }

        // GET: api/DevicesController
        [EnableCors("AllowedSpecificOrigins")]
        [HttpGet]
        public IEnumerable<Device> GetDevices()
        {
            //FOR TESTING ONLY
            //return  TestData.allDevices;
            //Will return from a real database connection
            return _context.Devices.ToList();

            //want to return result here as a json obj to solve front-end issues
            //var listOfDevices = JsonResult(_context.Devices);

            //return listOfDevices.ToList().;
        }

        // GET: api/DevicesControllerEF/5
        [EnableCors("AllowedSpecificOrigins")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDevice(int id)
        {
            var device = await _context.Devices.FindAsync(id);

            if (device == null)
            {
                return NotFound();
            }

            return (IActionResult)(Device)device;
        }

        // PUT: api/DevicesControllerEF/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDeviceAsync(int id, Device device)
        {
            if (id != device.DeviceId)
            {
                return BadRequest();
            }

            _context.Entry(device).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeviceExists(id))
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

        // POST: api/DevicesControllerEF
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [EnableCors("AllowedSpecificOrigins")]
        [HttpPost]
        public async Task<ActionResult<Device>> PostDevice(Device device)
        {
            _context.Devices.Add(device);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Device), new { id = device.DeviceId }, device);
        }

        // DELETE: api/DevicesControllerEF/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDevice(int id)
        {
            var device = await _context.Devices.FindAsync(id);
            if (device == null)
            {
                return NotFound();
            }

            _context.Devices.Remove(device);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DeviceExists(int id)
        {
            return _context.Devices.Any(e => e.DeviceId == id);
        }
    }
}
