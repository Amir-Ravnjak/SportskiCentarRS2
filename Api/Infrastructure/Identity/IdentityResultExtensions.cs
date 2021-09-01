using Microsoft.AspNetCore.Identity;
using SportskiCentarRS2.Application.HelperModels;
using System.Linq;

namespace SportskiCentarRS2.Infrastructure.Identity
{
    public static class IdentityResultExtensions
    {
        public static Result ToApplicationResult(this IdentityResult result, string title = null)
        {
            return result.Succeeded
                ? Result.Success()
                : Result.Failure(title, result.Errors.Select(e => e.Description));
        }
    }
}