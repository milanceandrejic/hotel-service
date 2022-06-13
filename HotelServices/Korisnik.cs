using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelServices
{
    public enum tipKorisnika { admin=0,recep,count}
    [Serializable()]
    public class Korisnik
    {
        static int ID;

        private int idKorisnika;
        private string imeKorisnika;
        private string prezimeKorisnika;
        private string korisnickoIme;
        private string lozinka;
        private tipKorisnika tip;

        public Korisnik(string imeKorisnika, string korisnickoIme, string prezimeKorisnika, string lozinka, tipKorisnika tip)
        {
            /*
             * Konstruktor za dodavanje korisnika
             * 
             */
            proveriID();
            this.idKorisnika = ID;
            this.ImeKorisnika = imeKorisnika;
            this.PrezimeKorisnika = prezimeKorisnika;
            this.KorisnickoIme = korisnickoIme;
            this.Lozinka = lozinka;
            this.Tip = tip;
        }
        //Samo za default admina ako ne postoji fajl
        public Korisnik(string imeKorisnika, string korisnickoIme, string prezimeKorisnika, string lozinka)
        {
            /*
             * Konstruktor za defaultnog admina
             */
            this.idKorisnika = 0;
            this.ImeKorisnika = imeKorisnika;
            this.PrezimeKorisnika = prezimeKorisnika;
            this.KorisnickoIme = korisnickoIme;
            this.Lozinka = lozinka;
            this.Tip = tipKorisnika.admin;
        }

        public int IdKorisnika { get => idKorisnika; }
        public string ImeKorisnika { get => imeKorisnika; set => imeKorisnika = value; }
        public string PrezimeKorisnika { get => prezimeKorisnika; set => prezimeKorisnika = value; }
        public string KorisnickoIme { get => korisnickoIme; set => korisnickoIme = value; }
        public string Lozinka { get => lozinka; set => lozinka = value; }
        public tipKorisnika Tip { get => tip; set => tip = value; }

        public override string ToString()
        {
            return "ID: " +this.idKorisnika
                + " | Ime i prezime: " +ImeKorisnika + " " + PrezimeKorisnika
                + " | Korsničko ime: " + this.KorisnickoIme 
                + " | Tip korisnika: " + this.Tip.ToString();
        }

        private void proveriID()
        {
            /*
             * Proverava ID poslednjeg upisanog korisnika u fajlu
             * vraca void
             * settuje static ID na vrednost sledecu od poslednje upisane u fajlu
             * ako ne postoji fajl sa upisanim gostima setuje static ID na 1 kao prvog Korisnika
             */
            string nazivfajla = "korisnici.dat";
            BinaryFormatter binary = new BinaryFormatter();
            if (File.Exists(nazivfajla))
            {
                FileStream fileStream = new FileStream(nazivfajla, FileMode.Open);
                List<Korisnik> korisniks = new List<Korisnik>();
                try
                {
                     korisniks = binary.Deserialize(fileStream) as List<Korisnik>;
                     ID = korisniks.Last().idKorisnika + 1;
                }
                catch
                {
                    ID = 0;
                }
                fileStream.Dispose();
            }
            else
                ID = 0;
        }

        public static void PrikaziKorisnike(ListBox target)
        {
            /*
             * Staticka metoda za prikazivanje korisnika na target LB
             * cita Korisnike iz datoteke
             */
            string nazivfajla = "korisnici.dat";
            BinaryFormatter binary = new BinaryFormatter();
            if (File.Exists(nazivfajla))
            {
                FileStream fileStream = new FileStream(nazivfajla, FileMode.Open);
                List<Korisnik> korisniks = new List<Korisnik>();
                korisniks = binary.Deserialize(fileStream) as List<Korisnik>;

                target.DataSource = null;
                target.DataSource = korisniks;

                fileStream.Dispose();
            }
            else
                target.DataSource = null;
        }
    }
}
