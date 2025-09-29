using Ecom.Core.Interfaces;
using Ecom.Infrastructure.Data;
using Ecom.Infrastructure.Reposatories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Infrastructure.Registration
{
    public static class InfreastructureRegistration
    {
        public static IServiceCollection Register(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddScoped(typeof(IGenericReposetory<>), typeof(GenericReposatory<>));
            services.AddScoped<IProductReposatory, ProductReposatory>();
            services.AddScoped<ICategoryReposatory, CategoryReposatory>();
            services.AddScoped<IPhotoReposatory, PhotoReposatory>();
            services.AddDbContext<AppDBContext>(builder => builder.UseSqlServer(configuration.GetConnectionString("local")));
            return services;
        }
    }
}
