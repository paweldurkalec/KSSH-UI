using Microsoft.IdentityModel.Tokens;
using SSH_Configurer_UI.Pages.List;
using System.ComponentModel.DataAnnotations;
using System.Numerics;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

       

        public bool AllFinished()
        {
            return deviceStatuses.Where(ds => ds.status != ConfigurationStatuses.FINISHED).IsNullOrEmpty();
        }

        public bool AllValid()
        {
            return deviceStatuses.Where(ds => ds.statusMessage != "Ok").IsNullOrEmpty();
        }

        public bool AllUnvalid()
        {
            return deviceStatuses.Where(ds => ds.statusMessage != "Error while running script").IsNullOrEmpty();
        }

        public void SetDevices(IEnumerable<Device> devices)
        {
            deviceStatuses = devices.Select(d => new DeviceStatus(d)).ToList();
        }
    }
}
