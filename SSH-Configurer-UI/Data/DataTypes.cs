namespace SSH_Configurer_UI.Data
{
    public class DataTypes
    {
        public record Device(int Id, string Name, string Hostname, int Port, int ServerPubKeyId, string Password);

        public record Group(int Id, string Name, int ServerPubKeyId, List<int>? DeviceIds);

        public record Script(int Id, string Name, string Content);

        public record PublicKey(int Id, string Content);

        public record NavMenuItem(string displayedText, string href, int depth, string iconNotExpanded, string iconExpanded, List<NavMenuItem> subItems);
    }
}
