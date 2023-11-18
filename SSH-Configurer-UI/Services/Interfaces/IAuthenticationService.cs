using SSH_Configurer_UI.Model.DTOs.Authentication;

namespace SSH_Configurer_UI.Services.Interfaces
{
    public interface IAuthenticationService
    {

        ValueTask<string> GetJwtAsync();
        Task<int> LoginAsync(LoginModel credentials);
        Task LogoutAsync();
        Task<int> RegisterAsync(RegisterModel credentials);
        Task<bool> CheckIfUserExists();
    }
}