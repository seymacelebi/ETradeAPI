using ETradeAPI.Application.Abstractions.Services;
using ETradeAPI.Application.DTOs.User;
using ETradeAPI.Application.Features.Command.AppUser.CreateUser;
using ETradeAPI.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Persistence.Services
{
    public class UserService : IUserService
    {
        readonly UserManager<Domain.Entities.Identity.AppUser> _userManager;

        public UserService(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public Task<CreateUserResponse> CreateAsync(CreateUser model)
        {
            throw new NotImplementedException();
        }
    }
}
