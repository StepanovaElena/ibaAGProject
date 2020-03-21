using BussinesLayer;
using DataLayer.Entity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace PresentationLayer.Services
{
    public class AuthService
    {
        private DataManager _dataManager;

        public AuthService(DataManager dataManager)
        {
            this._dataManager = dataManager;

        }

        public object GetToken(ClaimsIdentity identity)
        {
            var now = DateTime.UtcNow;
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256)
                    );
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return new
            {
                access_token = encodedJwt,
                email = identity.Name
            };
        }

        public ClaimsIdentity GetIdentity(string email, string password)
        {
            Users _user = _dataManager.Users.GetUsersByEmailPassword(email, password);

            if (_user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, _user.Email),
                };

                ClaimsIdentity claimsIdentity = new ClaimsIdentity(
                    claims, "Token", 
                    ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;
            }
            
            return null;
        }
    }
}
