using DTO;
using BusinessLogic.Interfaces;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace GamesWPF.ViewModels
{
    public class GenresListModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyname)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }

        private IGamesManager _genres;
        private GenresDTO _SelectedGenre;

        private ObservableCollection<GenresDTO> _genrelist;
        public ObservableCollection<GenresDTO> GenresList
        {
            get { return _genrelist; }
            set
            {
                _genrelist = value;
                OnPropertyChanged(nameof(GenresList));
            }
        }

        public GenresListModel(IGamesManager manager)
        {
            _genres = manager;
            Update();
        }
        public void Update()
        {
            var genres = _genres.GetAllGenres();
            GenresList = new ObservableCollection<GenresDTO>();
        }

        public GenresDTO SelectedGenre
        {
            get { return _SelectedGenre; }
            set
            {
                _SelectedGenre = value;
            }
        }
        public int SelectedGenreID()
        {
            int genreID = _SelectedGenre.GenreID;
            return genreID;
        }
    }
}
