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
    public partial class FormLogin : Form
    {
        bool count = true;
        UserService userService;
        PasswordService passwordService;
        public FormLogin()
        {
            InitializeComponent();
            userService = new UserService();
            passwordService = new PasswordService();
        }
        string langue;
        public FormLogin(string _langue)
        {
            InitializeComponent();
            userService = new UserService();
            passwordService = new PasswordService();
            langue = _langue;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string email = txtEmail.Text;
                string pass = txtPassword1.Text;
                DUser dUser = userService.CheckLogin(email, pass);
                if (dUser != null)
                {
                    FormMain formMain = new FormMain(dUser.DUserID,langue);
                    formMain.Owner = this;
                    this.Hide();
                    formMain.Show();
                    txtEmail.Text = "";
                    txtPassword1.Text = "";
                    
                }
                else if(langue == "Eng") MessageBox.Show("Please check your user information.");
                else if (langue == "Tr") MessageBox.Show("Lütfen kullanıcınızı bilgilerinizi kontrol edin.");
            }
            catch (Exception ex2)
            {
                MessageBox.Show(ex2.Message);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnShowPass_Click(object sender, EventArgs e)
        {
            if (count == true)
            {
                txtPassword1.PasswordChar = '\0';
                count = false;
            }
            else if (count == false)
            {
                txtPassword1.PasswordChar = '*';
                count = true;
            }
        }

        private void FormLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Owner.Show();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            switch (langue)
            {
                case "Eng":
                    label1.Text = "E-mail :";
                    label2.Text = "Password :";
                    groupBox2.Text = "Register";
                    linkLabel1.Text = "Forgot My Password";
                    this.Text = "Login";
                    break;
                case "Tr":
                    label1.Text = "E-posta :";
                    label2.Text = "Şifre :";
                    groupBox2.Text = "Giriş";
                    linkLabel1.Text = "Şifremi Unuttum";
                    this.Text = "Giriş";
                    break;
            }
        }
    }
}
