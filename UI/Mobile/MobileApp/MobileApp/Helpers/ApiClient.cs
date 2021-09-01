using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SportskiCentarRS2.MobileApp.Properties;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SportskiCentarRS2.MobileApp.Helpers
{
    public static class ApiClient
    {
        public static HttpClient httpClient = new HttpClient() { BaseAddress = new Uri(Resources.ApiRoute), Timeout = TimeSpan.FromMinutes(1) };
        public static void UpdateAuthorizationHeader(string access_token)
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", access_token);
        }
        public static async Task<bool> GetAccessTokenForUserAndSetItToHttpClient(string username, string password)
        {
            var response = await httpClient.PostAsync($"Authentication/Login", new StringContent(JsonConvert.SerializeObject(new { Username = username, Password = password }), Encoding.UTF8, "application/json"));
            if(response.IsSuccessStatusCode)
            {
                var access_token = JsonConvert.DeserializeObject<JObject>(await response.Content.ReadAsStringAsync())["access_token"].ToString();

                UpdateAuthorizationHeader(access_token);
                return true;
            }
            await PrikaziGreskuKorisniku(response.StatusCode, await response.Content.ReadAsStringAsync());
            return false;
        }
        public static async Task LogOutAsync()
        {
            var response = await httpClient.GetAsync("Authentication/LogOut");
            if (response.IsSuccessStatusCode)
                httpClient.DefaultRequestHeaders.Authorization = null;
            else
                await PrikaziGreskuKorisniku(response.StatusCode, await response.Content.ReadAsStringAsync());
        }
        public static async Task PrikaziGreskuKorisniku(HttpStatusCode statusCode, string responseString)
        {
            if ((int)statusCode >= 500)
            {
                await Application.Current.MainPage.DisplayAlert("Greška", "Greška na serveru, kontaktirajte podršku.", "OK");
                return;
            }
                
            if(statusCode == HttpStatusCode.BadRequest)
            {
                BadRequestResponseModel responseModel = JsonConvert.DeserializeObject<BadRequestResponseModel>(responseString);
                var greske = "";
                foreach (var error in responseModel.Errors)
                {
                    greske += error.Key + ":" + "\r\n\t" + string.Join("\r\n\t", error.Value);
                }
                await Application.Current.MainPage.DisplayAlert("Greška", $"Neuspješna operacija. \r\nGreška/e:\r\n  {greske}", "OK");
                return;
            }
            if(statusCode == HttpStatusCode.NotFound)
            {
                NotFounResponseModel responseModel = JsonConvert.DeserializeObject<NotFounResponseModel>(responseString);
                await Application.Current.MainPage.DisplayAlert("Greška", $"Neuspješna operacija. \r\nGreška/e:\r\n  {responseModel.Details}", "OK");
                return;
            }

            await Application.Current.MainPage.DisplayAlert("Greška", $"Neuspješno dohvatanje podataka.", "OK");
        }
        public static async Task<T> GetAsync<T>(string route)
        {
            var response = await httpClient.GetAsync(route);
            var str = await response.Content.ReadAsStringAsync();
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                var autorizacijaUspjesna = await GetAccessTokenForUserAndSetItToHttpClient(LoginInfo.KorisnickoIme, LoginInfo.Lozinka);
                if (autorizacijaUspjesna)
                    return await GetAsync<T>(route);
            }
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<T>(str);
            else
                await PrikaziGreskuKorisniku(response.StatusCode, str);

            return default;
        }
        public static async Task<(bool, string)> PostAsync<T>(string route, T model)
        {
            var response = await httpClient.PostAsync(route, new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json"));
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                var autorizacijaUspjesna = await GetAccessTokenForUserAndSetItToHttpClient(LoginInfo.KorisnickoIme, LoginInfo.Lozinka);
                if (autorizacijaUspjesna)
                    return await PostAsync(route, model);
            }
            var responseString = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return (response.IsSuccessStatusCode, responseString);
            else
            {
                await PrikaziGreskuKorisniku(response.StatusCode, responseString);
                return default;
            }
        }
        public static async Task<(bool, string)> PutAsync<T>(string route, T model)
        {
            var response = await httpClient.PutAsync(route, new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json"));
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                var autorizacijaUspjesna = await GetAccessTokenForUserAndSetItToHttpClient(LoginInfo.KorisnickoIme, LoginInfo.Lozinka);
                if (autorizacijaUspjesna)
                    return await PutAsync(route, model);
            }
            var responseString = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return (response.IsSuccessStatusCode, responseString);
            else
            {
                await PrikaziGreskuKorisniku (response.StatusCode, responseString);
                return default;
            }
        }
        public static async Task<(bool, string)> DeleteAsync(string route)
        {
            var response = await httpClient.DeleteAsync(route);
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                var autorizacijaUspjesna = await GetAccessTokenForUserAndSetItToHttpClient(LoginInfo.KorisnickoIme, LoginInfo.Lozinka);
                if (autorizacijaUspjesna)
                    return await DeleteAsync(route);
            }
            var responseString = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return (response.IsSuccessStatusCode, responseString);
            else
            {
                await PrikaziGreskuKorisniku (response.StatusCode, responseString);
                return default;
            }
        }
    }
}
