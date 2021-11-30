using ZhijunsBooks.DataAccess.Repository.IRepository;
using ZhijunsBooks.Models;
using System;
using System.Collections.Generic;
using System.Text;
using ZhijunsBooks.DataAccess.Data;
using System.Linq;
using System.Linq.Expressions;

namespace ZhijunsBooks.DataAccess.Repository
{
    public class CoverTypeRepository : Repository<CoverType>, ICoverTypeRepository
    {
        private readonly ApplicationDbContext _db;
        public CoverTypeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Add(CoverType entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CoverType> GetAll(Expression<Func<CoverType, bool>> filter = null, Func<IQueryable<CoverType>, IOrderedQueryable<CoverType>> orderBy = null, string includeProperties = null)
        {
            throw new NotImplementedException();
        }

        public CoverType GetFirstOrDefault(Expression<Func<CoverType, bool>> filter = null, string includeProperties = null)
        {
            throw new NotImplementedException();
        }

        public void Remove(CoverType entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<CoverType> entity)
        {
            throw new NotImplementedException();
        }

        public void Update(CoverType coverType)
        {
            //use .net LINQ to retrieve the first of default coverType object
            //then pass the id as a generic entity which matches the coverType ID
            var objFromDb = _db.CoverTypes.FirstOrDefault(s => s.Id == coverType.Id);
            if (objFromDb != null) //save changes if not null
            {
                objFromDb.Name = coverType.Name;
                _db.SaveChanges();
            }
        }

        CoverType IRepository<CoverType>.Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}


