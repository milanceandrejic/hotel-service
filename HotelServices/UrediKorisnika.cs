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
    public partial class UrediKorisnika : KorisnikForma
    {
        Korisnik izabraniKorisnik;// korisnik za izmenu
        public UrediKorisnika(Korisnik izabrani)
        {
            /*
             * Konstruktor 
             * prihvata korisnika nad kojim se vrse izmene
             */
            this.izabraniKorisnik = izabrani;
            InitializeComponent();
        }

        private void btnSacuvaj_Click(object sender, EventArgs e)
        {
            /*
             * Provera korisnika
             * Azuriranje podataka za korisnika
             * refresh datoteke
             */
            string nazivfajla = "korisnici.dat";
            if (File.Exists(nazivfajla))
            {
                BinaryFormatter binary = new BinaryFormatter();
                FileStream fileStream = new FileStream(nazivfajla, FileMode.Open);
                List<Korisnik> korisniks = new List<Korisnik>();
                korisniks = binary.Deserialize(fileStream) as List<Korisnik>;
                fileStream.Dispose();

                //Provera tipa
                tipKorisnika tipDodavanja = tipKorisnika.recep;
                if (radioButton1.Checked)
                    tipDodavanja = tipKorisnika.admin;

                //AZURIRANJE KORISNIKA U LISTI


                foreach (Korisnik k in korisniks)
                {
                    //Provera korisnika po idu
                    if (k.IdKorisnika == izabraniKorisnik.IdKorisnika)
                    {
                        if (provera(txtIme) &&
                            provera(txtPrezime) &&
                            proveraUsera(txtUsername) &&
                            proveraPass(txtPassword) &&
                            proveraPassConfirm(txtConfirmPassword) &&
                            (k.IdKorisnika != izabraniKorisnik.IdKorisnika &&
                            !postojiLiUsername(txtUsername)))
                        {
                            k.ImeKorisnika = txtIme.Text;
                            k.PrezimeKorisnika = txtPrezime.Text;
                            k.Lozinka = txtPassword.Text;
                            k.KorisnickoIme = txtUsername.Text;
                            this.Close();
                        }
                        else
                            MessageBox.Show("UNESITE SVE PODATKE VALIDNO!", "Greška!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                //UPDATE FILE-a

                fileStream = new FileStream(nazivfajla, FileMode.Create);
                binary.Serialize(fileStream, korisniks);
                fileStream.Dispose();
            }
        }

        private void UrediKorisnika_Load(object sender, EventArgs e)
        {
            /*
             * Postavljanje podataka o korisniku u formu
             */
            string nazivfajla = "korisnici.dat";
            BinaryFormatter binary = new BinaryFormatter();
            FileStream fileStream = new FileStream(nazivfajla, FileMode.Open);
            List<Korisnik> korisniks = new List<Korisnik>();
            korisniks = binary.Deserialize(fileStream) as List<Korisnik>;
            fileStream.Dispose();
            foreach (Korisnik k in korisniks)
                if (k.IdKorisnika == izabraniKorisnik.IdKorisnika)
                {
                    txtIme.Text = k.ImeKorisnika;
                    txtPrezime.Text = k.PrezimeKorisnika;
                    txtUsername.Text = k.KorisnickoIme;
                    txtPassword.Text = k.Lozinka;
                    txtConfirmPassword.Text = k.Lozinka;
                }
        }

        protected new void txtUsername_TextChanged(object sender, EventArgs e)
        {
            /*
             * Override originalne metode 
             * koja se razlikuje za Dodavanje i Azuriranje
             */
            string nazivfajla = "korisnici.dat";
            BinaryFormatter binary = new BinaryFormatter();
            FileStream fileStream = new FileStream(nazivfajla, FileMode.Open);
            List<Korisnik> korisniks = new List<Korisnik>();
            korisniks = binary.Deserialize(fileStream) as List<Korisnik>;
            fileStream.Dispose();

            foreach(Korisnik k in korisniks)
            if (proveraUsera(sender as TextBox) &&
                            (k.IdKorisnika != izabraniKorisnik.IdKorisnika &&
                            !postojiLiUsername(txtUsername)))
                (sender as TextBox).BackColor = Color.FromArgb(200, 255, 200);
            else
                (sender as TextBox).BackColor = Color.FromArgb(255, 200, 200);
        }
    }
}
