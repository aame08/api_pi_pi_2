using api_pi_2.Models;
using api_pi_2.DTOs;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Windows;

namespace api_pi_2.Data
{
    public static class Api
    {
        public static async Task<User?> Auth(string login, string password)
        {
            using (var client = new HttpClient())
            {
                var result = client.GetAsync($"https://localhost:7088/api/User/{login}, {password}").Result;
                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return JsonConvert.DeserializeObject<User>((await result.Content.ReadAsStringAsync()));
                }
                return null;
            }
        }

        public static async Task<User?> Register(UserDTO userDto)
        {
            using (var client = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(userDto);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var result = await client.PostAsync("https://localhost:7088/api/User/register", content);
                if (result.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    return JsonConvert.DeserializeObject<User>(await result.Content.ReadAsStringAsync());
                }
                return null;
            }
        }

        public static async Task<List<Product>> GetProducts()
        {
            using (var client = new HttpClient())
            {
                var result = client.GetAsync($"https://localhost:7088/api/Product").Result;
                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return JsonConvert.DeserializeObject<List<Product>>((await result.Content.ReadAsStringAsync()));

                }
                return [];
            }
        }
    }
}
