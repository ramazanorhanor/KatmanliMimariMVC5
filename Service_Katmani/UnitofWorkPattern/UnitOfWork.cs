using Data_Katmani;
using Domain_Katmani;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_Katmani.UnitofWorkPattern
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public IRepository<Product> Products { get; private set; }
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Products = new Repository<Product>(_context);
        }
        public int SaveChanges() => _context.SaveChanges();
        public void Dispose() => _context.Dispose();
    }

}
