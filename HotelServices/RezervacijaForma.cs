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
    public partial class RezervacijaForma : Form
    {
        //Dugme koje je pozvalo formu
        Button pozivalac;
        //Rezervacija za update
        Rezervacija izabranaRezervacija;
        enum Poziv { DODAJ, AZURIRAJ};
        Poziv poziv;

        //DODAJ GOSTA STRING
        const string DODAJ_GOSTA = "Dodaj gosta...";
        //Datumi prijave i odjave
        DateTime datumPrijave;
        DateTime datumOdjave;
        //Broj min dana u sobi
        int minimumDana = 1;

        public RezervacijaForma(Button pozivalac)
        {
            /*
             * Konstruktor za dodavanje rezervacije
             * prihvata dugme koje poziva konstruktor
             */
            //Provera dugmeta koje je pozvalo formu radi izvrsavanja odredjene operacije
            this.pozivalac = pozivalac;

            if(pozivalac.Text=="Dodaj")
            { 
                poziv= Poziv.DODAJ; 
            }
            else if(pozivalac.Text=="Uredi")
            {
                poziv = Poziv.AZURIRAJ;
            }

            InitializeComponent();
        }
        public RezervacijaForma(Button pozivalac,Rezervacija izabranaRezervacija)
        {
            /*
             * Konstruktor za azuriranje
             * prihvata dugme koje je pozvalo
             * prihvata izabranu rezervaciju za azuriranje
             */
            //Provera dugmeta koje je pozvalo formu radi izvrsavanja odredjene operacije
            this.pozivalac = pozivalac;
            this.izabranaRezervacija = izabranaRezervacija;
            if (pozivalac.Text == "Dodaj")
            {
                poziv = Poziv.DODAJ;
            }
            else if (pozivalac.Text == "Uredi")
            {
                poziv = Poziv.AZURIRAJ;
            }

            InitializeComponent();

        }

        private void RezervacijaForma_Load(object sender, EventArgs e)
        {
            //Settovanje default datuma i minimalnog datuma
            datePickPrijava.MinDate = DateTime.Now;
            datePickOdjava.MinDate = DateTime.Now.AddDays(minimumDana);
                
            //Punjenje Comboboxeva
            ComboTipNapuni();
            ComboSobeNapuni();
            ComboGostiNapuni();

            comboTip.SelectedIndex = 0;

            //Setovanje forme za azuriranje
            if(poziv == Poziv.AZURIRAJ)
            {
                datePickPrijava.MinDate = izabranaRezervacija.DatumPrijave;

                int tipPom = (int)izabranaRezervacija.TipRezervacije;
                //Setovanje polja
                datePickPrijava.Value = izabranaRezervacija.DatumPrijave;
                datePickOdjava.Value = izabranaRezervacija.DatumOdjave;
                comboTip.SelectedIndex = tipPom;
                comboGost.SelectedIndex = comboGost.FindStringExact(nadjiGosta().ToString());
                try 
                { 
                comboSoba.SelectedIndex = comboSoba.FindStringExact(nadjiSobu().ToString());
                }
                catch { }
            }

            //Dodavanje u combobox za filtriranje tipa Sobe
            comboTipFilter.Items.Add(TipSobe.Standard);
            comboTipFilter.Items.Add(TipSobe.Lux);
            comboTipFilter.Items.Add("Sve");
            comboTipFilter.SelectedIndex = 2;
        }

        private Gost nadjiGosta()
        {
            /*
             * pronalazi i
             * vraca Gosta koji se nalazi u 
             * izabranoj Rezervaciji 
             * za azuriranje
             */
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fs = new FileStream("gosti.dat",FileMode.Open);
            List<Gost> list = new List<Gost>();
            list = formatter.Deserialize(fs) as List<Gost>;
            fs.Dispose();

            int broj = 1;
            foreach (Gost g in list)
            {
                if (g.IdGosta == izabranaRezervacija.IdGosta)
                {
                    return g;
                    break;
                }

            }
            return list[0];
        }

        private Soba nadjiSobu()
        {
            /*
             * pronalazi i
             * vraca Sobu koja se nalazi u 
             * izabranoj Rezervaciji 
             * za azuriranje
             * preko IdSobe
             */
            BinaryFormatter formatter = new BinaryFormatter();
            List<Soba> list = new List<Soba>();

            foreach (Soba s in comboSoba.Items)
            {
                if (s.IdSobe == izabranaRezervacija.IdSobe)
                {
                    return s;
                    break;
                }

            }
            return null;
        }

        private void ComboTipNapuni()
        {
            /*
             * Puni combobox za tip rezervacije-pun, polu, dorucak
             * vraca void
             */
            comboTip.Items.Add(TipRezervacije.PunPansion);
            comboTip.Items.Add(TipRezervacije.PoluPansion);
            comboTip.Items.Add(TipRezervacije.SamoDorucak);
        }

        private void ComboSobeNapuni()
        {
            /*
             * Puni combo za sobe
             * vrsi filtriranje soba prema datumu
             * vraca void
             * 
             */
            string nazivfajla = "sobe.dat";
            BinaryFormatter binary = new BinaryFormatter();
            if (File.Exists(nazivfajla))
            {
                //Ucitavanje soba
                FileStream fileStream = new FileStream(nazivfajla, FileMode.Open);
                List<Soba> sobe = new List<Soba>();
                sobe = binary.Deserialize(fileStream) as List<Soba>;
                fileStream.Dispose();

                //Ucitavanje rezervacija
                string naziv2 = "rezervacije.dat";
                fileStream = new FileStream(naziv2, FileMode.Open);

                List<Rezervacija> rezervacijas = new List<Rezervacija>();
                rezervacijas = binary.Deserialize(fileStream) as List<Rezervacija>;

                fileStream.Dispose();
                try
                {
                    System.Diagnostics.Debug.WriteLine("Prosao");
                    //Provera dostupnosti soba za datume
                    for(int i = 0; i < sobe.Count; i++)
                    {
                        Soba s = sobe[i];
                        for (int j = 0; j < rezervacijas.Count; j++)
                        {
                            if (s.IdSobe == rezervacijas.ElementAt(j).IdSobe)
                            {
                                if (!((datumPrijave <= rezervacijas.ElementAt(j).DatumPrijave ||
                                    datumPrijave > rezervacijas.ElementAt(j).DatumOdjave) &&
                                    (datumOdjave < rezervacijas.ElementAt(j).DatumPrijave ||
                                    datumOdjave >= rezervacijas.ElementAt(j).DatumOdjave) 

                                    )//|| (rezervacijas[j].IdRezervacije != izabranaRezervacija.IdRezervacije)
                                     )
                                {
                                    if ((izabranaRezervacija == null || 
                                        rezervacijas[j].IdRezervacije != izabranaRezervacija.IdRezervacije))
                                    {
                                        sobe.RemoveAt(i);
                                        i--;
                                    }
                                }

                            }

                        }

                    }

                    //Provera filtera
                    int brkFilter = (int)filterBrKreveta.Value;
                    int tipFilter = comboTipFilter.SelectedIndex;
                    
                    /*
                     * Primena izabranih filtera
                     */
                    if(brkFilter!=0 || tipFilter != 2)//Ovaj red je radi neke optimizacije
                    {
                        for (int i = 0; i < sobe.Count; i++)
                        {
                            Soba s = sobe[i];
                            //Provera broja kreveta
                            if(brkFilter != 0 &&
                                s.BrojKreveta != brkFilter 
                                )
                            {
                                sobe.RemoveAt(i);
                                i--;
                            }
                            //Provera tipa sobe
                            if( tipFilter != 2 &&
                                s.TipSobe != (TipSobe)comboTipFilter.SelectedItem
                                )
                            {
                                sobe.RemoveAt(i);
                                i--;
                            }

                        }
                    }
                }
                catch { System.Diagnostics.Debug.WriteLine("Catchovan"); }
                comboSoba.DataSource = null;
                comboSoba.DataSource = sobe;

                
            }
            else
                comboSoba.DataSource = null;
        }

        private void ComboGostiNapuni()
        {
            string nazivfajla = "gosti.dat";
            BinaryFormatter binary = new BinaryFormatter();
            if (File.Exists(nazivfajla))
            {
                FileStream fileStream = new FileStream(nazivfajla, FileMode.Open);
                List<Gost> gosts = new List<Gost>();
                try { 
                    gosts = binary.Deserialize(fileStream) as List<Gost>;
                }
                catch
                {
                    System.Console.WriteLine("Prazan Stream");
                }

                comboGost.Items.Clear();

                foreach(Gost gost in gosts)
                {
                    comboGost.Items.Add(gost);
                }
                comboGost.Items.Add(DODAJ_GOSTA);
                /*
                 * Biranjem DODAJ_GOSTA itema
                 * otvara se forma za Dodavanje gosta
                 */

                fileStream.Dispose();
            }
            else
                comboGost.Items.Add(DODAJ_GOSTA);
            
        }

        
        private void datePickPrijava_ValueChanged(object sender, EventArgs e)
        {
            /*
             * Menja se datum za odjavu
             * puni se combobox slobodnim sobama
             */
            
            datePickOdjava.MinDate = datePickPrijava.Value.AddDays(minimumDana);
            datumPrijave = this.datePickPrijava.Value;
            datumOdjave = this.datePickOdjava.Value;
            ComboSobeNapuni();
        }
        private void datePickOdjava_ValueChanged(object sender, EventArgs e)
        {
            /*
             * Puni sobe
             * Racuna ukupnu cenu
             */
            datumPrijave = this.datePickPrijava.Value;
            datumOdjave = this.datePickOdjava.Value;
            ComboSobeNapuni();
            RacunajUkupnuCenu();
        }

        private void btnOtkazi_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*
             * Osluskuje da li korisnik zeli
             * da doda novg gosta
             */
            if (comboGost.SelectedItem.Equals(DODAJ_GOSTA))
            {
                /*
                 * Kreiranje dugmeta radi prosledjivanja
                 * konstruktoru GostForme
                 */
                Button btn = new Button();
                btn.Text = "Dodaj";

                GostForma gostForm = new GostForma(btn);
                gostForm.ShowDialog();
                ComboGostiNapuni();
            }
        }

        private void btnSacuvaj_Click(object sender, EventArgs e)
        {
            //Izbor operacije na osnovu dugmeta koje je pozvalo formu
            switch(poziv)
            {
                case Poziv.DODAJ:
                    //Dodavanje Rezervacije
                    dodajRezervaciju();
                    break;

                case Poziv.AZURIRAJ:
                    //Azuriranje Rezervacije
                    azurirajRezervaciju();
                    break;
            }
        }

        private void dodajRezervaciju()
        {
            /*
             * Dodaje novu rezervacij
             * refreshuje datoteku
             */
            string nazivfajla = "rezervacije.dat";
            if (File.Exists(nazivfajla))
            {
                BinaryFormatter binary = new BinaryFormatter();
                FileStream fileStream = new FileStream(nazivfajla, FileMode.Open);
                List<Rezervacija> rezervacijas = new List<Rezervacija>();
                rezervacijas = binary.Deserialize(fileStream) as List<Rezervacija>;
                fileStream.Dispose();

                //Dodavanje rezervacije

                datumPrijave = this.datePickPrijava.Value;
                datumOdjave = this.datePickOdjava.Value;

                if (this.comboSoba.SelectedItem!=null &&
                    this.comboTip.SelectedItem!=null &&
                    this.comboGost.SelectedItem!=null
                    )
                {
                    int idIzabraneSobe = (this.comboSoba.SelectedItem as Soba).IdSobe;
                    int idIzabranogGosta = (this.comboGost.SelectedItem as Gost).IdGosta;
                    TipRezervacije izabraniTip = (TipRezervacije)comboTip.SelectedItem;
                    
                    rezervacijas.Add(new Rezervacija(idIzabraneSobe,
                                                     idIzabranogGosta,
                                                     datumPrijave,
                                                     datumOdjave,
                                                     izabraniTip));
                    this.Close();
                }
                else
                    MessageBox.Show("UNESITE SVE PODATKE VALIDNO!", "Greška!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                //UPDATE FILE-a

                fileStream = new FileStream(nazivfajla, FileMode.Create);
                binary.Serialize(fileStream, rezervacijas);
                fileStream.Dispose();

            }
        }
        private void azurirajRezervaciju()
        {
            /*
             * Azurira izabranu Rezervaciju
             * refreshuje datoteku
             */
            string nazivfajla = "rezervacije.dat";
            if (File.Exists(nazivfajla))
            {
                BinaryFormatter binary = new BinaryFormatter();
                FileStream fileStream = new FileStream(nazivfajla, FileMode.Open);
                List<Rezervacija> rezervacijas = new List<Rezervacija>();
                rezervacijas = binary.Deserialize(fileStream) as List<Rezervacija>;
                fileStream.Dispose();

                //Azuriranje rezervacije

                datumPrijave = this.datePickPrijava.Value;
                datumOdjave = this.datePickOdjava.Value;

                if (this.comboSoba.SelectedItem != null &&
                    this.comboTip.SelectedItem != null &&
                    this.comboGost.SelectedItem != null
                    )
                {
                    int idIzabraneSobe = (this.comboSoba.SelectedItem as Soba).IdSobe;
                    int idIzabranogGosta = (this.comboGost.SelectedItem as Gost).IdGosta;
                    TipRezervacije izabraniTip = (TipRezervacije)comboTip.SelectedItem;

                    foreach(Rezervacija rez in rezervacijas)
                    {
                        if(rez.IdRezervacije == izabranaRezervacija.IdRezervacije)
                        {
                            rez.TipRezervacije = izabraniTip;
                            rez.DatumPrijave = datumPrijave;
                            rez.DatumOdjave = datumOdjave;
                            rez.IdGosta = idIzabranogGosta;
                            rez.IdSobe = idIzabraneSobe;
                        }
                    }
                    this.Close();
                }
                else
                    MessageBox.Show("UNESITE SVE PODATKE VALIDNO!", "Greška!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                //UPDATE FILE-a

                fileStream = new FileStream(nazivfajla, FileMode.Create);
                binary.Serialize(fileStream, rezervacijas);
                fileStream.Dispose();

            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*
             * Osluskuje promenu sobe i pomera
             * minimalan datum za odjavu na osnovu 
             * datuma prijave i minimalnog broja dana za datu sobu
             */
            int dani=0;
            try
            {
                dani = (comboSoba.SelectedItem as Soba).MinimalnoDana;
            }
            catch
            {
                dani = 1;
            }
            datePickOdjava.MinDate = datePickPrijava.Value.AddDays(dani);
            //datePickOdjava.Value = datePickPrijava.Value.AddDays(dani);
            RacunajUkupnuCenu();
        }

        private void RacunajUkupnuCenu()
        {
            /*
             * Racuna ukupnu cenu za izabran broj dana
             * mnozi sa cenom po danu u sobi
             */
            try
            {
                double cenaDan = (comboSoba.SelectedItem as Soba).Cena;
                int BrDana = (datePickOdjava.Value - datePickPrijava.Value).Days;

                txtUkCena.Text = (BrDana * cenaDan).ToString();
            }
            catch
            {
                txtUkCena.Text = "0";
            }
            
        }

        private void filterBrKreveta_ValueChanged(object sender, EventArgs e)
        {
            /*
             * Primenjuje filter na promenu vrednosti
             * Broj Kreveta
             */
            ComboSobeNapuni();
        }

        private void comboTipFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*
             * Primenjuje filter na promenu vrednosti 
             * Tip Sobe
             */
            ComboSobeNapuni();
        }
    }
}
