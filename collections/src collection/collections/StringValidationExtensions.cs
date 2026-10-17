
using System.Text.RegularExpressions;

namespace Collections;

public static class StringValidationExtensions
{
    public static bool IsValidEgyptianPhone(this string? phone)
    {
        return Regex.IsMatch
        (
            phone ?? string.Empty , @"^(01[0125]\d{8}|\+201[0125]\d{8})$"
        );
    }

    public static bool IsValidEgyptianNationalId(this string? nationalId)
    {
        return Regex.IsMatch
        (
            nationalId ?? string.Empty , @"^[23]\d{13}$"
        );
    }
}