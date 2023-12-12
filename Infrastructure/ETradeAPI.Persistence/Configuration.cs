using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;
namespace ETradeAPI.Persistence
{
    static class Configuration
    {
        static public string ConnectionString
        {
            get
            {
                IConfigurationBuilder configurationBuilder = new ConfigurationBuilder()
                    .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/ETradeAPI.API"))
                    .AddJsonFile("appsettings.json");

                IConfigurationRoot configuration = configurationBuilder.Build();

                return configuration.GetConnectionString("PostgreSQL");
            }
        }
    }
}
