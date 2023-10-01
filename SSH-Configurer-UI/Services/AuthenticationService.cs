using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Forms;
using SSH_Configurer_UI.Model.DTOs.Authentication;
using SSH_Configurer_UI.Model.DTOs.KeyPair;
using SSH_Configurer_UI.Pages.List;
using SSH_Configurer_UI.Services.Interfaces;
using Syncfusion.Blazor.FileManager.Internal;
using Syncfusion.Blazor.Kanban.Internal;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;

namespace SSH_Configurer_UI.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        const int ACCESS_TOKEN_EXPIRATION_TIME_MINUTES = 5;

        private readonly HttpClient _httpClient;
        private ISessionStorageService _sessionStorageService;
        private DateTime _accessRefresh;
        private const string JWT_KEY = nameof(JWT_KEY);
        private const string JWT_REFRESH_KEY = nameof(JWT_REFRESH_KEY);
        private string? _jwtCache;
        private string? _jwtRefreshCache;

        public event Action<string?>? LoginChange;

        private bool shouldRefresh()
        {
            DateTime currentDateTime = DateTime.Now;
            TimeSpan timeDifference = currentDateTime - _accessRefresh;
            
            if (timeDifference.TotalMinutes > ACCESS_TOKEN_EXPIRATION_TIME_MINUTES)
            {
                return true;
            }
            return false;
        }


        private async Task refreshAccessToken()
        {
            string refreshToken = await GetJwtRefreshAsync();
            RefreshModel refreshModel = new RefreshModel();
            refreshModel.refresh = refreshToken;
            string serialized = JsonSerializer.Serialize(refreshModel);
            var bytes = MyUtils.ConvertToBytes(serialized);

            var response = await _httpClient.PostAsync("refresh/", bytes).ConfigureAwait(false);

            if (!response.IsSuccessStatusCode) { return; }

            var content = await response.Content.ReadFromJsonAsync<RefreshResponse>().ConfigureAwait(false);

            await _sessionStorageService.SetItemAsync(JWT_KEY, content.access).ConfigureAwait(false);
            _jwtCache = null;
            _accessRefresh = DateTime.Now;
        }

        public AuthenticationService(ISessionStorageService sessionStorageService)
        {
            var httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://127.0.0.1:8000/auth/")
            };
            _httpClient = httpClient;
            _sessionStorageService = sessionStorageService;
        }

        public async ValueTask<string> GetJwtRefreshAsync()
        {
            if (string.IsNullOrEmpty(_jwtRefreshCache))
                _jwtRefreshCache = await _sessionStorageService.GetItemAsync<string>(JWT_REFRESH_KEY).ConfigureAwait(false);

            return _jwtRefreshCache;
        }

        public async ValueTask<string> GetJwtAsync()
        {
            if (shouldRefresh())
            {
                await refreshAccessToken();
            }

            if (string.IsNullOrEmpty(_jwtCache))
                _jwtCache = await _sessionStorageService.GetItemAsync<string>(JWT_KEY).ConfigureAwait(false);

            return _jwtCache;
        }

        private static string GetUsername(string token)
        {
            var jwt = new JwtSecurityToken(token);

            return jwt.Claims.First(c => c.Type == ClaimTypes.Name).Value;
        }

        public async Task LogoutAsync()
        {
            await _sessionStorageService.RemoveItemAsync(JWT_KEY).ConfigureAwait(false);

            _jwtCache = null;

            LoginChange?.Invoke(null);
        }

        public async Task<int> LoginAsync(LoginModel credentials)
        {
            string serialized = JsonSerializer.Serialize(credentials);
            var bytes = MyUtils.ConvertToBytes(serialized);

            var response = await _httpClient.PostAsync("login/", bytes).ConfigureAwait(false);

            if (!response.IsSuccessStatusCode)
            {
                throw new UnauthorizedAccessException("Login failed!");
            }

            var content = await response.Content.ReadFromJsonAsync<LoginResponse>().ConfigureAwait(false);

            if (content == null)
            {
                throw new InvalidDataException();
            }

            await _sessionStorageService.SetItemAsync(JWT_KEY, content.access).ConfigureAwait(false);
            await _sessionStorageService.SetItemAsync(JWT_REFRESH_KEY, content.refresh).ConfigureAwait(false);
            _jwtCache = null;
            _jwtRefreshCache = null;
            _accessRefresh = DateTime.Now;

            LoginChange?.Invoke(GetUsername(content.access));

            return 0;
        }
    }
}
