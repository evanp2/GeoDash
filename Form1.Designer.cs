namespace GeoDash
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            ground = new PictureBox();
            player = new PictureBox();
            GameTimer = new System.Windows.Forms.Timer(components);
            RotateTimer = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)ground).BeginInit();
            ((System.ComponentModel.ISupportInitialize)player).BeginInit();
            SuspendLayout();
            // 
            // ground
            // 
            ground.BackgroundImage = Properties.Resources.tile;
            ground.Location = new Point(1, 415);
            ground.Name = "ground";
            ground.Size = new Size(835, 34);
            ground.TabIndex = 0;
            ground.TabStop = false;
            ground.Tag = "ground";
            // 
            // player
            // 
            player.Image = Properties.Resources.player2;
            player.Location = new Point(163, 362);
            player.Name = "player";
            player.Size = new Size(52, 51);
            player.SizeMode = PictureBoxSizeMode.StretchImage;
            player.TabIndex = 1;
            player.TabStop = false;
            player.Tag = "player";
            // 
            // GameTimer
            // 
            GameTimer.Enabled = true;
            GameTimer.Interval = 20;
            GameTimer.Tick += GameTimerEvent;
            // 
            // RotateTimer
            // 
            RotateTimer.Enabled = true;
            RotateTimer.Interval = 20;
            RotateTimer.Tick += RotateTimerEvent;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.spaceBackground;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(player);
            Controls.Add(ground);
            DoubleBuffered = true;
            Name = "Form1";
            Text = "Form1";
            KeyDown += KeyPressedFcn;
            ((System.ComponentModel.ISupportInitialize)ground).EndInit();
            ((System.ComponentModel.ISupportInitialize)player).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox ground;
        private PictureBox player;
        private System.Windows.Forms.Timer GameTimer;
        private System.Windows.Forms.Timer RotateTimer;
    }
}
