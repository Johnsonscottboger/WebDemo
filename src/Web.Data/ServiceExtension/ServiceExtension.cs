using Microsoft.Extensions.DependencyInjection;
using RedMan.Data.IRepository;
using RedMan.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Data.Entities;
using Web.DataAccess.Entities;

namespace Web.Data.ServiceExtension
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            /*注册服务*/
            services.AddScoped<IRepository<User>,Repository<User>>();
            services.AddScoped<IRepository<Role>,Repository<Role>>();
            services.AddScoped<IRepository<User_Role>,Repository<User_Role>>();

            return services;
        }
    }
}
