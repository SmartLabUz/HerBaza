namespace HerBaza;

public partial class ItemCreatePage : ContentPage
{
	public ItemCreatePage()
	{
		InitializeComponent();
	}

    async void SaveAndBack(object sender, EventArgs b)
    {
       Item item = new Item(name:Name.Text,sureName:SureName.Text,phone:Phone.Text);
       await App.Database.SaveItemAsync(item);
       await DisplayAlert("Saqlandi", "Vazifa saqlandi!", "OK");
       await Navigation.PopAsync();
    }

}