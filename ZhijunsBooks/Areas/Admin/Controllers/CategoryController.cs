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

       // public CategoryController()
        //{
        //}

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Upsert(int? id)   //actioin method for Upsert
        {
            Category category = new Category();
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
        //API calls here
        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            return NotFound();
            var allObj = _unitOfWork.Category.GetAll();
            return Json(new { data = allObj });
        }
        #endregion
    }
}
