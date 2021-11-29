using ZhijunsBooks.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZhijunsBooks.Models;
using Microsoft.AspNetCore.Mvc;

namespace ZhijunsBooks.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

       //public CategoryController()
       // {
       // }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Upsert(int? id)   //action method for Upsert
        {
            Category category = new Category(); //using ZhijunsBook.Models
            if (id == null)
            {
                //this is for create
                return View(category);
            }
            //this for the edit
            category = _unitOfWork.Category.Get(id.GetValueOrDefault());
            if (category == null)
            {
                return NotFound();
            }
            return View();
        }
        //use HTTP POST to define the post-action method
        #region API CALLS
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Category category)
        {
            if (ModelState.IsValid) //checks all validation in the model(e.g. Name required) to increase security
            {
                if (category.Id == 0)
                {
                    _unitOfWork.Category.Add(category);
                }
                else
                {
                    _unitOfWork.Category.Update(category);
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index)); // to see all the categories
            }
            return View(category);
        }
        //API calls here
        #endregion
        #region API CALLS
        [HttpGet]
        public IActionResult GetAll() 
        {
            //return NotFound();
            var allOjb = _unitOfWork.Category.GetAll();
            return Json(new { data = allOjb });
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.Category.Get(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            _unitOfWork.Category.Remove(objFromDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete successful" });
        }
        #endregion
    }
}