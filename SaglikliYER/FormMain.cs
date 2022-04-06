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
        public FormMain(int _userID)
        {
            InitializeComponent();
            userID = _userID;
            userService = new UserService();
        }

        private void btnDrinkWater_Click(object sender, EventArgs e)
        {
            FormSuEkleme suEkleme = new FormSuEkleme(userID);
            suEkleme.ShowDialog();
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
            FormMeal meal = new FormMeal(userID);
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
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            button13.Enabled = false;
            button14.Enabled = false;
            button15.Enabled = false;
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
            FormSettings formSettings = new FormSettings(userID);
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

            if (count != 0 && count % 300 == 0)
            {
                dUser.Level += 1;
                userService.userUpdateForLevel(userID, dUser);
                MessageBox.Show("Level Up !! Your level = " + dUser.Level);
            }
        }
    }
}
