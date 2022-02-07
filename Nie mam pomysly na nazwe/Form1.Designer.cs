using System.Windows.Forms;

namespace Nie_mam_pomysly_na_nazwe
{
    partial class RPG_Kapek
    {

        
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RPG_Kapek));
            this.LifeBar = new System.Windows.Forms.ProgressBar();
            this.MovingAnimation = new System.Windows.Forms.Timer(this.components);
            this.restartBtn = new System.Windows.Forms.Button();
            this.gameOverLbl = new System.Windows.Forms.Label();
            this.countdownLbl = new System.Windows.Forms.Label();
            this.countdownTimer = new System.Windows.Forms.Timer(this.components);
            this.sniperCooldownPrgsbar = new System.Windows.Forms.ProgressBar();
            this.item2PictureBox = new System.Windows.Forms.PictureBox();
            this.item1PictureBox = new System.Windows.Forms.PictureBox();
            this.Adventurer = new System.Windows.Forms.PictureBox();
            this.HitboxForEnemy = new System.Windows.Forms.PictureBox();
            this.sniperAmmoLbl = new System.Windows.Forms.Label();
            this.noAmmoLbl = new System.Windows.Forms.Label();
            this.didYouHitLbl = new System.Windows.Forms.Label();
            this.item3PictureBox = new System.Windows.Forms.PictureBox();
            this.trapsAmountLbl = new System.Windows.Forms.Label();
            this.Spawning = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.item2PictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.item1PictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Adventurer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HitboxForEnemy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.item3PictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // LifeBar
            // 
            this.LifeBar.ForeColor = System.Drawing.Color.Lime;
            this.LifeBar.Location = new System.Drawing.Point(552, 190);
            this.LifeBar.Maximum = 10;
            this.LifeBar.Name = "LifeBar";
            this.LifeBar.Size = new System.Drawing.Size(140, 23);
            this.LifeBar.TabIndex = 0;
            this.LifeBar.Value = 10;
            // 
            // MovingAnimation
            // 
            this.MovingAnimation.Interval = 5;
            this.MovingAnimation.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // restartBtn
            // 
            this.restartBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.restartBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.restartBtn.Location = new System.Drawing.Point(331, 475);
            this.restartBtn.Name = "restartBtn";
            this.restartBtn.Size = new System.Drawing.Size(587, 149);
            this.restartBtn.TabIndex = 4;
            this.restartBtn.Text = "RESTART?";
            this.restartBtn.UseVisualStyleBackColor = false;
            this.restartBtn.Click += new System.EventHandler(this.restartBtn_Click);
            // 
            // gameOverLbl
            // 
            this.gameOverLbl.AutoSize = true;
            this.gameOverLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gameOverLbl.Location = new System.Drawing.Point(47, 108);
            this.gameOverLbl.Name = "gameOverLbl";
            this.gameOverLbl.Size = new System.Drawing.Size(1169, 108);
            this.gameOverLbl.TabIndex = 5;
            this.gameOverLbl.Text = "GAME OVER. YOU DIED.";
            // 
            // countdownLbl
            // 
            this.countdownLbl.AutoSize = true;
            this.countdownLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.countdownLbl.Location = new System.Drawing.Point(578, 9);
            this.countdownLbl.Name = "countdownLbl";
            this.countdownLbl.Size = new System.Drawing.Size(98, 108);
            this.countdownLbl.TabIndex = 6;
            this.countdownLbl.Text = "3";
            this.countdownLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // countdownTimer
            // 
            this.countdownTimer.Enabled = true;
            this.countdownTimer.Interval = 1000;
            this.countdownTimer.Tick += new System.EventHandler(this.countdownTimer_Tick);
            // 
            // sniperCooldownPrgsbar
            // 
            this.sniperCooldownPrgsbar.ForeColor = System.Drawing.Color.Cyan;
            this.sniperCooldownPrgsbar.Location = new System.Drawing.Point(586, 387);
            this.sniperCooldownPrgsbar.Name = "sniperCooldownPrgsbar";
            this.sniperCooldownPrgsbar.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.sniperCooldownPrgsbar.Size = new System.Drawing.Size(74, 23);
            this.sniperCooldownPrgsbar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.sniperCooldownPrgsbar.TabIndex = 7;
            this.sniperCooldownPrgsbar.Visible = false;
            // 
            // item2PictureBox
            // 
            this.item2PictureBox.BackColor = System.Drawing.Color.Transparent;
            this.item2PictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.item2PictureBox.Cursor = System.Windows.Forms.Cursors.No;
            this.item2PictureBox.Image = global::Nie_mam_pomysly_na_nazwe.Properties.Resources.sniper;
            this.item2PictureBox.Location = new System.Drawing.Point(92, 12);
            this.item2PictureBox.Name = "item2PictureBox";
            this.item2PictureBox.Size = new System.Drawing.Size(74, 74);
            this.item2PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.item2PictureBox.TabIndex = 8;
            this.item2PictureBox.TabStop = false;
            // 
            // item1PictureBox
            // 
            this.item1PictureBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(69)))), ((int)(((byte)(69)))));
            this.item1PictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.item1PictureBox.Cursor = System.Windows.Forms.Cursors.No;
            this.item1PictureBox.Image = global::Nie_mam_pomysly_na_nazwe.Properties.Resources.Katana;
            this.item1PictureBox.Location = new System.Drawing.Point(12, 12);
            this.item1PictureBox.Name = "item1PictureBox";
            this.item1PictureBox.Size = new System.Drawing.Size(74, 74);
            this.item1PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.item1PictureBox.TabIndex = 3;
            this.item1PictureBox.TabStop = false;
            this.item1PictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Enemy_MouseClick);
            // 
            // Adventurer
            // 
            this.Adventurer.BackColor = System.Drawing.Color.Transparent;
            this.Adventurer.Image = global::Nie_mam_pomysly_na_nazwe.Properties.Resources.MyHoboDown;
            this.Adventurer.Location = new System.Drawing.Point(586, 307);
            this.Adventurer.Name = "Adventurer";
            this.Adventurer.Size = new System.Drawing.Size(74, 74);
            this.Adventurer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Adventurer.TabIndex = 1;
            this.Adventurer.TabStop = false;
            // 
            // HitboxForEnemy
            // 
            this.HitboxForEnemy.Cursor = System.Windows.Forms.Cursors.Cross;
            this.HitboxForEnemy.Location = new System.Drawing.Point(488, 209);
            this.HitboxForEnemy.Name = "HitboxForEnemy";
            this.HitboxForEnemy.Size = new System.Drawing.Size(270, 270);
            this.HitboxForEnemy.TabIndex = 2;
            this.HitboxForEnemy.TabStop = false;
            this.HitboxForEnemy.Click += new System.EventHandler(this.HitboxForEnemy_Click);
            // 
            // sniperAmmoLbl
            // 
            this.sniperAmmoLbl.BackColor = System.Drawing.Color.Transparent;
            this.sniperAmmoLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.sniperAmmoLbl.Location = new System.Drawing.Point(141, 61);
            this.sniperAmmoLbl.Name = "sniperAmmoLbl";
            this.sniperAmmoLbl.Size = new System.Drawing.Size(23, 23);
            this.sniperAmmoLbl.TabIndex = 9;
            this.sniperAmmoLbl.Text = "6";
            // 
            // noAmmoLbl
            // 
            this.noAmmoLbl.AutoSize = true;
            this.noAmmoLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.noAmmoLbl.ForeColor = System.Drawing.Color.Red;
            this.noAmmoLbl.Location = new System.Drawing.Point(572, 271);
            this.noAmmoLbl.Name = "noAmmoLbl";
            this.noAmmoLbl.Size = new System.Drawing.Size(104, 24);
            this.noAmmoLbl.TabIndex = 10;
            this.noAmmoLbl.Text = "NO AMMO";
            this.noAmmoLbl.Visible = false;
            // 
            // didYouHitLbl
            // 
            this.didYouHitLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.didYouHitLbl.ForeColor = System.Drawing.Color.Lime;
            this.didYouHitLbl.Location = new System.Drawing.Point(498, 71);
            this.didYouHitLbl.Name = "didYouHitLbl";
            this.didYouHitLbl.Size = new System.Drawing.Size(250, 46);
            this.didYouHitLbl.TabIndex = 11;
            this.didYouHitLbl.Text = "ENEMY HAS BEEN SHOT";
            this.didYouHitLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.didYouHitLbl.Visible = false;
            // 
            // item3PictureBox
            // 
            this.item3PictureBox.BackColor = System.Drawing.Color.Transparent;
            this.item3PictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.item3PictureBox.Cursor = System.Windows.Forms.Cursors.No;
            this.item3PictureBox.Image = global::Nie_mam_pomysly_na_nazwe.Properties.Resources.Trap;
            this.item3PictureBox.Location = new System.Drawing.Point(172, 12);
            this.item3PictureBox.Name = "item3PictureBox";
            this.item3PictureBox.Size = new System.Drawing.Size(74, 74);
            this.item3PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.item3PictureBox.TabIndex = 12;
            this.item3PictureBox.TabStop = false;
            // 
            // trapsAmountLbl
            // 
            this.trapsAmountLbl.BackColor = System.Drawing.Color.Transparent;
            this.trapsAmountLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.trapsAmountLbl.Location = new System.Drawing.Point(224, 61);
            this.trapsAmountLbl.Name = "trapsAmountLbl";
            this.trapsAmountLbl.Size = new System.Drawing.Size(20, 24);
            this.trapsAmountLbl.TabIndex = 13;
            this.trapsAmountLbl.Text = "2";
            // 
            // Spawning
            // 
            this.Spawning.Interval = 2500;
            this.Spawning.Tick += new System.EventHandler(this.Spawning_Tick);
            // 
            // RPG_Kapek
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.trapsAmountLbl);
            this.Controls.Add(this.item3PictureBox);
            this.Controls.Add(this.didYouHitLbl);
            this.Controls.Add(this.noAmmoLbl);
            this.Controls.Add(this.sniperAmmoLbl);
            this.Controls.Add(this.item2PictureBox);
            this.Controls.Add(this.sniperCooldownPrgsbar);
            this.Controls.Add(this.countdownLbl);
            this.Controls.Add(this.gameOverLbl);
            this.Controls.Add(this.restartBtn);
            this.Controls.Add(this.item1PictureBox);
            this.Controls.Add(this.Adventurer);
            this.Controls.Add(this.LifeBar);
            this.Controls.Add(this.HitboxForEnemy);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RPG_Kapek";
            this.Text = "Hobo Simulator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RPG_Kapek_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RPG_Kapek_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RPG_Kapek_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.RPG_Kapek_KeyUp);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.RPG_Kapek_MouseClick);
            ((System.ComponentModel.ISupportInitialize)(this.item2PictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.item1PictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Adventurer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HitboxForEnemy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.item3PictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar LifeBar;
        private System.Windows.Forms.PictureBox Adventurer;
        private System.Windows.Forms.PictureBox HitboxForEnemy;
        private System.Windows.Forms.Timer MovingAnimation;
        private System.Windows.Forms.PictureBox item1PictureBox;
        private System.Windows.Forms.Button restartBtn;
        private System.Windows.Forms.Label gameOverLbl;
        private System.Windows.Forms.Label countdownLbl;
        private System.Windows.Forms.Timer countdownTimer;
        private System.Windows.Forms.ProgressBar sniperCooldownPrgsbar;
        private System.Windows.Forms.PictureBox item2PictureBox;
        private Label sniperAmmoLbl;
        private Label noAmmoLbl;
        private Label didYouHitLbl;
        private PictureBox item3PictureBox;
        private Label trapsAmountLbl;
        private Timer Spawning;
    }
}

