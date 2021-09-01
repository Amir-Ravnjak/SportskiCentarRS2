using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SportskiCentarRS2.WinForm.Helperi;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SportskiCentarRS2.WinForm.Helpers
{
    public static class ApiClient
    {
        public static HttpClient httpClient = new HttpClient() { BaseAddress = new Uri(Properties.Settings.Default.ApiRoute), Timeout = TimeSpan.FromMinutes(1) };
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
            PrikaziGreskuKorisniku(response.StatusCode, await response.Content.ReadAsStringAsync());
            return false;
        }
        public static async Task LogOutAsync()
        {
            var response = await httpClient.GetAsync("Authentication/LogOut");
            if (response.IsSuccessStatusCode)
                httpClient.DefaultRequestHeaders.Authorization = null;
            else
                PrikaziGreskuKorisniku(response.StatusCode, await response.Content.ReadAsStringAsync());
        }
        public static void PrikaziGreskuKorisniku(HttpStatusCode statusCode, string responseString)
        {
            if ((int)statusCode >= 500)
            {
                MessageBox.Show("Greška na serveru, kontaktirajte podršku.");
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
                MessageBox.Show($"Neuspješna operacija. \r\nGreška/e:\r\n  {greske}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(statusCode == HttpStatusCode.NotFound)
            {
                NotFounResponseModel responseModel = JsonConvert.DeserializeObject<NotFounResponseModel>(responseString);                
                MessageBox.Show($"Neuspješna operacija. \r\nGreška/e:\r\n  {responseModel.Details}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show($"Neuspješno dohvatanje podataka.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                PrikaziGreskuKorisniku(response.StatusCode, str);

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
                PrikaziGreskuKorisniku(response.StatusCode, responseString);
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
                PrikaziGreskuKorisniku(response.StatusCode, responseString);
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
                PrikaziGreskuKorisniku(response.StatusCode, responseString);
                return default;
            }
        }
    }
}
