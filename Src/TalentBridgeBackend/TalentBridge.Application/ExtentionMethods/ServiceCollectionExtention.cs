using Microsoft.Extensions.DependencyInjection;
using TalentBridge.Application.Services;

namespace TalentBridge.Application.ExtentionMethods
{
    public static class ServiceCollectionExtention
    {
        public static IServiceCollection AddService(this IServiceCollection service)
            => service
                .AddScoped<AuthenticationService>()
                .AddScoped<HrService>()
                .AddScoped<JobService>()
                .AddScoped<ApplicationService>();
    }
}
