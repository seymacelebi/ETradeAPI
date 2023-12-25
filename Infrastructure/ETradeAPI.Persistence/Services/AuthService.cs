using ETradeAPI.Application.Abstractions;
using ETradeAPI.Application.Abstractions.Services;
using ETradeAPI.Application.DTOs;
using ETradeAPI.Application.Exceptions;
using ETradeAPI.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Persistence.Services
{
    public class AuthService : IAuthService
    {
        readonly UserManager<Domain.Entities.Identity.AppUser> _userManager;
        readonly SignInManager<Domain.Entities.Identity.AppUser> _signInManager;
        readonly ITokenHandler _tokenHandler;
        readonly IUserService _userService;


        public AuthService(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, ITokenHandler tokenHandler, IUserService userService)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _tokenHandler = tokenHandler;
            _userService = userService;
        }

        public Task<Token> FacebookLoginAsync(string authToken, int accessTokenLifeTime)
        {
            throw new NotImplementedException();
        }

        public Task<Token> GoogleLoginAsync(string idToken, int accessTokenLifeTime)
        {
            throw new NotImplementedException();
        }

        public async Task<Token> LoginAsync(string usernameOrEmail, string password, int accessTokenLifeTime)
        {
            Domain.Entities.Identity.AppUser user = await _userManager.FindByNameAsync(usernameOrEmail);
            if (user == null)
                user = await _userManager.FindByEmailAsync(usernameOrEmail);
            if (user == null)
                throw new NotFoundUserException();

            SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, password, false);
            if (result.Succeeded) //Authentication başarılı!
            {
                Token token = _tokenHandler.CreateAccessToken(accessTokenLifeTime, user);

                return token;
            }
            throw new AuthenticationErrorException();
        }
        public async Task<Token> RefreshTokenLoginAsync(string refreshToken)
        {
            AppUser? user = await _userManager.Users.FirstOrDefaultAsync(u => u.RefreshToken == refreshToken);
            if (user != null && user?.RefreshTokenEndDate > DateTime.UtcNow)
            {
                Token token = _tokenHandler.CreateAccessToken(15, user);
                await _userService.UpdateRefreshToken(token.RefreshToken, user, token.Expiration, 15);
                return token;
            }
            else
                throw new NotFoundUserException();
        }
    }
}
