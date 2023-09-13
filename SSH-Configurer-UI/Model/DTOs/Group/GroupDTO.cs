namespace SSH_Configurer_UI.Model.DTOs.Group
{
    public class GroupDTO
    {
        public string name { get; set; }

        public int? key_pair { get; set; }

        public List<int> devices { get; set; }

        public GroupDTO() { }

        public GroupDTO(Model.Group group)
        {
            name = group.Name;
            key_pair = group.KeyPairId > 0 ? group.KeyPairId : null;
            devices = group.DeviceIds is null ? new() : group.DeviceIds;
        }
    }
}
