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
    public partial class Registo : Form
    {
        public Registo()
        {
            InitializeComponent();
        }

        private void btnBackLogin_Click(object sender, EventArgs e)
        {
            Login openLogin = new Login();
            openLogin.Show();
            Visible = false;
        }

        private void btnRegist_Click(object sender, EventArgs e)
        {
            string users = @"users.txt";
            // localização do ficheiro
            StreamWriter sw;
            // verifica se o ficheiro existe
            if (File.Exists(users))
            {
                //Verifica se há campos por preencher
                if((txtName.Text == "") || (txtEmail.Text == "") || (txtPass.Text == "")|| (txtUserName.Text == ""))
                {
                    MessageBox.Show("Não pode deixar campos por preencher");
                }
                else if((txtName.Text != "") && (txtEmail.Text != "") && (txtPass.Text != "") && (txtUserName.Text != ""))  // se os campos nao tiverem vazios
                {
                    StreamReader sr = File.OpenText(users);
                    string linha = "";
                    while((linha = sr.ReadLine()) != null)
                    {
                        int pos = linha.IndexOf(";");  // le ate ao ponto e virgula no txt
                        // Verifica se já existe um utilizador com o mesmo nome de utilizador
                        if(txtUserName.Text == linha.Substring(0, pos))
                        {
                            MessageBox.Show("Nome de utilizador indisponivel");
                        }
                    }
                    sr.Close();
                    // Se não exister ninguem , abre o ficheiro
                    using (sw = File.AppendText(users))
                    {
                        //Escreve uma linha no ficheiro txt com as informações do user
                        sw.WriteLine(txtUserName.Text + ";" + txtName.Text + ";" + txtEmail.Text + ";" + txtPass.Text);
                        sw.Close();
                        MessageBox.Show("Registo Efetuado com Sucesso");
                    }
                    sr.Close();
                }
            }
            else // se nao existir 
            {
                //Verifica se existe algum campo em branco
                if((txtUserName.Text == null) ||(txtName.Text == null) || (txtEmail.Text == null) ||(txtPass.Text == null))
                {
                    MessageBox.Show("Deixou algum espaço em branco.");
                    
                }
                else if ((txtName.Text != null) && (txtEmail.Text != null) && (txtPass.Text != null) && (txtUserName.Text != null))
                {
                    //Se o ficheiro nao existir cria-se um
                    using(sw = File.CreateText(users))
                    {
                        // Escreve a linha com as informaçoes do user
                        sw.WriteLine(txtUserName.Text + ";" + txtName.Text + ";" + txtEmail.Text + ";" + txtPass.Text);
                        sw.Close();
                        MessageBox.Show("Registo Efetuado");
                    }
                }

            }
        }
    }
}
