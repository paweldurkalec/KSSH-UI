namespace SSH_Configurer_UI.Model
{
    public class ConfigurationProcess
    {
        public int GroupId { get; set; }
        public int ScriptId { get; set; }
        public string Status { get; set; }
        public ConfigurationProcess() { }
        public ConfigurationProcess(int groupId, int scriptId, string status)
        {
            GroupId = groupId;
            ScriptId = scriptId;
            Status = status;
        }
    }
}
