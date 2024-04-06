using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using PackagedeliveryusingQRcode.Models;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Azure.Identity;
using NuGet.Protocol;
using Azure.Core;


namespace PackagedeliveryusingQRcode.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly AuthenticationContext _context;

        public LoginController(AuthenticationContext context)
        {
            _context = context;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("authenticate")]
        public async Task<Object> Authenticate([FromBody] LoginModel model)
        {
            var user = await _context.Authentications.FindAsync(model.Username);
            var dbuser = _context.Authentications.Find(model.Username);
            if (dbuser != null)
            {


                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes("eyJhbGciOiJIUzI1NiJ9.eyJSb2xlIjoiQWRtaW4iLCJJc3N1ZXIiOiJJc3N1ZXIiLCJVc2VybmFtZSI6IkphdmFJblVzZSIsImV4cCI6MTcxMjAzNDkzNSwiaWF0IjoxNzEyMDM0OTM1fQ.IIQmYoViZtDvu-8WZgcrgCclCg5BM-I7JWsX6LFaJsI");
                TokenValidationParameters tokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    RequireExpirationTime = false,
                    ValidateLifetime = false,
                    ValidateAudience = false,
                    ValidateIssuer = false,

                };
                SecurityToken securityToken = null;
                try
                {
                    var res = tokenHandler.ValidateToken(dbuser.Jwttoken, tokenValidationParameters, out securityToken);



                    var userId = ((JwtSecurityToken)securityToken).Claims.ToList();

                    if (userId.ToArray()[1].Value.Equals(model.Password))
                    {
                        return "User Authenticated";
                    }
                    else
                    {
                        return "User Not Authenticated";
                    }
                }



                catch (Exception ex)
                {
                    return ex;
                }
                finally
                {
                    Console.WriteLine("Completed");
                }

            }
            return "Authentication over!User not found";
        }
    }
}
