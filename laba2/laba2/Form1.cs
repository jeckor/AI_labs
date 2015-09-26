using System;
using System.Drawing;
using System.Windows.Forms;

namespace laba2
{
    public partial class Form1 : Form
    {
        Button[,] etalon1 = new System.Windows.Forms.Button[5, 5];
        Button[,] etalon2 = new System.Windows.Forms.Button[5, 5];
        Button[,] etalon3 = new System.Windows.Forms.Button[5, 5];
        Button[,] etalon4 = new System.Windows.Forms.Button[5, 5];
        Button[,] etalon5 = new System.Windows.Forms.Button[5, 5];
        Button[,] user_picture = new System.Windows.Forms.Button[5, 5];
        double[,] weights;  //весовые коэффициенты 

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            weights = new double[5, 5];
            CreatePictures(etalon1, etalon2, etalon3, etalon4, etalon5, user_picture);
            Random rnd = new Random();
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                    weights[i, j] = rnd.NextDouble();
        }
        //general functions
        private void CreatePictures(System.Windows.Forms.Button[,] etalon1, System.Windows.Forms.Button[,] etalon2, System.Windows.Forms.Button[,] etalon3, System.Windows.Forms.Button[,] etalon4, System.Windows.Forms.Button[,] etalon5, System.Windows.Forms.Button[,] userpicture)
        {
            //etalon1
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                    etalon1[i, j]=CreatePicturesButton(picture_panel.Name + i * j, picture_panel.Location.X + 30 * i, 15 + 30 * j, (Empty_or_Cell()) ? "#" : "_");
            //etalon2
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++) 
                     etalon2[i, j]=CreatePicturesButton(picture_panel.Name + i * j, picture_panel.Location.X + 180 + 30 * i, 15 + 30 * j, (Empty_or_Cell()) ? "#" : "_");
            //etalon3
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                     etalon3[i, j]=CreatePicturesButton(picture_panel.Name + i * j, picture_panel.Location.X + 360 + 30 * i, 15 + 30 * j, (Empty_or_Cell()) ? "#" : "_");
            //etalon4
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                    etalon4[i, j] = CreatePicturesButton(picture_panel.Name + i * j, picture_panel.Location.X + 540 + 30 * i, 15 + 30 * j, (Empty_or_Cell()) ? "#" : "_");
            //etalon5
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                    etalon5[i, j] = CreatePicturesButton(picture_panel.Name + i * j, picture_panel.Location.X + 720 + 30 * i, 15 + 30 * j, (Empty_or_Cell()) ? "#" : "_");
            //userpicture
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                     user_picture[i, j]=CreatePicturesButton(picture_panel.Name + i * j, picture_panel.Location.X + 940 + 30 * i, 15 + 30 * j, "_");
        }
        private System.Windows.Forms.Button CreatePicturesButton(string name, int x, int y, string text)
        {
            System.Windows.Forms.Button button = new System.Windows.Forms.Button();
            button.Location = new Point(x, y);
            button.Name = name;
            button.Size = new Size(25, 25);
            button.TabIndex = 0;
            button.Text = text;
            button.UseVisualStyleBackColor = true;
            button.Click += new EventHandler(Etalon_UserPicture_Click);
            picture_panel.Controls.Add(button);
            return button;
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
                ((Button)sender).Text = "_";
            else
                ((Button)sender).Text = "#";
        }
        //methods of calculation distance
        private void Evklid_Click(object sender, EventArgs e)   //расстояние по Эвклиду
        {
            int sum1 = 0, sum2 = 0, sum3 = 0, sum4 = 0, sum5 = 0;
            //etalon1
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                {
                    byte etalon = 0, user = 0;
                    if (etalon1[i, j].Text == "#")
                        etalon = 1;
                    else
                        etalon = 0;
                    if (user_picture[i, j].Text == "#")
                        user = 1;
                    else
                        user = 0;
                    int temp_sum = etalon - user;
                    sum1 += (int)Math.Pow(temp_sum, 2);
                }
            evklid_label1.Text = "" + Math.Round(Math.Sqrt(sum1), 3);
            //etalon2
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                {
                    byte etalon = 0, user = 0;
                    if (etalon2[i, j].Text == "#")
                        etalon = 1;
                    else
                        etalon = 0;
                    if (user_picture[i, j].Text == "#")
                        user = 1;
                    else
                        user = 0;
                    int temp_sum = etalon - user;
                    sum2 += (int)Math.Pow(temp_sum, 2);
                }
            evklid_label2.Text = "" + Math.Round(Math.Sqrt(sum2), 3);
            //etalon3
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                {
                    byte etalon = 0, user = 0;
                    if (etalon3[i, j].Text == "#")
                        etalon = 1;
                    else
                        etalon = 0;
                    if (user_picture[i, j].Text == "#")
                        user = 1;
                    else
                        user = 0;
                    int temp_sum = etalon - user;
                    sum3 += (int)Math.Pow(temp_sum, 2);
                }
            evklid_label3.Text = "" + Math.Round(Math.Sqrt(sum3), 3);
            //etalon4
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                {
                    byte etalon = 0, user = 0;
                    if (etalon4[i, j].Text == "#")
                        etalon = 1;
                    else
                        etalon = 0;
                    if (user_picture[i, j].Text == "#")
                        user = 1;
                    else
                        user = 0;
                    int temp_sum = etalon - user;
                    sum4 += (int)Math.Pow(temp_sum, 2);
                }
            evklid_label4.Text = "" + Math.Round(Math.Sqrt(sum4), 3);
            //etalon5
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                {
                    byte etalon = 0, user = 0;
                    if (etalon5[i, j].Text == "#")
                        etalon = 1;
                    else
                        etalon = 0;
                    if (user_picture[i, j].Text == "#")
                        user = 1;
                    else
                        user = 0;
                    int temp_sum = etalon - user;
                    sum5 += (int)Math.Pow(temp_sum, 2);
                }
            evklid_label5.Text = "" + Math.Round(Math.Sqrt(sum5), 3);
        }
        private void Minskiy_Click(object sender, EventArgs e)
        {
            const int koeff = 5;
            int sum1 = 0, sum2 = 0, sum3 = 0;
            //etalon1
            for(int i = 0; i < 5; i++)
                for(int j = 0; j < 5; j++)
                {
                    byte etalon = 0, user = 0;
                    if (etalon1[i, j].Text == "#")
                        etalon = 1;
                    else
                        etalon = 0;
                    if (user_picture[i, j].Text == "#")
                        user = 1;
                    else
                        user = 0;
                    int temp_sum = etalon - user;
                    sum1 += (int)Math.Pow(temp_sum, koeff);
                }
            mynskyi_label1.Text = "" + Math.Round(Math.Sqrt(sum1), 3);
            //etalon2
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                {
                    byte etalon = 0, user = 0;
                    if (etalon2[i, j].Text == "#")
                        etalon = 1;
                    else
                        etalon = 0;
                    if (user_picture[i, j].Text == "#")
                        user = 1;
                    else
                        user = 0;
                    int temp_sum = etalon - user;
                    sum2 += (int)Math.Pow(temp_sum, koeff);
                }
            mynskyi_label2.Text = "" + Math.Round(Math.Sqrt(sum2), 3);
            //etalon3
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                {
                    byte etalon = 0, user = 0;
                    if (etalon3[i, j].Text == "#")
                        etalon = 1;
                    else
                        etalon = 0;
                    if (user_picture[i, j].Text == "#")
                        user = 1;
                    else
                        user = 0;
                    int temp_sum = etalon - user;
                    sum3 += (int)Math.Pow(temp_sum, koeff);
                }
            mynskyi_label3.Text = "" + Math.Round(Math.Sqrt(sum3), 3);
        }   //расстояние по Минскому
        private void SumModule_Click(object sender, EventArgs e)    //сумма моделуй разностей
        {
            int sum1 = 0, sum2 = 0, sum3 = 0;
            //etalon1
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                {
                    if (String.Compare(etalon1[i, j].Text, user_picture[i, j].Text) == 0)
                        sum1++;
                    else
                        continue;
                }
            summodule_label1.Text = "" + Math.Round(Math.Sqrt(sum1), 3);
            //etalon2
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                {
                    if (String.Compare(etalon2[i, j].Text, user_picture[i, j].Text) == 0)
                        sum2++;
                    else
                        continue;
                }
            summodule_label2.Text = "" + Math.Round(Math.Sqrt(sum2), 3);
            //etalon3
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                {
                    if (String.Compare(etalon3[i, j].Text, user_picture[i, j].Text) == 0)
                        sum3++;
                    else
                        continue;
                }
            summodule_label3.Text = "" + Math.Round(Math.Sqrt(sum3), 3);
        }
        private void Camberr_Click(object sender, EventArgs e)      //расстояние по Крамерру
        {
            double sum1 = 0, sum2 = 0, sum3 = 0;
            //etalon1
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                {
                    byte etalon = 0, user = 0;
                    if (etalon1[i, j].Text == "#")
                        etalon = 1;
                    else
                        etalon = 0;
                    if (user_picture[i, j].Text == "#")
                        user = 1;
                    else
                        user = 0;
                    double temp_sum = Math.Abs((etalon - user)) / 1;
                    sum1 += temp_sum;
                }
            camber_label1.Text = "" + Math.Round(Math.Sqrt(sum1), 3);
            //etalon2
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                {
                    byte etalon = 0, user = 0;
                    if (etalon2[i, j].Text == "#")
                        etalon = 1;
                    else
                        etalon = 0;
                    if (user_picture[i, j].Text == "#")
                        user = 1;
                    else
                        user = 0;
                    double temp_sum = Math.Abs((etalon - user)) / 1;
                    sum2 += temp_sum;
                }
            camber_label2.Text = "" + Math.Round(Math.Sqrt(sum2), 3);
            //etalon3
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                {
                    byte etalon = 0, user = 0;
                    if (etalon3[i, j].Text == "#")
                        etalon = 1;
                    else
                        etalon = 0;
                    if (user_picture[i, j].Text == "#")
                        user = 1;
                    else
                        user = 0;
                    double temp_sum = Math.Abs((etalon - user)) / 1;
                    sum3 += temp_sum;
                }
            camber_label3.Text = "" + Math.Round(Math.Sqrt(sum3), 3);
        }
        //methods of calculation distance with random weights
        private void WeightsEvklid_Click(object sender, EventArgs e)
        {
            double sum1 = 0, sum2 = 0, sum3 = 0;
            //etalon1
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                {
                    byte etalon = 0, user = 0;
                    if (etalon1[i, j].Text == "#")
                        etalon = 1;
                    else
                        etalon = 0;
                    if (user_picture[i, j].Text == "#")
                        user = 1;
                    else
                        user = 0;
                    int temp_sum = etalon - user;
                    sum1 += (int)Math.Pow(temp_sum, 2) * weights[i, j];
                }
            weightevklid_label1.Text = "" + Math.Round(Math.Sqrt(sum1), 3);
            //etalon2
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                {
                    byte etalon = 0, user = 0;
                    if (etalon2[i, j].Text == "#")
                        etalon = 1;
                    else
                        etalon = 0;
                    if (user_picture[i, j].Text == "#")
                        user = 1;
                    else
                        user = 0;
                    int temp_sum = etalon - user;
                    sum2 += (int)Math.Pow(temp_sum, 2) * weights[i, j];
                }
            weightevklid_label2.Text = "" + Math.Round(Math.Sqrt(sum2), 3);
            //etalon3
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                {
                    byte etalon = 0, user = 0;
                    if (etalon3[i, j].Text == "#")
                        etalon = 1;
                    else
                        etalon = 0;
                    if (user_picture[i, j].Text == "#")
                        user = 1;
                    else
                        user = 0;
                    int temp_sum = etalon - user;
                    sum3 += (int)Math.Pow(temp_sum, 2) * weights[i, j];
                }
            weightevklid_label3.Text = "" + Math.Round(Math.Sqrt(sum3), 3);
        }
        private void WeightMynskiy_Click(object sender, EventArgs e)
        {
            const int koeff = 5;
            double sum1 = 0, sum2 = 0, sum3 = 0;
            //etalon1
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                {
                    byte etalon = 0, user = 0;
                    if (etalon1[i, j].Text == "#")
                        etalon = 1;
                    else
                        etalon = 0;
                    if (user_picture[i, j].Text == "#")
                        user = 1;
                    else
                        user = 0;
                    int temp_sum = etalon - user;
                    sum1 += (int)Math.Pow(temp_sum, koeff) * weights[i,j];
                }
            weightsmunskiy_label1.Text = "" + Math.Round(Math.Sqrt(sum1), 3);
            //etalon2
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                {
                    byte etalon = 0, user = 0;
                    if (etalon2[i, j].Text == "#")
                        etalon = 1;
                    else
                        etalon = 0;
                    if (user_picture[i, j].Text == "#")
                        user = 1;
                    else
                        user = 0;
                    int temp_sum = etalon - user;
                    sum2 += (int)Math.Pow(temp_sum, koeff) * weights[i, j];
                }
            weightsmunskiy_label2.Text = "" + Math.Round(Math.Sqrt(sum2), 3);
            //etalon3
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                {
                    byte etalon = 0, user = 0;
                    if (etalon3[i, j].Text == "#")
                        etalon = 1;
                    else
                        etalon = 0;
                    if (user_picture[i, j].Text == "#")
                        user = 1;
                    else
                        user = 0;
                    int temp_sum = etalon - user;
                    sum3 += (int)Math.Pow(temp_sum, koeff) * weights[i, j];
                }
            weightsmunskiy_label3.Text = "" + Math.Round(Math.Sqrt(sum3), 3);
        }
        private void WeightsSumModule_Click(object sender, EventArgs e)
        {
            double sum1 = 0, sum2 = 0, sum3 = 0;
            //etalon1
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                {
                    if (String.Compare(etalon1[i, j].Text, user_picture[i, j].Text) == 0)
                        sum1 += 1 * weights[i, j];
                    else
                        continue;
                }
            weightssummodule_label1.Text = "" + Math.Round(Math.Sqrt(sum1), 3);
            //etalon2
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                {
                    if (String.Compare(etalon2[i, j].Text, user_picture[i, j].Text) == 0)
                        sum2 += 1 * weights[i, j];
                    else
                        continue;
                }
            weightssummodule_label2.Text = "" + Math.Round(Math.Sqrt(sum2), 3);
            //etalon3
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                {
                    if (String.Compare(etalon3[i, j].Text, user_picture[i, j].Text) == 0)
                        sum3 += 1 * weights[i, j];
                    else
                        continue;
                }
            weightssummodule_label3.Text = "" + Math.Round(Math.Sqrt(sum3), 3);
        }
    }
}
