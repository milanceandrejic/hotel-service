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
    [Serializable()]
    public class Gost
    {
        private static int ID;

        private int idGosta;
        private string ime;
        private string prezime;
        private DateTime datumRodjenja;
        private string brTelefona;

        public int IdGosta { get => idGosta; }
        public string Ime { get => ime; set => ime = value; }
        public string Prezime { get => prezime; set => prezime = value; }
        public DateTime DatumRodjenja { get => datumRodjenja; set => datumRodjenja = value; }
        public string BrTelefona { get => brTelefona; set => brTelefona = value; }

        private void proveriID()
        {
            /*
             * Proverava ID poslednjeg upisanog Gosta u fajlu
             * vraca void
             * settuje static ID na vrednost sledecu od poslednje upisane u fajlu
             * ako ne postoji fajl sa upisanim gostima setuje static ID na 1 kao prvog Gosta
             */
            string nazivfajla = "gosti.dat";
            BinaryFormatter binary = new BinaryFormatter();
            if (File.Exists(nazivfajla))
            {
                FileStream fileStream = new FileStream(nazivfajla, FileMode.Open);
                List<Gost> gosts = new List<Gost>();
                try
                {
                    gosts = binary.Deserialize(fileStream) as List<Gost>;
                    ID = gosts.Last().idGosta + 1;
                }
                catch 
                {
                    ID = 1;
                }
                
                fileStream.Dispose();
            }
            else
                ID = 1;
        }

        public Gost(string ime, string prezime, DateTime datumRodjenja, string brTelefona)
        {
            /*
             * Glavni konstruktor
             */ 
            proveriID(); // Pozivanje proveriID radi setovanja ID-a korisnika
            this.idGosta = ID;
            this.Ime = ime;
            this.Prezime = prezime;
            this.DatumRodjenja = datumRodjenja;
            this.BrTelefona = brTelefona;
        }

        public static void PrikaziGoste(ListBox target)
        {
            /*
             * Prikaz gostiju na target LB
             * citanje gostiju iz datoteke
             */
            string nazivfajla = "gosti.dat";
            BinaryFormatter binary = new BinaryFormatter();
            if (File.Exists(nazivfajla))
            {
                FileStream fileStream = new FileStream(nazivfajla, FileMode.Open);
                List<Gost> gosts = new List<Gost>();
                gosts = binary.Deserialize(fileStream) as List<Gost>;

                target.DataSource = null;
                target.DataSource = gosts;

                fileStream.Dispose();
            }
            else
                target.DataSource = null;
        }

        public override string ToString()
        {
            return 
                "Ime i prezime: " + this.ime + " " + this.prezime + " | Datum rodjenja: " +
                this.datumRodjenja.Date.ToShortDateString() + " | Telefon: " + this.brTelefona;
        }
    }
}
