using CloudRepublic.DevOps.ServerUI.Data.Models.Azure;
using System.Net.Http.Headers;

namespace CloudRepublic.DevOps.ServerUI.Data
{
    public class AzurePrerequestHandler : DelegatingHandler
    {
        private readonly string tenantId;
        private readonly string clientId;
        private readonly string clientSecret;

        private string BearerToken { get; set; }
        private DateTimeOffset? BearerTokenExpiresOn { get; set; }

        public AzurePrerequestHandler(string tenantId, string clientId, string clientSecret)
        {
            this.tenantId = tenantId;
            this.clientId = clientId;
            this.clientSecret = clientSecret;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(BearerToken) || BearerTokenExpiresOn == null || BearerTokenExpiresOn < DateTime.UtcNow.AddMinutes(-5))
            {
                await GetAccessTokenAsync();
            }

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", BearerToken);

            // Call the base SendAsync method to continue the request pipeline
            var response = await base.SendAsync(request, cancellationToken);

            return response;
        }

        private async Task GetAccessTokenAsync()
        {
            var uri = $"https://login.microsoftonline.com/{tenantId}/oauth2/token";
            var client = new HttpClient();
            var requestContent = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("grant_type", "client_credentials"),
                new KeyValuePair<string, string>("client_id", clientId),
                new KeyValuePair<string, string>("client_secret", clientSecret),
                new KeyValuePair<string, string>("resource", "https://management.azure.com/")
            });

            var response = await client.PostAsync(uri, requestContent);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsAsync<Token>();

                BearerTokenExpiresOn = DateTimeOffset.FromUnixTimeSeconds(responseContent.ExpiresOn);
                BearerToken = responseContent.AccessToken;
            }
            else
            {
                var err = await response.Content.ReadAsStringAsync();
                throw new Exception(err);
            }
        }
    }
}
