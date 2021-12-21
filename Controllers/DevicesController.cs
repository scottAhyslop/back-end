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
using back_end.Classes;

namespace back_end.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevicesController : ControllerBase
    {
        private readonly DeviceContext _context;
       
        //dbContext
        public DevicesController(DeviceContext context)
        {
            _context = context;
        }

        // GET: api/DevicesController
        [EnableCors("AllowedSpecificOrigins")]
        [HttpGet]
        public async Task<IActionResult> GetDevices([FromQuery] DeviceSearchParams  deviceSearchParams)
        {
            //FOR TESTING ONLY
            //return  TestData.allDevices;

            //makes sure page>0., else page falls out of range and errors out
            if (deviceSearchParams.Page<=0)
            {
                deviceSearchParams.Page = 1;
            }

            //Will return from a real database connection
            IQueryable<Device> devices = _context.Devices;

            //set LINQ search params based on DeviceName, DeviceOs, DeviceType
            if ((deviceSearchParams.DeviceName != null) || (deviceSearchParams.DeviceOS !=null) || (deviceSearchParams.DeviceType != null))
            {
               var selectedDevices = from value in 
                   (from device in devices
                    orderby device.DeviceName descending
                    select new { DeviceName = device.DeviceName, DeviceOS = device.DeviceOs, DeviceType = device.DeviceOs})
                    group value by value.DeviceName into dg
                    select dg.First();
                    
            }//end LINQ statement

            //Search by SearchTerm
            if (!string.IsNullOrEmpty(deviceSearchParams.SearchTerm))
            {
                devices = devices.Where(d => d.DeviceName.ToLower().Contains(deviceSearchParams.SearchTerm.ToLower()) || d.DeviceName.ToLower().Contains(deviceSearchParams.SearchTerm.ToLower()));
            }


            //Search by Name
            if (!string.IsNullOrEmpty(deviceSearchParams.DeviceName))
            {
                //by DeviceId
                //devices = devices.Where(d => d.DeviceId == deviceSearchParams.DeviceId);

                //By DeviceName
                devices = devices.Where(d =>d.DeviceName == deviceSearchParams.DeviceName);

            }

            //SortBy options using IQueryableExtensions
            if (!string.IsNullOrEmpty(deviceSearchParams.SortBy))
            {
                devices = devices.OrderByCustom(deviceSearchParams.SortBy, deviceSearchParams.SortOrder);
            }

            //for item and pagination
            devices = devices
                .Skip(deviceSearchParams.Size*(deviceSearchParams.Page - 1))
                .Take(deviceSearchParams.Size);

            return Ok(await devices.ToListAsync());

            //JsonResult 
            //return new JsonResult(devices);

        }

        // GET: api/DevicesControllerEF/5
        [EnableCors("AllowedSpecificOrigins")]//FOR TESTING ONLY, remove for production
        [HttpGet, Route("{id:int}")]
        
        public async Task<IActionResult> GetDevice(int deviceId)
        {
            var device = await _context.Devices.FindAsync(deviceId);

            if (device == null)
            {
                return NotFound();
            }

            return Ok(device);
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
