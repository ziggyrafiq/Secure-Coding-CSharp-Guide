namespace ZiggyRafiq.CSharpSecureCodingGuide.Console;
public static class AntiSamy
{
    public static string Sanitize(string input)
    {
        // Implement your sanitization logic here
        // For example, you can use regular expressions to remove or neutralize malicious HTML/JS code
        string sanitizedInput = input.Replace("<script>", "").Replace("</script>", "");

        return sanitizedInput;
    }
}
