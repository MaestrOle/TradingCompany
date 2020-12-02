using BusinessLogic.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GamesWF
{
    public partial class GenresForm : Form
    {
        IGamesManager _manager;
        ILoginManager _loginManager;
        public static int genreID;
        public GenresForm()
        {
            InitializeComponent();
            List<GenresDTO> genres;
            {
                genres = _manager.GetAllGenres();
            }
            for(int i = 0; i<genres.Count; i++)
            {
                listBox1.Items.Add(genres[i]);
            }
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            genreID = listBox1.SelectedIndex + 1;
            GamesForm gamesForm = new GamesForm();
            gamesForm.Show();
            Close();
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm(_loginManager);
            loginForm.Show();
            Close();
        }
    }
}
