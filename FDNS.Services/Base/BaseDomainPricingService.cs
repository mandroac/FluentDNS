using FDNS.Common.DataTransferObjects;
using FDNS.Common.Models;
using FDNS.Domain.Interfaces;
using FDNS.Domain.Models.Base;
using FDNS.Services.Abstractions.Base;
using Microsoft.EntityFrameworkCore;

namespace FDNS.Services.Base
{
    public class BaseDomainPricingService<TEntity> : IBaseDomainPricingService<TEntity>
        where TEntity : BasePrice
    {
        protected readonly IBasePriceRepository<TEntity> BaseRepository;

        public BaseDomainPricingService(IBasePriceRepository<TEntity> repository)
        {
            BaseRepository = repository;
        }
        public async Task<ServiceResult<IEnumerable<DomainPriceDTO>>> GetDefaultDomainPricing()
        {
            var tlds = new List<string>
            {
                "com",
                "net",
                "org",
                "biz",
                "info",
                "dev"
            };
            var pricing = await BaseRepository.AsQueryable().Where(d => tlds.Any(tld => 
                tld.Equals(d.ProductName)) && d.Duration == 1).ToListAsync();

            var result = new List<DomainPriceDTO>();
            uint cnt = 1;
            foreach (var tld in tlds)
            {
                var prices = pricing.Where(p => p.ProductName == tld);
                var register = prices.FirstOrDefault(p => p.ProductCategoryName.Equals("register"));
                var redemption = prices.FirstOrDefault(p => p.ProductCategoryName.Equals("redemption"));
                var renew = prices.FirstOrDefault(p => p.ProductCategoryName.Equals("renew"));
                
                result.Add(new DomainPriceDTO
                {
                    Id = cnt++,
                    TLD = tld,
                    Register = register == null ? null : Math.Round(register.UserPrice, 2),
                    Redemption = redemption == null ? null : Math.Round(redemption.UserPrice, 2),
                    Renew = renew == null ? null : Math.Round(renew.UserPrice, 2)
                });
            }

            return new ServiceResult<IEnumerable<DomainPriceDTO>>(result);
        }

        public async Task<ServiceResult<IEnumerable<DomainPriceDTO>>> GetDomainsPricingAsync()
        {
            var pricing = await BaseRepository.AsQueryable().ToListAsync();
            var tlds = pricing.Select(p => p.ProductName).Distinct();

            var result = new List<DomainPriceDTO>();
            uint cnt = 1;
            foreach (var tld in tlds)
            {
                var prices = pricing.Where(p => p.ProductName == tld);
                var register = prices.FirstOrDefault(p => p.ProductCategoryName.Equals("register"));
                var redemption = prices.FirstOrDefault(p => p.ProductCategoryName.Equals("redemption"));
                var renew = prices.FirstOrDefault(p => p.ProductCategoryName.Equals("renew"));

                result.Add(new DomainPriceDTO
                {
                    Id = cnt++,
                    TLD = tld,
                    Register = register == null ? null : Math.Round(register.UserPrice, 2),
                    Redemption = redemption == null ? null : Math.Round(redemption.UserPrice, 2),
                    Renew = renew == null ? null : Math.Round(renew.UserPrice, 2)
                });
            }

            return new ServiceResult<IEnumerable<DomainPriceDTO>>(result);
        }
    }
}