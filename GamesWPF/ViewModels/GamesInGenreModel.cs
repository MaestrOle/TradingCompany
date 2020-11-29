using DTO;
using BusinessLogic.Interfaces;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using System;

namespace GamesWPF.ViewModels
{
    public class GamesInGenreModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyname)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }

        private IGamesManager _games;
        private GenresListModel _ConcreteGenreID;
        private ObservableCollection<GamesDTO> _gameslist;
        private GamesDTO _SelectedGame;
        public ObservableCollection<GamesDTO> GamesInGenre
        {
            get { return _gameslist; }
            set
            {
                _gameslist = value;
                OnPropertyChanged(nameof(GamesInGenre));
            }
        }

        public GamesInGenreModel(IGamesManager manager)
        {
            _games = manager;
            Update();
        }
        public void Update()
        {

            var games = _games.GamesInGenre(_ConcreteGenreID.SelectedGenreID());
            GamesInGenre = new ObservableCollection<GamesDTO>();
        }
        public GamesDTO SelectedGame
        {
            get { return _SelectedGame; }
            set
            {
                _SelectedGame = value;
            }
        }
        public int SelectedGameID()
        {
            int gameID = _SelectedGame.GameID;
            return gameID;
        }
    }
}