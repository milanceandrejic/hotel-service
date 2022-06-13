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
    public partial class dodajKorisnika : KorisnikForma
    {
        public dodajKorisnika()
        {
            InitializeComponent();
        }

        private void DodajKorisnika_Load(object sender, EventArgs e)
        {
            //ovo je neki visak, al bolje da ne diram nista
        }
        private void btnDodaj_Click(object sender, EventArgs e)
        {
            /*
             * Dodavanje korisnika na klik dugmeta
             * refresh datoteke
             */
            string nazivfajla = "korisnici.dat";
            if (File.Exists(nazivfajla))
            {
                BinaryFormatter binary = new BinaryFormatter();
                FileStream fileStream = new FileStream(nazivfajla, FileMode.Open);
                List<Korisnik> korisniks = new List<Korisnik>();
                korisniks = binary.Deserialize(fileStream) as List<Korisnik>;

                //Provera tipa
                tipKorisnika tipDodavanja = tipKorisnika.recep;
                if (radioButton1.Checked)
                    tipDodavanja = tipKorisnika.admin;

                //DODAVANJE KORISNIKA U LISTU
                //Korisnik temp;
                fileStream.Dispose();
                if (provera(txtIme) &&
                    provera(txtPrezime) &&
                    proveraUsera(txtUsername) &&
                    proveraPass(txtPassword) &&
                    proveraPassConfirm(txtConfirmPassword) &&
                    !postojiLiUsername(txtUsername))
                {
                    korisniks.Add(new Korisnik(txtIme.Text,
                                                txtUsername.Text,
                                                txtPrezime.Text,
                                                txtPassword.Text,
                                                tipDodavanja));
                    this.Close();
                }
                else
                    MessageBox.Show("UNESITE SVE PODATKE VALIDNO!", "Greška!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                //UPDATE FILE-a

                fileStream = new FileStream(nazivfajla, FileMode.Create);
                binary.Serialize(fileStream, korisniks);
                fileStream.Dispose();

            }
            
        }

        protected new void txtUsername_TextChanged(object sender, EventArgs e)
        {
            if (proveraUsera(sender as TextBox) && !postojiLiUsername(sender as TextBox))
                (sender as TextBox).BackColor = Color.FromArgb(200, 255, 200);
            else
                (sender as TextBox).BackColor = Color.FromArgb(255, 200, 200);
        }
    }
}
