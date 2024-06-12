namespace Recipe.Common;

public partial class NavigationHeader : ContentView
{
    public static readonly BindableProperty TitleTextProperty = BindableProperty.Create(nameof(TitleText), typeof(string), typeof(NavigationHeader), string.Empty);
  
    public string TitleText
    {
        get => (string)GetValue(TitleTextProperty);
        set => SetValue(TitleTextProperty, value);
    }

    
    public NavigationHeader()
	{
		InitializeComponent();
        BindingContext = this;
    }

    private  async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        if (Application.Current.MainPage.Navigation.NavigationStack.Count > 1)
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }

    }
}