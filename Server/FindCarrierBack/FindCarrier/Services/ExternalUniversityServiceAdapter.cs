using FindCarrier.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FindCarrier.Services.Services
{
    public class ExternalUniversityServiceAdapter : IExternalUniversityService
    {
        private readonly HttpClient _httpClient;

        public ExternalUniversityServiceAdapter()
        {
            _httpClient = new HttpClient();
        }

        public async Task<string> SendApplication(string universityName, string studentName)
        {
            // Simulating the application process
            await Task.Delay(1000);

            // Send the application request to the university server
            var applicationResponse = await _httpClient.PostAsync("http://university-server.com/apply", null);
            applicationResponse.EnsureSuccessStatusCode();

            // Return the application status as a string
            return await applicationResponse.Content.ReadAsStringAsync();
        }
    }

}