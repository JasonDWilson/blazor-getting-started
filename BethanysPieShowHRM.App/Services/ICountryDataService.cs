using BethanysPieShopHRM.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShowHRM.App.Services
{
    public interface ICountryDataService
    {
        Task<IEnumerable<Country>> GetCountriesAsync();

        Task<Country> GetCountryAsync(int countryId);
    }
}
