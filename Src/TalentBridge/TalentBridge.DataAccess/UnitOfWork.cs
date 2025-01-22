using TalentBridge.DataAccess.Interfaces;
using TalentBridge.DataContext;
using TalentBridge.Entities.Models;


namespace TalentBridge.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;
        public IBaseRepository<Job> Jobs { get; private set; }
        public UnitOfWork(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
       

        public IBaseRepository<T> Repository<T>() where T : class
        {
            throw new NotImplementedException();
        }

        public int Complete()
        {
            return _dbContext.SaveChanges();
        }
        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
