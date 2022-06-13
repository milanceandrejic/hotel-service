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
    enum IzborMODA { Korisnik=1, Rezervacija, Soba, Gost}
    //Mod u kojem je Administrator,prikaz i uredjivanje
    /*
     * Od izabranog moda zavise
     * prikaz u Listboxu
     * Funkcije dugmadi
     */
    public partial class FormAdministracija : Form
    {
        /*
         * Forma za Administratore
         */
        formLogin formLog; // Cuva referencu login forme
        Korisnik trenutniKorisnik;
        IzborMODA izbor = IzborMODA.Korisnik;
        public FormAdministracija(formLogin forma,Korisnik trenutni)
        {
            /* 
             * Konstruktor forme
             * Prihvata ref na login formu
             * Prihvata logovanog korisnika
             */
            this.formLog = forma;
            this.trenutniKorisnik = trenutni;
            InitializeComponent();
        }


        //Odjava na zatvaranje
        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            formLog.Show();
            //Prikaz Login forme nakon odjave
        }


        //Load forme prikazuje default za Administratora
        private void Form2_Load(object sender, EventArgs e)
        {
            //PRIKAZ Imena i prezimena ulogovanog korisnika
            this.label1.Text = trenutniKorisnik.ImeKorisnika + "\n" + trenutniKorisnik.PrezimeKorisnika;
            
            //Prikaz korisnici kao default
            Korisnik.PrikaziKorisnike(this.listPrikaz);

        }


        //LOGOUT dugme
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        //Metode za Izbor Moda klikom na odg dugme
        private void btnKorisnici_Click(object sender, EventArgs e)
        {
            izbor = IzborMODA.Korisnik;
            Korisnik.PrikaziKorisnike(this.listPrikaz);
        }

        private void btnRezervacije_Click(object sender, EventArgs e)
        {
            izbor = IzborMODA.Rezervacija;
            Rezervacija.PrikaziRezervacije(this.listPrikaz);
        }

        private void btnSobe_Click(object sender, EventArgs e)
        {
            izbor = IzborMODA.Soba;
            Soba.PrikaziSobe(this.listPrikaz);
        }

        private void btnGosti_Click(object sender, EventArgs e)
        {
            izbor = IzborMODA.Gost;
            Gost.PrikaziGoste(this.listPrikaz);
        }


        //Metode za brisanje
        private void ObrisiKorisnika()
        {
            Korisnik zaBrisanje = listPrikaz.SelectedItem as Korisnik;
            System.Diagnostics.Debug.WriteLine(zaBrisanje.ToString());
            string nazivfajla = "korisnici.dat";
            if (File.Exists(nazivfajla))
            {
                BinaryFormatter binary = new BinaryFormatter();
                FileStream fileStream = new FileStream(nazivfajla, FileMode.Open);
                List<Korisnik> korisniks = new List<Korisnik>();
                korisniks = binary.Deserialize(fileStream) as List<Korisnik>;

                //BRISANJE KORISNIKA IZ LISTE
                fileStream.Dispose();
                if (zaBrisanje.IdKorisnika != trenutniKorisnik.IdKorisnika)
                    foreach (Korisnik k in korisniks)
                    {
                        if (k.IdKorisnika == zaBrisanje.IdKorisnika)
                        {
                            korisniks.Remove(k);
                            break;
                        }
                    }
                else
                    MessageBox.Show("NE MOŽETE OBRISATI SEBE!", "Greška!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //UPDATE FILE-a

                fileStream = new FileStream(nazivfajla, FileMode.Create);
                binary.Serialize(fileStream, korisniks);
                fileStream.Dispose();
            }
        }
        private void ObrisiSobu()
        {
            string nazivfajla = "sobe.dat";
            if (File.Exists(nazivfajla))
            {   Soba zaBrisanje = listPrikaz.SelectedItem as Soba;
                BinaryFormatter binary = new BinaryFormatter();
                FileStream fileStream = new FileStream(nazivfajla, FileMode.Open);

                List<Soba> sobe = new List<Soba>();
                sobe = binary.Deserialize(fileStream) as List<Soba>;
                fileStream.Dispose();

                //BRISANJE SOBE IZ LISTE
                
                    foreach (Soba s in sobe)
                    {
                        if (s.IdSobe == zaBrisanje.IdSobe)
                        {
                            sobe.Remove(s);
                            break;
                        }
                    }
                //UPDATE FILE-a

                fileStream = new FileStream(nazivfajla, FileMode.Create);
                binary.Serialize(fileStream, sobe);
                fileStream.Dispose();
            }
        }
        private void ObrisiRezervaciju()
        {
            string nazivfajla = "rezervacije.dat";
            if (File.Exists(nazivfajla))
            {   Rezervacija zaBrisanje = listPrikaz.SelectedItem as Rezervacija;
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
        private void ObrisiGosta()
        {
           
           
            string nazivfajla = "gosti.dat";
            if (File.Exists(nazivfajla))
            {   Gost zaBrisanje = listPrikaz.SelectedItem as Gost;
                BinaryFormatter binary = new BinaryFormatter();
                FileStream fileStream = new FileStream(nazivfajla, FileMode.Open);

                List<Gost> gosts = new List<Gost>();
                gosts = binary.Deserialize(fileStream) as List<Gost>;
                fileStream.Dispose();

                //BRISANJE SOBE IZ LISTE

                foreach (Gost g in gosts)
                {
                    if (g.IdGosta == zaBrisanje.IdGosta)
                    {
                        gosts.Remove(g);
                        break;
                    }
                }
                //UPDATE FILE-a

                fileStream = new FileStream(nazivfajla, FileMode.Create);
                binary.Serialize(fileStream, gosts);
                fileStream.Dispose();
            }
            
        }



        //DUGMICI ZA BRISANJE EDIT DODAVANJE
        private void btnIzbrisi_Click(object sender, EventArgs e)
        {
            switch (izbor)//izbor moda za rad
            {
                case IzborMODA.Korisnik:
                    ObrisiKorisnika();
                    //UPDATE PRIKAZA
                    Korisnik.PrikaziKorisnike(this.listPrikaz);
                    break;

                case IzborMODA.Rezervacija:
                    ObrisiRezervaciju();
                    Rezervacija.PrikaziRezervacije(this.listPrikaz);
                    break;

                case IzborMODA.Soba:
                    ObrisiSobu();
                    Soba.PrikaziSobe(this.listPrikaz);
                    break;

                case IzborMODA.Gost:
                    ObrisiGosta();
                    Gost.PrikaziGoste(this.listPrikaz);
                    break;
            }
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            switch (izbor) // izbor moda za rad
            {
                case IzborMODA.Korisnik:
                    dodajKorisnika dodavanjeKorisnika = new dodajKorisnika();
                    dodavanjeKorisnika.ShowDialog();
                    Korisnik.PrikaziKorisnike(this.listPrikaz);
                    break;

                case IzborMODA.Rezervacija:
                    RezervacijaForma rezervacijaForma = new RezervacijaForma(btnDodaj);
                    rezervacijaForma.ShowDialog();
                    Rezervacija.PrikaziRezervacije(listPrikaz);
                    break;

                case IzborMODA.Soba:
                    SobaForma dodavanjeSobe = new SobaForma(btnDodaj);
                    dodavanjeSobe.ShowDialog();
                    Soba.PrikaziSobe(listPrikaz);
                    break;

                case IzborMODA.Gost:
                    GostForma gostForm = new GostForma(btnDodaj);
                    gostForm.ShowDialog();
                    Gost.PrikaziGoste(listPrikaz);
                    break;
            }
           
        }

        private void btnUredi_Click(object sender, EventArgs e)
        {
            switch (izbor)
            {
                case IzborMODA.Korisnik:
                    UrediKorisnika uredi = new UrediKorisnika(listPrikaz.SelectedItem as Korisnik);
                    uredi.ShowDialog();
                    Korisnik.PrikaziKorisnike(this.listPrikaz);
                    break;

                case IzborMODA.Rezervacija:
                    RezervacijaForma urediRez = new RezervacijaForma(btnUredi, listPrikaz.SelectedItem as Rezervacija);
                    urediRez.ShowDialog();
                    Rezervacija.PrikaziRezervacije(listPrikaz);
                    break;

                case IzborMODA.Soba:
                    SobaForma urediSobu = new SobaForma(btnUredi, listPrikaz.SelectedItem as Soba);
                    urediSobu.ShowDialog();
                    Soba.PrikaziSobe(listPrikaz);
                    break;

                case IzborMODA.Gost:
                    GostForma urediGosta = new GostForma(btnUredi, listPrikaz.SelectedItem as Gost);
                    urediGosta.ShowDialog();
                    Gost.PrikaziGoste(listPrikaz);
                    break;
            }
            
        }
    }
}
