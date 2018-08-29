using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Core.Api;
using FluentAssertions;

namespace Automagic.Core.Api.Tests
{
    public static class ApiTestExtensions
    {
        public static async Task<IList<ModelError>> GetModelErrorsAsync(this HttpResponseMessage response)
        {
            return (await response.Content.ReadAsAsync<IEnumerable<ModelError>>()).ToList();
        }

        public static void AssertStatusCode(this HttpResponseMessage response, HttpStatusCode expectedStatusCode)
        {
            response.StatusCode.Should().Be(expectedStatusCode);
        }

        public static async Task<T> GetResponseModelAsync<T>(this HttpResponseMessage response) where T : class
        {
            return await response.Content.ReadAsAsync<T>();
        }

        public static void AssertErrorExists(this HttpResponseMessage response, string key, string message)
        {
            response.AssertStatusCode(HttpStatusCode.BadRequest);
            var errors = response.GetModelErrorsAsync().Result;
            errors.Should().Contain(new ModelError(key, message));
        }
    }
}
