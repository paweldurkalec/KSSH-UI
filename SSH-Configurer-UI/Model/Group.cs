using SSH_Configurer_UI.Model.DTOs.Device;
using SSH_Configurer_UI.Model.DTOs.Group;
using Syncfusion.Blazor.Diagram;
using System.ComponentModel.DataAnnotations;

namespace SSH_Configurer_UI.Model
{
    public class Group
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int KeyPairId { get; set; }
        public List<int>? DeviceIds { get; set; }

        public Group(int id, string name, int keyPairId, List<int>? deviceIds)
        {
            Id = id;
            Name = name;
            KeyPairId = keyPairId;
            DeviceIds = deviceIds;
        }

        public Group() { }

        public Group(GroupDTOId groupDTO)
        {
            Id = groupDTO.id;
            Name = groupDTO.name;
            KeyPairId = groupDTO.key_pair ?? -1;
            DeviceIds = groupDTO.devices;
        }
    }
}
