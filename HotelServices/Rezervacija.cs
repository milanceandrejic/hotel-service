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
    public enum TipRezervacije { PunPansion=0, PoluPansion, SamoDorucak , Count }

    [Serializable()]
    public class Rezervacija
    {
        private static int ID;

        private int idRezervacije;
        private int idSobe;
        private int idGosta;
        private DateTime datumPrijave;
        private DateTime datumOdjave;
        private double ukupnaCena;
        private TipRezervacije tipRezervacije;

        public int IdRezervacije { get => idRezervacije; }
        public int IdSobe { get => idSobe; set => idSobe = value; }
        public int IdGosta { get => idGosta; set => idGosta = value; }
        public DateTime DatumPrijave { get => datumPrijave; set => datumPrijave = value; }
        public DateTime DatumOdjave { get => datumOdjave; set => datumOdjave = value; }
        public double UkupnaCena { get => ukupnaCena; set => ukupnaCena = value; }
        public TipRezervacije TipRezervacije { get => tipRezervacije; set => tipRezervacije = value; }

        public Rezervacija(int idSobe, int idGosta, DateTime datumPrijave, DateTime datumOdjave, TipRezervacije tipRezervacije)
        {
            /*
             * Glavni konstruktor
             */
            proveriID();
            this.idRezervacije = ID;
            this.idSobe = idSobe;
            this.idGosta = idGosta;
            this.datumPrijave = datumPrijave;
            this.datumOdjave = datumOdjave;
            this.tipRezervacije = tipRezervacije;
        }

        private void proveriID()
        {
            /*
             * Proverava ID poslednje upisane Rezervacije u fajlu
             * vraca void
             * settuje static ID na vrednost sledecu od poslednje upisane u fajlu
             * ako ne postoji fajl sa upisanim rezervacijama setuje static ID na 1 kao prvu Rezervaciju
             */
            string nazivfajla = "rezervacije.dat";
            BinaryFormatter binary = new BinaryFormatter();
            if (File.Exists(nazivfajla))
            {
                FileStream fileStream = new FileStream(nazivfajla, FileMode.Open);
                List<Rezervacija> rezervacijas = new List<Rezervacija>();
                try
                {
                    rezervacijas = binary.Deserialize(fileStream) as List<Rezervacija>;
                    ID = rezervacijas.Last().idRezervacije + 1;
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

        public static void PrikaziRezervacije(ListBox target)
        {
            string nazivfajla = "rezervacije.dat";
            BinaryFormatter binary = new BinaryFormatter();
            if (File.Exists(nazivfajla))
            {
                FileStream fileStream = new FileStream(nazivfajla, FileMode.Open);
                List<Rezervacija> rezervacijas = new List<Rezervacija>();
                rezervacijas = binary.Deserialize(fileStream) as List<Rezervacija>;

                target.DataSource = null;
                target.DataSource = rezervacijas;

                fileStream.Dispose();
            }
            else
                target.DataSource = null;
        }

        private string PodaciGosta()
        {
            /*
             * vraca string
             * vraca Ime i prezime Gosta kao jedan string
             * pronalazi gosta po IDu
             */
            string gostImePrezime="";
            string nazivfajla = "gosti.dat";
            BinaryFormatter binary = new BinaryFormatter();
            List<Gost> gosts = new List<Gost>();
            if (File.Exists(nazivfajla))
            {
                FileStream fileStream = new FileStream(nazivfajla, FileMode.Open);
                
                gosts = binary.Deserialize(fileStream)as List<Gost>;
                fileStream.Dispose();
            }
            foreach(Gost g in gosts)
            {
                if (g.IdGosta == this.idGosta)
                { 
                    gostImePrezime = g.Ime + " " + g.Prezime;
                    break;
                }
            }
            return gostImePrezime;
        }

        private string PodaciSobe()
        {
            /*
             * Vraca broj sobe kao string
             * postavlja i racuna Ukupnu cenu
             * 
             */
            string brojSobebroj = "";
            string nazivfajla = "sobe.dat";
            BinaryFormatter binary = new BinaryFormatter();
            List<Soba> sobas = new List<Soba>();
            if (File.Exists(nazivfajla))
            {
                FileStream fileStream = new FileStream(nazivfajla, FileMode.Open);

                sobas = binary.Deserialize(fileStream) as List<Soba>;
                fileStream.Dispose();
            }
            foreach (Soba g in sobas)
            {
                if (g.IdSobe == this.idSobe)
                {
                    brojSobebroj = g.BrojSobe.ToString();
                    this.ukupnaCena = (g.Cena - g.Popust) * (datumOdjave - DatumPrijave).Days;
                    break;
                }
            }
            return brojSobebroj;
        }

        public override string ToString()
        {
            return idRezervacije + "Rezervacija: " + datumPrijave.Date.ToShortDateString() + 
                " - " + datumOdjave.Date.ToShortDateString() + 
                " | Gost: " + PodaciGosta() +
                " | Soba: " + PodaciSobe() +
                " | Ukupna cena: " + ukupnaCena.ToString() + 
                " | Tip: " + tipRezervacije;
        }
    }
}
