namespace SSH_Configurer_UI.Model
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
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
    }
}
