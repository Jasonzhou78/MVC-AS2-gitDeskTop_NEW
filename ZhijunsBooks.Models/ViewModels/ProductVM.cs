using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using ZhijunBooks.Models;

namespace ZhijunsBooks.Models.ViewModels
{
    public class ProductVM
    {
        public Product Product { get; set; }  //Display all the product details
        public IEnumerable<SelectListItem> CategoryList { get; set; } //install package 'Microsoft.AspNetCore.Mvc.ViewFeatures' package
        public IEnumerable<SelectListItem> CoverTypeList { get; set; }
    }
}
