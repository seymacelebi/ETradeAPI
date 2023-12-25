﻿using ETradeAPI.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Application.Abstractions
{
    public interface ITokenHandler
    {
        DTOs.Token CreateAccessToken(int second);
        string CreateRefreshToken();
    }
}
