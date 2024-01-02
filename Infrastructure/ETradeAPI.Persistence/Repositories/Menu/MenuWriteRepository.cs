﻿using ETradeAPI.Application.Repositories;
using ETradeAPI.Domain.Entities;
using ETradeAPI.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Persistence.Repositories;

public class MenuWriteRepository : WriteRepository<Menu>, IMenuWriteRepository
{
    public MenuWriteRepository(ETradeAPIDbContext context) : base(context)
    {
    }
}


