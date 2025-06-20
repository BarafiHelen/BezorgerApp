using System.Net.Http.Headers;
using System.Text.Json;
using System.Text;
using BezorgerApp.Models;

namespace BezorgerApp.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "http://51.137.100.120:5000/api"; 
        private const string ApiKey = "bc59d3e6-fc6c-4c50-85c1-712ec8d8636f";

        public ApiService()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("ApiKey", ApiKey);
        }

        public async Task<List<Order>> GetOrdersAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync($"{BaseUrl}/orders");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"API Response: {json}");
                    return JsonSerializer.Deserialize<List<Order>>(json);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[GetOrdersAsync] Error: {ex.Message}");
            }

            return new List<Order>();
        }

        public async Task<bool> UpdateOrderAsync(Order order)
        {
            var json = JsonSerializer.Serialize(order);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"{BaseUrl}/orders/{order.Id}", content);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UploadPhotoAsync(int orderId, byte[] photoBytes)
        {
            var content = new MultipartFormDataContent();
            var imageContent = new ByteArrayContent(photoBytes);
            imageContent.Headers.ContentType = MediaTypeHeaderValue.Parse("image/jpeg");
            content.Add(imageContent, "file", "photo.jpg");

            var response = await _httpClient.PostAsync($"{BaseUrl}/orders/{orderId}/photo", content);
            return response.IsSuccessStatusCode;
        }
        public async Task<bool> UploadLocationAsync(int orderId, Models.Location location)
        {
            var json = JsonSerializer.Serialize(location);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"{BaseUrl}/orders/{orderId}/location", content);
            return response.IsSuccessStatusCode;
        }
        public async Task<bool> UploadSignatureAsync(int orderId, string base64Signature)
        {
            var signatureData = new
            {
                ImageBase64 = base64Signature,
                SignedAt = DateTime.UtcNow
            };

            var json = JsonSerializer.Serialize(signatureData);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync($"{BaseUrl}/orders/{orderId}/signature", content);
            return response.IsSuccessStatusCode;
        }
    }
}
