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
    public partial class Detalhes : Form
    {

        
        

        

        public Detalhes()
        {
            InitializeComponent();
           
            
            
            
            
            // tive de retirar o que estava aqui porque estava a fazer conflito e nao dava load aos conteudos
           

            
        }

        private void Detalhes_Load(object sender, EventArgs e)
        {

            int numero = 0;
            MessageBox.Show("aqui");
            string nome = lblTitle.Text + "views" + ".txt";

            if(File.Exists(nome))
            {
                StreamReader sr = File.OpenText(nome);
                numero = Convert.ToInt32(sr.ReadLine());

                sr.Close();
            }
            // views ao dar load soma 1
            numero++;
           
             // soma ao 0 que esta inicializado +1

            lblNumViews.Text = numero.ToString(); // numero.tostring porque numero é um int e precisa de ser convertido


            
            // ficheiro txt criado para contrar as views da receita vai estar sempre a ser criado porque a cada vez que um user entra no detalhe a view soma +1
                StreamWriter sw = File.CreateText(lblTitle.Text + "views" + ".txt");

                sw.WriteLine(lblNumViews.Text);

                sw.Close();

         /*
            // acho que nao preciso deste porque o de cima vai dar overwrite sempre que atualiza
            if(File.Exists(lblTitle.Text + "views" + ".txt"))
            {
                StreamReader sr = File.OpenText(lblTitle.Text + "views" + ".txt");
                string linha;
                while((linha = sr.ReadLine()) != null)
                {
                    lblNumViews.Text = linha.ToString();
                }
                sr.Close();
            }*/
                
            







            string coments = lblTitle.Text + ".txt";
          //  int pos = coments.IndexOf('.');
            //coments = coments.Substring(0, pos) + ".txt";

          //  if(lblTitle.Text == coments)

            if(File.Exists(lblTitle.Text + ".txt"))
            {
                StreamReader sr = File.OpenText(lblTitle.Text + ".txt");
                string linha;
                while((linha = sr.ReadLine()) != null)
                {
                    listBoxComentarios.Items.Add(linha);
                }
                sr.Close();
            }
        }

        

        

        // comentar
        private void btnComentar_Click(object sender, EventArgs e)
        {
            MessageBox.Show(textBox1.Text);              
            string comment = people.username + "|" + DateTime.Now.ToString("yyyy-MM-dd") + ":" + textBox1.Text;

            listBoxComentarios.Items.Add(comment);

            StreamWriter sw = File.CreateText(lblTitle.Text + ".txt");
            int num = listBoxComentarios.Items.Count;

            for(int i = 0; i < num; i++)
            {
                string linha = listBoxComentarios.Items[i].ToString();
                sw.WriteLine(linha);
            }
            sw.Close();
            
        }

        private void lblTime_Click(object sender, EventArgs e)
        {

        }


        // fazer o mesmo que fiz para o comentar 
        private void btnPontuar_Click(object sender, EventArgs e)
        {
            string points = @"points.txt";
            StreamWriter sw;

            if (File.Exists(points))
            {
                if(txtPoints.Text == "")
                {
                    MessageBox.Show("deixou o campo em branco");
                }

                else if(txtPoints.Text != "")
                {
                    StreamReader sr = File.OpenText(points);
                    string linha = "";
                    while((linha = sr.ReadLine()) != null)
                    {
                        int pos = linha.IndexOf(";");

                        if (people.username == linha.Substring(0, pos) && lblTitle.Text == linha.Substring(pos, pos + 1)) // verifica se o user ja esta no txt e se o nome da receita é o mesmo
                        {
                            MessageBox.Show("Já pontuaste uma vez");
                        }
                    }
                    sr.Close();


                    using (sw = File.AppendText(points))
                    {
                        //Escreve uma linha no ficheiro txt com as informações do user
                        sw.WriteLine(people.username + ";" + lblTitle.Text + ";" + txtPoints.Text);
                        sw.Close();
                        MessageBox.Show("Pontuação registada");
                    }
                    sr.Close();

                }


            }
            else
            {
                if(txtPoints.Text == null)
                {
                    MessageBox.Show("Deixou um espaço em branco");
                }
                else if(txtPoints.Text != null )
                {
                    //Se o ficheiro nao existir cria-se um
                    using (sw = File.CreateText(points))
                    {
                        // Escreve a linha com as informaçoes da pontuaçao (user que deu a pontuaçao, titulo da receita e pontuaçao)
                        sw.WriteLine(people.username + ";" + lblTitle.Text + ";" + txtPoints.Text);
                        sw.Close();
                        MessageBox.Show("Pontuacao Registada");
                    }
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        // botao para adicionar a receita aos favoritos cria um file txt com o nome do user que esta online
        private void btnFav_Click(object sender, EventArgs e)
        {



            if (File.Exists(people.username + ".txt"))   // sem isto o user ao adicionar aos favoritos vai sempre dar overwrite à receita primeiramente adicionada
            {
                

                 
                    StreamReader sr = File.OpenText(people.username + ".txt");
                    string linha = "";
                    while ((linha = sr.ReadLine()) != null)
                    {
                        int pos = linha.IndexOf(";");

                        if (people.username == linha.Substring(0, pos) && lblTitle.Text == linha.Substring(pos, pos + 1)) // verifica se o user ja esta no txt e se o nome da receita é o mesmo
                        {
                            MessageBox.Show("Já pontuaste uma vez");
                        }
                    }
                    sr.Close();


                    using (StreamWriter sw1 = File.AppendText(people.username + ".txt"))
                    {
                        //Escreve uma linha no ficheiro txt com as informações do user
                        sw1.WriteLine(lblTitle.Text + ";" + lblTime.Text + ";" + lblCategoria.Text + ";" + lblIng.Text + ";" + lblPrep.Text);
                        sw1.Close();
                        MessageBox.Show("Receita adicionada aos favoritos");
                    }
                    sr.Close();

                }


            else
            {


                // ficheiro txt dos favoritos do utilizador vai ter o nome do user para quando der load no perfil saber diferenciar
                StreamWriter sw = File.CreateText(people.username + ".txt");

                sw.WriteLine(lblTitle.Text + ";" + lblTime.Text + ";" + lblCategoria.Text + ";" + lblIng.Text + ";" + lblPrep.Text);

                sw.Close();
                MessageBox.Show("Receita Adicionada aos favoritos");
            }


        }





            
        }
    }

