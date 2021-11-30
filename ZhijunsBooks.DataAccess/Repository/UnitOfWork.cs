using ZhijunsBooks.DataAccess.Repository;
using ZhijunsBooks.DataAccess.Repository.IRepository;
using ZhijunsBooks.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZhijunsBooks.Models;

namespace ZhijunsBooks.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork //make the method public to access the class
    {
        private readonly ApplicationDbContext _db; //the using statement
        public UnitOfWork(ApplicationDbContext db)  //constructor
        {
            _db = db;
            Category = new CategoryRepository(_db);
            CoverType = new CoverTypeRepository(_db);
            SP_Call = new SP_Call(_db);
        }
        public ICategoryRepository Category { get; private set; }
        public ISP_Call SP_Call { get; private set; }
        public void Dispose()
        {
            _db.Dispose();
        }
        public void Save() // all changes wilkl be saved when the Save method is called at the 'parent' level
        {
            _db.SaveChanges();
        }
    }
}
