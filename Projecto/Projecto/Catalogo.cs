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
    public partial class Catalogo : Form
    {
        string receitas = @"receitas.txt";
        StreamReader sr;


        public Catalogo()
        {
            InitializeComponent();

        }

        private void Catalogo_Load(object sender, EventArgs e)
        {

            

            //Carregar o ficheiro txt receitas na dataGrid (titulo , tempo , categoria , ingredientes )
            
            if (File.Exists(receitas))
            {
                sr = File.OpenText(receitas);
                string linha = "";
                int x = 0;
                while((linha = sr.ReadLine()) != null)
                {
                    string[] campos = linha.Split(';');
                    dataGridReceitas.Rows.Add(1);
                    dataGridReceitas[0, x].Value = campos[0];
                    dataGridReceitas[1, x].Value = campos[1];
                    dataGridReceitas[2, x].Value = campos[2];
                    dataGridReceitas[3, x].Value = campos[3];
                    dataGridReceitas[4, x].Value = campos[4];  // coluna do modo de preparaçao invisivel
                    dataGridReceitas[5, x].Value = campos[5];

                    x++;



                  
                   

                }
                sr.Close();
            }

            // Carregar ficheiro txt categorias na combobox
            string categories = @"categories.txt";
            StreamReader sr1;
            //confirma se existe o ficheiro categories txt
            if (File.Exists(categories))
            {
                //se existir coloca as categorias na combo
                sr1 = File.OpenText(categories);
                string linha1;
                while ((linha1 = sr1.ReadLine()) != null)
                {
                    comboBoxCategorias.Items.Add(linha1);
                }
                sr1.Close();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // Procura pela categoria da receita
          if(txtTitulo.Text == "" && txtIngredientes.Text == "")
          {

            dataGridReceitas.Rows.Clear();// limpar a tabela para só ficar com os resultados pretendidos
            
             if (File.Exists(receitas))
             { // combox selecionada sem as duas caixas de texto
                sr = File.OpenText(receitas);
                string linha2 = "";
                int x = 0;
                while ((linha2 = sr.ReadLine()) != null)
                {
                    string[] campos2 = linha2.Split(';');

                        if (comboBoxCategorias.SelectedItem.ToString() == campos2[2])
                        {
                            dataGridReceitas.Rows.Add(1); // acrescentas mais uma linha para a aplicaçao nao crashar
                            dataGridReceitas[0, x].Value = campos2[0];
                            dataGridReceitas[1, x].Value = campos2[1];
                            dataGridReceitas[2, x].Value = campos2[2];
                            dataGridReceitas[3, x].Value = campos2[3];
                            dataGridReceitas[4, x].Value = campos2[4];
                            dataGridReceitas[5, x].Value = campos2[5];
                            x++;
                        }

                    
                }
                sr.Close();
             }
          }


          // Procura pelo titulo da receita
            else if (txtTitulo.Text != "" && txtIngredientes.Text == "")
            {
                dataGridReceitas.Rows.Clear();
                
                if (File.Exists(receitas))
                {
                    sr = File.OpenText(receitas);
                    string linha = "";
                    int x1 = 0;
                    while ((linha = sr.ReadLine()) != null)
                    {
                        string[] campos = linha.Split(';');
                        if (txtTitulo.Text == campos[0])
                        {
                            dataGridReceitas.Rows.Add(1);
                            dataGridReceitas[0, x1].Value = campos[0];
                            dataGridReceitas[1, x1].Value = campos[1];
                            dataGridReceitas[2, x1].Value = campos[2];
                            dataGridReceitas[3, x1].Value = campos[3];
                            dataGridReceitas[4, x1].Value = campos[4];
                            dataGridReceitas[5, x1].Value = campos[5];

                            x1++;
                        }
                    }
                    sr.Close();
                    
                }

            }
          //Procura pelos ingredientes
           else if(txtTitulo.Text == "" && txtIngredientes.Text != "")
            {
                dataGridReceitas.Rows.Clear();

                if (File.Exists(receitas))
                {
                    sr = File.OpenText(receitas);
                    string linha = "";
                    int x = 0;
                    while((linha = sr.ReadLine()) != null)
                    {
                        string[] campos = linha.Split(';');
                        
                        
                        if(txtIngredientes.Text == campos[3])
                        {
                            
                            dataGridReceitas.Rows.Add(1);
                            dataGridReceitas[0, x].Value = campos[0];
                            dataGridReceitas[1, x].Value = campos[1];
                            dataGridReceitas[2, x].Value = campos[2];
                            dataGridReceitas[3, x].Value = campos[3];
                            dataGridReceitas[4, x].Value = campos[4];
                            dataGridReceitas[5, x].Value = campos[5];

                            x++;
                        }
                    }
                    sr.Close();
                }
            }

        }// end


        // clica duas vezes na row e vai para outro form com as informaçoes mais detalhadas da receita (mod preparacao e imagem estao na tabela mas escondidos)
        private void dataGridReceitas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
            Detalhes openDetalhes = new Detalhes();
            openDetalhes.lblTitle.Text = this.dataGridReceitas.CurrentRow.Cells[0].Value.ToString();
            openDetalhes.lblTime.Text = this.dataGridReceitas.CurrentRow.Cells[1].Value.ToString();
            openDetalhes.lblCategoria.Text = this.dataGridReceitas.CurrentRow.Cells[2].Value.ToString();
            openDetalhes.lblIng.Text = this.dataGridReceitas.CurrentRow.Cells[3].Value.ToString();
            openDetalhes.lblPrep.Text = this.dataGridReceitas.CurrentRow.Cells[4].Value.ToString();
            openDetalhes.pictureBox1.ImageLocation = this.dataGridReceitas.CurrentRow.Cells[5].Value.ToString();
            openDetalhes.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Main openMain = new Main();
            openMain.Show();
            this.Hide();
        }
    }

        
    
}
