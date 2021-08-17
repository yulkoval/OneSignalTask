using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using OneSignalTask.Domain.Models;
using OneSignalTask.Services.Infrastructure.Configurations;
using OneSignalTask.Services.Interfaces;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OneSignalTask.Services
{
    public class OneSignalService : IOneSignalService
    {
        private readonly IRestClient _restClient;
        private readonly OneSignalOptions _oneSignalApiConfig;

        public OneSignalService(IRestClient restClient, IOptions<OneSignalOptions> options)
        {
            _restClient = restClient;
            _oneSignalApiConfig = options.Value;
        }

        /// <summary>
        /// Gets the collection of Apps via sending GET async request to the OneSignal.
        /// </summary>
        /// <returns>The collection of Apps if the request was successful, else throws an exception.</returns>
        public async Task<IEnumerable<App>> GetAppsAsync()
        {
            RestRequest request = new RestRequest(_oneSignalApiConfig.BaseUrl, Method.GET);
            request.AddHeader("Authorization", "Basic " + _oneSignalApiConfig.ApiKey);
            
            IRestResponse<IEnumerable<App>> response = await _restClient.ExecuteTaskAsync<IEnumerable<App>>(request);

            if (response.IsSuccessful)
            {
                return JsonConvert.DeserializeObject<IEnumerable<App>>(response.Content);
            }
            else
            {
                throw new Exception(response.ErrorMessage);
            }
        }

        /// <summary>
        /// Gets the App via sending GET async request to the OneSignal.
        /// </summary>
        /// <param name="id">The unique identifier of the App.</param>
        /// <returns>The App if the request was successful, else throws an exception.</returns>
        public async Task<App> GetAppAsync(string id)
        {
            RestRequest request = new RestRequest(_oneSignalApiConfig.BaseUrl, Method.GET);
            request.Resource += id;
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Basic " + _oneSignalApiConfig.ApiKey);

            IRestResponse<App> response = await _restClient.ExecuteTaskAsync<App>(request);

            if (response.IsSuccessful)
            {
                return JsonConvert.DeserializeObject<App>(response.Content);
            }
            else
            {
                throw new Exception(response.ErrorMessage);
            }
        }

        /// <summary>
        /// Gets the created App via sending POST async request to the OneSignal.
        /// </summary>
        /// <param name="app">The new App.</param>
        /// <returns>The created App if request was executed successfully, else throws an exception.</returns>
        public async Task<App> CreateAppAsync(App app)
        {
            RestRequest request = new RestRequest(_oneSignalApiConfig.BaseUrl, Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Basic " + _oneSignalApiConfig.ApiKey);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(JsonConvert.SerializeObject(app));

            IRestResponse<App> response = await _restClient.ExecuteTaskAsync<App>(request);
            
            if (response.IsSuccessful)
            {
                return JsonConvert.DeserializeObject<App>(response.Content);
            }
            else
            {
                throw new Exception(response.ErrorMessage);
            }
        }

        /// <summary>
        /// Gets the updated App via sending PUT async request to the OneSignal.
        /// </summary>
        /// <param name="app">The App with the edited parameters.</param>
        /// <returns>The updated App if request was executed successfully, else throws an exception.</returns>
        public async Task<App> UpdateAppAsync(App app)
        {
            RestRequest request = new RestRequest(_oneSignalApiConfig.BaseUrl, Method.PUT);
            request.Resource += app.Id;
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Basic " + _oneSignalApiConfig.ApiKey);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(JsonConvert.SerializeObject(app));

            IRestResponse<App> response = await _restClient.ExecuteTaskAsync<App>(request);

            if (response.IsSuccessful)
            {
                return JsonConvert.DeserializeObject<App>(response.Content);
            }
            else
            {
                throw new Exception(response.ErrorMessage);
            }
        }

    }
}
