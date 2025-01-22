using Microsoft.Extensions.DependencyInjection;
using TalentBridge.DataAccess.Repositories;
using TalentBridge.DataAccess.Repositories.Interfaces;
using TalentBridge.Entities.Models;

namespace TalentBridge.Application.ExtentionMethods
{
    public static class RepositoryCollectionExtention
    {
        public static IServiceCollection AddRepository(this IServiceCollection service)
            => service
                .AddScoped<IBaseRepository<Job>, JobRepository>();

    }
}