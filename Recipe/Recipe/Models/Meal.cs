using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Models
{
    public class Meal
    {
        public string idMeal { get; set; }
        public string strMeal { get; set; }
        public string strMealThumb { get; set; }
    }

    public class MealList
    {
        public List<Meal> meals { get; set; }
    }
}
