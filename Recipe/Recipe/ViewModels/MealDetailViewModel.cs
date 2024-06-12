using Recipe.Models;
using Recipe.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.ViewModels
{
    public class MealDetailViewModel : BindableObject
    {
        private readonly ApiService _apiService = new ApiService();
        private MealDetail _mealDetail;

        public MealDetail MealDetail
        {
            get => _mealDetail;
            set
            {
                _mealDetail = value;
                OnPropertyChanged();
            }
        }

        public async Task LoadMealDetailAsync(string id)
        {
            var mealDetailList = await _apiService.GetMealDetailAsync(id);
            MealDetail = mealDetailList.meals[0];
        }
    }
}

