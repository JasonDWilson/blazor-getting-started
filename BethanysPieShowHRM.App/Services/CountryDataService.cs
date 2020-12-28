using BethanysPieShopHRM.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BethanysPieShowHRM.App.Services
{
    public class CountryDataService : ICountryDataService
    {
        private readonly HttpClient _httpClient;

        public CountryDataService(HttpClient client) =>
            _httpClient = client ?? throw new ArgumentNullException(nameof(client));

        public async Task<IEnumerable<Country>> GetCountries()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<Country>>(
                await _httpClient.GetStreamAsync(string.Empty),
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }


        public async Task<Country> GetCountry(int countryId)
        {
            return await JsonSerializer.DeserializeAsync<Country>(
                await _httpClient.GetStreamAsync($"{countryId}"),
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

    }
}
