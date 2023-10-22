using System.ComponentModel.DataAnnotations;

namespace SSH_Configurer_UI.Model
{
    public class DeviceStatus
    {
        public Device device;

        public string statusMessage;

        public ConfigurationStatuses status = ConfigurationStatuses.INITIALIZED;

        public List<string> warnings;

        public string standardOutput;

        public string standardError;

        public DeviceStatus(Device device)
        {
            this.device = device;
            statusMessage = "Unknown";
            standardOutput = "";
            standardError = "";
            warnings = new();
        }
    }
}
