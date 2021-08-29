using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using SynetecAssessmentApi.AutoMapper;

namespace SynetecAssessmentApi.AppStart
{
    public static class AutoMapper
    {
        public static void RegisterAutoMapper(this IServiceCollection services)
        {
            // Auto Mapper Configurations
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new EmployeeProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
