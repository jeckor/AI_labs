using System;
using System.Drawing;
using System.Windows.Forms;

namespace laba2
{
    public partial class Form1 : Form
    {
        Button[,] etalon1 = new Button[5, 5];
        Button[,] etalon2 = new Button[5, 5];
        Button[,] etalon3 = new Button[5, 5];
        Button[,] etalon4 = new Button[5, 5];
        Button[,] etalon5 = new Button[5, 5];
        Button[,] user_picture = new Button[5, 5];
        string more;

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            CreateBackgroundImage();
            CreatePictures(etalon1, etalon2, etalon3, etalon4, etalon5, user_picture);
            SetMore(ref more);
        }
        //general functions
        private void CreatePictures(Button[,] etalon1, Button[,] etalon2, Button[,] etalon3, Button[,] etalon4, Button[,] etalon5, System.Windows.Forms.Button[,] userpicture)
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
        private Button CreatePicturesButton(string name, int x, int y, string text)
        {
            Button button = new Button();
            button.Location = new Point(x, y);
            button.Name = name;
            button.Size = new Size(25, 25);
            button.TabIndex = 0;
            button.Text = text;
            button.ForeColor = Color.Black;
            button.UseVisualStyleBackColor = true;
            button.Click += new EventHandler(Etalon_UserPicture_Click);
            picture_panel.Controls.Add(button);
            return button;
        }
        private void SetMore(ref string more)
        {
            int count_cell = 0, count_empty = 0;
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                {
                    if (user_picture[i, j].Text == "#")
                        count_cell++;
                    else
                        count_empty++;
                }
            if (count_cell > count_empty)
                more = "#";
            else
                more = "_";
        }
        private void CreateBackgroundImage()
        {
            PictureBox background = new PictureBox();
            this.Controls.Add(background);
            background.Size = new Size(1500, 1500);
            background.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
            background.ImageLocation = "eye_4.jpg";
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
                    if (etalon1[i, j].Text == more)
                        etalon = 1;
                    else
                        etalon = 0;
                    if (user_picture[i, j].Text == more)
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
                    if (etalon2[i, j].Text == more)
                        etalon = 1;
                    else
                        etalon = 0;
                    if (user_picture[i, j].Text == more)
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
                    if (etalon3[i, j].Text == more)
                        etalon = 1;
                    else
                        etalon = 0;
                    if (user_picture[i, j].Text == more)
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
                    if (etalon4[i, j].Text == more)
                        etalon = 1;
                    else
                        etalon = 0;
                    if (user_picture[i, j].Text == more)
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
                    if (etalon5[i, j].Text == more)
                        etalon = 1;
                    else
                        etalon = 0;
                    if (user_picture[i, j].Text == more)
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
            const int koeff = 6;
            int sum1 = 0, sum2 = 0, sum3 = 0, sum4 = 0, sum5 = 0;
            //etalon1
            for(int i = 0; i < 5; i++)
                for(int j = 0; j < 5; j++)
                {
                    byte etalon = 0, user = 0;
                    if (etalon1[i, j].Text == more)
                        etalon = 1;
                    else
                        etalon = 0;
                    if (user_picture[i, j].Text == more)
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
                    if (etalon2[i, j].Text == more)
                        etalon = 1;
                    else
                        etalon = 0;
                    if (user_picture[i, j].Text == more)
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
                    if (etalon3[i, j].Text == more)
                        etalon = 1;
                    else
                        etalon = 0;
                    if (user_picture[i, j].Text == more)
                        user = 1;
                    else
                        user = 0;
                    int temp_sum = etalon - user;
                    sum3 += (int)Math.Pow(temp_sum, koeff);
                }
            mynskyi_label3.Text = "" + Math.Round(Math.Sqrt(sum3), 3);
            //etalon4
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                {
                    byte etalon = 0, user = 0;
                    if (etalon4[i, j].Text == more)
                        etalon = 1;
                    else
                        etalon = 0;
                    if (user_picture[i, j].Text == more)
                        user = 1;
                    else
                        user = 0;
                    int temp_sum = etalon - user;
                    sum4 += (int)Math.Pow(temp_sum, 2);
                }
            mynskyi_label4.Text = "" + Math.Round(Math.Sqrt(sum4), 3);
            //etalon5
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                {
                    byte etalon = 0, user = 0;
                    if (etalon5[i, j].Text == more)
                        etalon = 1;
                    else
                        etalon = 0;
                    if (user_picture[i, j].Text == more)
                        user = 1;
                    else
                        user = 0;
                    int temp_sum = etalon - user;
                    sum5 += (int)Math.Pow(temp_sum, 2);
                }
            mynskyi_label5.Text = "" + Math.Round(Math.Sqrt(sum5), 3);
        }   //расстояние по Минскому
        private void SumModule_Click(object sender, EventArgs e)    //сумма моделуй разностей
        {
            int sum1 = 0, sum2 = 0, sum3 = 0, sum4 = 0, sum5 = 0;
            //etalon1
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                {
                    byte etalon = 0, user = 0;
                    if (etalon1[i, j].Text == more)
                        etalon = 1;
                    else
                        etalon = 0;
                    if (user_picture[i, j].Text == more)
                        user = 1;
                    else
                        user = 0;
                    int temp_sum = etalon - user;
                    sum1 += Math.Abs(temp_sum);
                }
            summodule_label1.Text = "" + Math.Round(Math.Sqrt(sum1), 3);
            //etalon2
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                {
                    byte etalon = 0, user = 0;
                    if (etalon2[i, j].Text == more)
                        etalon = 1;
                    else
                        etalon = 0;
                    if (user_picture[i, j].Text == more)
                        user = 1;
                    else
                        user = 0;
                    int temp_sum = etalon - user;
                    sum2 += Math.Abs(temp_sum); 
                }
            summodule_label2.Text = "" + Math.Round(Math.Sqrt(sum2), 3);
            //etalon3
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                {
                    byte etalon = 0, user = 0;
                    if (etalon3[i, j].Text == more)
                        etalon = 1;
                    else
                        etalon = 0;
                    if (user_picture[i, j].Text == more)
                        user = 1;
                    else
                        user = 0;
                    int temp_sum = etalon - user;
                    sum3 += Math.Abs(temp_sum);
                }
            summodule_label3.Text = "" + Math.Round(Math.Sqrt(sum3), 3);
            //etalon4
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                {
                    byte etalon = 0, user = 0;
                    if (etalon4[i, j].Text == more)
                        etalon = 1;
                    else
                        etalon = 0;
                    if (user_picture[i, j].Text == more)
                        user = 1;
                    else
                        user = 0;
                    int temp_sum = etalon - user;
                    sum4 += Math.Abs(temp_sum);
                }
            summodule_label4.Text = "" + Math.Round(Math.Sqrt(sum4), 3);
            //etalon5
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                {
                    byte etalon = 0, user = 0;
                    if (etalon5[i, j].Text == more)
                        etalon = 1;
                    else
                        etalon = 0;
                    if (user_picture[i, j].Text == more)
                        user = 1;
                    else
                        user = 0;
                    int temp_sum = etalon - user;
                    sum5 += Math.Abs(temp_sum);
                }
            summodule_label5.Text = "" + Math.Round(Math.Sqrt(sum5), 3);
        }
        private void Camberr_Click(object sender, EventArgs e)      //расстояние по Крамерру
        {
            double sum1 = 0, sum2 = 0, sum3 = 0, sum4 = 0, sum5 = 0;
            //etalon1
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                {
                    byte etalon = 0, user = 0;
                    if (etalon1[i, j].Text == more)
                        etalon = 1;
                    else
                        etalon = 0;
                    if (user_picture[i, j].Text == more)
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
                    if (etalon2[i, j].Text == more)
                        etalon = 1;
                    else
                        etalon = 0;
                    if (user_picture[i, j].Text == more)
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
                    if (etalon3[i, j].Text == more)
                        etalon = 1;
                    else
                        etalon = 0;
                    if (user_picture[i, j].Text == more)
                        user = 1;
                    else
                        user = 0;
                    double temp_sum = Math.Abs((etalon - user)) / 1;
                    sum3 += temp_sum;
                }
            camber_label3.Text = "" + Math.Round(Math.Sqrt(sum3), 3);
            //etalon4
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                {
                    byte etalon = 0, user = 0;
                    if (etalon4[i, j].Text == more)
                        etalon = 1;
                    else
                        etalon = 0;
                    if (user_picture[i, j].Text == more)
                        user = 1;
                    else
                        user = 0;
                    double temp_sum = Math.Abs((etalon - user)) / 1;
                    sum4 += temp_sum;
                }
            camber_label4.Text = "" + Math.Round(Math.Sqrt(sum4), 3);
            //etalon5
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                {
                    byte etalon = 0, user = 0;
                    if (etalon5[i, j].Text == more)
                        etalon = 1;
                    else
                        etalon = 0;
                    if (user_picture[i, j].Text == more)
                        user = 1;
                    else
                        user = 0;
                    double temp_sum = Math.Abs((etalon - user)) / 1;
                    sum5 += temp_sum;
                }
            camber_label5.Text = "" + Math.Round(Math.Sqrt(sum5), 3);
        }
        //methods of calculation distance with weights
        private void WeightsEvklid_Click(object sender, EventArgs e)
        {
            double sum1 = 0, sum2 = 0, sum3 = 0, sum4 = 0, sum5 = 0;
            //etalon1
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                {
                    byte etalon = 0, user = 0;
                    if (etalon1[i, j].Text == more)
                        etalon = 1;
                    else
                        etalon = 0;
                    if (user_picture[i, j].Text == more)
                        user = 1;
                    else
                        user = 0;
                    int temp_sum = etalon - user;
                    if(temp_sum == 0)
                        sum1 += (int)Math.Pow(temp_sum, 2) * 0.1;
                    else
                        sum1 += (int)Math.Pow(temp_sum, 2) * 1.0;
                }
            weightevklid_label1.Text = "" + Math.Round(Math.Sqrt(sum1), 3);
            //etalon2
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                {
                    byte etalon = 0, user = 0;
                    if (etalon2[i, j].Text == more)
                        etalon = 1;
                    else
                        etalon = 0;
                    if (user_picture[i, j].Text == more)
                        user = 1;
                    else
                        user = 0;
                    int temp_sum = etalon - user;
                    if (temp_sum == 0)
                        sum2 += (int)Math.Pow(temp_sum, 2) * 0.1;
                    else
                        sum2 += (int)Math.Pow(temp_sum, 2) * 1.0;
                }
            weightevklid_label2.Text = "" + Math.Round(Math.Sqrt(sum2), 3);
            //etalon3
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                {
                    byte etalon = 0, user = 0;
                    if (etalon3[i, j].Text == more)
                        etalon = 1;
                    else
                        etalon = 0;
                    if (user_picture[i, j].Text == more)
                        user = 1;
                    else
                        user = 0;
                    int temp_sum = etalon - user;
                    if (temp_sum == 0)
                        sum3 += (int)Math.Pow(temp_sum, 2) * 0.1;
                    else
                        sum3 += (int)Math.Pow(temp_sum, 2) * 1.0;
                }
            weightevklid_label3.Text = "" + Math.Round(Math.Sqrt(sum3), 3);
            //etalon4
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                {
                    byte etalon = 0, user = 0;
                    if (etalon4[i, j].Text == more)
                        etalon = 1;
                    else
                        etalon = 0;
                    if (user_picture[i, j].Text == more)
                        user = 1;
                    else
                        user = 0;
                    int temp_sum = etalon - user;
                    if (temp_sum == 0)
                        sum4 += (int)Math.Pow(temp_sum, 2) * 0.1;
                    else
                        sum4 += (int)Math.Pow(temp_sum, 2) * 1.0;
                }
            weightevklid_label4.Text = "" + Math.Round(Math.Sqrt(sum4), 3);
            //etalon5
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                {
                    byte etalon = 0, user = 0;
                    if (etalon5[i, j].Text == more)
                        etalon = 1;
                    else
                        etalon = 0;
                    if (user_picture[i, j].Text == more)
                        user = 1;
                    else
                        user = 0;
                    int temp_sum = etalon - user;
                    if (temp_sum == 0)
                        sum5 += (int)Math.Pow(temp_sum, 2) * 0.1;
                    else
                        sum5 += (int)Math.Pow(temp_sum, 2) * 1.0;
                }
            weightevklid_label5.Text = "" + Math.Round(Math.Sqrt(sum5), 3);
        }
        private void WeightMynskiy_Click(object sender, EventArgs e)
        {
            const int koeff = 6;
            double sum1 = 0, sum2 = 0, sum3 = 0, sum4 = 0, sum5 = 0;
            //etalon1
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                {
                    byte etalon = 0, user = 0;
                    if (etalon1[i, j].Text == more)
                        etalon = 1;
                    else
                        etalon = 0;
                    if (user_picture[i, j].Text == more)
                        user = 1;
                    else
                        user = 0;
                    int temp_sum = etalon - user;
                    if(temp_sum == 0)
                        sum1 += (int)Math.Pow(temp_sum, koeff) * 0.1;
                    else
                        sum1 += (int)Math.Pow(temp_sum, koeff) * 1.0;
                }
            weightsmunskiy_label1.Text = "" + Math.Round(Math.Sqrt(sum1), 3);
            //etalon2
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                {
                    byte etalon = 0, user = 0;
                    if (etalon2[i, j].Text == more)
                        etalon = 1;
                    else
                        etalon = 0;
                    if (user_picture[i, j].Text == more)
                        user = 1;
                    else
                        user = 0;
                    int temp_sum = etalon - user;
                    if (temp_sum == 0)
                        sum2 += (int)Math.Pow(temp_sum, koeff) * 0.1;
                    else
                        sum2 += (int)Math.Pow(temp_sum, koeff) * 1.0;
                }
            weightsmunskiy_label2.Text = "" + Math.Round(Math.Sqrt(sum2), 3);
            //etalon3
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                {
                    byte etalon = 0, user = 0;
                    if (etalon3[i, j].Text == more)
                        etalon = 1;
                    else
                        etalon = 0;
                    if (user_picture[i, j].Text == more)
                        user = 1;
                    else
                        user = 0;
                    int temp_sum = etalon - user;
                    if (temp_sum == 0)
                        sum3 += (int)Math.Pow(temp_sum, koeff) * 0.1;
                    else
                        sum3 += (int)Math.Pow(temp_sum, koeff) * 1.0;
                }
            weightsmunskiy_label3.Text = "" + Math.Round(Math.Sqrt(sum3), 3);
            //etalon4
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                {
                    byte etalon = 0, user = 0;
                    if (etalon4[i, j].Text == more)
                        etalon = 1;
                    else
                        etalon = 0;
                    if (user_picture[i, j].Text == more)
                        user = 1;
                    else
                        user = 0;
                    int temp_sum = etalon - user;
                    if (temp_sum == 0)
                        sum4 += (int)Math.Pow(temp_sum, koeff) * 0.1;
                    else
                        sum4 += (int)Math.Pow(temp_sum, koeff) * 1.0;
                }
            weightsmunskiy_label4.Text = "" + Math.Round(Math.Sqrt(sum4), 3);
            //etalon5
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                {
                    byte etalon = 0, user = 0;
                    if (etalon5[i, j].Text == more)
                        etalon = 1;
                    else
                        etalon = 0;
                    if (user_picture[i, j].Text == more)
                        user = 1;
                    else
                        user = 0;
                    int temp_sum = etalon - user;
                    if (temp_sum == 0)
                        sum5 += (int)Math.Pow(temp_sum, koeff) * 0.1;
                    else
                        sum5 += (int)Math.Pow(temp_sum, koeff) * 1.0;
                }
            weightsmunskiy_label5.Text = "" + Math.Round(Math.Sqrt(sum5), 3);
        }
        private void WeightsSumModule_Click(object sender, EventArgs e)
        {
            double sum1 = 0, sum2 = 0, sum3 = 0, sum4 = 0, sum5 = 0;
            //etalon1
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                {
                    byte etalon = 0, user = 0;
                    if (etalon1[i, j].Text == more)
                        etalon = 1;
                    else
                        etalon = 0;
                    if (user_picture[i, j].Text == more)
                        user = 1;
                    else
                        user = 0;
                    int temp_sum = etalon - user;
                    if (temp_sum == 0)
                        sum1 += Math.Abs(temp_sum) * 0.1;
                    else
                        sum1 += Math.Abs(temp_sum) * 1.0;
                }
            weightssummodule_label1.Text = "" + Math.Round(Math.Sqrt(sum1), 3);
            //etalon2
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                {
                    byte etalon = 0, user = 0;
                    if (etalon2[i, j].Text == more)
                        etalon = 1;
                    else
                        etalon = 0;
                    if (user_picture[i, j].Text == more)
                        user = 1;
                    else
                        user = 0;
                    int temp_sum = etalon - user;
                    if (temp_sum == 0)
                        sum2 += Math.Abs(temp_sum) * 0.1;
                    else
                        sum2 += Math.Abs(temp_sum) * 1.0;
                }
            weightssummodule_label2.Text = "" + Math.Round(Math.Sqrt(sum2), 3);
            //etalon3
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                {
                    byte etalon = 0, user = 0;
                    if (etalon3[i, j].Text == more)
                        etalon = 1;
                    else
                        etalon = 0;
                    if (user_picture[i, j].Text == more)
                        user = 1;
                    else
                        user = 0;
                    int temp_sum = etalon - user;
                    if (temp_sum == 0)
                        sum3 += Math.Abs(temp_sum) * 0.1;
                    else
                        sum3 += Math.Abs(temp_sum) * 1.0;
                }
            weightssummodule_label3.Text = "" + Math.Round(Math.Sqrt(sum3), 3);
            //etalon4
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                {
                    byte etalon = 0, user = 0;
                    if (etalon4[i, j].Text == more)
                        etalon = 1;
                    else
                        etalon = 0;
                    if (user_picture[i, j].Text == more)
                        user = 1;
                    else
                        user = 0;
                    int temp_sum = etalon - user;
                    if (temp_sum == 0)
                        sum4 += Math.Abs(temp_sum) * 0.1;
                    else
                        sum4 += Math.Abs(temp_sum) * 1.0;
                }
            weightssummodule_label4.Text = "" + Math.Round(Math.Sqrt(sum4), 3);
            //etalon5
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                {
                    byte etalon = 0, user = 0;
                    if (etalon5[i, j].Text == more)
                        etalon = 1;
                    else
                        etalon = 0;
                    if (user_picture[i, j].Text == more)
                        user = 1;
                    else
                        user = 0;
                    int temp_sum = etalon - user;
                    if (temp_sum == 0)
                        sum5 += Math.Abs(temp_sum) * 0.1;
                    else
                        sum5 += Math.Abs(temp_sum) * 1.0;
                }
            weightssummodule_label5.Text = "" + Math.Round(Math.Sqrt(sum5), 3);
        }
    }
}
