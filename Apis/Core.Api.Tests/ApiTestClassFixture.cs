using System.Linq;
using System.Net;
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

        public async Task<HttpResponseMessage> EnsurePost<TRequestObject>(
            string uri,
            TRequestObject obj,
            HttpStatusCode expectedStatusCode) where TRequestObject : IRequestModel, new()
        {
            var content = new ObjectContent<TRequestObject>(
                obj,
                _formatter);

            using (var client = Factory.CreateClient())
            {
                var response = await client.PostAsync(uri, content);

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    response.Content.Headers.ContentType.ToString().Should().Be("application/json; charset=utf-8");
                }

                if (response.StatusCode == HttpStatusCode.BadRequest)
                {
                    response.Content.Headers.Count().Should().Be(0);
                }
                
                response.StatusCode.Should().Be(expectedStatusCode);
                return response;
            }
        }
    }
}
