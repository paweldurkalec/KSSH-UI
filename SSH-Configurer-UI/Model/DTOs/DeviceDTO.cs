using Foolproof;
using System.ComponentModel.DataAnnotations;

namespace SSH_Configurer_UI.Model.DTOs
{
    public class DeviceDTO
    {
        public int id { get; set; }

        public string name { get; set; }

        public string hostname { get; set; }

        public int port { get; set; } = 22;
 
        public string username { get; set; }

        public int? key_pair { get; set; }

        public string? password { get; set; }
        public DeviceDTO() { }
    }
}
