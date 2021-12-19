
using back_end.Models;
using back_end.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OneValetAssessmentAPI.Data
{
    public class TestData
    {
        public List<Device> Devices => allDevices;

        DeviceOSIcon newDeviceType = new DeviceOSIcon();
        DeviceOSIcon newDeviceOS = new DeviceOSIcon();

        public static List<Device> allDevices = new List<Device>()
        {

          /*
            public string? DeviceIconPath { get; set; }
            public string? DeviceOSIconPath { get; set; }
            public string? DeviceType{get; set; }
            public string? DeviceOS{get; set; }
            public string? DeviceStatus { get; set; } 
            public TimeSpan? TimeInUse { get; set; }

            DeviceOSIcon(string deviceOS, string deviceType)

          */
            new Device()
            {
                DeviceId=1,
                DeviceName="My Lovely iPad",
                Temperature=(float)34.5,
                //DeviceIconPath=newDeviceType.newDeviceNameAndIconDictionary         ,//DeviceOSIcon("tablet","iOS"),
                //DeviceOSIconPath="iOS",
                DeviceType="Tablet",
                DeviceOS="iOS",
                DeviceStatus="OPERATIONAL",
                TimeInUse=new TimeSpan(1,3,14,56)
            },
            new Device()
            {
                DeviceId=2,
                DeviceName="Dad's Phone",
                Temperature=(float)68.5,
                //DeviceIconPath="Phone",
                //DeviceOSIconPath="Android",
                DeviceType="Phone",
                DeviceOS="Android",
                DeviceStatus="OVERHEATING",
                TimeInUse=new TimeSpan(16,24,46,2)
            },
            new Device()
            {
                DeviceId=3,
                DeviceName="Mom's laptop",
                Temperature=(float)14.5,
                //DeviceIconPath="Laptop",
                //DeviceOSIconPath="Windows",
                DeviceType="laptop",
                DeviceOS="Windows",
                DeviceStatus="COOLING",
                TimeInUse=new TimeSpan(29,41,37,42)
            }
        };//end Device list
    }//end data class
}//end namespace