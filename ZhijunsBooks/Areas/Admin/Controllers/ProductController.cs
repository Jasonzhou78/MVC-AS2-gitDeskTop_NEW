using ZhijunsBooks.DataAccess.Repository.IRepository;
using ZhijunsBooks.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZhijunsBooks.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ZhijunsBooks.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment; //to upload images on the server inside wwwroot
        public ProductController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }





        //public IActionResult Upsert(int? id)  //get action method for Upsert
        //{
        //    ProductVM productVM = new ProductVM()
        //    {
        //        Product = new Product(),
        //        CategoryList = _unitOfWork.Category.GetAll().Select(i => new SelectListItem
        //        {
        //            Text = i.Name,
        //            Value = i.Id.ToString()
        //        }),
        //    };   //using ZhijunsBooks.Models
        //    if (id == null)
        //    {
        //        //this is for create
        //        return View(productVM);
        //    }
        //    //this is for the edit
        //    productVM.Product = _unitOfWork.Product.Get(id.GetValueOrDefault());
        //    if (productVM.Product == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(productVM);

        //}
        //API calls here
        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            //return NotFound();
            var allObj = _unitOfWork.Product.GetAll(includeProperties: "Category, coverType");
            return Json(new { data = allObj });
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.Product.Get(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            _unitOfWork.Product.Remove(objFromDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete succefully" });
        }
        #endregion
    }
}
