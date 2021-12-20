using System;
using System.Collections.Generic;

#nullable disable

namespace back_end.Models
{
    public partial class Device
    {
        public int DeviceId { get; set; }
        public string DeviceName { get; set; }
        public string Temperature { get; set; }
        public string DeviceIconPath { get; set; }
        public string DeviceOsiconPath { get; set; }
        public string DeviceType { get; set; }
        public string DeviceOs { get; set; }
        public string DeviceStatus { get; set; }
        public string TimeInUse { get; set; }
    }
}
