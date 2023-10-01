using SSH_Configurer_UI.Model.DTOs.Authentication;

namespace SSH_Configurer_UI.Services.Interfaces
{
    public interface IAuthenticationService
    {
        event Action<string?>? LoginChange;

        ValueTask<string> GetJwtAsync();
        Task<int> LoginAsync(LoginModel credentials);
        Task LogoutAsync();
    }
}