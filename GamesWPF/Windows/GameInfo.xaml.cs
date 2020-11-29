using GamesWPF.ViewModels;
using System.Windows;
using System.Windows.Controls;
using BusinessLogic.Concrete;
using DTO;

namespace GamesWPF.Windows
{
    /// <summary>
    /// Interaction logic for MovieDetails.xaml
    /// </summary>
    public partial class GameInfo : Window
    {
        GamesInfoModel _gameDetailsViewModel;
        ListViewItem _listView;
        GamesManager _basketmanager;
        public GameInfo(GamesInfoModel vm)
        {
            _gameDetailsViewModel = vm;
            DataContext = vm;

            InitializeComponent();
            _listView = (ListViewItem)(Resources["GameInfo"]);
        }
        private void btnAddToBasket_Click(object sender, RoutedEventArgs e)
        {
            BasketDTO newelem = new BasketDTO();
            {
                newelem.Title = _gameDetailsViewModel.GameInfo.Title;
                newelem.Price = _gameDetailsViewModel.GameInfo.Price;
            }
            _basketmanager.AddToBasket(newelem);
        }

    }
}