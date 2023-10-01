using SSH_Configurer_UI.Services.Interfaces;
using System.Net.Http.Headers;
using System.Net;
using Microsoft.AspNetCore.Components;

namespace SSH_Configurer_UI.Handlers
{
    public class AuthenticationHandler : DelegatingHandler
    {
        private readonly IAuthenticationService _authenticationService;
        private bool _refreshing;

        public AuthenticationHandler(IAuthenticationService authenticationService) : base(new HttpClientHandler())
        {
            _authenticationService = authenticationService;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var jwt = await _authenticationService.GetJwtAsync().ConfigureAwait(false);
            var isToServer = request.RequestUri?.AbsoluteUri.StartsWith("http://127.0.0.1:8000" ?? "") ?? false;

            if (isToServer && !string.IsNullOrEmpty(jwt))
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", jwt);

            var response = await base.SendAsync(request, cancellationToken).ConfigureAwait(false);

            //if (!_refreshing && !string.IsNullOrEmpty(jwt) && response.StatusCode == HttpStatusCode.Unauthorized)
            //{
            //    try
            //    {
            //        _refreshing = true;

            //        if (await _authenticationService.RefreshAsync())
            //        {
            //            jwt = await _authenticationService.GetJwtAsync();

            //            if (isToServer && !string.IsNullOrEmpty(jwt))
            //                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", jwt);

            //            response = await base.SendAsync(request, cancellationToken);
            //        }
            //    }
            //    finally
            //    {
            //        _refreshing = false;
            //    }
            //}

            return response;
        }
    }
}
