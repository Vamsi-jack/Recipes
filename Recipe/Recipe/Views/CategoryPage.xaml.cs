using Recipe.Models;
using Recipe.ViewModels;

namespace Recipe.Views;

public partial class CategoryPage : ContentPage
{
	public CategoryPage()
	{
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var viewModel = BindingContext as CategoryViewModel;
        await viewModel.LoadCategoriesAsync();
    }

    private  async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        var category = (Category)e.Parameter;
        if (category == null)
            return;

        await Navigation.PushAsync(new MealPage(category.strCategory));
    }

 
}