using ETradeAPI.Application.Abstractions.Services;
using ETradeAPI.Application.DTOs.User;
using ETradeAPI.Application.Features.Command.Product.CreateProduct;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Application.Features.Command.AppUser.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
{

    readonly IUserService _userService;

    public CreateUserCommandHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
    {
        CreateUserResponse response = await _userService.CreateAsync(new()
        {
            Email = request.Email,
            NameSurname = request.NameSurname,
            Password = request.Password,
            PasswordConfirm = request.PasswordConfirm,
            Username = request.Username,
        });

        return new()
        {
            Message = response.Message,
            Succeeded = response.Succeeded,
        };

    }
}
