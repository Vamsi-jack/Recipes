using Recipe.Models;
using Recipe.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Recipe.ViewModels
{
    public class MealViewModel : INotifyPropertyChanged
    {
        private readonly ApiService _apiService = new ApiService();
        private ObservableCollection<Meal> _meals;
        private bool _isLoading;
        private int _pageNumber = 1;
        private const int PageSize = 15;
        private string _category;

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Meal> Meals
        {
            get => _meals;
            set
            {
                _meals = value;
                OnPropertyChanged();
            }
        }

        public bool IsLoading
        {
            get => _isLoading;
            set
            {
                _isLoading = value;
                OnPropertyChanged();
            }
        }

        public ICommand LoadMoreMealsCommand { get; }

        public MealViewModel(string category)
        {
            _category = category;
            Meals = new ObservableCollection<Meal>();
            LoadMoreMealsCommand = new Command(async () => await LoadMoreMealsAsync());
        }

        public async Task LoadMealsAsync(string category, int pageNumber)
        {
            try
            {
                IsLoading = true;
                var mealList = await _apiService.GetMealsByCategoryAsync(category);
                var pagedMeals = mealList.meals.Skip((pageNumber - 1) * PageSize).Take(PageSize).ToList();
                foreach (var meal in pagedMeals)
                {
                    Meals.Add(meal);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching meals: {ex.Message}");
            }
            finally
            {
                IsLoading = false;
            }
        }

        public async Task LoadMoreMealsAsync()
        {
            _pageNumber++;
            await LoadMealsAsync(_category, _pageNumber);
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}