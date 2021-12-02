using ZhijunsBooks.DataAccess.Repository.IRepository;
using ZhijunsBooks.Models;
using System;
using System.Collections.Generic;
using System.Text;
using ZhijunsBooks.DataAccess.Data;
using System.Linq;
using ZhijunBooks.Models;

namespace ZhijunsBooks.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Product product)
        {
            //use .net LINQ to retrieve the first of default category object
            //then pass the id as a generic entity which matches the category ID
            var objFromDb = _db.Products.FirstOrDefault(s => s.Id == product.Id);
            if (objFromDb != null) //save changes if not null
            {
                if (product.ImageUrl != null)
                {
                    objFromDb.ImageUrl = product.ImageUrl; //add the check for ImageUrl
                }
                objFromDb.Title = product.Title;
                objFromDb.Description = product.Description;
                objFromDb.ISBN = product.ISBN;
                objFromDb.Author = product.Author;
                objFromDb.ListPrice = product.ListPrice;
                objFromDb.CategoryId = product.CategoryId;
                objFromDb.CoverType = product.CoverType; //all properties of Product object
            }
        }
    }
}