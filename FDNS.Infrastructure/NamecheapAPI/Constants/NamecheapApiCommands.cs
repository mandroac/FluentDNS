namespace FDNS.Infrastructure.NamecheapAPI.Constants
{
    internal static class NamecheapApiCommands
    {
        internal static class Domains
        {
            public const string GetList = "namecheap.domains.getList";
            public const string GetContacts = "namecheap.domains.getContacts";
            public const string Create = "namecheap.domains.create";
            public const string GetTldList = "namecheap.domains.getTldList";
            public const string SetContacts = "namecheap.domains.setContacts";
            public const string Check = "namecheap.domains.check";
            public const string Reactivate = "namecheap.domains.reactivate";
            public const string Renew = "namecheap.domains.renew";
            public const string GetRegistrarLock = "namecheap.domains.getRegistrarLock";
            public const string SetRegistrarLock = "namecheap.domains.setRegistrarLock";
            public const string GetInfo = "namecheap.domains.getInfo";

            internal static class DNS
            {
                public const string SetDefault = "namecheap.domains.dns.setDefault";
                public const string SetCustom = "namecheap.domains.dns.setCustom";
                public const string GetList = "namecheap.domains.dns.getList";
                public const string GetHosts = "namecheap.domains.dns.getHosts";
                public const string GetEmailForwarding = "namecheap.domains.dns.getEmailForwarding";
                public const string SetEmailForwarding = "namecheap.domains.dns.setEmailForwarding";
                public const string SetHosts = "namecheap.domains.dns.setHosts";

            }
        }

        internal static class Users
        {
            public const string GetPricing = "namecheap.users.getPricing";
            public const string GetBalances = "namecheap.users.getBalances";
            public const string ChangePassword = "namecheap.users.changePassword";
            public const string Update = "namecheap.users.update";
            public const string Createaddfundsrequest = "namecheap.users.createaddfundsrequest";
            public const string GetAddFundsStatus = "namecheap.users.getAddFundsStatus";
            public const string Create = "namecheap.users.create";
            public const string Login = "namecheap.users.login";
            public const string ResetPassword = "namecheap.users.resetPassword";
        }
    }
}
