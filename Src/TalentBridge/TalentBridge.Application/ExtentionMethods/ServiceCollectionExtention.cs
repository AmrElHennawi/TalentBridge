using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using TalentBridge.Application.Services;

namespace TalentBridge.Application.ExtentionMethods
{
    public static class ServiceCollectionExtention
    {
        public static IServiceCollection AddService(this IServiceCollection service)
            => service
                .AddScoped<AuthenticationService>()
                .AddScoped<HrService>();
    }
}
