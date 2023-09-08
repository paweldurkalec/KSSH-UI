using SSH_Configurer_UI.Model;
using SSH_Configurer_UI.Model.DTOs.Device;
using SSH_Configurer_UI.Pages.List;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace SSH_Configurer_UI.Services
{
    public class DeviceService : IDeviceService
    {
        private readonly HttpClient httpClient;

        public DeviceService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<int> AddDevice(Device device)
        {
            string serialized = JsonSerializer.Serialize(new DeviceDTOPost(device));
            var bytes = MyUtils.ConvertToBytes(serialized);

            var response = await httpClient.PostAsync("", bytes).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        public async Task<int> UpdateDevice(int id, Device device)
        {
            string serialized = JsonSerializer.Serialize(new DeviceDTOPost(device));
            var bytes = MyUtils.ConvertToBytes(serialized);

            var response = await httpClient.PutAsync($"{id}/", bytes).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        public async Task<IEnumerable<Device>> GetAllDevices()
        {
            var dtos = await httpClient.GetFromJsonAsync<IEnumerable<DeviceDTO>>("").ConfigureAwait(false);

            return dtos.Select(d => new Device(d)).OrderBy(d => d.Id).ToList();
        }
    

        public async Task<Device?> GetById(int id)
        {
            try
            {
                var dto = await httpClient.GetFromJsonAsync<DeviceDTO>($"{id}/").ConfigureAwait(false);

                if (dto != null)
                {
                    return new Device(dto);
                }
                else
                {
                    return null;
                }
            }
            catch (HttpRequestException)
            {
                return null;
            }
        }

        public async Task<IEnumerable<Device>> GetByIds(IEnumerable<int> ids)
        {
            var tasks = ids.Select(id => GetById(id));
            var devices = await Task.WhenAll(tasks).ConfigureAwait(false);

            return devices.Where(device => device is not null).Select(device => device!);
        } 

        public async Task<IEnumerable<Device>> SearchByName(string input)
        {
            var allDevices = await GetAllDevices().ConfigureAwait(false);

            var filteredDevices = allDevices.Where(device => device.Name.Equals(input, StringComparison.OrdinalIgnoreCase));

            return filteredDevices.ToList();
        }

        public async Task<int> RemoveDevice(Device device)
        {
            try
            {
                var response = await httpClient.DeleteAsync($"{device.Id}").ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    return 0;
                }
                else
                { 
                    return 1;
                }
            }
            catch (HttpRequestException)
            {
                return 1;
            }
        }
    }
}
