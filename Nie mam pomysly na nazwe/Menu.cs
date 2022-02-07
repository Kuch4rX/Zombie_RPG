using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nie_mam_pomysly_na_nazwe
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void startGameBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form gameStartForm = new RPG_Kapek();
            gameStartForm.Show();
        }

        private void Menu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void exitGameBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void howToPlayBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form gameStartForm = new HowToPlayMenu();
            gameStartForm.Show();
        }
    }
}
