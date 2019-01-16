using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
namespace Gra
{
    public partial class Form1 : Form
    {
        // start the variables 
        int x = PortDataReceived.x;
        int y = PortDataReceived.y;
        bool gora;
        bool dol;
        bool lewo;
        bool prawo;
        int predk = 7;

        int wynik = 0;
        // end of listing variables 
        public Form1()
        {
            InitializeComponent();
            label2.Visible = false;
        }
        

        private void Ster( int x, int y)
        {
           
            if (x > 2000)
            {
                lewo = true;
            }
            else if (x < -2000)
            {
                prawo = true;
            }
            if (y > 2000)
            {
                gora = true;
            }
            else if (y < -2000)
            {
                dol = true;
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = "Wynik: " + wynik; // show the score on the board 
            //player movement codes start 
            if (lewo)
            {
                Kulka.Left -= predk;
                //moving player to the left.  
            }
            if (prawo)
            {
                Kulka.Left += predk;
                //moving player to the right
            }
            if (gora)
            {
                Kulka.Top -= predk;
                //moving to the top 
            }
            if (dol)
            {
                Kulka.Top += predk;
                //moving down 
            }

            //for loop to check walls, ghosts and points 
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && x.Tag == "sciana")
                {
                    // checking if the player hits the wall or the ghost, then game is over 

                    if (((PictureBox)x).Bounds.IntersectsWith(Kulka.Bounds) && wynik == 0)
                    {
                        Kulka.Left = 0;
                        Kulka.Top = 25;
                        label2.Text = "Przegrales";
                        label2.Visible = true;
                        timer1.Stop();
                    }
                    else if (wynik == 1)
                    {
                        Kulka.Left = 0;
                        Kulka.Top = 25;
                        label2.Text = "Wygrales";
                        label2.Visible = true;
                        timer1.Stop();
                    }
                }
                if (x is PictureBox && x.Tag == "Wygr")
                {
                    //checking if the player hits the points picturebox then we can add to the score 
                    if (((PictureBox)x).Bounds.IntersectsWith(Kulka.Bounds))
                    {
                        this.Controls.Remove(x);
                        //remove that point 
                        wynik++;
                        // add to the score 
                    }
                }
            }
            // end of for loop checking walls, points and ghosts. 
        }

        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private PictureBox pictureBox4;
        private PictureBox pictureBox5;
        private PictureBox pictureBox6;
        private PictureBox pictureBox7;
        private PictureBox pictureBox8;
        private PictureBox pictureBox9;
        private PictureBox pictureBox10;
        private PictureBox Kulka;

    }
}