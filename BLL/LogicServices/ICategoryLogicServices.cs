using BOL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.LogicServices
{
    public interface ICategoryLogicServices
    {
        List<Category> GetAllCategories();
    }
}
