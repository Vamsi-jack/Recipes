using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Models
{
    public class MealDetail
    {
        public string idMeal { get; set; }
        public string strMeal { get; set; }
        public string strInstructions { get; set; }
        public string strMealThumb { get; set; }
    }

    public class MealDetailList
    {
        public List<MealDetail> meals { get; set; }
    }
}
