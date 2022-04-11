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
        string langue;
        public FormMain(int _userID,string _langue)
        {
            InitializeComponent();
            userID = _userID;
            userService = new UserService();
            langue = _langue;
        }

        private void btnDrinkWater_Click(object sender, EventArgs e)
        {
            FormSuEkleme suEkleme = new FormSuEkleme(userID);
            suEkleme.Owner = this;
            this.Hide();
            suEkleme.Show();
        }

        private void btnAddFood_Click(object sender, EventArgs e)
        {
            DUser dUser = userService.GetUserByUserID(userID);

            if (dUser.Level >= 5)
            {
                FormUrunEkleme urunEkleme = new FormUrunEkleme();
                urunEkleme.Owner = this;
                this.Hide();
                urunEkleme.Show();
            }
            else MessageBox.Show("Your level is not enough for adding food. " +
                "You need to spend more time in the program to level up.");
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
            FormMeal meal = new FormMeal(userID,langue);
            meal.Owner = this;
            this.Hide();
            meal.Show();
        }

        private void btnChallange_Click(object sender, EventArgs e)
        {
            FormChallange challange = new FormChallange(userID);
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
            switch (langue)
            {
                  case "Eng":
                    //    label3.Text = "Tab to drink water !!";
                    //    label2.Text = "Tab to eat food !!";
                    //    label4.Text = "Tab to calculate calorie !!";
                    //    label8.Text = "Tab for reports !!";
                    //    label6.Text = "Tab to your challange !!";
                    //    label7.Text = "Tab to your meals !!";
                    groupBox2.Text = "What Do You Wish";
                    groupBox3.Text = "Calculate Cal.";
                    groupBox2.Text = "Your Reports";
                    groupBox1.Text = "Drink Water";
                    groupBox4.Text = "Add Food";
                    groupBox9.Text = "Your Meal";
                    groupBox7.Text = "Your Challenge";
                    groupBox10.Text = "Your Reports";
                    //button5.Enabled = false;
                    //button6.Enabled = false;
                    //button7.Enabled = false;
                    //button13.Enabled = false;
                    //button14.Enabled = false;
                    //button15.Enabled = false;
                    break;
                case "Tr":
                    //label3.Text = "Su içmek için basınız !!";
                    //label2.Text = "Yiyecek eklemek için basınız !!";
                    //label4.Text = "Kalori hesabı yapmak için !!";
                    //label8.Text = "Raporlar için basınız !!";
                    //label6.Text = "Challangelar için basınız !!";
                    //label7.Text = "Öğünlerin için basınız !!";
                    groupBox2.Text = "Ne Yapmak İstersin";
                    groupBox3.Text = "Kalori Hesabı";
                    groupBox2.Text = "Raporların";
                    groupBox1.Text = "Su içmek";
                    groupBox10.Text = "Raporların";
                    groupBox9.Text = "Öğünlerin";
                    groupBox7.Text = "Challenge";
                    groupBox4.Text = "Yiyecek Eklemek";
                    //button5.Enabled = false;
                    //button6.Enabled = false;
                    //button7.Enabled = false;
                    //button13.Enabled = false;
                    //button14.Enabled = false;
                    //button15.Enabled = false;
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
            FormSettings formSettings = new FormSettings(userID,langue);
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

            if (count != 0 && count % 20 == 0)
            {
                dUser.Level += 1;
                userService.userUpdateForLevel(userID, dUser);
                MessageBox.Show("Level Up !! Your level = " + dUser.Level);
            }
        }
        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Owner.Show();
            timer1.Stop();
        }

        private void groupBox9_MouseHover(object sender, EventArgs e)
        {
            FormInfo formInfo = new FormInfo();
            formInfo.ShowDialog();
        }
    }
}
