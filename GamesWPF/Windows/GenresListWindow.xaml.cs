using GamesWPF.ViewModels;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using Unity;


namespace GamesWPF.Windows
{
    /// <summary>
    /// Логика взаимодействия для GenresListWindow.xaml
    /// </summary>
    public partial class GenresListWindow : Window
    {
        GenresListModel _genreListViewModel;
        CollectionViewSource _GenresList;
        public GenresListWindow(GenresListModel vm)
        {
            InitializeComponent();
            _genreListViewModel = vm;
            DataContext = vm;

            _GenresList = (CollectionViewSource)(Resources["GenresCollection"]);
        }
        private void DgGenres_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var gamesInGenre = ((App)Application.Current).Container.Resolve<GamesInGenre>();
            gamesInGenre.ShowDialog();
        }
        private void Logout_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }
    }
}
