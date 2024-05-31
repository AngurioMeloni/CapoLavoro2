using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static CapoLavoro2.Form1;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CapoLavoro2
{
    public partial class Form1 : Form
    {
        private GestionePiste gestionePiste = new GestionePiste();
        private GestioneSciatori gestioneSciatori = new GestioneSciatori();
        private float tempoMassimo;
        private float tempoMinimo;
        private float tempoDiscesa;
        private string Nome;
        private string Cognome;
        private int Eta;
        private string Categoria;
        private int NumeroPettorale;
        private string Sesso;
        private int CodicePista;
        private int Punti;
        private float TempoDiscesa;
        public Form1()
        {
            InitializeComponent();
            // Create a new TabControl
            TabControl tabControl = new TabControl();

            // Create three TabPages
            TabPage tabPage1 = new TabPage("Pista");
            TabPage tabPage2 = new TabPage("Sciatore");
            TabPage tabPage3 = new TabPage("Classifica");

            // Add the TabPages to the TabControl
            tabControl.TabPages.Add(tabPage1);
            tabControl.TabPages.Add(tabPage2);
            tabControl.TabPages.Add(tabPage3);
     

            // Add the TabControl to the form
            this.Controls.Add(tabControl);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        #region Classi
        public class Pista
        {
            public float TempoMassimo { get; set; }
            public float TempoMinimo { get; set; }
            public int NumeroPettoraliTotali { get; set; }
            public string TipoGara { get; set; }
            public int Codice { get; set;}

            public Pista(float tempoMassimo, float tempoMinimo, int numeroPettoraliTotali, string tipoGara, int codice)
            {
                TempoMassimo = tempoMassimo;
                TempoMinimo = tempoMinimo;
                NumeroPettoraliTotali = numeroPettoraliTotali;
                TipoGara = tipoGara;
                Codice = codice;
            }
        }
        public class Sciatore
        {
            public string Nome { get; set; }
            public string Cognome { get; set; }
            public int Eta { get; set; }
            public string Categoria { get; set; }
            public int NumeroPettorale { get; set; }
            public string Sesso { get; set; }
            public int CodicePista { get; set; }
            public int Punti { get; set; }
            public float TempoDiscesa { get; set; }

            public Sciatore(string nome, string cognome, int eta, string categoria, int numeroPettorale, string sesso, float tempoDiscesa,int codicePista,int punti)
            {
                Nome = nome;
                Cognome = cognome;
                Eta = eta;
                Categoria = categoria;
                NumeroPettorale = numeroPettorale;
                Sesso = sesso;
                TempoDiscesa = tempoDiscesa; 
                CodicePista = codicePista;
                Punti = punti;
            }
        }
        #endregion

        #region GestionePiste
        public class GestionePiste
        {
            private List<Pista> piste = new List<Pista>();

            public List<Pista> Piste
            {
                get { return piste; }
            }

            public void AggiungiPista(Pista pista)
            {
                piste.Add(pista);
            }

            public void RimuoviPista(int codice)
            {
                var pistaDaRimuovere = piste.FirstOrDefault(p => p.Codice == codice);
                if (pistaDaRimuovere != null)
                {
                    piste.Remove(pistaDaRimuovere);
                }
            }
            public void ModificaPista(Pista pistaModificata)
            {
                var pistaDaModificare = piste.FirstOrDefault(p => p.Codice == pistaModificata.Codice);
                if (pistaDaModificare != null)
                {
                    pistaDaModificare.TempoMassimo = pistaModificata.TempoMassimo;
                    pistaDaModificare.TempoMinimo = pistaModificata.TempoMinimo;
                    pistaDaModificare.NumeroPettoraliTotali = pistaModificata.NumeroPettoraliTotali;
                    pistaDaModificare.TipoGara = pistaModificata.TipoGara;
                }
            }

        }
        #endregion

        #region GestioneSciatori
        public class GestioneSciatori
        {
            private List<Sciatore> sciatori = new List<Sciatore>();

            public List<Sciatore> Sciatori
            {
                get { return sciatori; }
            }

            public void AggiungiSciatore(Sciatore sciatore)
            {
                sciatori.Add(sciatore);
            }

            public void RimuoviSciatore(int numeroPettorale)
            {
                var sciatoreDaRimuovere = sciatori.FirstOrDefault(s => s.NumeroPettorale == numeroPettorale);
                if (sciatoreDaRimuovere != null)
                {
                    sciatori.Remove(sciatoreDaRimuovere);
                }
            }

            public void ModificaSciatore(Sciatore sciatoreModificato)
               
            {
                var sciatoreDaModificare = sciatori.FirstOrDefault(s => s.NumeroPettorale == sciatoreModificato.NumeroPettorale);
                if (sciatoreDaModificare != null)
                {
                    sciatoreDaModificare.Nome = sciatoreModificato.Nome;
                    sciatoreDaModificare.Cognome = sciatoreModificato.Cognome;
                    sciatoreDaModificare.Eta = sciatoreModificato.Eta;
                    sciatoreDaModificare.Categoria = sciatoreModificato.Categoria;
                    sciatoreDaModificare.Sesso = sciatoreModificato.Sesso;
                    sciatoreDaModificare.CodicePista = sciatoreModificato.CodicePista;
                    sciatoreDaModificare.TempoDiscesa = sciatoreModificato.TempoDiscesa;
                }               
                         
            }
        }
        #endregion

        #region Buttons
        private void button1_Click(object sender, EventArgs e)
        {
            // Crea una nuova pista dai valori dei TextBox
            var pista = new Pista(
                float.Parse(textBox1.Text),
                float.Parse(textBox2.Text),
                int.Parse(textBox3.Text),
                textBox4.Text,
                int.Parse(textBox5.Text)
            );

            if (textBox5.Text.Length == 6)
            {
                gestionePiste.AggiungiPista(pista);
                tempoMassimo = float.Parse(textBox1.Text);
                tempoMinimo = float.Parse(textBox2.Text);

                MessageBox.Show("Pista aggiunta correttamente");
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
            }
            else
            {
                MessageBox.Show("Il codice deve essere di 6 cifre.");
            }
        }
    
        private void button3_Click(object sender, EventArgs e)
        {
            // Prendi il codice dalla TextBox e convertilo in un intero
            var codice = int.Parse(textBox5.Text);

            // Rimuovi la pista
            gestionePiste.RimuoviPista(codice);

            MessageBox.Show("Pista rimossa correttamente");
            textBox5.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            listView1.Columns.Clear();
            listView1.View = View.Details;
            listView1.Columns.Add("Tempo Massimo").Width = 120;
            listView1.Columns.Add("Tempo Minimo").Width = 120;
            listView1.Columns.Add("Numero Partecipanti").Width = 120;
            listView1.Columns.Add("Tipo di Gara").Width = 120;
            listView1.Columns.Add("Codice").Width = 120;
            foreach (var pista in gestionePiste.Piste)
            {
                ListViewItem item = new ListViewItem(pista.TempoMassimo.ToString());
                item.SubItems.Add(pista.TempoMinimo.ToString());
                item.SubItems.Add(pista.NumeroPettoraliTotali.ToString());
                item.SubItems.Add(pista.TipoGara);
                item.SubItems.Add(pista.Codice.ToString());

                listView1.Items.Add(item);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            // Crea una nuova pista dai valori dei TextBox
            var pista = new Pista(
                float.Parse(textBox1.Text),
                float.Parse(textBox2.Text),
                int.Parse(textBox3.Text),
                textBox4.Text,
                int.Parse(textBox5.Text)
            );

            // Modifica la pista
            gestionePiste.ModificaPista(pista);

            MessageBox.Show("Pista modificata correttamente");
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Assumendo che tu abbia TextBox con questi nomi nel tuo form
            string nome = textBox6.Text;
            string cognome = textBox7.Text;
            int eta = int.Parse(textBox8.Text);
            string categoria = textBox9.Text;
            int numeroPettorale = int.Parse(textBox11.Text);
            string sesso = textBox10.Text;
            int codicePista = int.Parse(textBox12.Text);
            int punti = 0;

            Console.WriteLine(codicePista);

            // Genera un tempo di discesa casuale tra 30 e 120 secondi
            Random random = new Random();
            float tempoDiscesa = random.Next(int.Parse(tempoMinimo.ToString()), int.Parse(tempoMassimo.ToString()));

            Sciatore sciatore = new Sciatore(nome, cognome, eta, categoria, numeroPettorale, sesso, tempoDiscesa, codicePista, punti);
            gestioneSciatori.AggiungiSciatore(sciatore);

            MessageBox.Show("Sciatore aggiunto correttamente");
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();
            textBox12.Clear();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            // Assumendo che tu abbia un TextBox con questo nome nel tuo form
            int numeroPettorale = int.Parse(textBox11.Text);

            gestioneSciatori.RimuoviSciatore(numeroPettorale);

            textBox11.Clear();
            MessageBox.Show("Sciatore rimosso correttamente");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // Crea un nuovo oggetto Sciatore con i valori delle textbox
            // Crea un nuovo sciatore dai valori dei TextBox
            Random random = new Random();
            var sciatoreModificato = new Sciatore(Nome, Cognome, Eta, Categoria, NumeroPettorale, Sesso, TempoDiscesa, CodicePista, Punti)
            {
                Nome = textBox6.Text,
                Cognome = textBox7.Text,
                Eta = int.Parse(textBox8.Text),
                Categoria = textBox9.Text,
                NumeroPettorale = int.Parse(textBox11.Text),
                Sesso = textBox10.Text,
                CodicePista = int.Parse(textBox12.Text),
                Punti = 0,
                TempoDiscesa = random.Next(int.Parse(tempoMinimo.ToString()), int.Parse(tempoMassimo.ToString()))

            };

            // Chiama la funzione di modifica

            if (textBox12.Text.Length == 6)
            {
                // Modifica lo sciatore
                gestioneSciatori.ModificaSciatore(sciatoreModificato);

                MessageBox.Show("Sciatore modificato correttamente");
                textBox6.Clear();
                textBox7.Clear();
                textBox8.Clear();
                textBox9.Clear();
                textBox10.Clear();
                textBox11.Clear();
                textBox12.Clear();
            }
            else
            {
                MessageBox.Show("Il codice gara deve avere almeno 6 cifre");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            listView2.Items.Clear();
            listView2.Columns.Clear();
            listView2.View = View.Details;
            listView2.Columns.Add("Nome").Width = 120;
            listView2.Columns.Add("Cognome").Width = 120;
            listView2.Columns.Add("Età").Width = 120;
            listView2.Columns.Add("Categoria").Width = 120;
            listView2.Columns.Add("Numero Pettorale").Width = 120;
            listView2.Columns.Add("Sesso").Width = 120;
            listView2.Columns.Add("Tempo Discesa").Width = 120;
            listView2.Columns.Add("Codice Pista").Width = 120;
            foreach (var sciatore in gestioneSciatori.Sciatori)
            {
                ListViewItem item = new ListViewItem(sciatore.Nome);
                item.SubItems.Add(sciatore.Cognome);
                item.SubItems.Add(sciatore.Eta.ToString());
                item.SubItems.Add(sciatore.Categoria);
                item.SubItems.Add(sciatore.NumeroPettorale.ToString());
                item.SubItems.Add(sciatore.Sesso);
                item.SubItems.Add(sciatore.TempoDiscesa.ToString());
                item.SubItems.Add(sciatore.CodicePista.ToString());

                listView2.Items.Add(item);
            }
        }
        private void button9_Click(object sender, EventArgs e)
        {
            // Ordina la lista di sciatori in base al tempo di discesa (in ordine ascendente)
            var sciatoriOrdinati = gestioneSciatori.Sciatori.OrderBy(s => s.TempoDiscesa).ToList();

            // Assegna i punti in base alla posizione
            for (int i = 0; i < sciatoriOrdinati.Count; i++)
            {
                switch (i)
                {
                    case 0:
                        sciatoriOrdinati[i].Punti = 25;
                        break;
                    case 1:
                        sciatoriOrdinati[i].Punti = 18;
                        break;
                    case 2:
                        sciatoriOrdinati[i].Punti = 15;
                        break;
                    case 3:
                        sciatoriOrdinati[i].Punti = 12;
                        break;
                    case 4:
                        sciatoriOrdinati[i].Punti = 10;
                        break;
                    case 5:
                        sciatoriOrdinati[i].Punti = 8;
                        break;
                    case 6:
                        sciatoriOrdinati[i].Punti = 6;
                        break;
                    case 7:
                        sciatoriOrdinati[i].Punti = 4;
                        break;
                    case 8:
                        sciatoriOrdinati[i].Punti = 2;
                        break;
                    case 9:
                        sciatoriOrdinati[i].Punti = 1;
                        break;
                    default:
                        sciatoriOrdinati[i].Punti = 0;
                        break;
                }
            }


            // Aggiorna la visualizzazione
            listView2.Items.Clear();
            listView2.Columns.Clear();
            listView2.View = View.Details;
            listView2.Columns.Add("Posizione").Width = 70;
            listView2.Columns.Add("Nome").Width = 120;
            listView2.Columns.Add("Cognome").Width = 120;
            listView2.Columns.Add("Tempo Discesa").Width = 120;
            listView2.Columns.Add("Punti").Width = 70;
            for (int i = 0; i < sciatoriOrdinati.Count; i++)
            {
                ListViewItem item = new ListViewItem((i + 1).ToString());
                item.SubItems.Add(sciatoriOrdinati[i].Nome);
                item.SubItems.Add(sciatoriOrdinati[i].Cognome);
                item.SubItems.Add(sciatoriOrdinati[i].TempoDiscesa.ToString());
                item.SubItems.Add(sciatoriOrdinati[i].Punti.ToString());

                listView2.Items.Add(item);
            }

            MessageBox.Show("Classifica aggiornata correttamente");
        }
    }
}
#endregion
