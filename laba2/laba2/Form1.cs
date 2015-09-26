using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace laba2
{
    public partial class Form1 : Form
    {
        Button[,] etalon1;
        Button[,] etalon2;
        Button[,] etalon3;
        Button[,] user_picture;

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            etalon1 = new Button[5, 5];
            etalon2 = new Button[5, 5];
            etalon3 = new Button[5, 5];
            user_picture = new Button[5, 5];

            CreatePictures(etalon1, etalon2, etalon3, user_picture);

        }
        //general functions
        private void CreatePictures(Button[,] etalon1, Button[,] etalon2, Button[,] etalon3, Button[,] userpicture)
        {
            //etalon1
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                    CreatePictureButton(picture_panel.Name + i * j, picture_panel.Location.X + 30 * i, 15 + 30 * j, (Empty_or_Cell()) ? "#" : "", etalon1[i, j]);
            //etalon2
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                    CreatePictureButton(picture_panel.Name + i * j, picture_panel.Location.X + 180 + 30 * i, 15 + 30 * j, (Empty_or_Cell()) ? "#" : "", etalon2[i, j]);
            //etalon3
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                    CreatePictureButton(picture_panel.Name + i * j, picture_panel.Location.X + 360 + 30 * i, 15 + 30 * j, (Empty_or_Cell()) ? "#" : "", etalon3[i, j]);
            //userpicture
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                    CreatePictureButton(picture_panel.Name + i * j, picture_panel.Location.X + 580 + 30 * i, 15 + 30 * j, "", user_picture[i, j]);
        }
        private void CreatePictureButton(string name, int x, int y, string text, Button button)
        {
            button = new Button();
            button.Location = new Point(x, y);
            button.Name = name;
            button.Size = new Size(25, 25);
            button.Text = text;
            button.Click += new EventHandler(Etalon_UserPicture_Click);
            picture_panel.Controls.Add(button);
        }
        //additional functions
        private bool Empty_or_Cell()    //if true - cell
        {
            Random rnd = new Random();
            int res = rnd.Next(100);
            return (res > 50) ? true : false;
        }
        //events
        private void Etalon_UserPicture_Click(object sender, EventArgs e)
        {
            if (((Button)sender).Text == "#")
                ((Button)sender).Text = "";
            else
                ((Button)sender).Text = "#";
        }
        
    }
}
