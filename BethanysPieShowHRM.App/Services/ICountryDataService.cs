using BethanysPieShopHRM.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BethanysPieShowHRM.App.Services
{
    public interface ICountryDataService
    {

        Task<IEnumerable<Country>> GetCountries();
        Task<Country> GetCountry(int countryId);
    }
}
