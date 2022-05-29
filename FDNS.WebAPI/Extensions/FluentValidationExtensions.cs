using FDNS.Domain.Interfaces;
using FDNS.WebAPI.Models.Domains;
using FluentValidation;
using System.Text.RegularExpressions;

namespace FDNS.WebAPI.Extensions
{
    public static class FluentValidationExtensions
    {
        public static IRuleBuilderOptions<DomainsGetListRequest, string?> ValidSortingParameter(this IRuleBuilder<DomainsGetListRequest, string?> ruleBuilder)
        {
            var possibleValues = typeof(Common.Constants.ListType)
                .GetProperties().Select(p => p.GetConstantValue()?.ToString()?.ToUpper());
            return ruleBuilder.Must(val => val == null || possibleValues.Contains(val));
        }

        public static IRuleBuilderOptions<DomainsGetListRequest, string?> ValidSortByParameter(this IRuleBuilder<DomainsGetListRequest, string?> ruleBuilder)
        {
            var possibleValues = typeof(Common.Constants.SortBy)
                .GetProperties().Select(p => p.GetConstantValue()?.ToString()?.ToUpper());
            return ruleBuilder.Must(val => val == null || possibleValues.Contains(val));
        }

        public static IRuleBuilderOptions<DomainContactsRequest, string> ValidCountry(this IRuleBuilder<DomainContactsRequest, string> ruleBuilder, ICountriesRepository countriesRepository)
        {
            return ruleBuilder.Must((entity, value) =>
            {
                var country = countriesRepository.GetByFilterAsync(c => c.FullName == value).Result;
                return country != null; 
            }).WithMessage("Country '{PropertyValue}' was not found in a database");
        }

        public static IRuleBuilderOptions<T, string> ValidPhoneFormat<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.Matches(new Regex(@"\+[0-9]{1,3}.[0-9]{5,10}"))
                .WithMessage("{PropertyName} number must be filled in format +NNN.NNNNNNNNNN");
        }

        public static IRuleBuilderOptions<T, string> YesNoProperty<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.Matches(new Regex(@"\b(?i)(yes|no)\b"))
                .WithMessage("{PropertyName} property accepts 'yes' or 'no' values only");
        }

        public static IRuleBuilderOptions<T, string> MustFindDomainByName<T>(this IRuleBuilder<T, string> ruleBuilder, IDomainsRepository domainsRepository)
        {
            return ruleBuilder.Must((entity, value) =>
            {
                var domain = domainsRepository.GetByFilterAsync(d => d.Name == value).Result;
                return domain != null && domain.Count() == 1;
            }).WithMessage("Domain '{PropertyValue}' was not found in a database");
        }
    }
}