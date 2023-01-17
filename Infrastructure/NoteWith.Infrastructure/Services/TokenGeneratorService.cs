using System;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using NoteWith.Application.Services;
using NoteWith.Domain.DTOModels.SecurityModels;
using NoteWith.Domain.EntitiyModels.UserModels;

namespace NoteWith.Infrastructure.Services
{
    public class TokenGeneratorService: ITokenGeneratorService
    {
        private readonly IConfiguration config;
        public TokenGeneratorService(IConfiguration _config)
		{
            config = _config;
		}

        public string DigitTokenGenerator(int DigitCount = 6)
        {
            try
            {
                var tiks = DateTime.Now.Ticks.ToString();
                return tiks.Substring(tiks.Length - DigitCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string JWTTokenGenerate(SessionModel user, DateTime expiredDate)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key= Encoding.ASCII.GetBytes(config["AppSettings:Token"]);
                var tokenDecriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                   {
                        new Claim(ClaimTypes.NameIdentifier, user.ID.ToString()),
                        new Claim(ClaimTypes.Name, user.Name),
                        new Claim(ClaimTypes.Surname, user.Surname),
                        new Claim(ClaimTypes.Email, user.Email),
                        new Claim("fireBaseConnectionID",user.FireBaseConnectionID??"")
                   }),
                    Expires = expiredDate,
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                   SecurityAlgorithms.HmacSha512Signature)
                };
                var token = tokenHandler.CreateToken(tokenDecriptor);
                return tokenHandler.WriteToken(token);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

