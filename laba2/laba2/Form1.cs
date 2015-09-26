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

            CreateEtalon(etalon1, etalon1_panel);
            CreateEtalon(etalon2, etalon2_panel);
            CreateEtalon(etalon3, etalon3_panel);

        }
        private void CreateEtalon(Button[,] etalon, Panel panel)
        {
            int X = panel.Location.X;
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                    CreateEtalonButton(panel.Name + i * j, X + 30 * i, 15 + 30 * j, (Empty_or_Cell()) ? "#" : "", etalon[i, j], panel);
        }
        private void CreateEtalonButton(string name, int x, int y, string text, Button button, Panel panel)
        {
            button = new Button();
            button.Location = new Point(x, y);
            button.Name = name;
            button.Size = new Size(25, 25);
            button.Text = text;
            button.Click += new EventHandler(Etalon_UserPicture_Click);
            panel.Controls.Add(button);
        }
        private bool Empty_or_Cell()    //if true - cell
        {
            Random rnd = new Random();
            int res = rnd.Next(100);
            return (res > 50) ? true : false;
        }

        private void Etalon_UserPicture_Click(object sender, EventArgs e)
        {
            if (((Button)sender).Text == "#")
                ((Button)sender).Text = "";
            else
                ((Button)sender).Text = "#";
        }
        
    }
}
