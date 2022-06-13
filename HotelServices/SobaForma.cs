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
    public partial class SobaForma : Form
    {
        Button pozivalac;
        Soba izabranaSoba;
        enum Poziv { DODAJ, AZURIRAJ };
        Poziv poziv;
        public SobaForma(Button pozivalac)
        {
            /*
             * Konstruktor za dodavanje Sobe
             * prihvata dugme koje poziva formu zbog izbora moda
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
        }        
        public SobaForma(Button pozivalac,Soba izabranaSoba)
        {
            /*
             * Konstruktor za azuriranje Sobe
             * prihvata dugme koje poziva formu zbog izbora moda
             * prihvata sobu za azuriranje
             */
            this.pozivalac = pozivalac;
            this.izabranaSoba = izabranaSoba;

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

        private void btnOtkazi_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSacuvaj_Click(object sender, EventArgs e)
        {
            /*
             * Dodavanje ili azuriranje Sobe
             */
            switch (poziv)
            {
                case Poziv.DODAJ:
                    //Dodavanje Sobe
                    dodajSobu();
                    break;

                case Poziv.AZURIRAJ:
                    //Azuriranje Sobe
                    azurirajSobu();
                    break;
            }
        }

        private void azurirajSobu()
        {   
            /*
             * Funkcija za azuriranje sobe
             * refresh datoteke
            */
            string nazivfajla = "sobe.dat";
            if (File.Exists(nazivfajla))
            {
                BinaryFormatter binary = new BinaryFormatter();
                FileStream fileStream = new FileStream(nazivfajla, FileMode.Open);
                List<Soba> sobas = new List<Soba>();
                sobas = binary.Deserialize(fileStream) as List<Soba>;
                fileStream.Dispose();

                //Azuriranje rezervacije

                if (Int32.TryParse(txtBrojSobe.Text, out int brSobe) &&
                    Double.TryParse(txtCena.Text, out double cena) &&
                    Double.TryParse(txtPopust.Text, out double popust) &&
                    ProveriBrSobe()
                    )
                {
                    foreach(Soba s in sobas)
                    {
                        if (s.IdSobe == izabranaSoba.IdSobe)
                        {
                            s.TipSobe = (TipSobe)comboBox1.SelectedItem;
                            s.BrojSobe = brSobe;
                            s.MinimalnoDana = (int)numMinDana.Value;
                            s.Cena = cena;
                            s.Popust = popust;
                            s.BrojKreveta = (int)numBrKreveta.Value;
                            break;
                        }
                    }
                    this.Close();
                }
                else
                    MessageBox.Show("UNESITE SVE PODATKE VALIDNO!", "Greška!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                //UPDATE FILE-a

                fileStream = new FileStream(nazivfajla, FileMode.Create);
                binary.Serialize(fileStream, sobas);
                fileStream.Dispose();
            }
        }

        private void dodajSobu()
        {
            /*
             * Funkcija za dodavanje sobe
             * refresh datoteke
             */
            string nazivfajla = "sobe.dat";
            if (File.Exists(nazivfajla))
            {
                BinaryFormatter binary = new BinaryFormatter();
                FileStream fileStream = new FileStream(nazivfajla, FileMode.Open);
                List<Soba> sobas = new List<Soba>();
                sobas = binary.Deserialize(fileStream) as List<Soba>;
                fileStream.Dispose();

                //Dodavanje rezervacije

                if (Int32.TryParse(txtBrojSobe.Text, out int brSobe) &&
                    Double.TryParse(txtCena.Text, out double cena) &&
                    Double.TryParse(txtPopust.Text, out double popust) &&
                    ProveriBrSobe()
                    )
                {
                    sobas.Add(new Soba(brSobe,
                                        (int)numBrKreveta.Value,
                                        (TipSobe)comboBox1.SelectedItem,
                                        cena,
                                        popust,
                                        (int)numMinDana.Value
                                         ));
                    this.Close();
                }
                else
                    MessageBox.Show("UNESITE SVE PODATKE VALIDNO!", "Greška!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                //UPDATE FILE-a

                fileStream = new FileStream(nazivfajla, FileMode.Create);
                binary.Serialize(fileStream, sobas);
                fileStream.Dispose();
            }
        }

        private void SobaForma_Load(object sender, EventArgs e)
        {
            //Punjenje comboboxa tipovima sobe
            comboBox1.Items.Add(TipSobe.Standard);
            comboBox1.Items.Add(TipSobe.Lux);
            comboBox1.SelectedIndex = 1;

            //ubacivanje podataka u slucaju azuriranja
            if(poziv == Poziv.AZURIRAJ)
            {
                this.txtBrojSobe.Text = izabranaSoba.BrojSobe.ToString();
                this.numBrKreveta.Value = izabranaSoba.BrojKreveta;
                this.comboBox1.SelectedIndex = (int)izabranaSoba.TipSobe;
                this.txtCena.Text = izabranaSoba.Cena.ToString();
                this.txtPopust.Text = izabranaSoba.Popust.ToString();
                this.numMinDana.Value = izabranaSoba.MinimalnoDana;
            }
        }        

        private bool ProveriBrSobe()
        {
            /*
             * vraca bool
             * proverava da li postoji upisani broj sobe negde vec
             * ne dozvoljava 2 ista broja sobe
             * vraca true ako ne postoji br sobe
             * vraca false ako postoji br sobe
             */
            string nazivfajla = "sobe.dat";
            if (File.Exists(nazivfajla))
            {
                Int32.TryParse(txtBrojSobe.Text, out int brS);
                BinaryFormatter binary = new BinaryFormatter();
                FileStream fileStream = new FileStream(nazivfajla, FileMode.Open);
                List<Soba> sobas = new List<Soba>();
                sobas = binary.Deserialize(fileStream) as List<Soba>;
                fileStream.Dispose();

                foreach (Soba s in sobas)
                {
                    //provera broja sobe
                    //ne vazi za sobu ako se azurira
                    if (s.BrojSobe == brS &&
                        ( izabranaSoba != null &&
                        s.BrojSobe != izabranaSoba.BrojSobe))
                        return false;
                }
            }
            return true;
        }

        private void txtBrojSobe_TextChanged(object sender, EventArgs e)
        {
            /*
             * Poziva proveru broja sobe
             */
            if (!ProveriBrSobe() || 
                txtBrojSobe==null ||
                txtBrojSobe.Text.Trim() == "")
            {
                txtBrojSobe.BackColor = Color.FromArgb(255, 200, 200);
            }
            else
            {
                txtBrojSobe.BackColor = Color.FromArgb(200, 255, 200);
            }
        }
    }    
} 

