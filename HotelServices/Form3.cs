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
    public partial class FormRecepcija : Form
    {
        formLogin formLog;
        Korisnik trenutniKorisnik;
        public FormRecepcija(formLogin forma,Korisnik korisnik)
        {
            /*
             * Glavni konstruktor
             * prihvata login formu i trenutnog korisnika
             */
            this.formLog = forma;
            this.trenutniKorisnik = korisnik;
            InitializeComponent();
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Logout
            formLog.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Logout na dugme
            this.Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            //PRIKAZ Imena i prezimena ulogovanog korisnika
            this.label1.Text = trenutniKorisnik.ImeKorisnika + "\n" + trenutniKorisnik.PrezimeKorisnika;
            //Settovanje minimalnog datuma na danasnji
            this.dateTimePicker1.MinDate = DateTime.Now;
            //Prikaz defaultno aktuelnih rezervacija
            PrikaziAktuelneRezervacije();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            /*
             * Funkcija promene datuma prikaza
             * Filtrira sve rezervacije koje su aktuelne za zadati datum
             */
            string nazivfajla = "rezervacije.dat";
            BinaryFormatter binary = new BinaryFormatter();
            if (File.Exists(nazivfajla))
            {
                FileStream fileStream = new FileStream(nazivfajla, FileMode.Open);
                List<Rezervacija> rezervacijas = new List<Rezervacija>();
                rezervacijas = binary.Deserialize(fileStream) as List<Rezervacija>;
                fileStream.Dispose();

                //Filtriranje rezervacija
                for (int i= 0 ; i < rezervacijas.Count ; i++)
                {
                    if (dateTimePicker1.Value >= rezervacijas[i].DatumOdjave ||
                        dateTimePicker1.Value <= rezervacijas[i].DatumPrijave)
                    {
                        rezervacijas.RemoveAt(i);
                        i--;
                    }
                }

                //Refresh listboxa
                listPrikaz.DataSource = null;
                listPrikaz.DataSource = rezervacijas;

            }
            else
                listPrikaz.DataSource = null;
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            /*
             * Metoda koja poziva formu za dodavanje rezervacija
             */
            RezervacijaForma rezervacijaForm = new RezervacijaForma(btnDodaj);
            rezervacijaForm.ShowDialog();
            Rezervacija.PrikaziRezervacije(listPrikaz);
        }

        private void btnUredi_Click(object sender, EventArgs e)
        {
            /*
             * Metoda koja poziva formu za uredjivanje selektovane rezervacije
             */
            RezervacijaForma urediRez = new RezervacijaForma(btnUredi,listPrikaz.SelectedItem as Rezervacija);
            urediRez.ShowDialog();
            Rezervacija.PrikaziRezervacije(listPrikaz);
        }

        private void btnIzbrisi_Click(object sender, EventArgs e)
        {
            /*
             * Funkcija za brisanje
             * selektovane rezervacije u listboxu
             * iz datoteke
             */
            string nazivfajla = "rezervacije.dat";
            if (File.Exists(nazivfajla))
            {
                Rezervacija zaBrisanje = listPrikaz.SelectedItem as Rezervacija;
                BinaryFormatter binary = new BinaryFormatter();
                FileStream fileStream = new FileStream(nazivfajla, FileMode.Open);

                List<Rezervacija> rezervacijas = new List<Rezervacija>();
                rezervacijas = binary.Deserialize(fileStream) as List<Rezervacija>;
                fileStream.Dispose();

                //BRISANJE SOBE IZ LISTE

                foreach (Rezervacija s in rezervacijas)
                {
                    if (s.IdRezervacije == zaBrisanje.IdRezervacije)
                    {
                        rezervacijas.Remove(s);
                        break;
                    }
                }
                //UPDATE FILE-a

                fileStream = new FileStream(nazivfajla, FileMode.Create);
                binary.Serialize(fileStream, rezervacijas);
                fileStream.Dispose();
            }
        }

        private void btnRezervacije_Click(object sender, EventArgs e)
        {
            PrikaziAktuelneRezervacije();
        }

        private void PrikaziAktuelneRezervacije()
        {
            /*
             * Funkcija za prikazivanje svih rezervacija
             * koje su aktuelne trenutno 
             * i u buducnosti
             */
            string nazivfajla = "rezervacije.dat";
            BinaryFormatter binary = new BinaryFormatter();
            if (File.Exists(nazivfajla))
            {
                FileStream fileStream = new FileStream(nazivfajla, FileMode.Open);
                List<Rezervacija> rezervacijas = new List<Rezervacija>();
                rezervacijas = binary.Deserialize(fileStream) as List<Rezervacija>;
                fileStream.Dispose();

                //Filtriranje zastarelih rezervacija,
                //prikaz samo aktuelnih za naredni period
                for (int i = 0; i < rezervacijas.Count; i++)
                {
                    if (DateTime.Now > rezervacijas[i].DatumOdjave)
                    {
                        rezervacijas.RemoveAt(i);
                        i--;
                    }
                }

                listPrikaz.DataSource = null;
                listPrikaz.DataSource = rezervacijas;

            }
            else
                listPrikaz.DataSource = null;
        }
    }
}
