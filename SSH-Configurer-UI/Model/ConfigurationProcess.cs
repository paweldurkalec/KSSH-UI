using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace SSH_Configurer_UI.Model
{

    public enum ConfigurationStatuses
    {
        INITIALIZED,
        VALID,
        RUNNING,
        FINISHED
    }

    public class ConfigurationProcess
    {
        public string request_uuid { get; set; } = "";

        public ConfigurationStatuses status = ConfigurationStatuses.INITIALIZED;

        [Range(1, int.MaxValue, ErrorMessage = "Choose group.")]
        public int GroupId { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Choose script.")]
        public int ScriptId { get; set; }
        public List<DeviceStatus> deviceStatuses { get; set; }
        public ConfigurationProcess() 
        {
            deviceStatuses = new();
        }

        public bool AllValid()
        {
            return deviceStatuses.Where(ds => ds.status != "Ok").IsNullOrEmpty();
        }

        public void SetDevices(IEnumerable<Device> devices)
        {
            deviceStatuses = devices.Select(d => new DeviceStatus(d)).ToList();
        }
    }
}
