using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Models
{
    public class Category
    {
        public string strCategory { get; set; }
        public string strCategoryThumb { get; set; }
        public string strCategoryDescription { get; set; }
    }

    public class CategoryList
    {
        public List<Category> categories { get; set; }
    }
}
