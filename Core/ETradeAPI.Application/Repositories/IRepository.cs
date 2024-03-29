﻿using ETradeAPI.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Application.Repositories;

public interface IRepository<T> where T : BaseEntity
{
    //Dbset ile table alırız ama herhangi bir set işlemi yapmayız.

    DbSet<T> Table { get; }
}
