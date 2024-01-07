﻿using ETradeAPI.Application.Features.Command.Category.CreateCategory;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Application.Features.Command.Category;

public class CreateCategoryCommandRequest :  IRequest<CreateCategoryCommandResponse>
{
    public string Name { get; set; }
}
