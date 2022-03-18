using ECommerce.Bussiness.Abstract;
using ECommerce.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public IActionResult Index()
        {
            return View(new ListCategoryModel()
            {
                Categories = _categoryService.GetAll(x => x.IsDeleted == false)
            });
        }
    }
}
