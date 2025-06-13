namespace HerBaza
{
    public partial class App : Application
    {
        private static ItemDatabase _database;

        public static ItemDatabase Database
        {
            get
            {
                if (_database == null)
                {
                    string dbPath = Path.Combine(FileSystem.AppDataDirectory, "BAZA.db3");
                    _database = new ItemDatabase(dbPath);
                }
                return _database;
            }
        }

        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage( new AppShell());
        }
    }
}
