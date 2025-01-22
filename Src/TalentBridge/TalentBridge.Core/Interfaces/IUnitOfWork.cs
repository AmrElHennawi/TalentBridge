using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentBridge.DataAccess.Repositories.Interfaces;

namespace TalentBridge.DataAccess
{
    internal interface IUnitOfWork : IDisposable
    {
        IBaseRepository<T> Repository<T>() where T : class;
        int Complete();
    }
}
