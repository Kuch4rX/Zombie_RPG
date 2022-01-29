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
            ((System.ComponentModel.ISupportInitialize)(this.item2PictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.item1PictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Adventurer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HitboxForEnemy)).BeginInit();
            this.SuspendLayout();
            // 
            // LifeBar
            // 
            this.LifeBar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LifeBar.Location = new System.Drawing.Point(567, 12);
            this.LifeBar.Maximum = 10;
            this.LifeBar.Name = "LifeBar";
            this.LifeBar.Size = new System.Drawing.Size(160, 23);
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
            // sniperCooldownPrgsbar
            // 
            this.sniperCooldownPrgsbar.ForeColor = System.Drawing.Color.Cyan;
            this.sniperCooldownPrgsbar.Location = new System.Drawing.Point(604, 82);
            this.sniperCooldownPrgsbar.Name = "sniperCooldownPrgsbar";
            this.sniperCooldownPrgsbar.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.sniperCooldownPrgsbar.Size = new System.Drawing.Size(75, 23);
            this.sniperCooldownPrgsbar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.sniperCooldownPrgsbar.TabIndex = 7;
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
            this.item1PictureBox.BackColor = System.Drawing.Color.Transparent;
            this.item1PictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.item1PictureBox.Cursor = System.Windows.Forms.Cursors.No;
            this.item1PictureBox.Image = global::Nie_mam_pomysly_na_nazwe.Properties.Resources.knife;
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
            // RPG_Kapek
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.item2PictureBox);
            this.Controls.Add(this.sniperCooldownPrgsbar);
            this.Controls.Add(this.countdownLbl);
            this.Controls.Add(this.gameOverLbl);
            this.Controls.Add(this.restartBtn);
            this.Controls.Add(this.item1PictureBox);
            this.Controls.Add(this.Adventurer);
            this.Controls.Add(this.LifeBar);
            this.Controls.Add(this.HitboxForEnemy);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.Name = "RPG_Kapek";
            this.Text = "Kapek\'s RPG";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RPG_Kapek_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RPG_Kapek_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RPG_Kapek_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.RPG_Kapek_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.item2PictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.item1PictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Adventurer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HitboxForEnemy)).EndInit();
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
    }
}

