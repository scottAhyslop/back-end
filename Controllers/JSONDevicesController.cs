using back_end.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Collections.Immutable;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace back_end.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JSONDevicesController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;
        public JSONDevicesController(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }
        //to show a list of all devices
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                            select DeviceId, DeviceName, Temperature, DeviceIconPath, DeviceOSIconPath, DeviceType, DeviceOS, DeviceStatus, TimeInUse from Devices 
                  ";

            DataTable table = new();
            string sqlDataSource = _configuration.GetConnectionString("DeviceConn");
            SqlDataReader deviceReader;
            using (SqlConnection devconn = new SqlConnection(sqlDataSource))
            {
                devconn.Open();
                using (SqlCommand dbcom = new SqlCommand(query, devconn))
                {
                    deviceReader = dbcom.ExecuteReader();
                    table.Load(deviceReader);
                    deviceReader.Close();
                    devconn.Close();
                }
            }
            return new JsonResult(table);
        }//end Get

        //for updating values in Device
        [HttpPost]
        public JsonResult Post(Device dev)
        {
            //dev.DeviceType += dev.DeviceType.ToList<Device>();
            string query = @"
                           insert into dbo.Device
                           values (@DeviceName)";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DeviceConn");
            SqlDataReader deviceReader;
            using (SqlConnection devcon = new SqlConnection(sqlDataSource))
            {
                devcon.Open();
                using (SqlCommand devComm = new SqlCommand(query, devcon))
                {
                    devComm.Parameters.AddWithValue("@DeviceName", dev.DeviceName);
                    devComm.Parameters.AddWithValue("@DeviceType", dev.DeviceType);
                    devComm.Parameters.AddWithValue("@DeviceOS", dev.DeviceOS);
                    deviceReader = devComm.ExecuteReader();
                    table.Load(deviceReader);
                    deviceReader.Close();
                    devcon.Close();
                }
            }

            return new JsonResult(table);
        }//end Post

        //For updating the device
        [HttpPut]
        public JsonResult Put(Device dev)
        {
            string query = @"
                           update dbo.Device
                           set DeviceName=@DeviceName
                            where DeviceId=@DeviceId
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DeviceConn");
            SqlDataReader devReader;
            using (SqlConnection devconn= new SqlConnection(sqlDataSource))
            {
                devconn.Open();
                using (SqlCommand dbCom = new SqlCommand(query, devconn))
                {
                    dbCom.Parameters.AddWithValue("@DeviceId", dev.DeviceId);
                    dbCom.Parameters.AddWithValue("@DeviceName", dev.DeviceName);
                    devReader = dbCom.ExecuteReader();
                    table.Load(devReader);
                    devReader.Close();
                    devconn.Close();
                }
            }
            return new JsonResult("Updated Successfully");
        }

        //takes DeviceId for deletion
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = @"
                           delete from dbo.Device
                            where DeviceId=@DeviceId
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DeviceConn");
            SqlDataReader deviceReader;
            using (SqlConnection devconn = new SqlConnection(sqlDataSource))
            {
                devconn.Open();
                using (SqlCommand myCommand = new SqlCommand(query, devconn))
                {
                    myCommand.Parameters.AddWithValue("@DeviceId", id);

                    deviceReader = myCommand.ExecuteReader();
                    table.Load(deviceReader);
                    deviceReader.Close();
                    deviceReader.Close();
                }
            }
            return new JsonResult("Deleted Successfully");
        }//end Delete


        //for uploading pictures of the devices later
        [Route("Save File")]
        [HttpPost]
        public JsonResult SaveFile()
        {
            try
            {
                var httpRequest = Request.Form;
                var postedFile = httpRequest.Files[0];  
                string filename = postedFile.FileName;
                var physicalPath =  _env.ContentRootPath + "/Photos" + filename;

                using(var stream = new FileStream(physicalPath, FileMode.Create))
                {
                    postedFile.CopyTo(stream);  
                }
                return new JsonResult(filename);
            }
            catch (System.Exception)
            {

                return new JsonResult("anonymous.png");
            }
        }//end SaveFile
    }//end controller
}//end namespace
