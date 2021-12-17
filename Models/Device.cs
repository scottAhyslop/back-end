using System;
using System.Collections.Generic;


namespace back_end.Models
{
    public class Device
    {
        private int _deviceId;
        //DeviceId incrementer holder value
        private static int deviceIdIncrementer = 0;
       //DeviceID auto generated upon creation
        public int DeviceId 
        { get {return _deviceId;}
          set { if (value!=0)
                {
                    _deviceId=value;
                } else if(value==0)
                {
                     throw new NullReferenceException();
                }
          }
         }
        

        //blank constructor
        public Device()
        {
        }
        //these values will be pulled from data to populate the device, all values can be null, except for DeviceId which is created upon instantiation, and temp which will be wired to the device
        public Device(string deviceName, float temp, List<string> deviceIconPath, List<string> deviceOSIconPath, string deviceOS, string deviceType, string deviceStatus, TimeSpan timeInUse)
        {
            //create a new DeviceId using system clock to give each instance a unique id    
            this.DeviceId = System.Threading.Interlocked.Increment(ref deviceIdIncrementer);

            //Properties that may or may not be null depending on what data is passed in
            DeviceName = deviceName;
            if (DeviceName == null)
            {
                DeviceName="New Device";
            }
            if (temp == 0)
            {
                //assuming the temp of the Device is being tracked and updated by the tick...
                Temperature = this.Temperature;
            }
            //These fields will be chosen by the user in AddDevice
            //Drop-down menus in forms that will show icons co-relating to the OSs and Devices chosen
            //The icons, devices, and OSs currently can be populated into dictionaries by methods found DeviceOSIcon
            DeviceIconPath = deviceIconPath;
            DeviceOSIconPath = deviceOSIconPath;
            DeviceOS = deviceOS;
            DeviceType = deviceType;
            DeviceOSIcon newDeviceOSIcon = new DeviceOSIcon(deviceIconPath.ToString(), deviceOSIconPath.ToString());
            
            //a general health of the machine check, assuming that there is an active routine montioring 'health' params and that this app would have access to that, in the meantime, it's a string
            DeviceStatus = deviceStatus;
            if (DeviceStatus==null)
            {
                DeviceStatus="Unknown";
            }
        }

       
        public string DeviceName { get; set; }
        public float? Temperature { get; set; }
        public string DeviceType { get; set; }
        public string DeviceOS { get; set; }
        
        public string DeviceStatus { get; set; }
        public string AdminEyesOnly { get; set; } 
        public TimeSpan? TimeInUse { get; set; }
        public List<string> DeviceIconPath = new List<string>();
        public List<string> DeviceOSIconPath = new List<string>();

        
        

    }
        

}
