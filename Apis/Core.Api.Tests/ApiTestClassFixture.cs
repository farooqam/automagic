using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
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

        public ApiTestClassFixture(WebApplicationFactory<TStartup> factory)
        {
            Factory = factory;
        }

        public async Task<HttpResponseMessage> EnsurePostAsync<TRequestObject>(
            string uri,
            TRequestObject obj) where TRequestObject : IRequestModel, new()
        {
            var content = new ObjectContent<TRequestObject>(
                new TRequestObject(),
                new JsonMediaTypeFormatter
                {
                    SerializerSettings = new JsonSerializerSettings
                    {
                        ContractResolver = new CamelCasePropertyNamesContractResolver()
                    }
                });

            using (var client = Factory.CreateClient())
            {
                var response = await client.PostAsync(uri, content);
                response.EnsureSuccessStatusCode();
                response.Content.Headers.ContentType.ToString().Should().Be("application/json; charset=utf-8");
                return response;
            }
        }


    }
}
