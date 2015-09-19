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
        System.Windows.Forms.Button[,] etalon1;
        System.Windows.Forms.Button[,] etalon2;
        System.Windows.Forms.Button[,] etalon3;
        System.Windows.Forms.Button[,] user_picture;

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            etalon1 = new Button[15, 15];
            etalon2 = new Button[15, 15];
            etalon3 = new Button[15, 15];
            user_picture = new Button[15, 15];

        }
        private void CreateEtalon(Button[] etalon, Panel panel)
        {
            int X = panel.Location.X;
            int Y = panel.Location.Y;
            
        }

        private void Etalon_UserPicture_Click(object sender, EventArgs e)
        {

        }
    }
}
