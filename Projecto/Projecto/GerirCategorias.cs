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
    public partial class GerirCategorias : Form
    {
        string categories = "categories.txt";
        public GerirCategorias()
        {
            InitializeComponent();
        }

        private void GerirCategorias_Load(object sender, EventArgs e)
        {
           
            // carrega as categorias para a listbox
            string categories = @"categories.txt";
            if (File.Exists(categories))
            {
                StreamReader sr = File.OpenText(categories);
                string linha;
                while ((linha = sr.ReadLine()) != null)
                {
                    listBoxCategories.Items.Add(linha);
                }
                sr.Close();
                
            }
        }

        private void btnAddCategoria_Click(object sender, EventArgs e)
        {
            string categories = @"categories.txt";
            
            if(txtCategoria.Text == "")
            {
                MessageBox.Show("Não inseriu nenhuma categoria");
            }
            else
            {
                listBoxCategories.Items.Add(txtCategoria.Text);
                MessageBox.Show("Categoria Adicionada");
            }
            txtCategoria.Text = "";

           

            // Guarda para o ficheiro
            StreamWriter sw = File.CreateText(categories);
            int num = listBoxCategories.Items.Count;

            for(int i = 0; i < num; i++)
            {
                string linha = listBoxCategories.Items[i].ToString();
                sw.WriteLine(linha);
            }
            sw.Close();
        }

        //Remove da ListBox
        private void btnRemoveCategoria_Click(object sender, EventArgs e)
        {
            txtCategoria.Text = listBoxCategories.SelectedIndex.ToString();
            listBoxCategories.Items.Remove(listBoxCategories.SelectedItem);

            

            using(FileStream fs = new FileStream(categories, FileMode.Create, FileAccess.Write))
            {
                using (TextWriter tw = new StreamWriter(fs))
                    foreach (string item in listBoxCategories.Items)
                        tw.WriteLine(item);
            }
        }

       

        
    }
}
