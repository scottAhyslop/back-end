using System;

namespace back_end.Models
{
    public class DeviceDTO
    {
        public string DeviceName { get; set; }
        public float? Temperature { get; set; }
        public string DeviceType { get; set; }
        public string DeviceOS { get; set; }

        public string DeviceStatus { get; set; }
        public TimeSpan? TimeInUse { get; set; }
    }
}
