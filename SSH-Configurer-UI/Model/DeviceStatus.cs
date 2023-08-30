using System.ComponentModel.DataAnnotations;

namespace SSH_Configurer_UI.Model
{
    public class DeviceStatus
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Hostname { get; set; }
        public string Status { get; set; }
        public DeviceStatus() { }
        public DeviceStatus(int id, string name, string hostname, string status)
        {
            Id = id;
            Name = name;
            Hostname = hostname;
            Status = status;
        }
        public DeviceStatus(Device device)
        {
            Id = device.Id;
            Name = device.Name;
            Hostname = device.Hostname;
            Status = "Initializing";
        }
    }
}
