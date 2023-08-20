using SSH_Configurer_UI.Model;
using SSH_Configurer_UI.Pages.List;

namespace SSH_Configurer_UI.Services
{
    public class DeviceService
    {
        private static List<Device> Devices = new()
        {
            new Device(0,"Computer1","127.0.56.2", 22, 0, "adminadmin"),
            new Device(1,"Computer2","127.0.56.3", 22, 0, "adminadmin"),
            new Device(2,"Computer3","127.0.56.4", 22, 0, "adminadmin"),
            new Device(3,"Computer4","127.0.56.5", 22, 1, "adminadmin"),
            new Device(4,"Computer5","127.0.56.6", 22, 1, "adminadmin"),
            new Device(0,"Computer1","127.0.56.2", 22, 0, "adminadmin"),
            new Device(1,"Computer2","127.0.56.3", 22, 0, "adminadmin"),
            new Device(2,"Computer3","127.0.56.4", 22, 0, "adminadmin"),
            new Device(3,"Computer4","127.0.56.5", 22, 1, "adminadmin"),
            new Device(4,"Computer5","127.0.56.6", 22, 1, "adminadmin"),
            new Device(0,"Computer1","127.0.56.2", 22, 0, "adminadmin"),
            new Device(1,"Computer2","127.0.56.3", 22, 0, "adminadmin"),
            new Device(2,"Computer3","127.0.56.4", 22, 0, "adminadmin"),
            new Device(3,"Computer4","127.0.56.5", 22, 1, "adminadmin"),
            new Device(4,"Computer5","127.0.56.6", 22, 1, "adminadmin"),
            new Device(0,"Computer1","127.0.56.2", 22, 0, "adminadmin"),
            new Device(1,"Computer2","127.0.56.3", 22, 0, "adminadmin"),
            new Device(2,"Computer3","127.0.56.4", 22, 0, "adminadmin"),
            new Device(3,"Computer4","127.0.56.5", 22, 1, "adminadmin"),
            new Device(4,"Computer5","127.0.56.6", 22, 1, "adminadmin"),
            new Device(0,"Computer1","127.0.56.2", 22, 0, "adminadmin"),
            new Device(1,"Computer2","127.0.56.3", 22, 0, "adminadmin"),
            new Device(2,"Computer3","127.0.56.4", 22, 0, "adminadmin"),
            new Device(3,"Computer4","127.0.56.5", 22, 1, "adminadmin"),
            new Device(4,"Computer5","127.0.56.6", 22, 1, "adminadmin"),
            new Device(0,"Computer1","127.0.56.2", 22, 0, "adminadmin"),
            new Device(1,"Computer2","127.0.56.3", 22, 0, "adminadmin"),
            new Device(2,"Computer3","127.0.56.4", 22, 0, "adminadmin"),
            new Device(3,"Computer4","127.0.56.5", 22, 1, "adminadmin"),
            new Device(4,"Computer5Computer5","127.0.56.6", 22, 1, "adminadmin")
        };

        public List<Device> GetAllDevices()
        {
            return Devices;
        }

        public List<Device> SearchByName(string input)
        {
            List<Device> filtered = Devices.Where(device => device.Name.ToLower().Contains(input.ToLower())).ToList();

            return filtered;
        }

        public int AddDevice(Device device)
        {
            Devices.Add(device);
            return 0;
        }

        public int RemoveDevice(Device device)
        {
            Devices.Remove(device);
            return 0;
        }
    }
}
