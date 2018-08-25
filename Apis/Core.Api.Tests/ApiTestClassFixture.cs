using System;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using Core.Api;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Xunit;

namespace Automagic.Core.Api.Tests
{
    public class ApiTestClassFixture<TStartup> : IClassFixture<WebApplicationFactory<TStartup>> where TStartup : class
    {
        protected WebApplicationFactory<TStartup> Factory { get; }

        private readonly JsonMediaTypeFormatter _formatter = new JsonMediaTypeFormatter
        {
            SerializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            }
        };


        public ApiTestClassFixture(WebApplicationFactory<TStartup> factory)
        {
            Factory = factory;
        }

        public async Task Post<TRequestObject>(
            string uri,
            TRequestObject obj,
            Action<HttpResponseMessage> onSuccess = null, 
            Action<HttpResponseMessage> onError = null) where TRequestObject : IRequestModel, new()
        {
            var content = new ObjectContent<TRequestObject>(
                obj,
                _formatter);

            using (var client = Factory.CreateClient())
            {
                var response = await client.PostAsync(uri, content);

                if (response.IsSuccessStatusCode)
                {
                    onSuccess?.Invoke(response);
                }
                else
                {
                    onError?.Invoke(response);
                }
            }
        }
    }
}
