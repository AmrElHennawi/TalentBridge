using Microsoft.Extensions.DependencyInjection;
using TalentBridge.DataAccess;
using TalentBridge.DataAccess.Interfaces;
using TalentBridge.DataAccess.Repositories;

namespace TalentBridge.Application.ExtentionMethods
{
    public static class RepositoryCollectionExtention
    {
        public static IServiceCollection AddRepository(this IServiceCollection service)
            => service
                .AddScoped<IUnitOfWork, UnitOfWork>()
                .AddScoped<IHrRepository, HrRepository>();

    }
}