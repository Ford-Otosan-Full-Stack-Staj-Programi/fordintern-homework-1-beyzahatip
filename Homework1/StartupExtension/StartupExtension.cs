using Homework1.Data;
using Homework1.Data;
using System.Security.Principal;
using Homework1.Data.Model;
using Microsoft.VisualStudio.Services.Account;

namespace Homework1.Web.StartupExtension
{
    public static class StartupExtension
    {
        public static void AddServices (this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IGenericRepository<Staff>, GenericRepository<Staff>>();
        }
    }
}
