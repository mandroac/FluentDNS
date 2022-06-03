using FDNS.Common.Configuration;
using FDNS.Common.Models;
using FDNS.Infrastructure.NamecheapAPI.Constants;
using FDNS.Infrastructure.NamecheapAPI.Interfaces;
using FDNS.Infrastructure.NamecheapAPI.Models.Users;
using Microsoft.Extensions.Options;
using System.Globalization;

namespace FDNS.Infrastructure.NamecheapAPI.Services
{
    public class NamecheapUsersService : NamecheapApiBaseService, INamecheapUsersService
    {
        public NamecheapUsersService(IHttpClientFactory httpClientFactory, IOptions<NamecheapApiConfiguration> options) : base(httpClientFactory, options)
        {
        }

        public async Task<ServiceResult<UserGetPricingResult>> GetPricing(GetPricingRequest request)
        {
            if (request.ProductType == null)
            {
                return new ServiceResult<UserGetPricingResult>(new List<string>
                {
                    "ProductType cannot be empty"
                });
            }
            var query = new Query(NamecheapApiCommands.Users.GetPricing, GlobalParams)
                .AddParameter(NamecheapApiParams.Pricing.ProductType, request.ProductType);

            if (request.ProductCategory != null)
            {
                query.AddParameter(NamecheapApiParams.Pricing.ProductCategory, request.ProductCategory);
            }

            if (request.PromotionCode != null)
            {
                query.AddParameter(NamecheapApiParams.Pricing.PromotionCode, request.PromotionCode);
            }

            if (request.ActionName != null)
            {
                query.AddParameter(NamecheapApiParams.Pricing.ActionName, request.ActionName);
            }

            if (request.ProductName != null)
            {
                query.AddParameter(NamecheapApiParams.Pricing.ProductName, request.ProductName);
            }

            try
            {
                var responseElement = await SendRequestAsync<UserGetPricingResult>(new HttpRequestMessage(HttpMethod.Get, query.Result));
                var result = new UserGetPricingResult();
                var productTypeName = responseElement.Element(NS + "ProductType").Attribute("Name").Value;

                foreach (var category in responseElement.Element(NS + "ProductType").Elements(NS + "ProductCategory"))
                {
                    var productCategoryName = category.Attribute("Name").Value;
                    foreach (var product in category.Elements(NS + "Product"))
                    {
                        var productName = product.Attribute("Name").Value;
                        foreach (var price in product.Elements(NS + "Price"))
                        {
                            result.Prices.Add(new ProductPrice
                            {
                                ProductTypeName = productTypeName,
                                ProductCategoryName = productCategoryName,
                                ProductName = productName,
                                Duration = int.Parse(price.Attribute("Duration").Value),
                                DurationType = price.Attribute("DurationType").Value,
                                Price = double.Parse(price.Attribute("Price").Value, CultureInfo.InvariantCulture),
                                RegularPrice = double.Parse(price.Attribute("RegularPrice").Value, CultureInfo.InvariantCulture),
                                YourPrice = double.Parse(price.Attribute("YourPrice").Value, CultureInfo.InvariantCulture),
                                CouponPrice = double.Parse(price.Attribute("PromotionPrice").Value, CultureInfo.InvariantCulture),
                                AdditionalCost = price.Attribute("AdditionalCost") == null ? 0 : double.Parse(price.Attribute("AdditionalCost").Value, CultureInfo.InvariantCulture),
                                Currency = price.Attribute("Currency").Value
                            });
                        }
                    }
                }
                return new ServiceResult<UserGetPricingResult>(result);
            }
            catch (ApplicationException ex)
            {
                return new ServiceResult<UserGetPricingResult>(new List<string>
                {
                    ex.Message
                });
            }
        }
    }
}
