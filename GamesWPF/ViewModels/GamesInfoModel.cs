using DTO;
using BusinessLogic.Interfaces;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace GamesWPF.ViewModels
{
    public class GamesInfoModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyname)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }

        private IGamesManager _game;
        private GamesInGenreModel _ConcreteGame;

        private GamesDTO _gameinfo;
        public GamesDTO GameInfo
        {
            get { return _gameinfo; }
            set
            {
                _gameinfo = value;
                OnPropertyChanged(nameof(GameInfo));
            }
        }

        public GamesInfoModel(IGamesManager manager)
        {
            _game = manager;
            Update();
        }
        public void Update()
        {
            var game = _game.ShowGameInfo(_ConcreteGame.SelectedGameID());

        }
    }
}
