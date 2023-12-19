using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection collection)
        {
            //burada ServiceRegistration assembly hangisi ise bul ve ona göre mediatr yapılandırmasında inşaa et demek istiyoruz.
            collection.AddMediatR(typeof(ServiceRegistration));
        }
    }
}
