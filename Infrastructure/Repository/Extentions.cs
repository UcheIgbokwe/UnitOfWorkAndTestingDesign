using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Repository
{
    public static class Extentions
    {
        public static void AddUnitOfWork<Context>(this IServiceCollection services)
            where Context : DbContext
        {
            services.AddTransient(typeof(GenericRepository<,>), typeof(GenericRepository<,>));
            services.AddScoped<IUnitOfWork, UnitOfWork<Context>>();
        }
    }
}