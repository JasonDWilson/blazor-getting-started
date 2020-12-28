using BethanysPieShopHRM.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace BethanysPieShopHRM.App.Services
{
    public class JobCategoryDataService : IJobCategoryDataService
    {
        private readonly HttpClient _httpClient;

        public JobCategoryDataService(HttpClient client) => _httpClient =
            client ?? throw new ArgumentNullException(nameof(client));

        public async Task<IEnumerable<JobCategory>> GetJobCategoriesAsync()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<JobCategory>>(
                await _httpClient.GetStreamAsync(string.Empty),
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }


        public async Task<JobCategory> GetJobCategoryAsync(int JobCategoryId)
        {
            return await JsonSerializer.DeserializeAsync<JobCategory>(
                await _httpClient.GetStreamAsync($"{JobCategoryId}"),
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
    }
}
