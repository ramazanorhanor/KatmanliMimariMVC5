using Data_Katmani;
using Domain_Katmani;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_Katmani.UnitofWorkPattern
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Product> Products { get; }
        int SaveChanges();
    }
}
