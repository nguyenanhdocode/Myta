using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Myta.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Myta.Infrastructure
{
    public static class ServiceRegister
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services
            , string connectionString)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));
            return services;
        }
    }
}
