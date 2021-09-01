using Microsoft.AspNetCore.Http;
using SportskiCentarRS2.Application.HelperModels;
using SportskiCentarRS2.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportskiCentarRS2.Application.Common.Interfaces
{
    public interface IIdentityService
    {

        Task<Result> LoginUserAsync(LoginDto loginInfo, HttpContext httpContext);
        Task SignOutAsync();
        Task<string> GetUserNameAsync(string userId);

        Task<bool> IsInRoleAsync(string userId, string role);

        Task<bool> AuthorizeAsync(string userId, string policyName);

        Task<(Result Result, int UserId)> CreateUserAndAddToRoleAsync(RegisterDto korisnik);

        Task<Result> DeleteUserAsync(string userId);
    }
}
