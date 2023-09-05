using SSH_Configurer_UI.Model;
using SSH_Configurer_UI.Model.DTOs;
using SSH_Configurer_UI.Pages.List;

namespace SSH_Configurer_UI.Services
{
    public class DeviceService : IDeviceService
    {   
        private readonly HttpClient httpClient;

        public DeviceService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<Device>> GetAllDevices()
        {
            var dtos = await httpClient.GetFromJsonAsync<IEnumerable<DeviceDTO>>("/api/devices");
            return dtos.Select(d => new Device(d)).ToList();
        }

        public async Task<Device?> GetById(int id)
        {
            throw new NotImplementedException();
            //return Devices.FirstOrDefault(device => device.Id == id, null);
        }

        public async Task<IEnumerable<Device>> GetByIds(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
            //return ids.Select(GetById).Where(device => device is not null).ToList();
        } 

        public async Task<IEnumerable<Device>> SearchByName(string input)
        {
            throw new NotImplementedException();
            //List<Device> filtered = Devices.Where(device => device.Name.ToLower().Contains(input.ToLower())).ToList();

            //return filtered;
        }

        public async Task<int> AddDevice(Device device)
        {
            throw new NotImplementedException();
            //Devices.Add(device);
            //return 0;
        }

        public async Task<int> UpdateDevice(int id, Device device)
        {
            throw new NotImplementedException();
            //int index = Devices.IndexOf(Devices.FirstOrDefault(device => device.Id == id));
            //if (index != -1)
            //{
            //    Devices[index] = device;
            //    return 0;
            //}
            //return -1;
        }

        public async Task<int> RemoveDevice(Device device)
        {
            throw new NotImplementedException();
            //Devices.Remove(device);
            //return 0;
        }
    }
}
