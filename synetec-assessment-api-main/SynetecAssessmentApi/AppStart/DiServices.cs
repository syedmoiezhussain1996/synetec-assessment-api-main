using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SynetecAssessmentApi.Persistence;
using SynetecAssessmentApi.Services;

namespace SynetecAssessmentApi.AppStart
{
    public static class DiServices
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseInMemoryDatabase(databaseName: "HrDb"));
            services.AddScoped<IBonusPoolService, BonusPoolService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
        }
    }
}
