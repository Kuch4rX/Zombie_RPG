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
        int EnemySpeed = 3;
        bool EnemyCooldown;
        int AdventurerHealthPoints = 5;
        Random Random = new Random();
        List<Enemy> enemies = new List<Enemy>();



        private async void timer1_Tick(object sender, EventArgs e)
        {
            foreach (var item in enemies)
            {
                if (item.EnemyLook.Bounds.IntersectsWith(HitboxForEnemy.Bounds))
                {
                    item.EnemyLook.Cursor = Cursors.Cross;
                }
                else item.EnemyLook.Cursor = Cursors.No;
            }
            await AttackAdventurer();
            AdventurerMovement();
            EnemyMovement();

        }

        private async Task AttackAdventurer()
        {
            foreach (var item in enemies)
            {
                if (item.EnemyLook.Bounds.IntersectsWith(Adventurer.Bounds))
                {
                    if (!item.EnemyCooldown)
                    {
                        if (AdventurerHealthPoints == 0)
                        {
                            GAMEOVER();
                        }
                        item.EnemyCooldown = true;
                        await Task.Delay(100);
                        AdventurerHealthPoints--;
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

        private void GAMEOVER()
        {
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
            foreach (var item in enemies)
            {
                if (GoingLeft || GoingRight || GoingUp || GoingDown)
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
                /*else ();*/
            }
        }
        private Enemy GenerateEnemy() ///////////////////////////////////////////////////////////////////////
        {
            Enemy enemy = new Enemy(new Timer(), Random.Next(1, 3), GeneratePictureBox(), false, Random.Next(1, 6));
            return enemy;
        }

        private PictureBox GeneratePictureBox()
        {
            PictureBox EnemyPictureBox = new PictureBox();
            EnemyPictureBox.Size = new System.Drawing.Size(74, 74);
            EnemyPictureBox.BackColor = System.Drawing.Color.Lime;
            EnemyPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            EnemyPictureBox.Cursor = System.Windows.Forms.Cursors.No;
            int x = Random.Next(1, 3) == 1 ? Random.Next(-174, 0) : Random.Next(this.ClientSize.Width, this.ClientSize.Width + 100);
            int y = Random.Next(1, 3) == 1 ? Random.Next(-174, 0) : Random.Next(this.ClientSize.Height, this.ClientSize.Height + 100);
            EnemyPictureBox.Location = new System.Drawing.Point(x, y);
            EnemyPictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Enemy_MouseClick);
            this.Controls.Add(EnemyPictureBox);
            EnemyPictureBox.BringToFront();
            return EnemyPictureBox;
        }

        private async void Enemy_MouseClick(object sender, MouseEventArgs e) /////////////////////////////////////////////////////////////
        {
            
            PictureBox enemy = (PictureBox)sender;

            if (enemy.Cursor == Cursors.Cross && restartBtn.Enabled == false)
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
                await Task.Delay(500);
                Enemy item = FindEnemyItem(enemy);
                this.Controls.Remove(enemy);
                enemies.Remove(item);
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

        public RPG_Kapek()
        {
            InitializeComponent();
            for (int i = 0; i < 20; i++)
            {
                enemies.Add(GenerateEnemy());
            }
            LifeBar.ForeColor = Color.Red;
            restartBtn.Hide();
            restartBtn.Enabled = false;
            gameOverLbl.Hide();
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
