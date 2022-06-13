using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelServices
{
    public partial class KorisnikForma : Form
    {
        public KorisnikForma()
        {
            InitializeComponent();
        }

        protected void btnOtkazi_Click(object sender, EventArgs e)
        {
            //Otkazivanje pokrenute operacije
            this.Close();
        }

        protected void DodavanjeKorisnika_Load(object sender, EventArgs e)
        {
            //Podesavanje polja za password
            txtPassword.UseSystemPasswordChar = true;
            txtConfirmPassword.UseSystemPasswordChar = true;
        }
        protected bool provera(TextBox txt)
        {
            /*
             * Proverava da li je textBox Prazan
             */
            if(txt.Text.Trim() == "" || txt == null)
                return false;
            else
                return true;
        }
        protected bool proveraUsera(TextBox txt)
        {
            
            //Provera praznog stringa
            if (txt.Text.Trim() == "" || txt == null ||
                txt.Text.Contains(" ") || txt.Text.Length < 3)
                return false;

            return true;
        }

        protected bool postojiLiUsername(TextBox txt)
        {
            string nazivfajla = "korisnici.dat";
            //Provera da li vec postoji zadati username
            if (File.Exists(nazivfajla))
            {
                BinaryFormatter binary = new BinaryFormatter();
                FileStream fileStream = new FileStream(nazivfajla, FileMode.Open);
                List<Korisnik> korisniks = new List<Korisnik>();
                korisniks = binary.Deserialize(fileStream) as List<Korisnik>;
                fileStream.Dispose();

                //Provera tipa

                foreach (Korisnik k in korisniks)
                {
                    if (k.KorisnickoIme == txtUsername.Text.Trim())
                        return true;
                }
            }
            return false;

        }
        protected bool proveraPass(TextBox txt)
        {
            //Proverva da li je uneta sifra
            if (txt.Text.Trim() == "" || txt == null || txt.Text.Length < 6)
                return false;
            else
                return true;
        }
        protected bool proveraPassConfirm(TextBox txt)
        {
            /*
             * Proverava poklapanje sifara
             */
            if (txt.Text == txtPassword.Text)
            { 
                txt.BackColor = Color.FromArgb(200, 255, 200);
                return true;
            }  
            else
            { 
                txt.BackColor = Color.FromArgb(255, 200, 200);
                return false;
            }
                
        }

        protected void txtIme_TextChanged(object sender, EventArgs e)
        {
            /*
             * Boji polja ako su validna
             */
            if (provera(sender as TextBox))
                (sender as TextBox).BackColor = Color.FromArgb(200, 255, 200);
            else
                (sender as TextBox).BackColor = Color.FromArgb(255, 200, 200);
        }

        protected void txtUsername_TextChanged(object sender, EventArgs e)
        {
            if (proveraUsera(sender as TextBox))
                (sender as TextBox).BackColor = Color.FromArgb(200, 255, 200);
            else
                (sender as TextBox).BackColor = Color.FromArgb(255, 200, 200);
        }

        protected void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if (proveraPass(sender as TextBox))
                (sender as TextBox).BackColor = Color.FromArgb(200, 255, 200);
            else
                (sender as TextBox).BackColor = Color.FromArgb(255, 200, 200);
        }

        protected void txtConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            //Proverava validnost sifre
            proveraPassConfirm(sender as TextBox);
        }

    }
}
