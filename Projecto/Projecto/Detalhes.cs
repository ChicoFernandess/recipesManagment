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


        public string nome1;

        
        

        

        public Detalhes()
        {
            InitializeComponent();
           
            
            
            
            
            // tive de retirar o que estava aqui porque estava a fazer conflito e nao dava load aos conteudos
           

            
        }

        private void Detalhes_Load(object sender, EventArgs e)
        {
            // LOAD DAS VIEWS //
            int numero = 0;

            // para conseguir ler o titulo noutro form
            
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




            //string points = @"points.txt";

            //if (File.Exists(points))
            //{
            //    StreamReader sr1 = File.OpenText(points);
            //    string linha1 = "";

            //    while ((linha1 = sr1.ReadLine()) != null)
            //    {

            //        int pos = linha1.IndexOf(";");
            //        int pos2 = linha1.LastIndexOf(";");
            //        int fim = linha1.Length;
            //        int fim2 = fim - pos2;

            //        if(lblTitle.Text == linha1.Substring(pos2, fim2)) // se o titulo nos detalhes for o mesmo que esta na ultima posicao do txt ( que é o titulo da receita )
            //        {

            //            num = Convert.ToInt32(linha1.Substring(0, pos));
            //            lblPoints.Text = num.ToString();
            //            break;
            //        }



            //    }
            //    sr1.Close();

            //}

            //////////////////////////////////// PONTUACAO DA RECEITA /////////////////////////////////////////
            int num = 0; // para os pontos

            string nome1 = lblTitle.Text + "points" + ".txt";

            if (File.Exists(nome1))  // alterar os patchs das views
            {
                StreamReader sr = File.OpenText(nome1);
                num = Convert.ToInt32(sr.ReadLine());

                sr.Close();
            }
            
            lblPoints.Text = num.ToString(); // numero.tostring porque numero é um int e precisa de ser convertido



            // Deixar o botao disable caso o user já tenha pontuado aquela receita
            if (File.Exists(@"points.txt"))
            {
                StreamReader s4 = File.OpenText(@"points.txt");
                string linha = "";
                while((linha = s4.ReadLine()) != null)
                {
                    int pos = linha.IndexOf(";"); // verificar se o nome do user esta no ficheiro
                    int pos2 = linha.LastIndexOf(";") + 1; // verifica se o nome da receita esta no ficheiro
                    int fim = linha.Length;
                    int fim2 = fim - pos2;

                    if(people.username == linha.Substring(0,pos) && lblTitle.Text == linha.Substring(pos2, fim2))
                    {
                        btnPontuar.Enabled = false;
                    }

                    else
                    {
                        btnPontuar.Enabled = true;
                    }
                }
                s4.Close();
            }




            // LOAD DOS COMENTARIOS NA LISTBOX //
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


        // pontuar receita
        private void btnPontuar_Click(object sender, EventArgs e)
        {
            

            int num = 0; // para os pontos

            string nome1 = lblTitle.Text + "points" + ".txt";

            if (File.Exists(nome1))
            {
                StreamReader sr = File.OpenText(nome1);
                num = Convert.ToInt32(sr.ReadLine());

                sr.Close();
            }
            // views ao dar load soma 1
            num += Convert.ToInt32(numericPoints.Text);

            // soma ao 0 que esta inicializado +1

            lblPoints.Text = num.ToString(); // numero.tostring porque numero é um int e precisa de ser convertido



            // ficheiro txt criado para contrar as views da receita vai estar sempre a ser criado porque a cada vez que um user entra no detalhe a view soma +1
            StreamWriter sw = File.CreateText(nome1);

            sw.WriteLine(lblPoints.Text);

            sw.Close();



            // cria outro ficheiro de pontos
            string points = @"points.txt";
            StreamWriter sw3;

            if (File.Exists(points))
            {
               StreamReader sr3 = File.OpenText(points);
                

           
                sr3.Close();
                
                using (sw3 = File.AppendText(points))
                {
                    
                    sw3.WriteLine(people.username + ";" + numericPoints.Text + ";" + lblCategoria.Text + ";" + lblTitle.Text);
                    sw3.Close();
                    MessageBox.Show("Pontuado!");
                }
                sr3.Close();


            }

            else
            {
                // ficheiro txt criado para contar os pontos da receita
                using (sw3 = File.CreateText(points))
                {
                    sw3.WriteLine(people.username + ";" + numericPoints.Text + ";" + lblCategoria.Text + ";" + lblTitle.Text);

                    sw3.Close();
                }

                

            }




            btnPontuar.Enabled = false;

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

