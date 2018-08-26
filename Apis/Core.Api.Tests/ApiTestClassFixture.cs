using System;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using Core.Api;
using FluentAssertions;
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


        protected ApiTestClassFixture(WebApplicationFactory<TStartup> factory)
        {
            Factory = factory;
        }

        protected Action<HttpResponseMessage> AssertNotRun = response => true.Should().BeFalse();

        protected async Task Post<TRequestObject>(
            string uri,
            TRequestObject obj,
            Action<HttpResponseMessage> onSuccess, 
            Action<HttpResponseMessage> onError) where TRequestObject : IRequestModel, new()
        {
            var content = new ObjectContent<TRequestObject>(
                obj,
                _formatter);

            using (var client = Factory.CreateClient())
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
