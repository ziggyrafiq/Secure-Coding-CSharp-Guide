using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System.Buffers.Text;
using System.Net.NetworkInformation;
using System.Numerics;
using ZiggyRafiq.CSharpSecureCodingGuide.Console;
using static System.Runtime.InteropServices.JavaScript.JSType;

Console.WriteLine("Hello, from Ziggy Rafiq!");

Console.WriteLine("Enter your email address:");
string? email = Console.ReadLine();

if(!string.IsNullOrEmpty(email))
{
    Console.WriteLine(EmailValidator.IsValidEmail(email) ? "Email address is valid." : "Invalid email address format.");
}
else
{
    Console.WriteLine("Your email address is empty!");
}


/******************************************
 * SQL Injection Example                  *
 ******************************************/
SqlConnection connection = new SqlConnection("our_connection_string");
string inputUsername = "username"; // Example input
string inputPassword = "password"; // Example input

//Vulnerable Code
string vulnerableQuery = "SELECT * FROM Users WHERE Username = '" + inputUsername + "' AND Password = '" + inputPassword + "'";
SqlCommand vulneraCmd = new SqlCommand(vulnerableQuery, connection);

//Secure Code
string secureQuery = "SELECT * FROM Users WHERE Username = @Username AND Password = @Password";
SqlCommand secureCmd = new SqlCommand(secureQuery, connection);
secureCmd.Parameters.AddWithValue("@Username", inputUsername);
secureCmd.Parameters.AddWithValue("@Password", inputPassword);

/*******************************************
 * Cross-Site Scripting (XSS) Example      *
  ******************************************/
//Vulnerable Code
string userInput = "<script>alert('XSS')</script>";

//Secure Code
string sanitizedInput = System.Web.HttpUtility.HtmlEncode(userInput);

/******************************************
 * Password Hashing Example               *
 ******************************************/
//Hashing Password
string password = "user123";
string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

//Verifying Password
bool isPasswordValid = BCrypt.Net.BCrypt.Verify("user123", hashedPassword);

/******************************************
* Data Encryption Example                 *
******************************************/
//Encrypting Data
string originalData = "Some Sensitive information is here :)";
string encryptedData = EncryptionHelper.Encrypt(originalData, "encryptionKey");

//Decrypting Data
string decryptedData = EncryptionHelper.Decrypt(encryptedData, "encryptionKey");

/*******************************************
* Two - Factor Authentication(2FA) Example *
*******************************************/
//Generating and Verifying OTP
string userSecretKey = "userSecretKeyFromDatabase";
string generatedOTP = OTPGenerator.GenerateOTP(userSecretKey);

//Verifying OTP
string userEnteredOTP = "123YouGoFree";
bool isOTPValid = OTPGenerator.VerifyOTP(userSecretKey, userEnteredOTP);

/*******************************************
* Token - Based Authentication Example     *
*******************************************/
//Generating and Validating JWT Token
string userId = "iAmDummyUser";
string token = TokenGenerator.GenerateToken(userId);

//Validating JWT Token
bool isTokenValid = TokenGenerator.ValidateToken(token);

/*******************************************
* Using BCrypt.Net to hash passwords. *
*******************************************/
//BCrypt.Net password hashing example
string passwordHashingExample = "user123";
string hashedPasswordHashingExample = BCrypt.Net.BCrypt.HashPassword(password);

/********************************************************
Input validation and XSS prevention using OWASP AntiSamy*
********************************************************/

string userInpuAntiSamyt = "<script>alert('XSS')</script>";
string sanitizedInputAntiSamy = AntiSamy.Sanitize(userInput);
