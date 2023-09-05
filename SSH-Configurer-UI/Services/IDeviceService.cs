using SSH_Configurer_UI.Model;
using SSH_Configurer_UI.Pages.List;

namespace SSH_Configurer_UI.Services
{
    public interface IDeviceService
    {
        public Task<IEnumerable<Device>> GetAllDevices();

        public Task<Device?> GetById(int id);

        public Task<IEnumerable<Device>> GetByIds(IEnumerable<int> ids);

        public Task<IEnumerable<Device>> SearchByName(string input);

        public Task<int> AddDevice(Device device);

        public Task<int> UpdateDevice(int id, Device device);

        public Task<int> RemoveDevice(Device device);
    }
}
