using System.Globalization;

namespace FDNS.Infrastructure.NamecheapAPI.Extensions
{
    internal static class DateTimeHelper
    {
        internal static DateTime ParseNamecheapDate(this string dateTimeString)
        {
            return DateTime.ParseExact(dateTimeString, "d", CultureInfo.InvariantCulture);
        }
    }
}
