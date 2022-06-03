namespace FDNS.Infrastructure.NamecheapAPI.Constants
{
    internal static class NamecheapApiParams
    {
        internal static class Globals
        {
            public static readonly string Command = "Command";
            public static readonly string ApiUser = "ApiUser";
            public static readonly string Username = "Username";
            public static readonly string ApiKey = "ApiKey";
            public static readonly string ClientIp = "ClientIp";
        }

        internal static class Domains
        {
            public static readonly string DomainName = "DomainName";
            public static readonly string DomainList = "DomainList";
            public static readonly string HostName = "HostName";
            public static readonly string ListType = "ListType";
            public static readonly string SearchTerm = "SearchTerm";
            public static readonly string SortBy = "SortBy";
            public static readonly string Page = "Page";
            public static readonly string PageSize = "PageSize";
            public static readonly string Years = "Years";
            public static readonly string PromotionCode = "PromotionCode";

            internal static class DNS
            {
                public static readonly string SLD = "SLD";
                public static readonly string TLD = "TLD";
                public static readonly string HostName = "HostName";
                public static readonly string Address = "Address";
                public static readonly string MxPref = "MxPref";
                public static readonly string RecordType = "RecordType";
                public static readonly string TTL = "TTL";
            }
        }

        internal static class Pricing
        {
            public static readonly string ProductType = "ProductType";
            public static readonly string ProductCategory = "ProductCategory";
            public static readonly string PromotionCode = "PromotionCode";
            public static readonly string ActionName = "ActionName";
            public static readonly string ProductName = "ProductName";
        }
    }
}