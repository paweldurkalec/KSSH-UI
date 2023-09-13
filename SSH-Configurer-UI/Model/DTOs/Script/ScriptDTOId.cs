namespace SSH_Configurer_UI.Model.DTOs.Script
{
    public class ScriptDTOId
    {
        public int id { get; set; }

        public string name { get; set; }

        public string script { get; set; }

        public ScriptDTOId() { }


        public ScriptDTOId(Model.Script script)
        {
            id = script.Id;
            name = script.Name;
            this.script = script.Content;
        }
    }
}
