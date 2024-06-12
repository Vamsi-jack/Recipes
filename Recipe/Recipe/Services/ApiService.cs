using Newtonsoft.Json;
using Recipe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Services
{
    public class ApiService
    {
        private static readonly HttpClient client = new HttpClient();

        public async Task<CategoryList> GetCategoriesAsync()
        {
            var response = await client.GetStringAsync("https://www.themealdb.com/api/json/v1/1/categories.php");
            return JsonConvert.DeserializeObject<CategoryList>(response);
        }

        public async Task<MealList> GetMealsByCategoryAsync(string category)
        {
            var response = await client.GetStringAsync($"https://www.themealdb.com/api/json/v1/1/filter.php?c={category}");
            return JsonConvert.DeserializeObject<MealList>(response);
        }

        public async Task<MealDetailList> GetMealDetailAsync(string id)
        {
            var response = await client.GetStringAsync($"https://www.themealdb.com/api/json/v1/1/lookup.php?i={id}");
            return JsonConvert.DeserializeObject<MealDetailList>(response);
        }
    }
}
