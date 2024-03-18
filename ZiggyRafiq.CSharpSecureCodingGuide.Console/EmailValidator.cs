using System.Text.RegularExpressions;

namespace ZiggyRafiq.CSharpSecureCodingGuide.Console;
public static class EmailValidator
{
   public static bool IsValidEmail(string email)
    {
        // Regular expression for validating email addresses
        string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

        // Check if email matches the pattern
        return Regex.IsMatch(email, emailPattern);
    }

}
