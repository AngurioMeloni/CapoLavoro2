using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static CapoLavoro2.Form1;

namespace CapoLavoro2
{
    public partial class Form1 : Form
    {
        private GestionePiste gestionePiste = new GestionePiste();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
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
    }
}
