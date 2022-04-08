using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SaglikliYER
{
    public partial class FormGiris : Form
    {
        public FormGiris()
        {
            InitializeComponent();
        }
        string langue;
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(langue))
            {
                FormLogin login = new FormLogin(langue);
                login.Owner = this;
                this.Hide();
                login.Show();
            }
            else MessageBox.Show("Choose Langue");
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            FormSignUp signUp = new FormSignUp();
            signUp.Owner = this;
            this.Hide();
            signUp.Show();
        }

        private void btnKacKalori_Click(object sender, EventArgs e)
        {
            FormKalHesaplama kalHesaplama = new FormKalHesaplama();
            kalHesaplama.Owner = this;
            this.Hide();
            kalHesaplama.Show();
        }

        private void smSaglikliYer_Click(object sender, EventArgs e)
        {
            FormBilgilendirme bilgilendirme = new FormBilgilendirme(0);
            bilgilendirme.Owner = this;
            this.Hide();
            bilgilendirme.ShowDialog();
        }

        private void smEkibimiz_Click(object sender, EventArgs e)
        {
            FormBilgilendirme bilgilendirme = new FormBilgilendirme(1);
            bilgilendirme.Owner = this;
            this.Hide();
            bilgilendirme.ShowDialog();
        }

        private void msKaratay_Click(object sender, EventArgs e)
        {
            FormBilgilendirme bilgilendirme = new FormBilgilendirme(2);
            bilgilendirme.Owner = this;
            this.Hide();
            bilgilendirme.ShowDialog();
        }

        private void msKetojenik_Click(object sender, EventArgs e)
        {
            FormBilgilendirme bilgilendirme = new FormBilgilendirme(3);
            bilgilendirme.Owner = this;
            this.Hide();
            bilgilendirme.ShowDialog();
        }

        private void msIletisim_Click(object sender, EventArgs e)
        {
            FormBilgilendirme bilgilendirme = new FormBilgilendirme(4);
            bilgilendirme.Owner = this;
            this.Hide();
            bilgilendirme.ShowDialog();
        }

        private void msKonum_Click(object sender, EventArgs e)
        {
            FormBilgilendirme bilgilendirme = new FormBilgilendirme(5);
            bilgilendirme.Owner = this;
            this.Hide();
            bilgilendirme.ShowDialog();
        }

        private void btnEng_Click(object sender, EventArgs e)
        {
            langue = "Eng";
        }

        private void btnTr_Click(object sender, EventArgs e)
        {
            langue = "Tr";
        }
    }
}
