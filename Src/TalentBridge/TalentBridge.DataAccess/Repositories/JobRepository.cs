using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TalentBridge.DataAccess.Repositories.Interfaces;
using TalentBridge.Entities;

namespace TalentBridge.DataAccess.Repositories
{
    public class JobRepository:IBaseRepository<Job>
    {
        private readonly DbContext _dbContext;

        public JobRepository(DbContext dbContext)
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
