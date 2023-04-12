using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Web;

namespace JWTAuth.Models
{
    public class TokenManager
    {
        public static string GenerateToken(string username)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub,username),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier,username)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Convert.ToString(ConfigurationManager.AppSettings["config:Jwtkey"])));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(Convert.ToString(ConfigurationManager.AppSettings["config:JwtExpireDays"])));

            var token = new JwtSecurityToken(
                        Convert.ToString(ConfigurationManager.AppSettings["config:JwtIssuer"]),
                        Convert.ToString(ConfigurationManager.AppSettings["config:JwtAudience"]),
                        claims,
                        expires: expires,
                        signingCredentials: creds
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public static string ValidateToken(string token)
        {
            if (token == null) return null;

            var tokenhandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Convert.ToString(ConfigurationManager.AppSettings["config:JwtKey"]));
            try
            {
                tokenhandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,

                    ClockSkew = TimeSpan.Zero


                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var jti = jwtToken.Claims.First(claim => claim.Type == "jti").Value;
                var username = jwtToken.Claims.First(sub => sub.Type == "sub").Value;
                return username;
            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}