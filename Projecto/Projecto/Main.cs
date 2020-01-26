using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projecto
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            label2.Text = people.username; // nome do label do main é igual ao user logado

            if(label2.Text != "admin")
            {
                adminToolStripMenuItem.Visible = false;
            }
            else
            {
                adminToolStripMenuItem.Visible = true;
            }
        }

        private void gerirCategoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GerirCategorias openCategorias = new GerirCategorias();
            openCategorias.Show();
            
        }

        private void gerirReceitasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GerirReceitas openReceitas = new GerirReceitas();
            openReceitas.Show();
            
        }

        private void catálogoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Catalogo openCatalogo = new Catalogo();
            openCatalogo.Show();
            this.Hide();
        }

        private void perfilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Perfil openPerfil = new Perfil();
            openPerfil.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void topReceitasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ranking openRanking = new Ranking();
            openRanking.Show();
        }
    }
}
