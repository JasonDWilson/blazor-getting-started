using BethanysPieShopHRM.App.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace BethanysPieShopHRM.App
{
    public class Program
    {
        private static void registerServices(IServiceCollection services)
        {
            services
                .AddHttpClient<IEmployeeDataService, EmployeeDataService>(
                    client => client.BaseAddress = new Uri("https://localhost:44340/"));
            services
                .AddHttpClient<ICountryDataService, CountryDataService>(
                    client => client.BaseAddress = new Uri("https://localhost:44340/api/country/"));
            services
                .AddHttpClient<IJobCategoryDataService, JobCategoryDataService>(
                    client => client.BaseAddress = new Uri("https://localhost:44340/api/jobcategory/"));
        }

        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            registerServices(builder.Services);

            await builder.Build().RunAsync();
        }
    }
}
