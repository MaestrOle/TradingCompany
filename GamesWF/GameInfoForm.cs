using BusinessLogic.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GamesWF
{
    public partial class GameInfoForm : Form
    {
        private IGamesManager _manager;
        private readonly GamesDTO game;
        public GameInfoForm()
        {
            InitializeComponent();
            game = _manager.ShowGameInfo(GamesForm.gameID);
            listBox1.Items.Add(game);

        }
        private void Button1_Click(object sender, EventArgs e)
        {
            BasketDTO newelem = new BasketDTO();
            {
                newelem.Title = game.Title;
                newelem.Price = game.Price;
            }
            _manager.AddToBasket(newelem);
            GenresForm genresForm = new GenresForm();
            genresForm.Show();
            Close();
        }

    }
}
        