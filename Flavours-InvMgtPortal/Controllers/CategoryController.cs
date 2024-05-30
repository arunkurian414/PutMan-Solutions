using BOL.Models;
using BLL.LogicServices;
using Microsoft.AspNetCore.Mvc;

namespace Flavours_InvMgtPortal.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryLogicServices _categoryLogicServices;
        public CategoryController(ICategoryLogicServices categoryLogicServices)
        {
            _categoryLogicServices = categoryLogicServices;
        }
        public IActionResult Index()
        {
            List<Category> categoryList = new List<Category>();
            categoryList = _categoryLogicServices.GetAllCategories();
            return View(categoryList);
        }
      
    }
}

