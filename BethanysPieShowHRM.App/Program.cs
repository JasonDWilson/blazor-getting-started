using BethanysPieShowHRM.App.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace BethanysPieShowHRM.App
{
    public class Program
    {
        private static async Task registerServices(WebAssemblyHostBuilder builder)
        {
            builder.Services
                .AddHttpClient<IEmployeeDataService, EmployeeDataService>(
                    client => client.BaseAddress = new Uri("https://localhost:44340/api/employee/"));
            builder.Services
                .AddHttpClient<ICountryDataService, CountryDataService>(
                    client => client.BaseAddress = new Uri("https://localhost:44340/api/country/"));
        }

        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            await registerServices(builder);

            await builder.Build().RunAsync();
        }
    }
}
