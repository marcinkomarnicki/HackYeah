using HackYeah.Application.Queries.Models;
using HackYeah.DAL.Models;
using HackYeah.Infrastructure.Configurations;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HackYeah.Application.Queries
{
    public class GetUserTokenQuery : IRequest<UserToken>
    {
        public required string UserName { get; set; } 
        public required string Password { get; set; }
    }

    public class GetUserTokenQueryHandler : IRequestHandler<GetUserTokenQuery, UserToken>
    {
        private readonly UserManager<User> _userManager;
        private readonly IOptions<JWTSection> _jwtOptions;

        public GetUserTokenQueryHandler(UserManager<User> userManager, IOptions<JWTSection> jwtOptions)
        {
            _userManager = userManager;
            _jwtOptions = jwtOptions;
        }

        public async Task<UserToken> Handle(GetUserTokenQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);

            if (!await _userManager.CheckPasswordAsync(user, request.Password))
            {
                throw new Exception("user not found");

                //TODO: throw notfound exception
            }

            var jwtKey = Encoding.ASCII.GetBytes(_jwtOptions.Value.Secret);
            var jwtExpires = DateTime.Now.AddMinutes(_jwtOptions.Value.ExpirationTimeInMinutes);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, request.UserName)
            };

            var jwtToken = new JwtSecurityToken(claims: claims,
                notBefore: new DateTimeOffset(DateTime.Now).DateTime,
                expires: new DateTimeOffset(jwtExpires).DateTime,
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(jwtKey), SecurityAlgorithms.HmacSha256));

            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();

            return new UserToken
            {
                AccessToken = jwtSecurityTokenHandler.WriteToken(jwtToken)
            };
        }
    }
}
