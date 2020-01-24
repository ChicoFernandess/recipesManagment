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
    public partial class Perfil : Form
    {
        public Perfil()
        {
            InitializeComponent();
        }

        private void Perfil_Load(object sender, EventArgs e)
        {
            lblUser.Text = people.username; // usar este lbl para carregar os favoritos do user

            if(File.Exists(people.username + ".txt"))
            {
                StreamReader sr = File.OpenText(people.username + ".txt");

                string linha = "";
                int x = 0;
                while ((linha = sr.ReadLine()) != null)
                {
                    string[] campos = linha.Split(';');
                    dataGridfav.Rows.Add(1);
                    dataGridfav[0, x].Value = campos[0];
                    dataGridfav[1, x].Value = campos[1];
                    dataGridfav[2, x].Value = campos[2];
                    dataGridfav[3, x].Value = campos[3];
                    dataGridfav[4, x].Value = campos[4];  // coluna do modo de preparaçao invisivel
                    

                    x++;

                }
                sr.Close();
            }
        }

        // remove a receita dos favoritos
        private void btnRemoveFav_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewRow row in dataGridfav.SelectedRows)
            {
                if (!row.IsNewRow) dataGridfav.Rows.Remove(row);
            }

            using (FileStream fs = new FileStream(people.username + ".txt", FileMode.Create, FileAccess.Write))
            {
                using (TextWriter tw = new StreamWriter(fs))
                    foreach (DataGridViewRow row in dataGridfav.SelectedRows)
                    {
                        if (!row.IsNewRow) dataGridfav.Rows.Remove(row);
                        tw.WriteLine(row);
                    }
                
            }
        }
    }
}
