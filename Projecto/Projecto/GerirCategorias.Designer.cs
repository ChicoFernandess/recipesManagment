namespace Projecto
{
    partial class GerirCategorias
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCategoria = new System.Windows.Forms.TextBox();
            this.btnAddCategoria = new System.Windows.Forms.Button();
            this.listBoxCategories = new System.Windows.Forms.ListBox();
            this.btnRemoveCategoria = new System.Windows.Forms.Button();
            this.btnShowCategorias = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(255, 46);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Gerir Categorias";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(58, 119);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Categoria :";
            // 
            // txtCategoria
            // 
            this.txtCategoria.Location = new System.Drawing.Point(121, 119);
            this.txtCategoria.Margin = new System.Windows.Forms.Padding(2);
            this.txtCategoria.Name = "txtCategoria";
            this.txtCategoria.Size = new System.Drawing.Size(122, 20);
            this.txtCategoria.TabIndex = 2;
            // 
            // btnAddCategoria
            // 
            this.btnAddCategoria.Location = new System.Drawing.Point(147, 168);
            this.btnAddCategoria.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddCategoria.Name = "btnAddCategoria";
            this.btnAddCategoria.Size = new System.Drawing.Size(62, 19);
            this.btnAddCategoria.TabIndex = 3;
            this.btnAddCategoria.Text = "Adicionar";
            this.btnAddCategoria.UseVisualStyleBackColor = true;
            this.btnAddCategoria.Click += new System.EventHandler(this.btnAddCategoria_Click);
            // 
            // listBoxCategories
            // 
            this.listBoxCategories.FormattingEnabled = true;
            this.listBoxCategories.Location = new System.Drawing.Point(358, 117);
            this.listBoxCategories.Name = "listBoxCategories";
            this.listBoxCategories.Size = new System.Drawing.Size(120, 160);
            this.listBoxCategories.TabIndex = 4;
            // 
            // btnRemoveCategoria
            // 
            this.btnRemoveCategoria.Location = new System.Drawing.Point(372, 298);
            this.btnRemoveCategoria.Name = "btnRemoveCategoria";
            this.btnRemoveCategoria.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveCategoria.TabIndex = 7;
            this.btnRemoveCategoria.Text = "Remover";
            this.btnRemoveCategoria.UseVisualStyleBackColor = true;
            this.btnRemoveCategoria.Click += new System.EventHandler(this.btnRemoveCategoria_Click);
            // 
            // btnShowCategorias
            // 
            this.btnShowCategorias.Location = new System.Drawing.Point(361, 75);
            this.btnShowCategorias.Name = "btnShowCategorias";
            this.btnShowCategorias.Size = new System.Drawing.Size(109, 23);
            this.btnShowCategorias.TabIndex = 8;
            this.btnShowCategorias.Text = "Mostrar Categorias";
            this.btnShowCategorias.UseVisualStyleBackColor = true;
            this.btnShowCategorias.Click += new System.EventHandler(this.btnShowCategorias_Click);
            // 
            // GerirCategorias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.btnShowCategorias);
            this.Controls.Add(this.btnRemoveCategoria);
            this.Controls.Add(this.listBoxCategories);
            this.Controls.Add(this.btnAddCategoria);
            this.Controls.Add(this.txtCategoria);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "GerirCategorias";
            this.Text = "GerirCategorias";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCategoria;
        private System.Windows.Forms.Button btnAddCategoria;
        private System.Windows.Forms.ListBox listBoxCategories;
        private System.Windows.Forms.Button btnRemoveCategoria;
        private System.Windows.Forms.Button btnShowCategorias;
    }
}