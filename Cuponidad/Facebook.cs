using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Cuponidad
{
    public class Facebook
    {
        public static HttpClient GetFacebookClient()
        {
            HttpClient _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://graph.facebook.com/v2.8/")
            };
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return _httpClient;
        }

        public static async Task<T> GetAsync<T>(string accessToken, string endpoint, string args = null)
        {
            HttpClient _httpClient = GetFacebookClient();

            var response = await _httpClient.GetAsync($"{endpoint}?access_token={accessToken}&{args}");
            if (!response.IsSuccessStatusCode)
                return default(T);

            var result = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(result);
        }

        public static async Task<dynamic> GetAccountAsync(string accessToken)
        {
            var User = await GetAsync<dynamic>(
                accessToken, "me", "fields=id,name,email,first_name,middle_name,last_name,age_range,birthday,gender,locale,picture.width(800).height(800)");
            return User;
        }
    }
}
