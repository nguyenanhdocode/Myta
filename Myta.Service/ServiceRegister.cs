using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Myta.Service
{
    public static class ServiceRegister
    {
        public static IServiceCollection AddServiceServices(this IServiceCollection services)
        {
            return services;
        }
    }
}
