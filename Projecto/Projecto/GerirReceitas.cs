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
    public partial class GerirReceitas : Form
    {
        
        public GerirReceitas()
        {
            InitializeComponent();
        }

        // dar Load do ficheiro txt com as categorias para a combobox
        private void GerirReceitas_Load(object sender, EventArgs e)
        {
            string categories = @"categories.txt";
            StreamReader sr;
            //confirma se existe o ficheiro categories txt
            if (File.Exists(categories))
            {
                //se existir coloca as categorias na combo
                sr = File.OpenText(categories);
                string linha;
                while ((linha = sr.ReadLine()) != null)
               {
                   comboCategorias.Items.Add(linha);
                }
                sr.Close();
            }

            // carrega as receitas para a listbox
            string receitas = @"receitas.txt";
            if (File.Exists(receitas))
            {
                StreamReader sr1 = File.OpenText(receitas);
                string linha;
                while ((linha = sr1.ReadLine()) != null)
                {
                    listBoxReceitas.Items.Add(linha);
                }
                sr1.Close();

            }
        }


        // dar upload a uma imagem para a picturebox (no size meti zoom para aparecer a foto)
        private void btnUpload_Click(object sender, EventArgs e)
        {
            String imageLocation = "";
            try
            {
                OpenFileDialog openPicture = new OpenFileDialog();
                openPicture.Filter = "jpg files(*.jpg)|*.jpg| PNG files|*.png| All Files(*.*)|*.*";

                if(openPicture.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    imageLocation = openPicture.FileName;

                    pictureBox1.ImageLocation = imageLocation;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ocorreu um erro");
            }
        }

        private void btnSaveReceita_Click(object sender, EventArgs e)
        {
            string receitas = @"receitas.txt";
            // localização do ficheiro
            StreamWriter sw;
            // Verifica se o ficheiro existe
            if (File.Exists(receitas))
            {
                // Verifica se ha campos por preencher
                if ((txtNomeReceita.Text == "") || (txtPreparacao.Text == "") || (txtTempo.Text == ""))
                {
                    MessageBox.Show("Não pode deixar campos por preencher");
                }
                else if ((txtNomeReceita.Text != "") && (txtPreparacao.Text != "") && (txtTempo.Text != ""))
                {
                    StreamReader sr = File.OpenText(receitas);
                    string linha = "";
                    // Se não exister ninguem , abre o ficheiro
                    sr.Close(); // tive de meter este close se nao ao registar dizia que o ficheiro ja estava a ser processado
                    using (sw = File.AppendText(receitas))
                    {
                        //Escreve uma linha no ficheiro txt com as informações da receita
                        sw.WriteLine(txtNomeReceita.Text + ";" +  txtTempo.Text + ";" + comboCategorias.SelectedItem.ToString() + ";" + txtIngredientes.Text + ";" + txtPreparacao.Text + ";" + pictureBox1.ImageLocation);
                        sw.Close();
                        MessageBox.Show("Receita Registada");
                    }
                    sr.Close();
                }
            }
            else // se nao existir 
            {
                // Verifica se existe algum campo em branco
                if((txtNomeReceita.Text == null) || (txtPreparacao.Text == null) || (txtTempo.Text == null))
                {
                    MessageBox.Show("Deixou algum espaço em branco");
                }
                else if((txtNomeReceita.Text != null) && (txtPreparacao.Text != null) && (txtTempo.Text != null))
                {
                    // se o ficheiro nao existir cria-o
                    using(sw = File.CreateText(receitas))
                    {
                        // escreve na linha as informaçoes da receita
                        sw.WriteLine(txtNomeReceita.Text + ";" + txtTempo.Text + ";" + comboCategorias.SelectedItem.ToString() + ";" + txtIngredientes.Text + ";" + txtPreparacao.Text + ";" + pictureBox1.ImageLocation);
                        sw.Close();
                        MessageBox.Show("Receita Registada");
                    }
                    
                }
            }
        }
    }
}
