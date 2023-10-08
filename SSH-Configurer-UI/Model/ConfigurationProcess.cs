namespace SSH_Configurer_UI.Model
{
    public class ConfigurationProcess
    {
        public string request_uuid { get; set; } = "";
        public int GroupId { get; set; }
        public int ScriptId { get; set; }
        public List<DeviceStatus> deviceStatuses { get; set; }
        public ConfigurationProcess() 
        {
            deviceStatuses = new();
        }
        public void SetDevices(IEnumerable<Device> devices)
        {
            deviceStatuses = devices.Select(d => new DeviceStatus(d)).ToList();
        }
    }
}
