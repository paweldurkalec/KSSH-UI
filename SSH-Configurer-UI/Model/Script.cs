using SSH_Configurer_UI.Model.DTOs.Script;
using System.ComponentModel.DataAnnotations;

namespace SSH_Configurer_UI.Model
{
    public class Script
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Content { get; set; }

        public Script(int id, string name, string content)
        {
            Id = id;
            Name = name;
            Content = content;
        }

        public Script() { }

        public Script(ScriptDTOId scriptDTO)
        {
            Id = scriptDTO.id;
            Name = scriptDTO.name;
            Content = scriptDTO.script;
        }
    }
}
