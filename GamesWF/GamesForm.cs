using BusinessLogic.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GamesWF
{
    public partial class GamesForm : Form
    {
        private IGamesManager _manager;
        public static int gameID;
        public GamesForm()
        {
            InitializeComponent();
            List<GamesDTO> games;
            {
                games = _manager.GamesInGenre(GenresForm.genreID);
            }
            for (int i = 0; i < games.Count; i++)
            {
                listBox1.Items.Add(games[i]);
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            gameID = listBox1.SelectedIndex + 1;
            GameInfoForm gameInfo = new GameInfoForm();
            gameInfo.Show();
            Close();
        }
        
    }

}
