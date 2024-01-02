﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Application.Features.Command.AuthorizationEndpoint.AssignRoleEndpoint
{
    public class AssignRoleEndpointCommandRequest : IRequest<AssignRoleEndpointCommandResponse>
    {
        public string[] Roles { get; set; }
        public string Code { get; set; }
        public string Menu { get; set; }
        public Type? Type { get; set; }
    }
}
