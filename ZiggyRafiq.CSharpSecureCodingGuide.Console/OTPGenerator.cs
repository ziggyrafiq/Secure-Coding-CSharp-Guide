using System.Security.Cryptography;

namespace ZiggyRafiq.CSharpSecureCodingGuide.Console;
public static class OTPGenerator
{
    // Method to generate OTP
    public static string GenerateOTP(string secretKey)
    {
        // Convert secret key to byte array
        byte[] keyBytes = Convert.FromBase64String(secretKey);

        // Set current timestamp divided by time step
        long counter = DateTimeOffset.UtcNow.ToUnixTimeSeconds() / 30; // 30-second time step

        // Convert counter to byte array (big-endian)
        byte[] counterBytes = BitConverter.GetBytes(counter);
        if (BitConverter.IsLittleEndian)
        {
            Array.Reverse(counterBytes);
        }

        // Create HMAC-SHA1 hash using secret key and counter
        using (HMACSHA1 hmac = new HMACSHA1(keyBytes))
        {
            byte[] hash = hmac.ComputeHash(counterBytes);

            // Get last 4 bits of the hash
            int offset = hash[hash.Length - 1] & 0x0F;

            // Get 4 bytes starting from offset
            byte[] otpValue = new byte[4];
            Array.Copy(hash, offset, otpValue, 0, 4);

            // Mask most significant bit of last byte
            otpValue[0] &= 0x7F;

            // Convert bytes to integer
            int otp = BitConverter.ToInt32(otpValue, 0);

            // Generate 6-digit OTP
            otp %= 1000000;

            // Format OTP with leading zeros if necessary
            return otp.ToString("D6");
        }
    }

    // Method to verify OTP
    public static bool VerifyOTP(string secretKey, string userEnteredOTP)
    {
        // Convert secret key to byte array
        byte[] keyBytes = Convert.FromBase64String(secretKey);

        // Set current timestamp divided by time step
        long counter = DateTimeOffset.UtcNow.ToUnixTimeSeconds() / 30; // 30-second time step

        // Convert counter to byte array (big-endian)
        byte[] counterBytes = BitConverter.GetBytes(counter);
        if (BitConverter.IsLittleEndian)
        {
            Array.Reverse(counterBytes);
        }

        // Create HMAC-SHA1 hash using secret key and counter
        using (HMACSHA1 hmac = new HMACSHA1(keyBytes))
        {
            byte[] hash = hmac.ComputeHash(counterBytes);

            // Get last 4 bits of the hash
            int offset = hash[hash.Length - 1] & 0x0F;

            // Get 4 bytes starting from offset
            byte[] otpValue = new byte[4];
            Array.Copy(hash, offset, otpValue, 0, 4);

            // Mask most significant bit of last byte
            otpValue[0] &= 0x7F;

            // Convert bytes to integer
            int otp = BitConverter.ToInt32(otpValue, 0);

            // Generate 6-digit OTP
            otp %= 1000000;

            // Compare generated OTP with user-entered OTP
            return otp.ToString("D6") == userEnteredOTP;
        }
    }
}
