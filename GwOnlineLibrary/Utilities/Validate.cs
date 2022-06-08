using System.ComponentModel.DataAnnotations;

namespace GwOnlineLibrary.Utilities;

internal static class Validate
{
    internal static bool ValidateEmailFormat(this string email)
    {
        return new EmailAddressAttribute().IsValid(email);
    }

    internal static bool ValidateIp(this string ip)
    {
        var parts = ip.Split('.');

        return parts.Length == 4
               && !parts.Any(
                   x => int.TryParse(x, out var y) && y > 255 || y < 1);
    }
}