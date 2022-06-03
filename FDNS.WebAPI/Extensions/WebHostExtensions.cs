using AutoMapper;
using FDNS.Common.Configuration;
using FDNS.Domain.Interfaces;
using FDNS.Domain.Models;
using FDNS.Infrastructure.NamecheapAPI.Interfaces;
using FDNS.Infrastructure.NamecheapAPI.Models.Users;
using FNDS.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace FDNS.WebAPI.Extensions
{
    public static class WebHostExtensions
    {
        public static async Task<WebApplication> MigrateDatabaseAsync(this WebApplication webApp)
        {
            using (var scope = webApp.Services.CreateScope())
            {
                using var context = scope.ServiceProvider.GetRequiredService<FdnsDbContext>();
                try
                {
                    await context.Database.MigrateAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
            }
            return webApp;
        }

        public static async Task<WebApplication> SeedDatabaseAsync(this WebApplication webApp)
        {
            using var scope = webApp.Services.CreateScope();
            using var context = scope.ServiceProvider.GetRequiredService<FdnsDbContext>();
            try
            {
                if (!await context.SandboxDomainPricing.AnyAsync())
                {
                    await SeedSandboxPricingAsync(scope);
                }
                if (!await context.SandboxTLDs.AnyAsync())
                {
                    await SeedSandboxTldsAsync(scope);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

            return webApp;
        }

        private static async Task SeedSandboxTldsAsync(IServiceScope scope)
        {
            var namecheapApiService = scope.ServiceProvider.GetRequiredService<INamecheapDomainsService>();
            var sandboxTldsRepository = scope.ServiceProvider.GetRequiredService<IBaseTLDRepository<SandboxTLD>>();
            var mapper = scope.ServiceProvider.GetRequiredService<IMapper>();

            var apiResponse = await namecheapApiService.GetTldList();
            var tlds = mapper.Map<IEnumerable<SandboxTLD>>(apiResponse.Value.TldList);
            await sandboxTldsRepository.UploadTldsAsync(tlds);
        }

        private static async Task SeedSandboxPricingAsync(IServiceScope scope)
        {
            var namecheapApiService = scope.ServiceProvider.GetRequiredService<INamecheapUsersService>();
            var sandboxPricingRepository = scope.ServiceProvider.GetRequiredService<ISandboxDomainPricingRepository>();
            var mapper = scope.ServiceProvider.GetRequiredService<IMapper>();

            var mult = scope.ServiceProvider.GetRequiredService<IOptions<EconomyConfiguration>>().Value.ProfitabilityMultiplier;

            var apiResponse = await namecheapApiService.GetPricing(new GetPricingRequest
            {
                ProductType = "DOMAIN"
            });
            var pricing = mapper.Map<IEnumerable<SandboxDomainPrice>>(apiResponse.Value.Prices, opts => opts.Items.Add("Profitability", mult));
            await sandboxPricingRepository.UploadPricingAsync(pricing);
        }
    }
}