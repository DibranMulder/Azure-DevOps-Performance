﻿using CloudRepublic.DevOps.ServerUI.Data.Models.Azure;

namespace CloudRepublic.DevOps.ServerUI.Data
{
    public class AzureService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AzureService(IHttpClientFactory httpClientFactory) => 
            _httpClientFactory = httpClientFactory;

        public async Task<ListResponse<Subscription>> GetSubscriptionsAsync()
        {
            var httpClient = _httpClientFactory.CreateClient("azureHttpClient");

            const string ApiVersion = "2020-01-01";
            var response = await httpClient.GetAsync($"https://management.azure.com/subscriptions?api-version={ApiVersion}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsAsync<ListResponse<Subscription>>();
                return content;
            }
            else 
            {
                return null;
            }
        }

        public async Task<ListResponse<ResourceGroup>> GetResourceGroupsAsync(Guid subscriptionId)
        {
            var httpClient = _httpClientFactory.CreateClient("azureHttpClient");

            const string ApiVersion = "2020-09-01";
            var response = await httpClient.GetAsync($"https://management.azure.com/subscriptions/{subscriptionId}/resourcegroups?api-version={ApiVersion}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsAsync<ListResponse<ResourceGroup>>();
                return content;
            }
            else
            {
                return null;
            }
        }

        public async Task<ListResponse<ResourceGroup>> GetAppServicePlans(Guid subscriptionId)
        {
            var httpClient = _httpClientFactory.CreateClient("azureHttpClient");

            const string ApiVersion = "2020-09-01";
            var response = await httpClient.GetAsync($"https://management.azure.com/subscriptions/{subscriptionId}/resourcegroups?api-version={ApiVersion}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsAsync<ListResponse<ResourceGroup>>();
                return content;
            }
            else
            {
                return null;
            }
        }
    }
}
