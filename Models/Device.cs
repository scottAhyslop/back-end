﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace back_end.Models
{
    public partial class Device
    {
        public int DeviceId { get; set; }
        [Required]
        public string DeviceName { get; set; }
        public string Temperature { get; set; }
        public string DeviceIconPath { get; set; }
        public string DeviceOSIconPath { get; set; }
        public string DeviceType { get; set; }
        public string DeviceOS { get; set; }
        public string DeviceStatus { get; set; }
        public string TimeInUse { get; set; }
    }
}
