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
        int MovingSpeed = 10;
        int AdventurerHealthPoints = 10;
        int sniperCooldown = 0;
        int sniperAmmo = 500;
        int trapsCount = 2;
        int redColor = 0;
        int greenColor = 255;
        string itemHolding = "knife";
        bool GameOver = false;
        Random Random = new Random();
        List<Enemy> enemies = new List<Enemy>();
        List<Trap> traps = new List<Trap>();
        Cursor knifeCursor = new Cursor(Properties.Resources.bowie_knife.Handle);

        public RPG_Kapek()
        {
            InitializeComponent();
            for (int i = 0; i < 10; i++) /////////////////////////////////////////////////////
            {
                enemies.Add(GenerateEnemy());
            }
            restartBtn.Hide();
            restartBtn.Enabled = false;
            gameOverLbl.Hide();
        }

        private async void timer1_Tick(object sender, EventArgs e)
        {
            CursorLook();
            AdventurerMovement();
            EnemyMovement();
            DidEnemyFallInTrap();
            try
            {
                await AttackAdventurer();
            }
            catch (Exception) { }
        }

        private void DidEnemyFallInTrap()
        {
          
            Trap trapDoUsuniecia = new Trap();
            foreach (var item in enemies)
            {
                foreach (var item2 in traps)
                {
                    if (item.EnemyLook.Bounds.IntersectsWith(item2.trapLook.Bounds))
                    {
                        if (!item.Stunned)
                        {
                            item.Stunned = true;
                            item.HP--;
                            item.EnemyLook.Image = Properties.Resources.Trap;
                            trapDoUsuniecia = item2;
                        }
                    }
                }
                if (trapDoUsuniecia != null)
                {
                    this.Controls.Remove(trapDoUsuniecia.trapLook);
                    traps.Remove(trapDoUsuniecia);
                    trapDoUsuniecia = null;
                }
            }

        }

        private void CursorLook()
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
                else if (itemHolding == "trap")
                {
                    item.EnemyLook.Cursor = Cursors.Cross;
                }
                else item.EnemyLook.Cursor = Cursors.No;
            }
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
                            greenColor -= 25;
                            redColor += 25;
                            if (AdventurerHealthPoints == 0)
                            {
                                GAMEOVER();
                            }
                            if (AdventurerHealthPoints >= 0)
                            {
                                LifeBar.Value = AdventurerHealthPoints;
                                LifeBar.ForeColor = Color.FromArgb(redColor, greenColor, 0);
                            }
                            item.EnemyLook.Image = Properties.Resources.Klepsydra;
                            Adventurer.BackColor = Color.Red;
                            await Task.Delay(200);
                            Adventurer.BackColor = Color.Transparent;
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
            int x = 0;
            foreach (var item in enemies)
            {
                item.EnemyLook.BackColor = Color.Transparent;
                if (!item.Stunned)
                {
                    if (!item.StunnedByWeapon)
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
                            item.EnemyLook.Image = Properties.Resources.MyZombieRight;
                        }
                        if (Adventurer.Left < item.EnemyLook.Left)
                        {
                            item.EnemyLook.Left -= item.Speed;
                            item.EnemyLook.Image = Properties.Resources.MyZombieLeft;
                        }
                        x = Adventurer.Left - item.EnemyLook.Left;
                        if (x < 215 && x > -215)
                        {
                            if (Adventurer.Top > item.EnemyLook.Top)
                            {
                                item.EnemyLook.Image = Properties.Resources.MyZombieDown;
                            }
                            if (Adventurer.Top < item.EnemyLook.Top)
                            {
                                item.EnemyLook.Image = Properties.Resources.MyZombieUp;
                            }
                        }
                    }
                }
            }
        }

        private Trap FindTrapItem(PictureBox trapItem)
        {
            foreach (var item2 in traps)
            {
                if (item2.trapLook == trapItem)
                {
                    return item2;
                }
            }
            return null;
        }

        private void AdventurerMovement()
        {
            if (GoingLeft || GoingRight || GoingUp || GoingDown)
            {
                if(sniperCooldown != 0 && itemHolding == "sniper")
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

                foreach (var item in traps)
                {
                    if (GoingLeft)
                    {
                        item.trapLook.Left += MovingSpeed;
                    }
                    if (GoingRight)
                    {
                        item.trapLook.Left -= MovingSpeed;
                    }
                    if (GoingUp)
                    {
                        item.trapLook.Top += MovingSpeed;
                    }
                    if (GoingDown)
                    {
                        item.trapLook.Top -= MovingSpeed;
                    }
                }
                if (GoingUp)
                {
                    Adventurer.Image = Properties.Resources.MyHoboUp;

                }
                if (GoingDown)
                {
                    Adventurer.Image = Properties.Resources.MyHoboDown;

                }
                if (GoingLeft)
                {
                    Adventurer.Image = Properties.Resources.MyHoboLeft;

                }
                if (GoingRight)
                {
                    Adventurer.Image = Properties.Resources.MyHoboRight;
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
            Enemy enemy = new Enemy(new Timer(), 2, GeneratePictureBox(), false, Random.Next(1, 6), false, false);
            return enemy;
        }

        private PictureBox GeneratePictureBox()
        {
            PictureBox EnemyPictureBox = new PictureBox();
            EnemyPictureBox.Size = new System.Drawing.Size(74, 74);
            EnemyPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            if (itemHolding == "trap")
            {

                EnemyPictureBox.Image = Properties.Resources.Trap;
                EnemyPictureBox.BackColor = System.Drawing.Color.Transparent;
                EnemyPictureBox.Location = new System.Drawing.Point(586, 307);
            }
            else
            {
                int x = 0;
                int y = 0;
                EnemyPictureBox.BackColor = System.Drawing.Color.Lime;
                EnemyPictureBox.Cursor = System.Windows.Forms.Cursors.No;
                int losowanie = Random.Next(1, 5);
                switch (losowanie)
                {
                    case 1:
                        x = Random.Next(-174, this.ClientSize.Width);       //góra
                        y = Random.Next(-174, -74);
                        break;
                    case 2:
                        x = Random.Next(0, this.ClientSize.Width + 174);    //dół
                        y = Random.Next(this.ClientSize.Height + 74, this.ClientSize.Height + 174);
                        break;
                    case 3:
                        x = Random.Next(-174, -74);                         //lewo
                        y = Random.Next(0, this.ClientSize.Height + 174);
                        break;
                    case 4:                                                 //prawo
                        x = Random.Next(this.ClientSize.Width, this.ClientSize.Width + 174);
                        y = Random.Next(-174, this.ClientSize.Height);
                        break;
                }

                EnemyPictureBox.Location = new System.Drawing.Point(x, y);
                EnemyPictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Enemy_MouseClick);
            }
            this.Controls.Add(EnemyPictureBox);
            EnemyPictureBox.BringToFront();
            return EnemyPictureBox;

        }

        private async void Enemy_MouseClick(object sender, MouseEventArgs e) /////////////////////////////////////////////////////////////
        {
            if (!GameOver)
            {
                PictureBox enemy = (PictureBox)sender;
                Enemy item = FindEnemyItem(enemy);
                if (enemy.Cursor == Cursors.Cross && restartBtn.Enabled == false && itemHolding == "knife")
                {
                    item1PictureBox.Image = Properties.Resources.Katana_Blood;
                    if (!item.Stunned)
                    {
                        item.StunnedByWeapon = true;
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
                        item.StunnedByWeapon = false;
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
                    int sniperHitChance = -1;
                    sniperAmmo--;
                    sniperAmmoLbl.Text = sniperAmmo.ToString();
                    if (sniperCooldown == 100)
                    {
                        didYouHitLbl.Visible = true;
                        didYouHitLbl.ForeColor = Color.Green;
                        didYouHitLbl.Text = "ENEMY HAS BEEN SHOT";
                        await SniperHit(enemy, item);
                        await Task.Delay(1500);
                        didYouHitLbl.Visible = false;
                    }
                    else
                    {
                        if (sniperCooldown > 75)
                        {
                            sniperHitChance = Random.Next(0, 2);
                        }
                        else if (sniperCooldown >= 50)
                        {
                            sniperHitChance = Random.Next(0, 3);
                        }
                        else if (sniperCooldown > 25)
                        {
                            sniperHitChance = Random.Next(0, 4);
                        }
                        if (sniperHitChance == 0)
                        {
                            didYouHitLbl.Visible = true;
                            didYouHitLbl.ForeColor = Color.Green;
                            didYouHitLbl.Text = "ENEMY HAS BEEN SHOT";
                            await SniperHit(enemy, item);
                            await Task.Delay(1500);
                            didYouHitLbl.Visible = false;
                        }
                        else
                        {
                            didYouHitLbl.Visible = true;
                            didYouHitLbl.ForeColor = Color.Red;
                            didYouHitLbl.Text = "YOU'VE MISSED";
                            await Task.Delay(1500);
                            didYouHitLbl.Visible = false;

                        }
                    }
                    sniperCooldown = 0;
                    sniperCooldownPrgsbar.Value = sniperCooldown;
                }

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

        private async Task SniperHit(PictureBox enemy, Enemy item)
        {
            item.EnemyLook.BackColor = Color.Red;
            if (!item.Stunned)
            {
                item.StunnedByWeapon = true;
                if (Adventurer.Top > enemy.Top)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        await Task.Delay(2);
                        enemy.Top -= 20;
                    }
                }
                if (Adventurer.Top < enemy.Top)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        await Task.Delay(2);
                        enemy.Top += 20;                         //Mordi spierdalaj
                    }
                }
                if (Adventurer.Left > enemy.Left)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        await Task.Delay(2);
                        enemy.Left -= 20;
                    }
                }
                if (Adventurer.Left < enemy.Left)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        await Task.Delay(2);
                        enemy.Left += 20;
                    }
                }
                item.StunnedByWeapon = true;
            }
            this.Controls.Remove(enemy);
            enemies.Remove(item);
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
                trapsAmountLbl.BackColor = Color.FromArgb(30, 30, 30);
                item1PictureBox.BackColor = Color.FromArgb(69, 69, 69);
                item2PictureBox.BackColor = Color.FromArgb(30, 30, 30);
                item3PictureBox.BackColor = Color.FromArgb(30, 30, 30);
                sniperCooldownPrgsbar.Visible = false;
            }
            if (e.KeyChar == (char)Keys.D2)
            {
                itemHolding = "sniper";
                sniperCooldown = 0;
                sniperCooldownPrgsbar.Visible = true;
                sniperAmmoLbl.BackColor = Color.FromArgb(69, 69, 69);
                trapsAmountLbl.BackColor = Color.FromArgb(30, 30, 30);
                item1PictureBox.BackColor = Color.FromArgb(30, 30, 30);
                item2PictureBox.BackColor = Color.FromArgb(69, 69, 69);
                item3PictureBox.BackColor = Color.FromArgb(30, 30, 30);
            }
            if (e.KeyChar == (char)Keys.D3)
            {
                itemHolding = "trap";
                sniperAmmoLbl.BackColor = Color.FromArgb(30, 30, 30);
                trapsAmountLbl.BackColor = Color.FromArgb(69, 69, 69);
                item1PictureBox.BackColor = Color.FromArgb(30, 30, 30);
                item2PictureBox.BackColor = Color.FromArgb(30, 30, 30);
                item3PictureBox.BackColor = Color.FromArgb(69, 69, 69);
                sniperCooldownPrgsbar.Visible = false;
            }
        }

        private void HitboxForEnemy_Click(object sender, EventArgs e)
        {
            if (itemHolding == "trap" && MovingAnimation.Enabled == true && trapsCount > 0)
            {
                trapsCount--;
                trapsAmountLbl.Text = trapsCount.ToString();
                Trap trap = new Trap(GeneratePictureBox(), false);
                traps.Add(trap);
            }
        }

        private void Spawning_Tick(object sender, EventArgs e)
        {
            int howManyNeed = 0;
            foreach (var item in enemies)
            {
                if (item.EnemyLook.Left < -200 || item.EnemyLook.Top < -200 || item.EnemyLook.Left > 1480 || item.EnemyLook.Top > 920)
                {
                    int x = 0;
                    int y = 0;
                    int losowanie = Random.Next(1, 5);
                    switch (losowanie)
                    {
                        case 1:
                            x = Random.Next(-274, this.ClientSize.Width);       //góra
                            y = Random.Next(-274, -174);
                            break;
                        case 2:
                            x = Random.Next(0, this.ClientSize.Width + 274);    //dół
                            y = Random.Next(this.ClientSize.Height + 174, this.ClientSize.Height + 274);
                            break;
                        case 3:
                            x = Random.Next(-274, -174);                         //lewo
                            y = Random.Next(0, this.ClientSize.Height + 274);
                            break;
                        case 4:                                                 //prawo
                            x = Random.Next(this.ClientSize.Width + 174, this.ClientSize.Width + 274);
                            y = Random.Next(-274, this.ClientSize.Height);
                            break;
                    }
                    item.EnemyLook.Left = x;
                    item.EnemyLook.Top = y;
                }
            }
            if (enemies.Count < 10)
            {
                howManyNeed = 10 - enemies.Count;
                for (int i = 0; i < howManyNeed; i++) ///////////////////////////////////////////////////////////////
                {
                    enemies.Add(GenerateEnemy());
                }
            }
        }

        private void RPG_Kapek_MouseClick(object sender, MouseEventArgs e)
        {
            if (itemHolding == "trap" && MovingAnimation.Enabled == true && trapsCount > 0)
            {
                trapsCount--;
                trapsAmountLbl.Text = trapsCount.ToString();
                Trap trap = new Trap(GeneratePictureBox(), false);
                traps.Add(trap);
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
            Spawning.Start();
            await Task.Delay(1000);
            countdownLbl.Hide();
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