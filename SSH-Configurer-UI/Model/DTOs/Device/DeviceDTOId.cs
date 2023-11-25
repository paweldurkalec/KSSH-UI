using Foolproof;
using System.ComponentModel.DataAnnotations;
using SSH_Configurer_UI.Model;

namespace SSH_Configurer_UI.Model.DTOs.Device
{
    public class DeviceDTOId
    {
        public int id { get; set; }

        public string name { get; set; }

        public string hostname { get; set; }

        public int port { get; set; } = 22;

        public string username { get; set; }

        public int? key_pair { get; set; }

        public bool is_password_set { get; set; }

        public string? public_key { get; set; } = null;

        public DeviceDTOId() { }

        public DeviceDTOId(Model.Device device)
        {
            id = device.Id;
            name = device.Name;
            hostname = device.Hostname;
            port = device.Port;
            username = device.Username;
            key_pair = device.KeyPairId > 0 ? device.KeyPairId : null;
            public_key = device.DevPubKey;
        }
    }
}
