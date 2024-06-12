using Recipe.Common;
using Recipe.Models;
using Recipe.ViewModels;

namespace Recipe.Views;

public partial class MealPage : ContentPage
{
    private string _category;

    public MealPage(string category)
    {
        InitializeComponent();
        _category = category;
        BindingContext = new MealViewModel(_category);
        var navigationHeader = this.FindByName<NavigationHeader>("navigationHeader");
        if (navigationHeader != null)
        {
            navigationHeader.TitleText = category;
        }
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var viewModel = BindingContext as MealViewModel;
        if (viewModel != null)
        {
            await viewModel.LoadMealsAsync(_category, 1); 
        }
    }

    private async void OnMealTapped(object sender, TappedEventArgs e)
    {
        var meal = e.Parameter as Meal;
        if (meal == null)
        {
            return;
        }


        var viewModel = BindingContext as MealViewModel;
        if (viewModel != null)
        {
            viewModel.IsLoading = true;
            await Navigation.PushAsync(new MealDetailPage(meal.idMeal, meal.strMeal));
            viewModel.IsLoading = false;
        }
    }
}