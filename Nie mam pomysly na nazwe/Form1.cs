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
    public partial class RPG_Kapek : Form
    {
        bool GoingLeft, GoingRight, GoingUp, GoingDown;
        int MovingSpeed = 4;
        int EnemySpeed = 1;
        bool EnemyCooldown;
        int AdventurerHealthPoints = 5;

        private async void timer1_Tick(object sender, EventArgs e)
        {
            if (Enemy.Bounds.IntersectsWith(HitboxForEnemy.Bounds))
            {
                Enemy.Cursor = Cursors.Cross;
            }
            else Enemy.Cursor = Cursors.No;
            if (Enemy.Bounds.IntersectsWith(Adventurer.Bounds))
            {
                if (!EnemyCooldown)
                {
                    AdventurerHealthPoints--;
                    LifeBar.Value = AdventurerHealthPoints;
                    EnemyCooldown = true;
                    Enemy.Image = Properties.Resources.Klepsydra;
                    await Task.Delay(3000);
                    EnemyCooldown = false;
                    Enemy.Image = null;
                }
            }
            AdventurerMovement();
            EnemyMovement();
        }

        private void EnemyMovement()
        {
            if (Adventurer.Top > Enemy.Top)
            {
                Enemy.Top += EnemySpeed;
            }
            if (Adventurer.Top < Enemy.Top)
            {
                Enemy.Top -= EnemySpeed;
            }
            if (Adventurer.Left > Enemy.Left)
            {
                Enemy.Left += EnemySpeed;
            }
            if (Adventurer.Left < Enemy.Left)
            {
                Enemy.Left -= EnemySpeed;
            }
        }

        private void AdventurerMovement()
        {
            if (GoingLeft)
            {
                Adventurer.Left -= MovingSpeed;
                HitboxForEnemy.Left -= MovingSpeed;
                LifeBar.Left -= MovingSpeed;
            }
            if (GoingRight)
            {
                Adventurer.Left += MovingSpeed;
                HitboxForEnemy.Left += MovingSpeed;
                LifeBar.Left += MovingSpeed;
            }
            if (GoingUp)
            {
                Adventurer.Top -= MovingSpeed;
                HitboxForEnemy.Top -= MovingSpeed;
                LifeBar.Top -= MovingSpeed;
            }
            if (GoingDown)
            {
                Adventurer.Top += MovingSpeed;
                HitboxForEnemy.Top += MovingSpeed;
                LifeBar.Top += MovingSpeed;
            }
        }

        private async void Enemy_MouseClick(object sender, MouseEventArgs e)
        {
            if (Enemy.Cursor == Cursors.Cross)
            {
                if (Adventurer.Top > Enemy.Top && Adventurer.Left > Enemy.Left)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        await Task.Delay(2);
                        Enemy.Top -= 4;
                    }
                }
                if (Adventurer.Top < Enemy.Top)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        await Task.Delay(2);
                        Enemy.Top += 4;
                    }
                }
                if (Adventurer.Left > Enemy.Left)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        await Task.Delay(2);
                        Enemy.Left -= 4;
                    }
                }
                if (Adventurer.Left < Enemy.Left)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        await Task.Delay(2);
                        Enemy.Left += 4;
                    }
                }
            }
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
            LifeBar.ForeColor = Color.Red;
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
