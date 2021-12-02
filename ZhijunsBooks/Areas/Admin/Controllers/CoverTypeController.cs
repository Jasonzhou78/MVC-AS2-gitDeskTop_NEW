using ZhijunsBooks.DataAccess.Repository.IRepository;
using System;
using ZhijunsBooks.Utility;
using Dapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZhijunsBooks.Models;
using Microsoft.AspNetCore.Mvc;

namespace ZhijunsBooks.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CoverTypeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CoverTypeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //public CoverTypeController()
        // {
        // }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Upsert(int? id)   //action method for Upsert
        {
            CoverType coverType = new CoverType(); //using ZhijunsBook.Models
            if (id == null)
            {
                //this is for create
                return View(coverType);
            }
            //this for the edit
            coverType = _unitOfWork.CoverType.Get(id.GetValueOrDefault());
            if (coverType == null)
            {
                return NotFound();
            }
            return View(coverType);
        }
        //use HTTP POST to define the post-action method
        #region API CALLS
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(CoverType coverType)
        {
            if (ModelState.IsValid) //checks all validation in the model(e.g. Name required) to increase security
            {
                if (coverType.Id == 0)
                {
                    _unitOfWork.CoverType.Add(coverType);
                }
                else
                {
                    _unitOfWork.CoverType.Update(coverType);
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index)); // to see all the covertypes
            }
            return View(coverType);
        }
        //API calls here
        #endregion    
    }
}

