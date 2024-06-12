using Recipe.Services;
using Recipe.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Recipe.ViewModels
{
    public class CategoryViewModel : BindableObject
    {
        private readonly ApiService _apiService = new ApiService();
        private ObservableCollection<Category> _categories;

        public ObservableCollection<Category> Categories
        {
            get => _categories;
            set
            {
                _categories = value;
                OnPropertyChanged();
            }
        }


        public CategoryViewModel()
        {
           
        }

        public async Task LoadCategoriesAsync()
        {
            var categoryList = await _apiService.GetCategoriesAsync();
            Categories = new ObservableCollection<Category>(categoryList.categories);
        }

     
    }
}
