using Recipe.Common;
using Recipe.ViewModels;

namespace Recipe.Views;

public partial class MealDetailPage : ContentPage
{

    private string _mealId;

    public MealDetailPage(string mealId, string mealTitle)
    {
        InitializeComponent();
        _mealId = mealId;
        var navigationHeader = this.FindByName<NavigationHeader>("navigationHeader");
        if (navigationHeader != null)
        {
            navigationHeader.TitleText = mealTitle;
        }

    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var viewModel = BindingContext as MealDetailViewModel;
        await viewModel.LoadMealDetailAsync(_mealId);
    }

}