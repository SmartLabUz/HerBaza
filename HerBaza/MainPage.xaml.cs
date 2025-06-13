using System.Diagnostics;
using System.Windows.Input;

namespace HerBaza
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {  
            InitializeComponent();
            
        }
        protected override void OnAppearing()
        {
            LoadFromDB();
        }

        async void Gotonext(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ItemCreatePage());
        }   
        async void LoadFromDB()
        {
            itemsList.ItemsSource = await App.Database.GetItemsAsync();
        }

        async void OnDeleteClicked(object sender, EventArgs e)
        {
            var button = sender as ImageButton;
            var item = button?.CommandParameter as Item;
            if (item != null)
            {
                bool confirm = await DisplayAlert("Tasdiqlang", $"{item.Name} o‘chirishga ishonchingiz komilmi?", "Ha", "Yo‘q");
                if (confirm)
                {
                    await App.Database.DeleteItemAsync(item);
                    await DisplayAlert("O‘chirildi", $"{item.Name} muvaffaqiyatli o‘chirildi", "OK");
                    LoadFromDB(); // Ro‘yxatni yangilash
                }
            }
        }
    }

}
