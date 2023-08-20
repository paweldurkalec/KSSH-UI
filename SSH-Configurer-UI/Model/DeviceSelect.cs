using System.ComponentModel.DataAnnotations;

namespace SSH_Configurer_UI.Model
{
    public class DeviceSelect
    {   
        public int Id { get; set; }
        public string Name { get; set; }
        public string Hostname { get; set; }
        public bool IsSelected { get; set; }
        public DeviceSelect() { }
        public DeviceSelect(int id, string name, string hostname, bool isSelected)
        {
            Id = id;
            Name = name;
            Hostname = hostname;
            IsSelected = isSelected;
        }
    }
}
