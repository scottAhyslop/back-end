namespace back_end.Classes
{
    public class DeviceSearchParams: SearchParams
    {
        public DeviceSearchParams()
        {

        }
        public string DeviceName { get; set; }
        public string DeviceType { get; set; }
        public string DeviceOS { get; set; }

        public int DeviceId { get; set; }
    }
}
