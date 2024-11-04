using api_pi_2.DTOs;
using api_pi_2.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace api_pi_2.Data
{
    public static class Api
    {
        public static async Task<User?> Auth(string login, string password)
        {
            using (var client = new HttpClient())
            {
                var result = client.GetAsync($"http://localhost:5184/api/User/{login}, {password}").Result;
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

                var result = await client.PostAsync("http://localhost:5184/api/User/register", content);
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
                var result = client.GetAsync($"http://localhost:5184/api/Product").Result;
                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return JsonConvert.DeserializeObject<List<Product>>((await result.Content.ReadAsStringAsync()));
                }
                return [];
            }
        }
        public static async Task<List<Producttype>> GetProducttypes()
        {
            using (var client = new HttpClient())
            {
                var result = client.GetAsync("http://localhost:5184/api/ProductType").Result;
                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return JsonConvert.DeserializeObject<List<Producttype>>(await result.Content.ReadAsStringAsync());
                }
                return new List<Producttype>();
            }
        }
        public static async Task<List<Supplier>> GetSuppliers()
        {
            using (var client = new HttpClient())
            {
                var result = client.GetAsync("http://localhost:5184/api/Supplier").Result;
                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return JsonConvert.DeserializeObject<List<Supplier>>(await result.Content.ReadAsStringAsync());
                }
                return new List<Supplier>();
            }
        }
        public static async Task<List<Manufacturer>> GetManufacturers()
        {
            using (var client = new HttpClient())
            {
                var result = client.GetAsync("http://localhost:5184/api/Manufacturer").Result;
                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return JsonConvert.DeserializeObject<List<Manufacturer>>(await result.Content.ReadAsStringAsync());
                }
                return new List<Manufacturer>();
            }
        }

        public static async Task<Product> AddProduct(ProductDTO productDTO)
        {
            using (var client = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(productDTO);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var result = await client.PostAsync("http://localhost:5184/api/Product/adding", content);
                if (result.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    return JsonConvert.DeserializeObject<Product>(await result.Content.ReadAsStringAsync());
                }
                return null;
            }
        }

        public static async Task<bool> EditProduct(string article, ProductDTO productDTO)
        {
            using (var client = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(productDTO);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var result = await client.PutAsync($"http://localhost:5184/api/Product/{article}", content);
                if (result.StatusCode == System.Net.HttpStatusCode.NoContent) { return true; }
                return false;
            }
        }
        public static async Task<bool> DeleteProduct(string article)
        {
            using (var client = new HttpClient())
            {
                var result = await client.DeleteAsync($"http://localhost:5184/api/Product/{article}");
                return result.StatusCode == System.Net.HttpStatusCode.NoContent;
            }
        }

        public static async Task<bool> EditAccount(int id, UserDTO userDTO)
        {
            using (var client = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(userDTO);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var result = await client.PutAsync($"http://localhost:5184/api/User/{id}", content);
                if (result.StatusCode == System.Net.HttpStatusCode.NoContent) { return true; }
                return false;
            }
        }
    }
}
