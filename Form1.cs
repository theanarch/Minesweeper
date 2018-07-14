using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Drawing2D;

namespace MineSweeper
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

            FileStream fs = new System.IO.FileStream(@"images\eight.png", FileMode.Open, FileAccess.Read);
            pictureBox1.Image = Image.FromStream(fs);
            fs.Close();

            List<Button> buttons = new List<Button>();
            int row = 4;
            int col = 4;
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    Button button = new Button();
                    button.Size = new Size(25, 25);
                    button.Location = new Point(0 + (24*i), 0 + (24 * j));
                    button.Top = 200;

                    buttons.Add(button);

                    this.panel1.Controls.Add(button);
                }
            }




            //Point loc1 = new Point(0, 40);
            //Point loc2 = new Point(0, 0);

            //Button b1 = new Button();
            //Button b2 = new Button();

            //b1.Size = new Size(25, 25);
            //b2.Size = new Size(25, 25);

            //b1.Location = loc1;
            //b2.Location = loc2;

            //b1.Top = 150;
            //b1.TabIndex = 52;

            //b2.Top = 0;
            //b2.Left = 0;


            //Point loc2 = new Point(40,50);
            //Button button2 = new Button();
            //button2.Size = new Size(25, 25);
            //button2.Location = loc;
            //button2.Text = "M";

            //this.Controls.Add(button);




            RoundButton roundButton = new RoundButton();
            roundButton.Text = "jew";
            roundButton.Location = new Point(130, 130);

            button1.Size = new Size(25, 25);
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.Hide();

            circularProgressBar1.Maximum = 100;
            circularProgressBar1.Minimum = 0;
            circularProgressBar1.Value = 100;
            circularProgressBar1.AnimationSpeed = 10000; //How much time the player has left => SpeedSweeper!
        }

        public class RoundButton : Button
        {
            protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
            {
                GraphicsPath grPath = new GraphicsPath();
                grPath.AddEllipse(0, 0, ClientSize.Width, ClientSize.Height);
                this.Region = new System.Drawing.Region(grPath);
                base.OnPaint(e);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            button1.Hide();
            pictureBox1.Show();
            pictureBox1.Size = new Size(25, 25);

            for (int i = 100; i >= 0; i--)
            {
                //System.Threading.Thread.Sleep(100);
                circularProgressBar1.Value = i;
                circularProgressBar1.Update();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}