﻿using ETradeAPI.Application.Features.Command.AppUser.GoogleLogin;
using ETradeAPI.Application.Features.Command.AppUser.LoginUser;
using ETradeAPI.Application.Features.Command.AppUser.PasswordReset;
using ETradeAPI.Application.Features.Command.AppUser.VerifyResetToken;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETradeAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        readonly IMediator _mediator;
        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("[action]")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginUserCommandRequest loginUserCommandRequest)
        {
            LoginUserCommandResponse response = await _mediator.Send(loginUserCommandRequest);
            return Ok(response);
        }

        //[HttpPost("google-login")]
        //public async Task<IActionResult> GoogleLogin(GoogleLoginCommandRequest googleLoginCommandRequest)
        //{
        //    GoogleLoginCommandResponse response = await _mediator.Send(googleLoginCommandRequest);
        //    return Ok(response);
        //}
        [HttpPost("password-reset")]
        public async Task<IActionResult> PasswordReset([FromBody]PasswordResetCommandRequest passwordResetCommandRequest)
        {
            PasswordResetCommandResponse response = await _mediator.Send(passwordResetCommandRequest);
            return Ok(response);
        }
        [HttpPost("verify-reset-token")]
        public async Task<IActionResult> VerifyResetToken([FromBody] VerifyResetTokenCommandRequest verifyResetTokenCommandRequest)
        {
            VerifyResetTokenCommandResponse response = await _mediator.Send(verifyResetTokenCommandRequest);
            return Ok(response);
        }
    }
} 
