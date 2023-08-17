namespace SSH_Configurer_UI.Model
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ServerPubKeyId { get; set; }
        public List<int>? DeviceIds { get; set; }

        public Group(int id, string name, int serverPubKeyId, List<int>? deviceIds)
        {
            Id = id;
            Name = name;
            ServerPubKeyId = serverPubKeyId;
            DeviceIds = deviceIds;
        }

        public Group() { }
    }
}
