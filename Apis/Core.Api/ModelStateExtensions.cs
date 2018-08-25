using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Core.Api
{
    public static class ModelStateExtensions
    {
        public static IEnumerable<ModelError> GetModelErrors(this ModelStateDictionary modelState)
        {
            var result = from ms in modelState
                         where ms.Value.Errors.Any()
                         let fieldKey = ms.Key
                         let errors = ms.Value.Errors
                         from error in errors
                         select new ModelError(fieldKey, error.ErrorMessage);

            return result;

        }
    }
}
