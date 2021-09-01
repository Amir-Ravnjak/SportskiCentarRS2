using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using SportskiCentarRS2.Application.Common.Interfaces;
using SportskiCentarRS2.Application.HelperModels;
using SportskiCentarRS2.Domain.Entities;
using SportskiCentarRS2.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SportskiCentarRS2.Infrastructure.Identity
{
    public class IdentityService : IIdentityService
    {
        private readonly RoleManager<KorisnickaUloga> RoleManager;
        private readonly ILogger<IdentityService> logger;

        public UserManager<Korisnik> UserManager { get; }
        public SignInManager<Korisnik> SignInManager { get; }
        public IConfiguration Configuration { get; }

        public IdentityService(UserManager<Korisnik> userManager, SignInManager<Korisnik> signInManager, IConfiguration configuration, RoleManager<KorisnickaUloga> roleManager, ILogger<IdentityService> logger)
        {
            UserManager = userManager;
            SignInManager = signInManager;
            Configuration = configuration;
            RoleManager = roleManager;
            this.logger = logger;
        }

        public Task<bool> AuthorizeAsync(string userId, string policyName)
        {

            throw new NotImplementedException();
        }

        public async Task<(Result Result, int UserId)> CreateUserAndAddToRoleAsync(RegisterDto korisnik)
        {
            Dictionary<string, string[]> errors = new Dictionary<string, string[]>();
            if (korisnik.KorisnickaUloga != "Klijent")
                errors.Add("Korisnička uloga", new string[] { "Samo klijent ima pravo na registraciju, ostale naloge kreira administrator." });


            if (string.IsNullOrWhiteSpace(korisnik.Password))
                errors.Add("Lozinka", new string[] { "Unesite lozinku." });
            else if (korisnik.Password != korisnik.ConfirmPassword)
                errors.Add("Lozinka", new string[] { "Lozinka i potvrdna lozinka se ne podudaraju." });

            if (string.IsNullOrWhiteSpace(korisnik.Email))
                errors.Add("Email", new string[] { "Unesite email" });

            if (string.IsNullOrWhiteSpace(korisnik.FirstName))
                errors.Add("Ime", new string[] { "Unesite vaše ime." });
            if (string.IsNullOrWhiteSpace(korisnik.LastName))
                errors.Add("Prezime", new string[] { "Unesite vaše ime." });
            if (string.IsNullOrWhiteSpace(korisnik.PhoneNumber))
                errors.Add("Broj telefona", new string[] { "Unesite broj telefona." });

            if (errors.Any())
                return (Result.Failure(errors),0);

            var user = new Korisnik
            {
                UserName = korisnik.Username,
                Email = korisnik.Email,
                Ime = korisnik.FirstName,
                Prezime = korisnik.LastName,
                JMBG = JMBG.From(korisnik.JMBG),
                DatumRodjenja = korisnik.DateOfBirth,
                PhoneNumber = korisnik.PhoneNumber
            };
            var result = await UserManager.CreateAsync(user, korisnik.Password);
            if(!result.Succeeded)
                return (result.ToApplicationResult("Kreiranje korisnika"), user.Id);

            var addToRoleResult = await UserManager.AddToRoleAsync(user, string.IsNullOrWhiteSpace(korisnik.KorisnickaUloga) ? "Klijent" : korisnik.KorisnickaUloga);
            
            return (addToRoleResult.ToApplicationResult("Role"), user.Id);
        }
        public async Task SignOutAsync()
        {
            await SignInManager.SignOutAsync();
        }
        public Task<Result> DeleteUserAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetUserNameAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsInRoleAsync(string userId, string role)
        {
            throw new NotImplementedException();
        }

        public async Task<Result> LoginUserAsync(LoginDto loginInfo, HttpContext httpContext)
        {
            var user = await UserManager.FindByNameAsync(loginInfo.Username);
            if (user == null)
                return Result.Failure("Login", new List<string> { "Netačno korisničko ime ili lozinka"});
            var validanPassword = await UserManager.CheckPasswordAsync(user, loginInfo.Password);
            if(!validanPassword)
                return Result.Failure("Login", new List<string> { "Netačno korisničko ime ili lozinka" });
            
            
            var claims = await UserManager.GetClaimsAsync(user);
            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
            claims.Add(new Claim(ClaimTypes.Name, user.UserName));
            claims.Add(new Claim(ClaimTypes.Email, user.Email));
            var userRoles = await UserManager.GetRolesAsync(user);
            foreach (var role in userRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var secretBytes = Encoding.UTF8.GetBytes(Configuration.GetValue<string>("SecretKeyJWT"));
            var key = new SymmetricSecurityKey(secretBytes);
            var algorithm = SecurityAlgorithms.HmacSha256;

            var signingCredentials = new SigningCredentials(key, algorithm);

            var token = new JwtSecurityToken(
                Configuration.GetValue<string>("JWTIssuer"),
                Configuration.GetValue<string>("JWTAudience"),
                claims,
                notBefore: DateTime.Now,
                expires:  DateTime.Now.AddHours(1),
                signingCredentials);

            var access_token = new JwtSecurityTokenHandler().WriteToken(token);

            var responseObject = new
            {
                access_token,
                token_type = "Bearer"
            };
            var responseJson = JsonConvert.SerializeObject(responseObject);
            //var responseBytes = Encoding.UTF8.GetBytes(responseJson);

            //logger.LogInformation("Prije pisanja na body");
            //try
            //{
                //await httpContext.Response.Body.WriteAsync(responseBytes, 0, responseBytes.Length);
            //}
            //catch (Exception e)
            //{
                //logger.LogError(e.Message);
                //throw;
            //}
            //logger.LogInformation("Poslije pisanja na body");
            //await SignInManager.SignInWithClaimsAsync(user, loginInfo.RememberMe);

            return Result.Success(responseJson);
        }
        
    }
}
