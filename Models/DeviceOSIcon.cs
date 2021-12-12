using System.Collections.Generic;
using System.Linq;

namespace back_end.Models
{
    public class DeviceOSIcon
    {

        public DeviceOSIcon()
        {

        }

        public DeviceOSIcon(string deviceOs, string deviceType)
        {
            var device = deviceIconList.Where(x => x.Value == deviceType.AsEnumerable()).Select(x => x.Key).FirstOrDefault();
            var os =  deviceOSIconList.Where(x => x.Value == deviceOs.AsEnumerable()).Select(x => x.Key).FirstOrDefault();
        }

        //Icons and names for Device

        //These dictionary collections will be used to display information on the device-list bootstrap rows and creation and display of a since device, they will be tied into the device as soon as it's created, so the device will always carry these names and icon items with it
        //List<string> types to combine into a device name and icon dictionary collection

        public static List<string> DeviceNameList = new List<string> { "Desktop", "Laptop", "Phone", "Tablet" };
        public static List<string> DeviceIconList = new List<string> { "fas fa - desktop", "fas fa - laptop - code", "fas fa - mobile - alt", "fas fa - tablet - alt" };

        public static Dictionary<string, List<string>> deviceIconList = DeviceNameList.Select(x => new { key = x, value = DeviceIconList }).ToDictionary(e => e.key, e => e.value);
        //List<string> types to combine into a device name and icon dictionary collection
        public static List<string> DeviceOSNameList = new List<string> { "Windows", "MacOS", "Apple", "Android" };
        public static List<string> DeviceOSIconList = new List<string> { "fa fa-windows", "fas fa -laptop", "fab fa-apple", "fab fa-android" };

        public static Dictionary<string, List<string>> deviceOSIconList = DeviceOSNameList.Select(x => new { key = x, value = DeviceOSIconList }).ToDictionary(e => e.key, e => e.value);
    }
}
