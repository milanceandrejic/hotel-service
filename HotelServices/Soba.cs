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
    public enum TipSobe
    {
        Standard=0, Lux, Count
    }
    [Serializable()]
    public class Soba
    {
        static int ID;

        private int idSobe;
        private int brojSobe;
        private int brojKreveta;
        private TipSobe tipSobe;
        private double cena;
        private double popust;
        private int minimalnoDana;

        public int IdSobe { get => idSobe;}
        public int BrojSobe { get => brojSobe; set => brojSobe = value; }
        public int BrojKreveta { get => brojKreveta; set => brojKreveta = value; }
        public TipSobe TipSobe { get => tipSobe; set => tipSobe = value; }
        public double Cena { get => cena; set => cena = value; }
        public double Popust { get => popust; set => popust = value; }
        public int MinimalnoDana { get => minimalnoDana; set => minimalnoDana = value; }

        public Soba(int brojSobe, int brojKreveta, TipSobe tipSobe, double cena, double popust, int minimalnoDana)
        {
            /*
             * Glavni Konstruktor
             */
            proveriID();
            this.idSobe = ID;
            this.brojSobe = brojSobe;
            this.brojKreveta = brojKreveta;
            this.tipSobe = tipSobe;
            this.cena = cena;
            this.popust = popust;
            this.minimalnoDana = minimalnoDana;
        }

        private void proveriID()
        {
            /*
             * Proverava ID poslednje upisane Sobe u fajlu
             * vraca void
             * settuje static ID na vrednost sledecu od poslednje upisane u fajlu
             * ako ne postoji fajl sa upisanim sobama setuje static ID na 1 kao prvu Sobu
             */
            string nazivfajla = "sobe.dat";
            BinaryFormatter binary = new BinaryFormatter();
            if (File.Exists(nazivfajla))
            {
                FileStream fileStream = new FileStream(nazivfajla, FileMode.Open);
                List<Soba> sobe = new List<Soba>();
                
                try 
                { 
                    sobe = binary.Deserialize(fileStream) as List<Soba>;
                    ID = sobe.Last().idSobe + 1;
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

        public static void PrikaziSobe(ListBox target)
        {
            /*
             * Staticka metoda
             * vraca void
             * Cita sobe iz datoteke
             * Prikazuje Sobe u Listbox- target
             * Moze je pozvati bilo koja forma
             */
            string nazivfajla = "sobe.dat";
            BinaryFormatter binary = new BinaryFormatter();
            if (File.Exists(nazivfajla))
            {
                FileStream fileStream = new FileStream(nazivfajla, FileMode.Open);
                List<Soba> sobe = new List<Soba>();
                sobe = binary.Deserialize(fileStream) as List<Soba>;

                target.DataSource = null;
                target.DataSource = sobe;

                fileStream.Dispose();
            }
            else
                target.DataSource = null;
        }

        public override string ToString()
        {
            return "Soba " + this.idSobe + ": "
                + "| Broj sobe: " + this.brojSobe +
                " | Broj kreveta: " + this.brojKreveta +
                " | Tip: " + this.tipSobe +
                " | Cena: " + this.cena +
                " | Popust: " + this.popust +
                " | Minimalno dana: " + this.minimalnoDana;
        }
    }
}
