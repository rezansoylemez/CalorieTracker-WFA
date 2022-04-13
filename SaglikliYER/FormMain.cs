using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YerNTier.BLL.Services;
using YerNTier.Model.Entities;

namespace SaglikliYER
{
    public partial class FormMain : Form
    {
        UserService userService;
        public FormMain()
        {
            InitializeComponent();
        }
        int userID;
        string language;
        public FormMain(int _userID, string _language)
        {
            InitializeComponent();
            userID = _userID;
            userService = new UserService();
            language = _language;
        }

        private void btnDrinkWater_Click(object sender, EventArgs e)
        {
            FormSuEkleme suEkleme = new FormSuEkleme(userID,language);
            suEkleme.Owner = this;
            this.Hide();
            suEkleme.Show();
        }

        private void btnAddFood_Click(object sender, EventArgs e)
        {
            DUser dUser = userService.GetUserByUserID(userID);

            if (dUser.Level >= 5)
            {
                FormUrunEkleme urunEkleme = new FormUrunEkleme(language);
                urunEkleme.Owner = this;
                this.Hide();
                urunEkleme.Show();
            }
            else
            {
               if (language == "Eng") MessageBox.Show("Your level is not enough for adding food. " +
                  "You need to spend more time in the program to level up.");
               else if(language=="Tr") MessageBox.Show("Seviyeniz yiyecek eklemek için yeterli değil. " +
                    "Seviye atlamak için programda daha fazla zaman harcamanız gerekiyor");
            }
        }

        private void btnCalculator_Click(object sender, EventArgs e)
        {
            FormKalHesaplama kalHesaplama = new FormKalHesaplama();
            kalHesaplama.Owner = this;
            this.Hide();
            kalHesaplama.Show();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            FormReports reports = new FormReports(userID);
            reports.Owner = this;
            this.Hide();
            reports.Show();
        }

        private void btnMeal_Click(object sender, EventArgs e)
        {
            FormMeal meal = new FormMeal(userID, language);
            meal.Owner = this;
            this.Hide();
            meal.Show();
        }

        private void btnChallange_Click(object sender, EventArgs e)
        {
            FormChallange challange = new FormChallange(userID,language);
            challange.Owner = this;
            this.Hide();
            challange.Show();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            timer1.Start();
            timer2.Start();
            timer4.Start();
            switch (language)
            {
                  case "Eng":
                    groupBox2.Text = "What Do You Wish";
                    groupBox3.Text = "Calculate Cal.";
                    groupBox2.Text = "Your Reports";
                    groupBox1.Text = "Drink Water";
                    groupBox4.Text = "Add Food";
                    groupBox9.Text = "Your Meal";
                    groupBox7.Text = "Your Challenge";
                    groupBox10.Text = "What Do You Want";
                    groupBox5.Text = "Cal. Calculate";
                    label5.Text = "To see the calorie and protein values ​​of your food";
                    grpChallenge.Text = "Challenge";
                    label3.Text = "To reach the Challenge screen";
                    groupBox6.Text = "Add Food";
                    label6.Text = "You can add food depending on the level.";
                    groupBox8.Text = "Drink Water";
                    label7.Text = "The screen with your water consumption information";
                    break;
                case "Tr":
                    groupBox2.Text = "Ne Yapmak İstersin";
                    groupBox3.Text = "Kalori Hesabı";
                    groupBox2.Text = "Raporların";
                    groupBox1.Text = "Su içmek";
                    groupBox10.Text = "Ne Yapmak İstersin";
                    groupBox9.Text = "Öğünlerin";
                    groupBox7.Text = "Challenge";
                    groupBox4.Text = "Yiyecek Eklemek";
                    groupBox5.Text = "Cal. Hesap";
                    label5.Text = "Yiyeceklerinizin kalori ve protein değerlerini görmek için";
                    grpChallenge.Text = "Challenge";
                    label3.Text = "Challenge ekranına ulaşmak için";
                    groupBox6.Text = "Yiyecek Ekle";
                    label6.Text = "Seviyeye bağlı olarak yiyecek ekleyebilirsin.";
                    groupBox8.Text = "Su İçmek";
                    label7.Text = "Su tüketim bilgilerinizin olduğu ekran";
                    break;
            }
        }

        private void btnNotif_Click(object sender, EventArgs e)
        {
            FormNotification notification = new FormNotification(userID);
            notification.Owner = this;
            this.Hide();
            notification.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormSettings formSettings = new FormSettings(userID, language);
            formSettings.Owner = this;
            this.Hide();
            formSettings.Show();
        }
        private void btnOyun_Click(object sender, EventArgs e)
        {
            FormTicTacToe formTicTacToe = new FormTicTacToe();
            formTicTacToe.Owner = this;
            this.Hide();
            formTicTacToe.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormFeedMonster formFeedMonster = new FormFeedMonster();
            formFeedMonster.Owner = this;
            this.Hide();
            formFeedMonster.Show();
        }
        int count = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            DUser dUser = userService.GetUserByUserID(userID);
            count++;
            if (count != 0 && count % 100 == 0 && denemeCount != 0 || denemeCount % 100 == 0 || denemeCount % 101 == 0 ||  denemeCount % 102 == 0 || denemeCount % 103 == 0 || denemeCount % 104 == 0 || denemeCount % 105 == 0)
            {
                dUser.Level += 1;
                userService.userUpdateForLevel(userID, dUser);
                label4.Visible = true;
                if (language == "Eng")
                {
                    label4.Visible = true;
                    label4.Text = "You Are Level Up. WellDone !!!" + dUser.Level;

                }
                else if (language == "Tr")
                {
                    label4.Visible = true;
                    label4.Text = "Seviye Atladın. Tebrikler !!!" + dUser.Level;
                }
            }
            else label4.Visible = false;
        }
        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Owner.Show();
            timer1.Stop();
            timer2.Stop();
            timer3.Stop();
        }
        int count2 = 0;
        private void timer2_Tick(object sender, EventArgs e)
        {
            count2++;
            if (count2==35) grpEatMeal.Visible = true;
            else if (count2 == 70)
            {
                grpEatMeal.Visible = false;
                grpYourReport.Visible = true;
            }
            else if (count2 == 105)
            {
                grpEatMeal.Visible = false;
                grpYourReport.Visible = false;
                grpChallenge.Visible = true;
            }
            else if (count2 == 140)
            {
                grpEatMeal.Visible = false;
                grpYourReport.Visible = false;
                grpChallenge.Visible = false;
            }
        }
        int time=0;
        private void timer3_Tick(object sender, EventArgs e)
        {
            time++;
        }

        private void button5_MouseDown(object sender, MouseEventArgs e)
        {
            groupBox5.Visible = true;
        }

        private void button5_MouseUp(object sender, MouseEventArgs e)
        {
            groupBox5.Visible = false;
        }

        private void button4_MouseUp(object sender, MouseEventArgs e)
        {
            groupBox6.Visible = false;
        }

        private void button4_MouseDown(object sender, MouseEventArgs e)
        {
            groupBox6.Visible = true;
        }

        private void button3_MouseUp(object sender, MouseEventArgs e)
        {
            groupBox8.Visible = false;
        }

        private void button3_MouseDown(object sender, MouseEventArgs e)
        {
            groupBox8.Visible = true;
        }
        int denemeCount=0;
        private void timer4_Tick(object sender, EventArgs e)
        {
            denemeCount++;
        }
    }
}
