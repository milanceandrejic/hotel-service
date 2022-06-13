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
    public partial class GostForma : Form
    {
        Button pozivalac; // DUgme koje poziva formu bira mod Dodavanja / Uredjivanja
        Gost izabraniGost; // Izabrani gost za uredjivanje

        enum Poziv { DODAJ, AZURIRAJ }; // Modovi
        Poziv poziv;
        public GostForma(Button pozivalac)
        {
            /*
             * Konstruktor za mod Dodavanja
             */
            this.pozivalac = pozivalac;

            if (pozivalac.Text == "Dodaj")
            {
                poziv = Poziv.DODAJ;
            }
            else if (pozivalac.Text == "Uredi")
            {
                poziv = Poziv.AZURIRAJ;
            }
            InitializeComponent();
            comboRegion.SelectedIndex = 0;
        }
        public GostForma(Button pozivalac,Gost izabraniGost)
        {
            /*
             * Konstruktor za mod Uredjivanja 
             */
            this.pozivalac = pozivalac;
            this.izabraniGost = izabraniGost;
            if (pozivalac.Text == "Dodaj")
            {
                poziv = Poziv.DODAJ;
            }
            else if (pozivalac.Text == "Uredi")
            {
                poziv = Poziv.AZURIRAJ;
            }
            InitializeComponent();
            /*
             * Popunjavanje forme za izabranog gosta
             */
            txtIme.Text = izabraniGost.Ime;
            txtPrezime.Text = izabraniGost.Prezime;
            dateTimePicker1.Value = izabraniGost.DatumRodjenja;
            comboRegion.SelectedIndex = comboRegion.FindStringExact(izabraniGost.BrTelefona.Split(' ')[0]);
            txtBrTelefona.Text = izabraniGost.BrTelefona.Remove(0, comboRegion.SelectedItem.ToString().Length);
        }

        private void GostForma_Load(object sender, EventArgs e)
        {
            //Samo punoletne osobe
            dateTimePicker1.MaxDate = DateTime.Now.AddYears(-18);
            comboRegion.SelectedValue = "+381"; // default za izbor regiona
        }

        private void btnSacuvaj_Click(object sender, EventArgs e)
        {
            //Izbor operacije na osnovu dugmeta koje je pozvalo formu
            switch (poziv)
            {
                case Poziv.DODAJ:
                    //Dodavanje Rezervacije
                    dodajGosta();
                    break;

                case Poziv.AZURIRAJ:
                    //Azuriranje Rezervacije
                    azurirajGosta();
                    break;
            }
        }

        private void azurirajGosta()
        {
            /*
             * Funkcija za azuriranje korisnika
             * refreshuje datoteku
             */
            string nazivfajla = "gosti.dat";
            if (File.Exists(nazivfajla))
            {
                BinaryFormatter binary = new BinaryFormatter();
                FileStream fileStream = new FileStream(nazivfajla, FileMode.Open);
                List<Gost> gosts = new List<Gost>();
                try
                {
                    gosts = binary.Deserialize(fileStream) as List<Gost>;
                }
                catch
                {
                }

                fileStream.Dispose();

                //Dodavanje rezervacije

                if (
                    this.comboRegion.SelectedItem != null &&
                    this.txtIme != null && txtIme.Text.Trim() != ""
                    && txtIme.Text.Length > 1 &&
                    txtPrezime.Text.Trim() != "" &&
                    Int32.TryParse(txtBrTelefona.Text.Trim(), out int trash) &&
                    txtBrTelefona.Text.Trim().Length > 6 
                    )
                {
                    string ime = txtIme.Text.Trim();
                    string prezime = txtPrezime.Text.Trim();
                    string telefon = comboRegion.Text + " " + txtBrTelefona.Text.Trim();

                    foreach(Gost g in gosts)
                    {
                        if(g.IdGosta == izabraniGost.IdGosta)
                        {
                            g.Ime = ime;
                            g.Prezime = prezime;
                            g.DatumRodjenja = dateTimePicker1.Value;
                            g.BrTelefona = telefon;
                            break;
                        }
                    }

                    this.Close();
                }
                else
                    MessageBox.Show("UNESITE SVE PODATKE VALIDNO!", "Greška!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                //UPDATE FILE-a

                fileStream = new FileStream(nazivfajla, FileMode.Create);
                binary.Serialize(fileStream, gosts);
                fileStream.Dispose();
            }
            else
            {
                //Kreiranje FILE-a
                FileStream fileStream = new FileStream(nazivfajla, FileMode.Create);
                fileStream.Close();
                dodajGosta();
            }
        }

        private void dodajGosta()
        {
            /*
             * Funkcija za dodavanje Gosta
             */
            string nazivfajla = "gosti.dat";
            if (File.Exists(nazivfajla))
            {
                BinaryFormatter binary = new BinaryFormatter();
                FileStream fileStream = new FileStream(nazivfajla, FileMode.Open);
                List<Gost> gosts = new List<Gost>();
                try { 
                    gosts = binary.Deserialize(fileStream) as List<Gost>;
                }
                catch
                {
                }
                
                fileStream.Dispose();

                //Dodavanje rezervacije

                if (
                    this.comboRegion.SelectedItem != null &&
                    this.txtIme != null && txtIme.Text.Trim() != ""
                    && txtIme.Text.Length > 1 &&
                    txtPrezime.Text.Trim() != "" &&
                    Int32.TryParse(txtBrTelefona.Text.Trim(),out int trash) &&
                    txtBrTelefona.Text.Trim().Length > 6
                    )
                {
                    string ime = txtIme.Text.Trim();
                    string prezime = txtPrezime.Text.Trim();
                    string telefon = comboRegion.Text + " " + txtBrTelefona.Text.Trim();

                    gosts.Add(new Gost(
                                        ime, prezime,
                                        dateTimePicker1.Value,
                                        telefon));
                    this.Close();
                }
                else
                    MessageBox.Show("UNESITE SVE PODATKE VALIDNO!", "Greška!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                //UPDATE FILE-a

                fileStream = new FileStream(nazivfajla, FileMode.Create);
                binary.Serialize(fileStream, gosts);
                fileStream.Dispose();
            }
            else
            {
                //Kreiranje FILE-a
                FileStream fileStream = new FileStream(nazivfajla, FileMode.Create);
                fileStream.Close();
                dodajGosta();
            }
        }

        private void btnOtkazi_Click(object sender, EventArgs e)
        {
            //Otkazivanje zapocete operacije
            this.Close();
        }
    }
}

