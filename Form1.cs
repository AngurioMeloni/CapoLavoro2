﻿using System;
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
using Newtonsoft.Json;
using static CapoLavoro2.Form1;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Diagnostics;

namespace CapoLavoro2
{
        #region Form1
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
            tabControl.Dock = DockStyle.Fill;

            // Create three TabPages
            TabPage tabPage1 = new TabPage("Profilo Pista");
            TabPage tabPage2 = new TabPage("Profilo Sciatore");
            TabPage tabPage3 = new TabPage("Classifica");

            // Add the TabPages to the TabControl
            tabControl.TabPages.Add(tabPage1);
            tabControl.TabPages.Add(tabPage2);
            tabControl.TabPages.Add(tabPage3);

            // Add the TabControl to the form
            this.Controls.Add(tabControl);

            listView1.Hide();
            listView2.Hide();
            listView3.Hide();
            // Hide all TextBoxes, Labels, and Buttons
            foreach (Control control in this.Controls)
            {
                if (control is System.Windows.Forms.TextBox || control is Label || control is System.Windows.Forms.Button)
                {
                    control.Visible = false;
                }
            }

            // Handle the SelectedIndexChanged event
            tabControl.SelectedIndexChanged += (s, e) =>
            {
                // Hide all TextBoxes, Labels, and Buttons
                foreach (Control control in this.Controls)
                {
                    if (control is System.Windows.Forms.TextBox || control is Label || control is System.Windows.Forms.Button)
                    {
                        control.Visible = false;
                    }
                }

                listView1.Hide();
                listView2.Hide();
                listView3.Hide();

                // Check if tabPage1 is selected
                if (tabControl.SelectedTab == tabPage1)
                {
                    textBox1.Show();
                    textBox2.Show();
                    textBox3.Show();
                    textBox4.Show();
                    textBox5.Show();
                    label1.Show();
                    label2.Show();
                    label3.Show();
                    label4.Show();
                    label5.Show();
                    label6.Show();
                    button1.Show();
                    button2.Show();
                    button3.Show();
                    button4.Show();
                    listView1.Show();
                }
                else if (tabControl.SelectedTab == tabPage2)
                {
                    textBox6.Show();
                    textBox7.Show();
                    textBox8.Show();
                    textBox9.Show();
                    textBox10.Show();
                    textBox11.Show();
                    textBox12.Show();
                    label7.Show();
                    label8.Show();
                    label9.Show();
                    label10.Show();
                    label11.Show();
                    label12.Show();
                    label13.Show();
                    label14.Show();
                    button5.Show();
                    button6.Show();
                    button7.Show();
                    button8.Show();
                    listView2.Show();
                }
                else if (tabControl.SelectedTab == tabPage3)
                {
                    button9.Show();
                    button10.Show();
                    button11.Show();
                    listView3.Show();
                }
            };
 
        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }
        #endregion

        #region Classi
        public class Pista
        {
            public float TempoMassimo { get; set; }
            public float TempoMinimo { get; set; }
            public int NumeroPettoraliTotali { get; set; }
            public string TipoGara { get; set; }
            public int Codice { get; set; }

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

            public Sciatore(string nome, string cognome, int eta, string categoria, int numeroPettorale, string sesso, float tempoDiscesa, int codicePista, int punti)
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
        public class Gara
        {
            public int CodicePista { get; set; }
            public List<Sciatore> Partecipanti { get; set; }
            public List<Sciatore> Classifica { get; set; }

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
            public string StampaGaraInJson()
            {
                List<Gara> gare = new List<Gara>();
                
                // Ottieni tutti i codici pista univoci dagli sciatori iscritti
                var codiciPista = Sciatori.Select(s => s.CodicePista).Distinct();

                foreach (int codice in codiciPista)
                {
                    // Filtra gli sciatori per codice pista
                    var partecipanti = Sciatori.Where(s => s.CodicePista == codice).ToList();

                    // Ordina gli sciatori per tempo di discesa per creare la classifica
                    var classifica = partecipanti.OrderBy(s => s.TempoDiscesa).ToList();
                    // Crea un nuovo oggetto Gara
                    var gara = new Gara
                    {
                        CodicePista = codice,
                        Partecipanti = partecipanti,
                        Classifica = classifica,
                    };

                    gare.Add(gara);
                }

                // Converte la lista di gare in una stringa JSON
                string json = JsonConvert.SerializeObject(gare, Formatting.Indented);
                System.IO.File.WriteAllText("file.json", json);

                return json;
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
        {// Raggruppa gli sciatori per codice pista
            var sciatoriPerPista = gestioneSciatori.Sciatori.GroupBy(s => s.CodicePista);

            // Prepara la ListView
            listView3.Items.Clear();
            listView3.Columns.Clear();
            listView3.View = View.Details;
            listView3.Columns.Add("Gara").Width = 70;
            listView3.Columns.Add("Posizione").Width = 70;
            listView3.Columns.Add("Nome").Width = 120;
            listView3.Columns.Add("Cognome").Width = 120;
            listView3.Columns.Add("Tempo Discesa").Width = 120;
            listView3.Columns.Add("Punti").Width = 70;

            int gara = 1;

            foreach (var gruppo in sciatoriPerPista)
            {
                // Ordina gli sciatori del gruppo in base al tempo di discesa (in ordine ascendente)
                var sciatoriOrdinati = gruppo.OrderBy(s => s.TempoDiscesa).ToList();

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

                for (int i = 0; i < sciatoriOrdinati.Count; i++)
                {
                    ListViewItem item = new ListViewItem(gara.ToString());
                    item.SubItems.Add((i + 1).ToString());
                    item.SubItems.Add(sciatoriOrdinati[i].Nome);
                    item.SubItems.Add(sciatoriOrdinati[i].Cognome);
                    item.SubItems.Add(sciatoriOrdinati[i].TempoDiscesa.ToString());
                    item.SubItems.Add(sciatoriOrdinati[i].Punti.ToString());

                    listView3.Items.Add(item);
                }

                gara++;
            }

            MessageBox.Show("Classifica aggiornata correttamente");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string json = gestioneSciatori.StampaGaraInJson();
            MessageBox.Show("Json Creato Correttamente");

        }

        private void button11_Click(object sender, EventArgs e)
        {
            StringBuilder html = new StringBuilder();

            html.AppendLine("<!DOCTYPE html>");
            html.AppendLine("<html>");
            html.AppendLine("<head>");
            html.AppendLine("<title>My Website</title>");
            html.AppendLine("</head>");
            html.AppendLine("<body>");
            html.AppendLine("<h1>Welcome to my website!</h1>");
            html.AppendLine("<h2>Classifiche delle gare</h2>");
            html.AppendLine("<table border='1'>");
            html.AppendLine("<tr>");
            html.AppendLine("<th>Posizione</th>");
            html.AppendLine("<th>Nome</th>");
            html.AppendLine("<th>Tempo</th>");
            html.AppendLine("<th>Numero Pettorale</th>");
            html.AppendLine("</tr>");

            // Inserisci qui le righe della classifica
            foreach (var gara in gare)
            {
                html.AppendLine("<tr>");
                html.AppendLine("<td>" + gara.Posizione + "</td>");
                html.AppendLine("<td>" + gara.Nome + "</td>");
                html.AppendLine("<td>" + gara.Tempo + "</td>");
                html.AppendLine("<td>" + gara.NumeroPettorale + "</td>");
                html.AppendLine("</tr>");
            }

            html.AppendLine("</table>");
            html.AppendLine("</body>");
            html.AppendLine("</html>");

            File.WriteAllText("website.html", html.ToString());
            Process.Start("website.html");
        }
    }
}
#endregion
