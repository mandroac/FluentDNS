using FDNS.WebAPI.Models.Domains;
using FDNS.WebAPI.Extensions;
using FluentValidation;

namespace FDNS.WebAPI.Validators.Domains
{
    public class DomainsGetListRequestValidator : AbstractValidator<DomainsGetListRequest>
    {
        public DomainsGetListRequestValidator()
        {
            RuleFor(r => r.ListType).ValidSortingParameter();
            RuleFor(r => r.SearchTerm).MaximumLength(253);
            RuleFor(r => r.PageSize).InclusiveBetween(10, 100);
            RuleFor(r => r.SortBy).ValidSortByParameter();
        }
    }
}