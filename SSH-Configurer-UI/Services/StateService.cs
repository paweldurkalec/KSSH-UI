using SSH_Configurer_UI.Services.Interfaces;

namespace SSH_Configurer_UI.Services
{
    public class StateService : IStateService
    {
        public StateService() { }

        public LoginEventHandler? OnLogin;
    }
}
