using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL.Models
{
    public class Category
    {
        [DisplayName("Category ID")]
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public int DisplayOrder { get; set; }
    }
}
