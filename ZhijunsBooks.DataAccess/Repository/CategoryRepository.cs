using ZhijunsBooks.DataAccess.Repository.IRepository;
using ZhijunsBooks.Models;
using System;
using System.Collections.Generic;
using System.Text;
using ZhijunsBooks.DataAccess.Data;
using System.Linq;

namespace ZhijunsBooks.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Category category)
        {
            //use .net LINQ to retrieve the first of default category object
            //then pass the id as a generic entity which matches the category ID
            var objFromDb = _db.Categories.FirstOrDefault(s => s.Id == category.Id);
            if (objFromDb != null) //save changes if not null
            {
                objFromDb.Name = category.Name;
                _db.SaveChanges();
            }
        }
    }
}

