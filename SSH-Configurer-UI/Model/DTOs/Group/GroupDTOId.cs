namespace SSH_Configurer_UI.Model.DTOs.Group
{
    public class GroupDTOId
    {
        public int id { get; set; }

        public string name { get; set; }

        public int? key_pair { get; set; }

        public List<int> devices { get; set; }

        public GroupDTOId() { }

        public GroupDTOId(Model.Group group)
        {
            id = group.Id;
            name = group.Name;
            key_pair = group.KeyPairId > 0 ? group.KeyPairId : null;
            devices = group.DeviceIds is null ? new() : group.DeviceIds;
        }
    }
}
