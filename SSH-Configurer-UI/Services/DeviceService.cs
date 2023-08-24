using SSH_Configurer_UI.Model;
using SSH_Configurer_UI.Pages.List;

namespace SSH_Configurer_UI.Services
{
    public class DeviceService
    {
        private static List<Device> Devices = new()
        {
            new Device(0,"Computer1","127.0.56.2", 22, "root", 0, "adminadmin"),
            new Device(1,"Computer2","127.0.56.3", 22, "root", 0, "adminadmin"),
            new Device(2,"Computer3","127.0.56.4", 22, "root", 0, "adminadmin"),
            new Device(3,"Computer4","127.0.56.5", 22, "root", 1, "adminadmin"),
            new Device(4,"Computer5","127.0.56.6", 22, "root", 1, "adminadmin"),
            new Device(5,"Computer1","127.0.56.2", 22, "root", 0, "adminadmin"),
            new Device(6,"Computer2","127.0.56.3", 22, "root", 0, "adminadmin"),
            new Device(7,"Computer3","127.0.56.4", 22, "root", 0, "adminadmin"),
            new Device(8,"Computer4","127.0.56.5", 22, "root", 1, "adminadmin"),
            new Device(9,"Computer5","127.0.56.6", 22, "root", 1, "adminadmin"),
            new Device(10,"Computer1","127.0.56.2", 22, "root", 0, "adminadmin"),
            new Device(11,"Computer2","127.0.56.3", 22, "root", 0, "adminadmin"),
            new Device(12,"Computer3","127.0.56.4", 22, "root", 0, "adminadmin"),
            new Device(13,"Computer4","127.0.56.5", 22, "root", 1, "adminadmin"),
            new Device(14,"Computer5","127.0.56.6", 22, "root", 1, "adminadmin"),
            new Device(15,"Computer1","127.0.56.2", 22, "root", 0, "adminadmin"),
            new Device(16,"Computer2","127.0.56.3", 22, "root", 0, "adminadmin"),
            new Device(17,"Computer3","127.0.56.4", 22, "root", 0, "adminadmin"),
            new Device(18,"Computer4","127.0.56.5", 22, "root", 1, "adminadmin"),
            new Device(19,"Computer5","127.0.56.6", 22, "root", 1, "adminadmin"),
            new Device(20,"Computer1","127.0.56.2", 22, "root", 0, "adminadmin"),
            new Device(21,"Computer2","127.0.56.3", 22, "root", 0, "adminadmin"),
            new Device(22,"Computer3","127.0.56.4", 22, "root", 0, "adminadmin"),
            new Device(23,"Computer4","127.0.56.5", 22, "root", 1, "adminadmin"),
            new Device(24,"Computer5","127.0.56.6", 22, "root", 1, "adminadmin"),
            new Device(25,"Computer1","127.0.56.2", 22, "root", 0, "adminadmin"),
            new Device(26,"Computer2","127.0.56.3", 22, "root", 0, "adminadmin"),
            new Device(27,"Computer3","127.0.56.4", 22, "root", 0, "adminadmin"),
            new Device(28,"Computer4","127.0.56.5", 22, "root", 1, "adminadmin"),
            new Device(29,"Computer5Computer5","127.0.56.6", 22, "root", 1, "adminadmin")
        };

        public List<Device> GetAllDevices()
        {
            return Devices;
        }

        public Device? GetById(int id)
        {
            return Devices.FirstOrDefault(device => device.Id == id, null);
        }

        public List<Device> GetByIds(IEnumerable<int> ids) => ids.Select(GetById).Where(device => device is not null).ToList();

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

        public int UpdateDevice(int id, Device device)
        {
            int index = Devices.IndexOf(Devices.FirstOrDefault(device => device.Id == id));
            if (index != -1)
            {
                Devices[index] = device;
                return 0;
            }
            return -1;
        }

        public int RemoveDevice(Device device)
        {
            Devices.Remove(device);
            return 0;
        }
    }
}
