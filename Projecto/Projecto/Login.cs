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
    public partial class Login : System.Windows.Forms.Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string users = @"users.txt";
            StreamWriter sw;
            if (File.Exists(users))
            {
                //não faz nada
            }
            else
            {
                sw = File.CreateText(users);
                sw.WriteLine("admin;Admin;admin@admin;admin");
                sw.Close();
            }
        }

        private void btnRegisto_Click(object sender, EventArgs e)
        {
            Registo openRegisto = new Registo();
            openRegisto.Show();
            Visible = false;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string users = @"users.txt";
            if (File.Exists(users))
            {
                // abre o ficheiro
                StreamReader sr = File.OpenText(users);
                string linha = "";
                // lê sempre o ficheiro até a uma linha sem conteudo
                while((linha = sr.ReadLine()) != null)
                {
                    // veririfca a posicao do primeiro ";" para ver se o user está no ficheiro
                    int pos = linha.IndexOf(";");
                    //Verifica se já existe um user com o nome na textbox
                    if(txtUserName.Text == linha.Substring(0, pos))
                    {
                        // ir à posicao do ultimo ";" para ver a password ( a nossa password esta no ultimo lugar da linha )
                        int pos2 = linha.LastIndexOf(";") + 1;
                        int fim = linha.Length;
                        //Número de caracteres que vão desde o último ";" até ao fim da linha
                        int fim2 = fim - pos2;
                        // Confirma se a password está certa
                        if(txtPass.Text == linha.Substring(pos2, fim2))
                        {
                            people.username = txtUserName.Text;  // consegue sempre ir buscar o valor independetemente da pagina porque esta no Program.cs
                            MessageBox.Show("Bem vindo" + txtUserName.Text);
                            Main openMain = new Main();
                            openMain.Show();
                            this.Hide();
                            // usar o break para parar de procurar no loop do if porque ja encontrou user
                            break;
                        }
                        else
                        {
                            MessageBox.Show("Passoword incorreta");
                        }
                    }

                   
                }

                // se o nome de utilizador nao existir
                if (linha == null)
                {
                    MessageBox.Show("Utilizador nao registado");
                }

                sr.Close();
            }
        }
    }
}
