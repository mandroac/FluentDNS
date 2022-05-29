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
    }
}
