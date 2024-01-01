using ETradeAPI.Application.Abstractions;
using ETradeAPI.Application.Abstractions.Services;
using ETradeAPI.Application.Services;
using ETradeAPI.Infrastructure.Services;
using ETradeAPI.Infrastructure.Services.Token;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Infrastructure;

public  static class ServiceRegistration
{
    public static void AddInfrastructureServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IFileService, FileService>();
        serviceCollection.AddScoped<ITokenHandler, TokenHandler>();
        serviceCollection.AddScoped<IMailService, MailService>();
    }
}
