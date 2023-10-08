using System.ComponentModel.DataAnnotations;

namespace SSH_Configurer_UI.Model
{
    public class DeviceStatus
    {
        public Device device;

        public string status;

        public DeviceStatus(Device device)
        {
            this.device = device;
            status = "Unknown";
        }
    }
}
