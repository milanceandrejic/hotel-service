using System;
using System.Collections;
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
    public partial class formLogin : Form
    {
        public formLogin()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.hotelLogo;
            txtPassword.UseSystemPasswordChar = true; // setovanje password polja
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //Promenljive za loginformu
            string username = this.txtUsername.Text;
            string password = this.txtPassword.Text;
            tipKorisnika opcija;
            bool poruka = false;

            //...otvaranje fajla za citanje
            //...Recepcionera ili Administratora
            //...zavisno od odabrane opcije
            FileStream fileStream;
            string nazivFajla = "korisnici.dat";

            if (chkAdmin.Checked == true)
                opcija = tipKorisnika.admin;
            else
                opcija = tipKorisnika.recep;
            //Provera postojanja fajlova sa bazom korisnika sistema
            if (File.Exists(nazivFajla))
            {
                fileStream = new FileStream(nazivFajla, FileMode.Open);
                BinaryFormatter binaryFormatter = new BinaryFormatter();

                List<Korisnik> listaKorsinika = new List<Korisnik>();

                //Ucitavanje svih Korisnika iz datoteke
                listaKorsinika = binaryFormatter.Deserialize(fileStream) as List<Korisnik>;
                fileStream.Dispose();

                //Loginovanje
                foreach (Korisnik k in listaKorsinika)
                {
                    if (username == k.KorisnickoIme && password == k.Lozinka && opcija == k.Tip)
                    {
                        //ukoliko je pronadjen korisnik sa username i passom odgovarajuceg tipa
                        switch (opcija)
                        {
                            case tipKorisnika.admin:
                                this.Visible = false;
                                FormAdministracija formAdmin = new FormAdministracija(this,k);
                                formAdmin.Show();
                                poruka = true;
                                //this.Close();
                                break;

                            case tipKorisnika.recep:
                                this.Visible = false;
                                FormRecepcija formKorisnik = new FormRecepcija(this,k);
                                formKorisnik.Show();
                                poruka = true;
                                //this.Close();
                                break;

                            default:
                                poruka = false;
                                break;
                            
                        }
                        
                    }
                    
                }
                if(!poruka)
                    MessageBox.Show("Ne postoji korisnik sa unetim podacima, pokusajte ponovo");

            }
            else
                MessageBox.Show("NE POSTOJI DATOTEKA korisnici.txt", "Greška!", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void formLogin_Load(object sender, EventArgs e)
        {
            //Postavljanje default Administratora ako datoteka ne postoji
            //user > admin
            //pass > admin
            string nazivFajla = "korisnici.dat";
            if (!File.Exists(nazivFajla))
            {
                FileStream fileStream = new FileStream(nazivFajla, FileMode.Create);
                BinaryFormatter binaryFormatter = new BinaryFormatter();

                List<Korisnik> korisniks = new List<Korisnik>();
                korisniks.Add(new Korisnik("Administrator", "admin", "", "admin"));
                //korisniks.Add(new Korisnik("Administrator", "admin", "", "admin",tipKorisnika.admin));

                binaryFormatter.Serialize(fileStream, korisniks);
                fileStream.Dispose();
            }

            //Kreiranje svih fajlova ako ne postoje
            nazivFajla = "gosti.dat";
            if (!File.Exists(nazivFajla))
            {
                FileStream fileStream = new FileStream(nazivFajla, FileMode.Create);
                BinaryFormatter binaryFormatter = new BinaryFormatter();

                List<Gost> gosts = new List<Gost>();
                binaryFormatter.Serialize(fileStream, gosts);
                fileStream.Dispose();
            }
            nazivFajla = "sobe.dat";
            if (!File.Exists(nazivFajla))
            {
                FileStream fileStream = new FileStream(nazivFajla, FileMode.Create);
                BinaryFormatter binaryFormatter = new BinaryFormatter();

                List<Soba> sobas = new List<Soba>();
                binaryFormatter.Serialize(fileStream, sobas);
                fileStream.Dispose();
            }
            nazivFajla = "rezervacije.dat";
            if (!File.Exists(nazivFajla))
            {
                FileStream fileStream = new FileStream(nazivFajla, FileMode.Create);
                BinaryFormatter binaryFormatter = new BinaryFormatter();

                List<Rezervacija> rez = new List<Rezervacija>();
                binaryFormatter.Serialize(fileStream, rez);
                fileStream.Dispose();
            }
        }
        private bool proveriUsername(string user)
        {
            /*
                proverava da li je unet username
                vraca boolean
                true ako je username unet
                false ako username nije unet
             */
            if (user == null || user.Trim() == "")
                return false;
            return true;
        }
        private bool proveriPassword(string pass)
        {
            /*
                proverava da li je unet password
                vraca boolean
                true ako je sifra uneta
                false ako sifra nije uneta
             */
            if (pass == null || pass.Trim() == "")
                return false;
            return true;
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            /*proverava da li je tekst unet i enabluje dugme*/

            if (proveriUsername(txtUsername.Text) && proveriPassword(txtPassword.Text))
            {
                btnLogin.Enabled = true;
            }
            else
                btnLogin.Enabled = false;
        }

    }
}
