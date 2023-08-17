using SSH_Configurer_UI.Model;

namespace SSH_Configurer_UI.Services
{
    public class ScriptService
    {
        private static readonly Script[] Scripts = new[]
{
            new Script(0, "hello_world_python","#!/bin/bash\\nif ! command -v python3 &> /dev/null; then\\n    sudo apt-get update\\n    sudo apt-get install -y python3\\nfi\\npython3 -m venv venv\\nsource venv/bin/activate\\n\\n# Install any required packages within the virtual environment\\n# Example: pip install requests\\n\\necho \"print('Hello, World!')\" > hello.py\\npython hello.py\\ndeactivate\\nrm hello.py\\n"),
            new Script(1, "hello_world_dotnet", "#!/bin/bash\\nif ! command -v dotnet &> /dev/null; then\\n    wget https://packages.microsoft.com/config/ubuntu/$(lsb_release -rs)/packages-microsoft-prod.deb -O packages-microsoft-prod.deb\\n    sudo dpkg -i packages-microsoft-prod.deb\\n    sudo apt-get update\\n    sudo apt-get install -y dotnet-sdk-5.0\\nfi\\n\\nmkdir HelloWorldApp\\n\\n# Create a new console application\\ndotnet new console -n HelloWorldApp\\n\\ncd HelloWorldApp\\n\\ndotnet run\\n\\ncd ..\\n\\nrm -rf HelloWorldApp\\n\r\n")
        };

        public List<Script> GetAllScripts()
        {
            return new List<Script>(Scripts);
        }
    }
}
