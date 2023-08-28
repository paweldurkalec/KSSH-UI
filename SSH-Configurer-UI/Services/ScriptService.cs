using SSH_Configurer_UI.Model;
using SSH_Configurer_UI.Pages.List;

namespace SSH_Configurer_UI.Services
{
    public class ScriptService
    {
        private List<Script> Scripts = new()
{
            new Script(0, "hello_world_python","#!/bin/bash\nif ! command -v python3 &> /dev/null; then\n    sudo apt-get update\n    sudo apt-get install -y python3\nfi\npython3 -m venv venv\nsource venv/bin/activate\n\n# Install any required packages within the virtual environment\n# Example: pip install requests\n\necho \"print('Hello, World!')\" > hello.py\npython hello.py\ndeactivate\nrm hello.py\n"),
            new Script(1, "hello_world_dotnet", "#!/bin/bash\nif ! command -v dotnet &> /dev/null; then\n    wget https://packages.microsoft.com/config/ubuntu/$(lsb_release -rs)/packages-microsoft-prod.deb -O packages-microsoft-prod.deb\\n    sudo dpkg -i packages-microsoft-prod.deb\\n    sudo apt-get update\\n    sudo apt-get install -y dotnet-sdk-5.0\\nfi\\n\\nmkdir HelloWorldApp\\n\\n# Create a new console application\\ndotnet new console -n HelloWorldApp\\n\\ncd HelloWorldApp\\n\\ndotnet run\\n\\ncd ..\\n\\nrm -rf HelloWorldApp\\n\r\n")
        };

        public List<Script> GetAllScripts()
        {
            return new List<Script>(Scripts);
        }

        public Script? GetById(int id)
        {
            return Scripts.FirstOrDefault(script => script.Id == id, null);
        }

        public List<Script> GetByIds(IEnumerable<int> ids) => ids.Select(GetById).Where(script => script is not null).ToList();

        public List<Script> SearchByName(string input)
        {
            List<Script> filtered = Scripts.Where(script => script.Name.ToLower().Contains(input.ToLower())).ToList();

            return filtered;
        }

        public int AddScript(Script script)
        {
            Scripts.Add(script);
            return 0;
        }

        public int UpdateScript(int id, Script script)
        {
            int index = Scripts.IndexOf(Scripts.FirstOrDefault(script => script.Id == id));
            if (index != -1)
            {
                Scripts[index] = script;
                return 0;
            }
            return -1;
        }

        public int RemoveScript(Script script)
        {
            Scripts.Remove(script);
            return 0;
        }
    }
}
