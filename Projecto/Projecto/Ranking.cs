using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projecto
{
    public partial class Ranking : Form
    {

        string receitas = @"receitas.txt";
        string points = @"points.txt";

        public Ranking()
        {
            InitializeComponent();
        }

        

        private void Ranking_Load(object sender, EventArgs e)
        {

            // Load das receitas txt na datagrid mas apenas o nome da receita
            if (File.Exists(receitas))
            {
                StreamReader sr = File.OpenText(receitas);
                string linha = "";
                int i = 0; // mudar a linha da datagrid
                
                while((linha = sr.ReadLine()) != null)
                {
                    int pos = linha.IndexOf(";");

                    dataGridView1.Rows.Add(1);
                    dataGridView1[0, i].Value = linha.Substring(0,pos); // só quero que aparece o nome da receita entao tenho de ir buscar o elemente até ao primeiro ;
                    i++;
                }
                sr.Close();
            }

          


            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < dataGridView1.Rows.Count; i++) // vai ver linha a linha da datagrid das receitas
            {
                // ver se esta alguam linha selected
                if(dataGridView1.Rows[i].Selected == true)
                {
                    if (File.Exists(points))
                    {
                        dataGridView2.Rows.Clear();
                        StreamReader sr = File.OpenText(points);
                        string linha = "";
                        int j = 0;
                        
                        while((linha = sr.ReadLine()) != null)
                        {
                            string[] campos = linha.Split(';');
                            if(campos[3] == dataGridView1[0, i].Value.ToString())  // vai ao nosso ultimo valor no ficheiro points (que é o nome da receita) e compara com a outra datagridview
                            {
                                dataGridView2.Rows.Add(1);
                                dataGridView2[0, j].Value = campos[0];
                                dataGridView2[1, j].Value = campos[1];
                                dataGridView2[2, j].Value = campos[2];
                                

                                j++;
                            }
                        }
                        sr.Close();
                    }
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
