using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace GeoDash
{
    public partial class Form1 : Form
    {
        bool gameOver = false;
        bool isJumping = false;
        bool isTop = false;
        bool falling = false;
        bool suspy = false;
        int prev;
        private Control holdPlat;
        private Image flipImage;

        public Form1()
        {
            InitializeComponent();
            RestartGame();
        }

        private void KeyPressedFcn(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                foreach (Control x in this.Controls)
                {
                    if ((string)x.Tag == "ground")
                    {
                        if (x.Bounds.IntersectsWith(player.Bounds))
                        {
                            prev = player.Top;
                            player.Top -= 5;
                            isJumping = true;
                        }
                    }
                    else if ((string)x.Tag == "platty")
                    {
                        if (x.Bounds.IntersectsWith(player.Bounds))
                        {
                            prev = player.Top;
                            player.Top -= 5;
                            isJumping = true;
                        }
                    }
                }
            }
            if (e.KeyCode == Keys.Enter && gameOver == true)
            {
                RestartGame();
            }
        }

        private void GameTimerEvent(object sender, EventArgs e)
        {
            foreach (Control x in this.Controls)
            {
                if (x.Bounds.IntersectsWith(player.Bounds))
                {
                    if ((string)x.Tag == "platty" && x.Top + 2 < player.Bottom && x.Left >= player.Left)
                    {
                        gameOver = true;
                        GameTimer.Stop();
                        player.Hide();
                    }
                    if ((string)x.Tag == "spikey")
                    {
                        gameOver = true;
                        GameTimer.Stop();
                        player.Hide();
                    }
                }
            }

            if (suspy)
            {
                if (!holdPlat.Bounds.IntersectsWith(player.Bounds))
                {
                    falling = true;
                    suspy = false;
                }
            }

            if (isJumping == false)
            {
                if (Math.Abs((prev - player.Top) - 122) <= 5)
                {
                    isTop = true;
                    falling = true;
                }
                else
                {
                    isTop = false;
                }

                if (falling)
                {
                    for (int i = 0; i < 17; i++)
                    {
                        player.Top += 1;
                        foreach (Control x in this.Controls)
                        {
                            if (x.Bounds.IntersectsWith(player.Bounds))
                            {
                                if ((string)x.Tag == "ground")
                                {
                                    falling = false;
                                    break;
                                }
                                else if ((string)x.Tag == "platty")
                                {
                                    falling = false;
                                    holdPlat = x;
                                    suspy = true;
                                    break;
                                }
                            }
                        }
                        if (falling == false)
                        {
                            break;
                        }
                    }
                }
            }
            if (Math.Abs(prev - player.Top) < 109 && isJumping == true)
            {
                player.Top -= 17;
            }
            else
            {
                isJumping = false;
            }

            foreach (Control x in this.Controls)
            {
                if (!gameOver)
                {
                    if ((string)x.Tag == "platty" || (string)x.Tag == "spikey")
                    {
                        if (x.Left < player.Left - 69)
                        {
                            x.Dispose();
                        }
                        else
                        {
                            x.Left -= 12;
                        }
                    }
                }
            }
        }

        private void RestartGame()
        {
            EmptyMap();
            gameOver = false;
            GameTimer.Start();
            player.Show();
            player.Location = new Point(163, 365);
            player.Size = new Size(51, 51);
            prev = player.Top;
            CreateMap(this);
        }

        private void EmptyMap()
        {
            int i = this.Controls.Count - 1;
            while (this.Controls.Count > 2)
            {
                if ((string)this.Controls[i].Tag != "player" && (string)this.Controls[i].Tag != "ground")
                {
                    this.Controls[i].Dispose();
                    i--;
                }
            }
        }

        private void CreateMap(Form form)
        {
            int[] sp = new int[200];
            int[] spv = new int[200];
            int[] pl = new int[200];
            int[] plv = new int[200];

            for (int i = 0; i < 200; i++)
            {
                sp[i] = 0;
                spv[i] = 0;
                pl[i] = 0;
                plv[i] = 0;
            }

            sp[9] = 1;
            sp[12] = 1;
            sp[16] = 1;
            sp[20] = 1;
            sp[24] = 1;
            sp[28] = 1;
            pl[5] = 1;
            pl[11] = 1;
            plv[11] = 7;
            pl[17] = 1;
            plv[17] = 14;
            pl[23] = 1;
            plv[23] = 7;
            pl[22] = 1;
            plv[22] = 22;
            sp[22] = 1;
            spv[22] = 27;
            pl[32] = 1;
            sp[36] = 1;
            pl[47] = 1;
            pl[49] = 1;
            pl[51] = 1;
            sp[54] = 1;
            pl[56] = 1;
            plv[56] = 7;
            pl[58] = 1;
            plv[58] = 7;
            pl[60] = 1;
            plv[60] = 7;
            sp[64] = 1;
            sp[66] = 1;
            pl[67] = 1;
            plv[67] = 15;
            pl[69] = 1;
            plv[69] = 15;
            pl[74] = 1;
            plv[74] = 5;
            pl[76] = 1;
            pl[78] = 1;
            sp[81] = 1;
            sp[83] = 1;
            pl[86] = 1;
            sp[89] = 1;
            sp[91] = 1;
            pl[102] = 1;
            pl[104] = 1;
            pl[106] = 1;
            plv[106] = 5;
            pl[108] = 1;
            pl[110] = 1;
            pl[112] = 1;
            pl[114] = 1;
            sp[114] = 1;
            spv[114] = 5;

            for (int i = 122; i <= 192; i += 3)
            {
                sp[i] = 1;
            }

            pl[117] = 1;
            pl[124] = 1;
            pl[130] = 1;
            pl[136] = 1;
            pl[142] = 1;
            pl[148] = 1;
            pl[152] = 1;
            pl[158] = 1;
            pl[165] = 1;
            pl[172] = 1;
            pl[178] = 1;
            pl[184] = 1;

            plv[124] = 5;
            plv[130] = 10;
            plv[136] = 15;
            plv[142] = 20;
            plv[148] = 25;
            plv[152] = 20;
            plv[158] = 10;
            plv[165] = 15;
            plv[172] = 20;
            plv[178] = 10;
            plv[184] = 15;

            for (int i = 0; i < 200; i++)
            {
                if (pl[i] == 1)
                {
                    PictureBox plat = new PictureBox();
                    plat.Image = Properties.Resources.plat;
                    plat.Tag = "platty";
                    plat.Size = new Size(51, 51);
                    plat.Location = new Point(1000 + (i * 25), 369 - plv[i] * 10);
                    plat.SizeMode = PictureBoxSizeMode.StretchImage;
                    plat.Parent = form;
                    form.Controls.Add(plat);
                }
                if (sp[i] == 1)
                {
                    PictureBox spike = new PictureBox();
                    spike.Image = Properties.Resources.spike;
                    spike.Tag = "spikey";
                    spike.Size = new Size(46, 47);
                    spike.Location = new Point(1000 + (i * 25), 369 - spv[i] * 10);
                    spike.SizeMode = PictureBoxSizeMode.StretchImage;
                    spike.Parent = form;
                    form.Controls.Add(spike);
                }
            }
        }

        private void RotateTimerEvent(object sender, EventArgs e)
        {
            if (isTop)
            {
                flipImage = player.Image;
                flipImage.RotateFlip(RotateFlipType.Rotate90FlipNone);
                player.Image = flipImage;
            }
        }
    }
}
