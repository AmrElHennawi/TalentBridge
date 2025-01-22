
using TalentBridge.DataAccess.Interfaces;
using TalentBridge.DataContext;
using TalentBridge.Entities.Models;

namespace TalentBridge.DataAccess.Repositories
{
    public class JobRepository:IBaseRepository<Job>
    {
        private readonly AppDbContext _dbContext;

        public JobRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<IEnumerable<Job>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Job> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(Job entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Job entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
