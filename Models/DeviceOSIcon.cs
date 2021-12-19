using System.Collections.Generic;
using System.Linq;

namespace back_end.Models
{
    public class DeviceOSIcon
    {
       
        public DeviceOSIcon()
        {

        }

        public DeviceOSIcon(string deviceOS, string deviceType)
        {   
            //create two dictionaries to hold Device and OS Names and Icons
            Dictionary<string, List<string>> newDeviceNameAndIconDictionary = new Dictionary<string, List<string>>();

            Dictionary<string, List<string>> newOSNameAndIconDictionary = new Dictionary<string, List<string>>();

            //populated the Device Name and Icon with our Device Name and Icon lists
            newDeviceNameAndIconDictionary = NewDictionaryList(DeviceNameList, DeviceIconList);

            //populated the Device Name and Icon with our Device Name and Icon lists
            newOSNameAndIconDictionary = NewDictionaryList(DeviceOSNameList, DeviceOSIconList);


        }

        

        //Icons and names for Device

        //These dictionary collections will be used to display information on the device-list bootstrap rows and creation and display of a single device, they will be tied into the device as soon as it's created, so the device will always carry these names and icon items with it
        //List<string> types to combine into a device name and icon dictionary collection

        //these two lists for Device Name and Icon dictionary
        public static List<string> DeviceNameList = new List<string> { "Desktop", "Laptop", "Phone", "Tablet" };
        public static List<string> DeviceIconList = new List<string> { "fas fa - desktop", "fas fa - laptop - code", "fas fa - mobile - alt", "fas fa - tablet - alt" };
        //these two lists for OS Name and Icon dictionary    
        public static List<string> DeviceOSNameList = new List<string> { "Windows", "MacOS", "Apple", "Android" };
        public static List<string> DeviceOSIconList = new List<string> { "fa fa-windows", "fas fa -laptop", "fab fa-apple", "fab fa-android" };

        Dictionary<string, List<string>> NewDictionaryList(List<string> keyList, List<string> valueList)
        {
            Dictionary<string, List<string>> deviceOSIconList = keyList.Select(x => new { key = x, value = valueList }).ToDictionary(e => e.key, e => e.value);
            return deviceOSIconList;

        }
    }
}


