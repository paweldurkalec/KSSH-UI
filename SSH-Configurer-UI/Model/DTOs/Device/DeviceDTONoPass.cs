namespace SSH_Configurer_UI.Model.DTOs.Device
{
    public class DeviceDTONoPass
    {
        public string name { get; set; }

        public string hostname { get; set; }

        public int port { get; set; } = 22;

        public string username { get; set; }

        public int? key_pair { get; set; }

        public DeviceDTONoPass() { }

        public DeviceDTONoPass(Model.Device device)
        {
            name = device.Name;
            hostname = device.Hostname;
            port = device.Port;
            username = device.Username;
            key_pair = device.KeyPairId > 0 ? device.KeyPairId : null;
        }
}
}
