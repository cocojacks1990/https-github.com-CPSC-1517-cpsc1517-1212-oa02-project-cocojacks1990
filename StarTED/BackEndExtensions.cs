using Microsoft.EntityFrameworkCore;    // for DbContextOptionsBuilder
using Microsoft.Extensions.DependencyInjection; // for IServiceCollection, Action
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StarTEDsystem.BLL;   // for CategoryServices
using StarTEDsystem.DAL;   // for WestWindContext

namespace StarTEDsystem
{
    public static class BackendExtensions
    {
        public static void BackendDependencies(
            this IServiceCollection services,
            Action<DbContextOptionsBuilder> options)
        {

            services.AddDbContext<StartedContext>(options);

            services.AddTransient<ClubServices>((serviceProvider) =>
            {
                var dbContext = serviceProvider.GetService<StartedContext>();
                return new ClubServices(dbContext);
            });

            services.AddTransient<EmployeeServices>((serviceProvider) =>
            {
                var dbContext = serviceProvider.GetService<StartedContext>();
                return new EmployeeServices(dbContext);
            });


        }
    }
}