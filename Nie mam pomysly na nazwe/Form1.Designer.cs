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
            this.LifeBar = new System.Windows.Forms.ProgressBar();
            this.Adventurer = new System.Windows.Forms.PictureBox();
            this.HitboxForEnemy = new System.Windows.Forms.PictureBox();
            this.MovingAnimation = new System.Windows.Forms.Timer(this.components);
            this.Enemy = new System.Windows.Forms.PictureBox();
            this.restartBtn = new System.Windows.Forms.Button();
            this.gameOverLbl = new System.Windows.Forms.Label();
            this.countdownLbl = new System.Windows.Forms.Label();
            this.countdownTimer = new System.Windows.Forms.Timer(this.components);
            this.sniperRightToLeftCooldownPrgsbar = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.Adventurer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HitboxForEnemy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Enemy)).BeginInit();
            this.SuspendLayout();
            // 
            // LifeBar
            // 
            this.LifeBar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LifeBar.Location = new System.Drawing.Point(587, 278);
            this.LifeBar.Maximum = 5;
            this.LifeBar.Name = "LifeBar";
            this.LifeBar.Size = new System.Drawing.Size(72, 23);
            this.LifeBar.TabIndex = 0;
            this.LifeBar.Value = 5;
            // 
            // Adventurer
            // 
            this.Adventurer.BackColor = System.Drawing.Color.Gray;
            this.Adventurer.Location = new System.Drawing.Point(586, 307);
            this.Adventurer.Name = "Adventurer";
            this.Adventurer.Size = new System.Drawing.Size(74, 74);
            this.Adventurer.TabIndex = 1;
            this.Adventurer.TabStop = false;
            // 
            // HitboxForEnemy
            // 
            this.HitboxForEnemy.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.HitboxForEnemy.Cursor = System.Windows.Forms.Cursors.Cross;
            this.HitboxForEnemy.Location = new System.Drawing.Point(498, 219);
            this.HitboxForEnemy.Name = "HitboxForEnemy";
            this.HitboxForEnemy.Size = new System.Drawing.Size(250, 250);
            this.HitboxForEnemy.TabIndex = 2;
            this.HitboxForEnemy.TabStop = false;
            // 
            // MovingAnimation
            // 
            this.MovingAnimation.Interval = 5;
            this.MovingAnimation.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Enemy
            // 
            this.Enemy.BackColor = System.Drawing.Color.Lime;
            this.Enemy.Cursor = System.Windows.Forms.Cursors.No;
            this.Enemy.Location = new System.Drawing.Point(1178, 31);
            this.Enemy.Name = "Enemy";
            this.Enemy.Size = new System.Drawing.Size(74, 74);
            this.Enemy.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Enemy.TabIndex = 3;
            this.Enemy.TabStop = false;
            this.Enemy.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Enemy_MouseClick);
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
            this.countdownLbl.Location = new System.Drawing.Point(581, 97);
            this.countdownLbl.Name = "countdownLbl";
            this.countdownLbl.Size = new System.Drawing.Size(98, 108);
            this.countdownLbl.TabIndex = 6;
            this.countdownLbl.Text = "3";
            // 
            // countdownTimer
            // 
            this.countdownTimer.Enabled = true;
            this.countdownTimer.Interval = 1000;
            this.countdownTimer.Tick += new System.EventHandler(this.countdownTimer_Tick);
            // 
            // sniperRightToLeftCooldownPrgsbar
            // 
            this.sniperRightToLeftCooldownPrgsbar.ForeColor = System.Drawing.Color.Cyan;
            this.sniperRightToLeftCooldownPrgsbar.Location = new System.Drawing.Point(1072, 31);
            this.sniperRightToLeftCooldownPrgsbar.Name = "sniperRightToLeftCooldownPrgsbar";
            this.sniperRightToLeftCooldownPrgsbar.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.sniperRightToLeftCooldownPrgsbar.Size = new System.Drawing.Size(100, 23);
            this.sniperRightToLeftCooldownPrgsbar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.sniperRightToLeftCooldownPrgsbar.TabIndex = 7;
            this.sniperRightToLeftCooldownPrgsbar.Value = 30;
            // 
            // RPG_Kapek
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.sniperRightToLeftCooldownPrgsbar);
            this.Controls.Add(this.countdownLbl);
            this.Controls.Add(this.gameOverLbl);
            this.Controls.Add(this.restartBtn);
            this.Controls.Add(this.Enemy);
            this.Controls.Add(this.Adventurer);
            this.Controls.Add(this.LifeBar);
            this.Controls.Add(this.HitboxForEnemy);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.Name = "RPG_Kapek";
            this.Text = "Kapek\'s RPG";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RPG_Kapek_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RPG_Kapek_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.RPG_Kapek_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.Adventurer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HitboxForEnemy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Enemy)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar LifeBar;
        private System.Windows.Forms.PictureBox Adventurer;
        private System.Windows.Forms.PictureBox HitboxForEnemy;
        private System.Windows.Forms.Timer MovingAnimation;
        private System.Windows.Forms.PictureBox Enemy;
        private System.Windows.Forms.Button restartBtn;
        private System.Windows.Forms.Label gameOverLbl;
        private System.Windows.Forms.Label countdownLbl;
        private System.Windows.Forms.Timer countdownTimer;
        private System.Windows.Forms.ProgressBar sniperRightToLeftCooldownPrgsbar;
    }
}

