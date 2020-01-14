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
            label2.Text = people.username;

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
            this.Hide();
        }

        private void gerirReceitasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GerirReceitas openReceitas = new GerirReceitas();
            openReceitas.Show();
            this.Hide();
        }
    }
}
