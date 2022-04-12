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
    public partial class FormSignUp : Form
    {
        UserService userService;
        UserDatailsServece userDatailsServece;
        PasswordService passwordService;
        bool count = true;
        public FormSignUp()
        {
            InitializeComponent();
            userService = new UserService();
            userDatailsServece = new UserDatailsServece();
            passwordService = new PasswordService();
        }
        string language;
        public FormSignUp(string _language)
        {
            InitializeComponent();
            userService = new UserService();
            userDatailsServece = new UserDatailsServece();
            passwordService = new PasswordService();
            language = _language;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPassword1.Text != "" && txtPassword1.Text == txtPassword2.Text)
                {
                    bool sonuc = userService.UserEmailIfExist(txtEmail.Text);
                    if (sonuc == true)
                    {
                        if (!txtEmail.Text.Contains("@") || !txtEmail.Text.EndsWith(".com"))
                        {
                            if (language == "Eng") MessageBox.Show("Please type a correct email.");
                            else if (language == "Tr") MessageBox.Show("Lütfen doğru bir e - posta yazın.");
                            return;
                        }
                        passwordService.CheckPasswordText(txtPassword1.Text);

                        DUser dUser = new DUser();
                        dUser.Email = txtEmail.Text;
                        if (radioGain.Checked)
                            dUser.Wish = "Gain";
                        else if (radioKeep.Checked)
                            dUser.Wish = "Keep";
                        else if (radioToBeFit.Checked)
                            dUser.Wish = "To Be Fit";
                        else
                        {

                            if (language == "Eng") MessageBox.Show("Choose Your Goals");
                            else if (language == "Tr") MessageBox.Show("Hedeflerinizi Seçin");
                            return;
                        }
                        userService.AddUser(dUser);
                        
                        Password password = new Password();
                        password.PasswordText = txtPassword1.Text;
                        password.DUserID = dUser.DUserID;
                        passwordService.AddPassword(password);

                        UserDetail userDetail = new UserDetail();
                        userDetail.UserName = txtName.Text;
                        userDetail.SurName = txtSurname.Text;
                        userDetail.Height = numBoy.Value;
                        userDetail.Weight = numKilo.Value;
                        userDetail.BirthDate = dateTimeBirth.Value;
                        if (radioMan.Checked) userDetail.Gender = false;
                        else if (radioWoman.Checked) userDetail.Gender = true;
                        userDetail.UserDetailID = dUser.DUserID;
                        userDatailsServece.CAddUserDetail(userDetail);
                        MessageBox.Show("Completed");
                    }
                    txtEmail.Text = "";
                    txtPassword1.Text = "";
                    txtPassword2.Text = "";
                    txtName.Text = "";
                    txtSurname.Text = "";
                    numBoy.Value = 0;
                    numKilo.Value = 0;
                }
                if (language == "Eng") MessageBox.Show("Passwords do not match.");
                else if(language == "Tr") MessageBox.Show("Şifreler uyuşmuyor."); 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public string PassLevel(string _pass)
        {
            bool buyukMu = false;
            bool kucukMu = false;
            bool rakamMi = false;
            int UzunlukAl = _pass.Length;
            if (UzunlukAl < 6)
            {
                return "Weak..";
            }
            else
            {
                if (_pass.Any(char.IsUpper))
                {
                    buyukMu = true;
                }
                if (_pass.Any(char.IsLower))
                {
                    kucukMu = true;
                }
                if (_pass.Any(char.IsDigit))
                {
                    rakamMi = true;
                }

                if (rakamMi == true && buyukMu == true && kucukMu == true)
                {
                    return "Strong..";
                }
                else if (rakamMi == true && buyukMu == true && kucukMu == false)
                {
                    return "Normal..";
                }
                else if (rakamMi == false && buyukMu == false && kucukMu == false)
                {
                    return "Weak..";
                }
                else
                {
                    return "Normal..";
                }
            }
        }
        private void btnQuestions_Click(object sender, EventArgs e)
        {
            if(language == "Eng")
               MessageBox.Show("At least 6 characters" +
                    "Use at least one Number, one Uppercase and Lowercase!");
            else if (language == "Tr")
                MessageBox.Show("En az 6 karakter." +
                    "En az bir Rakam, bir Büyük Harf ve Küçük Harf Kullanın !");
        }
        private void txtPassword1_TextChanged(object sender, EventArgs e)
        {
            lblDerece.Text = PassLevel(txtPassword1.Text);

            if (PassLevel(txtPassword1.Text) == "Weak..")
            {
                if (language == "Eng")
                {
                    lblDerece1.ForeColor = Color.Red;
                    lblDerece1.Text = "Weak..";
                }
                else if (language == "Tr")
                {
                    lblDerece1.ForeColor = Color.Red;
                    lblDerece1.Text = "Kolay..";
                }
            }
            else if (PassLevel(txtPassword1.Text) == "Normal..")
            {
                if (language == "Eng")
                {
                    lblDerece1.ForeColor = Color.Orange;
                    lblDerece1.Text = "Normal..";
                }
                else if (language == "Tr")
                {
                    lblDerece1.ForeColor = Color.Orange;
                    lblDerece1.Text = "Normal..";
                }
            }
            else if (PassLevel(txtPassword1.Text) == "Strong..")
            {
                if (language == "Eng")
                {
                    lblDerece1.ForeColor = Color.Green;
                    lblDerece1.Text = "Strong..";
                }
                else if (language == "Tr")
                {
                    lblDerece1.ForeColor = Color.Green;
                    lblDerece1.Text = "Zor..";
                }
            }
        }
        
        private void btnShowPass_Click(object sender, EventArgs e)
        {
            if (count == true)
            {
                txtPassword1.PasswordChar = '\0';
                txtPassword2.PasswordChar = '\0';
                count = false;
            }
            else if (count == false)
            {
                txtPassword1.PasswordChar = '*';
                txtPassword2.PasswordChar = '*';
                count = true;
            }
        }

        private void FormSignUp_Load(object sender, EventArgs e)
        {
            switch (language)
            {
                case "Eng":
                    label1.Text = "E-mail :";
                    label2.Text = "Password :";
                    label8.Text = "Password :";
                    label9.Text = "Password Level:";
                    label3.Text = "Name :";
                    label4.Text = "Surname :";
                    label5.Text = "Height :";
                    label6.Text = "Weight :";
                    label7.Text = "Birth Date :";
                    radioToBeFit.Text = "To Be Fit";
                    radioKeep.Text = "Keep Fit";
                    radioGain.Text = "Gain Weight";
                    radioWoman.Text = "Woman";
                    radioMan.Text = "Man";
                    groupBox2.Text = "Register";
                    groupBox3.Text = "User Details";
                    groupBox1.Text = "Gender";
                    groupBox4.Text = "Your Goals";
                    this.Text = "Sign Up";
                    break;
                case "Tr":
                    label1.Text = "E-posta :";
                    label2.Text = "Şifre :";
                    label8.Text = "Şifre :";
                    label9.Text = "Şifre Seviyesi:";
                    label3.Text = "Ad :";
                    label4.Text = "Soyad :";
                    label5.Text = "Boy :";
                    label6.Text = "Kilo :";
                    label7.Text = "Doğum Tarihi :";
                    radioToBeFit.Text = "Fit Olmak";
                    radioKeep.Text = "Fit Kalmak";
                    radioGain.Text = "Kütle Kazanmak";
                    radioWoman.Text = "Kadın";
                    radioMan.Text = "Erkek";
                    groupBox2.Text = "Kayıt Ol";
                    groupBox3.Text = "Kullanıcı Detayı";
                    groupBox1.Text = "Cinsiyet";
                    groupBox4.Text = "Hedefin";
                    this.Text = "Kayıt Ol";
                    break;
            }
        }
        private void FormSignUp_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Owner.Show();
        }
    }
}
