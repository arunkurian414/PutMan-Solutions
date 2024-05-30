using BOL.Models;
using DAL.DataServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.LogicServices
{
    public class CategoryLogicServices : ICategoryLogicServices
    {
        private readonly ICategoryDataServices _categoryDataServices;
        public CategoryLogicServices(ICategoryDataServices categoryDataServices)
        {
            _categoryDataServices = categoryDataServices;
        }

        public List<Category> GetAllCategories()
        {
            return _categoryDataServices.GetAllCategories();
        }
    }
}
