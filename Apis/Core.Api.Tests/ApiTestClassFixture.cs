using System;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using Core.Api;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
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


        protected ApiTestClassFixture(WebApplicationFactory<TStartup> factory)
        {
            Factory = factory;
        }

        protected Action<HttpResponseMessage> AssertNotRun = response => true.Should().BeFalse();

        protected async Task Post<TRequestObject>(string uri,
            TRequestObject obj,
            Action<HttpResponseMessage> onSuccess,
            Action<HttpResponseMessage> onError,
            Action<IServiceCollection> services = null) where TRequestObject : IRequestModel, new()
        {
            var client = Factory.WithWebHostBuilder(builder =>
                {
                    if (services != null)
                    {
                        builder.ConfigureTestServices(services);
                    }
                })
                .CreateClient();


            var content = new ObjectContent<TRequestObject>(
                obj,
                _formatter);

            using (client)
            {
                var response = await client.PostAsync(uri, content);

                if (response.IsSuccessStatusCode)
                {
                    onSuccess.Invoke(response);
                }
                else
                {
                    onError.Invoke(response);
                }
            }
        }
    }
}
