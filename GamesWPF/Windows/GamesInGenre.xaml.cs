using DTO;
using GamesWPF.ViewModels;
using GamesWPF.Windows;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System;
using Unity.Resolution;
using GamesWPF.Windows;

namespace GamesWPF
{
    /// <summary>
    /// Логика взаимодействия для GamesInGenre.xaml
    /// </summary>
    public partial class GamesInGenre : Window
    {
        GamesInGenreModel _gamesListViewModel;
        CollectionViewSource _gamesCollection;

        public GamesInGenre(GamesInGenreModel vm)
        {
            _gamesListViewModel = vm;
            DataContext = vm;
            InitializeComponent();

            _gamesCollection = (CollectionViewSource)(Resources["GamesCollection"]);
            _gamesCollection.Filter += _gamesCollection_Filter;
        }

        private void _gamesCollection_Filter(object sender, FilterEventArgs e)
        {
            var filter = txtFilter.Text;
            var game = e.Item as GamesDTO;
            if (game.Title.Contains(filter) || game.GenreID.ToString().Contains(filter) || game.DevCompany.Contains(filter) || game.RelizeDate.ToString().Contains(filter))
            {
                e.Accepted = true;
            }
            else
            {
                e.Accepted = false;
            }
        }

        private void txtFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            _gamesCollection.View.Refresh();
        }

        private void dgGames_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataGrid grid = sender as DataGrid;
            var item = (GamesDTO)grid.SelectedItem;
            var detailsViewModel = ((App)Application.Current).Container.Resolve<GamesInfoModel>(new ParameterOverride("game", item));
            var gameInfoWindow = new GameInfo(detailsViewModel);
            gameInfoWindow.ShowDialog();
        }
    }
}