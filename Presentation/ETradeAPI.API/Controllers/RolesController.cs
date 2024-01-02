﻿using ETradeAPI.Application.CustomAttributes;
using ETradeAPI.Application.DTOs.Configuration;
using ETradeAPI.Application.Enums;
using ETradeAPI.Application.Features.Command.Role;
using ETradeAPI.Application.Features.Command.Role.CreateRole;
using ETradeAPI.Application.Features.Command.Role.DeleteRole;
using ETradeAPI.Application.Features.Command.Role.UpdateRole;
using ETradeAPI.Application.Features.Queries.Role;
using ETradeAPI.Application.Features.Queries.Role.GetRoleById;
using ETradeAPI.Application.Features.Queries.Role.GetRoles;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETradeAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Admin")]
    public class RolesController : ControllerBase
    {
        readonly IMediator _mediator;

        public RolesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        [AuthorizeDefinition(ActionType = ActionType.Reading, Definition = "Get Roles", Menu = "Roles")]
        public async Task<IActionResult> GetRoles(GetRolesQueryRequest getRolesQueryRequest)
        {
            GetRolesQueryResponse response = await _mediator.Send(getRolesQueryRequest);
            return Ok(response);
        }
        [HttpGet("{Id}")]
        [AuthorizeDefinition(ActionType = ActionType.Reading, Definition = "Get Role By Id", Menu = "Roles")]
        public async Task<IActionResult> GetRoles([FromRoute] GetRoleByIdQueryRequest getRoleByIdQueryRequest)
        {
            GetRoleByIdQueryResponse response = await _mediator.Send(getRoleByIdQueryRequest);
            return Ok(response);
        }
        [HttpPost]
        [AuthorizeDefinition(ActionType = ActionType.Writing, Definition = "Create Role", Menu = "Roles")]
        public async Task<IActionResult> reateRole([FromBody] CreateRoleCommandRequest createRoleCommandRequest)
        {
            CreateRoleCommandResponse response = await _mediator.Send(createRoleCommandRequest);
            return Ok(response);
        }
        [HttpPut("{Id}")]
        [AuthorizeDefinition(ActionType = ActionType.Updating, Definition = "Update Role", Menu = "Roles")]
        public async Task<IActionResult> UpdateRole([FromBody, FromRoute] UpdateRoleCommandRequest updateRoleCommandRequest)
        {
            UpdateRoleCommandResponse response = await _mediator.Send(updateRoleCommandRequest);
            return Ok(response);
        }
        [HttpDelete]
        [AuthorizeDefinition(ActionType = ActionType.Deleting, Definition = "Delete Role", Menu = "Roles")]
        public async Task<IActionResult> DeleteRole([FromRoute] DeleteRoleCommandRequest deleteRoleCommandRequest)
        {
            DeleteRoleCommandResponse response = await _mediator.Send(deleteRoleCommandRequest);
            return Ok(response);
        }

    }
}