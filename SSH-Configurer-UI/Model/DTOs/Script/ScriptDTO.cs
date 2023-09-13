using System.ComponentModel.DataAnnotations;

namespace SSH_Configurer_UI.Model.DTOs.Script
{
    public class ScriptDTO
    {
        public string name { get; set; }

        public string script { get; set; }

        public ScriptDTO() { }

        public ScriptDTO(Model.Script script)
        {
            name = script.Name;
            this.script = script.Content;
        }
    }
}
