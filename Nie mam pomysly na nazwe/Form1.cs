using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nie_mam_pomysly_na_nazwe
{
    public partial class RPG_Kapek : Form
    {
        bool GoingLeft, GoingRight, GoingUp, GoingDown;
        int MovingSpeed = 5;
        int AdventurerHealthPoints = 10;
        int sniperCooldown = 0;
        int sniperAmmo = 6;
        string itemHolding = "knife";
        bool GameOver = false;
        Random Random = new Random();
        List<Enemy> enemies = new List<Enemy>();
        Cursor knifeCursor = new Cursor(Properties.Resources.bowie_knife.Handle);

        public RPG_Kapek()
        {
            InitializeComponent();
            for (int i = 0; i < 10; i++) ///////////////////////////////////////////////////////////////
            {
                enemies.Add(GenerateEnemy());
            }
            LifeBar.ForeColor = Color.Red;
            restartBtn.Hide();
            restartBtn.Enabled = false;
            gameOverLbl.Hide();
        }

        private async void timer1_Tick(object sender, EventArgs e)
        {
            foreach (var item in enemies)
            {
                if (item.EnemyLook.Bounds.IntersectsWith(HitboxForEnemy.Bounds) && itemHolding == "knife")
                {
                    item.EnemyLook.Cursor = Cursors.Cross;
                }
                else if (itemHolding == "sniper")
                {
                    item.EnemyLook.Cursor = Cursors.Cross;
                }
                else item.EnemyLook.Cursor = Cursors.No;
            }
            AdventurerMovement();
            EnemyMovement();
            try
            {
                await AttackAdventurer();
            }
            catch (Exception) { }
        }

        private async Task AttackAdventurer()
        {
            foreach (var item in enemies)
            {
                if (item.EnemyLook.Bounds.IntersectsWith(Adventurer.Bounds))
                {
                    if (!item.EnemyCooldown)
                    {

                        item.EnemyCooldown = true;
                        await Task.Delay(100);
                        if (!GameOver)
                        {
                            AdventurerHealthPoints--;
                            if (AdventurerHealthPoints == 0)
                            {
                                GAMEOVER();
                            }
                            if (AdventurerHealthPoints >= 0)
                            {
                                LifeBar.Value = AdventurerHealthPoints;
                            }
                            item.EnemyLook.Image = Properties.Resources.Klepsydra;
                            Adventurer.BackColor = Color.Red;
                            await Task.Delay(200);
                            Adventurer.BackColor = Color.Gray;
                            await Task.Delay(900);
                            item.EnemyCooldown = false;
                            item.EnemyLook.Image = null;

                        }
                    }
                }
            }
        }

        private void GAMEOVER()
        {
            GameOver = true;
            MovingAnimation.Stop();
            restartBtn.Enabled = true;
            restartBtn.Show();
            gameOverLbl.Show();
        }

        private void EnemyMovement()
        {
            foreach (var item in enemies)
            {
                if (Adventurer.Top > item.EnemyLook.Top)
                {
                    item.EnemyLook.Top += item.Speed;
                }
                if (Adventurer.Top < item.EnemyLook.Top)
                {
                    item.EnemyLook.Top -= item.Speed;
                }
                if (Adventurer.Left > item.EnemyLook.Left)
                {
                    item.EnemyLook.Left += item.Speed;
                }
                if (Adventurer.Left < item.EnemyLook.Left)
                {
                    item.EnemyLook.Left -= item.Speed;
                }
            }

        }

        private void AdventurerMovement()
        {
            if (GoingLeft || GoingRight || GoingUp || GoingDown)
            {
                if (sniperCooldown != 0 && itemHolding == "sniper")
                {
                    sniperCooldown -= 2;
                }
                foreach (var item in enemies)
                {
                    if (GoingLeft)
                    {
                        item.EnemyLook.Left += MovingSpeed;
                    }
                    if (GoingRight)
                    {
                        item.EnemyLook.Left -= MovingSpeed;
                    }
                    if (GoingUp)
                    {
                        item.EnemyLook.Top += MovingSpeed;
                    }
                    if (GoingDown)
                    {
                        item.EnemyLook.Top -= MovingSpeed;
                    }
                }

            }
            else if (sniperCooldown != 100 && itemHolding == "sniper")
            {
                sniperCooldown += 2;

            }
            sniperCooldownPrgsbar.Value = sniperCooldown;
        }
        private Enemy GenerateEnemy() ///////////////////////////////////////////////////////////////////////
        {
            Enemy enemy = new Enemy(new Timer(), 2, GeneratePictureBox(), false, Random.Next(1, 6));
            return enemy;
        }

        private PictureBox GeneratePictureBox()
        {
            PictureBox EnemyPictureBox = new PictureBox();
            EnemyPictureBox.Size = new System.Drawing.Size(74, 74);
            EnemyPictureBox.BackColor = System.Drawing.Color.Lime;
            EnemyPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            EnemyPictureBox.Cursor = System.Windows.Forms.Cursors.No;
            int x = 0;
            int y = 0;
            int losowanie = Random.Next(1, 5);
            switch (losowanie)
            {
                case 1:
                    x = Random.Next(-174, this.ClientSize.Width); //poziomo u góry
                    y = Random.Next(-174, -74);
                    break;
                case 2:
                    x = Random.Next(0, this.ClientSize.Width + 174); //dół
                    y = Random.Next(this.ClientSize.Height + 74, this.ClientSize.Height + 174);
                    break;
                case 3:
                    x = Random.Next(-174, -74);//lewo
                    y = Random.Next(0, this.ClientSize.Height + 174);
                    break;
                case 4:                                                 //pionowo
                    x = Random.Next(this.ClientSize.Width, this.ClientSize.Width + 174);
                    y = Random.Next(-174, this.ClientSize.Height);
                    break;
            }

            EnemyPictureBox.Location = new System.Drawing.Point(x, y);
            EnemyPictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Enemy_MouseClick);
            this.Controls.Add(EnemyPictureBox);
            EnemyPictureBox.BringToFront();
            return EnemyPictureBox;
        }

        private async void Enemy_MouseClick(object sender, MouseEventArgs e) /////////////////////////////////////////////////////////////
        {

            PictureBox enemy = (PictureBox)sender;
            Enemy item = FindEnemyItem(enemy);
            if (enemy.Cursor == Cursors.Cross && restartBtn.Enabled == false && itemHolding == "knife")
            {
                if (Adventurer.Top > enemy.Top)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        await Task.Delay(2);
                        enemy.Top -= 4;
                    }
                }
                if (Adventurer.Top < enemy.Top)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        await Task.Delay(2);
                        enemy.Top += 4;                         //Mordi spierdalaj
                    }
                }
                if (Adventurer.Left > enemy.Left)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        await Task.Delay(2);
                        enemy.Left -= 4;
                    }
                }
                if (Adventurer.Left < enemy.Left)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        await Task.Delay(2);
                        enemy.Left += 4;
                    }
                }
                
                if (item != null)
                {
                    item.HP--;
                    if (item.HP == 1)
                    {
                        item.EnemyLook.BackColor = Color.Yellow;
                    }
                    if (item.HP == 0)
                    {
                        this.Controls.Remove(enemy);
                        enemies.Remove(item);
                    }
                }
            }
            if (itemHolding == "sniper" && sniperAmmo > 0)
            {
                sniperAmmo--;
                sniperAmmoLbl.Text = sniperAmmo.ToString();
                if (Adventurer.Top > enemy.Top)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        await Task.Delay(2);
                        enemy.Top -= 15;
                    }
                }
                if (Adventurer.Top < enemy.Top)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        await Task.Delay(2);
                        enemy.Top += 15;                         //Mordi spierdalaj
                    }
                }
                if (Adventurer.Left > enemy.Left)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        await Task.Delay(2);
                        enemy.Left -= 15;
                    }
                }
                if (Adventurer.Left < enemy.Left)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        await Task.Delay(2);
                        enemy.Left += 15;
                    }
                }
                this.Controls.Remove(enemy);
                enemies.Remove(item);
            }
            else if (itemHolding == "sniper")
            {
                noAmmoLbl.Visible = true;
                await Task.Delay(300);
                noAmmoLbl.Visible = false;
                await Task.Delay(300);
                noAmmoLbl.Visible = true;
                await Task.Delay(300);
                noAmmoLbl.Visible = false;
                await Task.Delay(300);
                noAmmoLbl.Visible = true;
                await Task.Delay(300);
                noAmmoLbl.Visible = false;
            }
        }

        private Enemy FindEnemyItem(PictureBox enemy)
        {
            foreach (var item in enemies)
            {
                if (item.EnemyLook == enemy)
                {
                    return item;
                }
            }
            return null;
        }

        private void RPG_Kapek_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void restartBtn_Click(object sender, EventArgs e)
        {
            Form gameStartForm = new RPG_Kapek();
            gameStartForm.Show();
            this.Hide();
        }

        private void RPG_Kapek_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
            {
                GoingLeft = false;
            }
            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
            {
                GoingRight = false;
            }
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.W)
            {
                GoingUp = false;
            }
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.S)
            {
                GoingDown = false;
            }
        }

        private void RPG_Kapek_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.D1)
            {
                itemHolding = "knife";
                sniperAmmoLbl.BackColor = Color.FromArgb(30, 30, 30);
                item1PictureBox.BackColor = Color.FromArgb(69, 69, 69);
                item2PictureBox.BackColor = Color.FromArgb(30, 30, 30);
                sniperCooldownPrgsbar.Visible = false;
            }
            if (e.KeyChar == (char)Keys.D2)
            {
                itemHolding = "sniper";
                sniperCooldown = 0;
                sniperCooldownPrgsbar.Visible = true;
                sniperAmmoLbl.BackColor = Color.FromArgb(69, 69, 69);
                item1PictureBox.BackColor = Color.FromArgb(30, 30, 30);
                item2PictureBox.BackColor = Color.FromArgb(69, 69, 69);
            }
        }

        private async void countdownTimer_Tick(object sender, EventArgs e)
        {
            countdownTimer.Stop();
            countdownLbl.Text = "2";
            await Task.Delay(1000);
            countdownLbl.Text = "1";
            await Task.Delay(1000);
            countdownLbl.Text = "GO!";
            MovingAnimation.Start();
            await Task.Delay(1000);
            countdownLbl.Hide();
        }

        private Task countdown()
        {
            throw new NotImplementedException();
        }

        private async void RPG_Kapek_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
            {
                GoingLeft = true;
            }
            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
            {
                GoingRight = true;
            }
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.W)
            {
                GoingUp = true;
            }
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.S)
            {
                GoingDown = true;
            }
        }
    }
}
