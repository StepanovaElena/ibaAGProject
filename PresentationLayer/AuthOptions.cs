using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace PresentationLayer
{
    public class AuthOptions
    {
        public const string ISSUER = "IbaTestAuthServer"; 
        public const string AUDIENCE = "IbaTestAuthClient";
        const string KEY = "mysupersecret_secretkey!123";
        public const int LIFETIME = 1440;
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
