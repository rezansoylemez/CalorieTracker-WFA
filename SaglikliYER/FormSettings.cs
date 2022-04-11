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
    public partial class FormSettings : Form
    {
        UserService userService;
        PasswordService passService;
        UserDatailsServece userDatailsServece;
        public FormSettings()
        {
            InitializeComponent();
        }
        int userID;
        string langue;
        public FormSettings(int _userID,string _langue)
        {
            InitializeComponent();
            userService = new UserService();
            passService = new PasswordService();
            userDatailsServece = new UserDatailsServece();
            userID = _userID;
            langue = _langue;
        }
        private void FormSettings_Load(object sender, EventArgs e)
        {
            switch (langue)
            {
                case "Eng":
                    label4.Text = "E-mail :";
                    label1.Text = "Name :";
                    label2.Text = "Surname : :";
                    label3.Text = "Age :";
                    label9.Text = "Height :";
                    label4.Text = "Weight :";
                    label15.Text = "Used Pass :";
                    label2.Text = "Neww Pass :";
                    label3.Text = "Pass Again :";
                    groupBox1.Text = "Your Password";
                    groupBox3.Text = "Your Profile";
                    groupBox2.Text = "Profile Picture";
                    break;
                case "Tr":
                    label4.Text = "E-posta :";
                    label1.Text = "Ad :";
                    label2.Text = "Soyad : :";
                    label3.Text = "Yaş :";
                    label9.Text = "Boy :";
                    label4.Text = "Kilo :";
                    label15.Text = "Kullanılan Şifre :";
                    label12.Text = "Yeni Şifre :";
                    label13.Text = "Şifre Tekrar :";
                    groupBox1.Text = "Şifrelerin";
                    groupBox3.Text = "Profilin";
                    groupBox2.Text = "Profil Fotoğrafın";
                    break;
            }
            UserDetail userDetail1 = userDatailsServece.GetUserDetailByID(userID);
            if (userDetail1.Gender == false) pictureBox1.Image = Image.FromFile(@"C:\Users\Rezan Söylemez\Desktop\SaglikliYER\Man.png");
            else if (userDetail1.Gender == true) pictureBox1.Image = Image.FromFile(@"C:\Users\Rezan Söylemez\Desktop\SaglikliYER\Woman.png");
            try
            {
                UserDetail userDetail = userDatailsServece.GetUserDetailByID(userID);
                txtName.Text = userDetail.UserName;
                txtSurname.Text = userDetail.SurName;
                int Age = DateTime.Now.Year - userDetail.BirthDate.Year;
                labelAge.Text = Age.ToString();
                txtHeight.Text = userDetail.Height.ToString();
                txtWeight.Text = userDetail.Weight.ToString();
                labelMail.Text = userDetail.DUser.Email;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdatePass_Click(object sender, EventArgs e)
        {
            try
            {
                Password activePassword = passService.GetActivePassword(userID);
                if (txtOldPass.Text != activePassword.PasswordText)
                {
                    if(langue=="Eng") MessageBox.Show("Password is wrong.");
                    else if(langue=="Tr")MessageBox.Show("Şifre yanlış");
                    return;
                }
                if (txtNewPass1.Text != txtNewPass2.Text)
                {
                    if (langue == "Eng") MessageBox.Show("Password repetition is wrong.");
                    else if (langue == "Tr") MessageBox.Show("Yanlış Şifre");
                    return;
                }
                bool check = passService.AddPassword(new Password()
                {
                    PasswordText = txtNewPass1.Text,
                    DUserID = userID
                });
                if (langue == "Eng") MessageBox.Show(check ? "Complete Successfully!" : "Process Failed!");
                else if (langue == "Tr") MessageBox.Show(check ? "Tamamlandı !" : "Tamamlanmadı !");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdateUser_Click(object sender, EventArgs e)
        {
            try
            {
                userDatailsServece.CUpdateUserDetails(new UserDetail()
                {
                    UserDetailID = userID,
                    UserName = txtName.Text,
                    SurName = txtSurname.Text,
                    Height = Convert.ToDecimal(txtHeight.Text),
                    Weight = Convert.ToDecimal(txtWeight.Text)
                });
                if (langue == "Eng") MessageBox.Show("Complete Successfully!");
                else if (langue == "Tr") MessageBox.Show("İşlem Tamamlanmadı");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void FormSettings_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Owner.Show();
        }
    }
}
