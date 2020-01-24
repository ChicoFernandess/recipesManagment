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
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(340, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Gerir Categorias";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(77, 146);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Categoria :";
            // 
            // txtCategoria
            // 
            this.txtCategoria.Location = new System.Drawing.Point(161, 146);
            this.txtCategoria.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCategoria.Name = "txtCategoria";
            this.txtCategoria.Size = new System.Drawing.Size(161, 22);
            this.txtCategoria.TabIndex = 2;
            // 
            // btnAddCategoria
            // 
            this.btnAddCategoria.Location = new System.Drawing.Point(196, 207);
            this.btnAddCategoria.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAddCategoria.Name = "btnAddCategoria";
            this.btnAddCategoria.Size = new System.Drawing.Size(83, 23);
            this.btnAddCategoria.TabIndex = 3;
            this.btnAddCategoria.Text = "Adicionar";
            this.btnAddCategoria.UseVisualStyleBackColor = true;
            this.btnAddCategoria.Click += new System.EventHandler(this.btnAddCategoria_Click);
            // 
            // listBoxCategories
            // 
            this.listBoxCategories.FormattingEnabled = true;
            this.listBoxCategories.ItemHeight = 16;
            this.listBoxCategories.Location = new System.Drawing.Point(477, 144);
            this.listBoxCategories.Margin = new System.Windows.Forms.Padding(4);
            this.listBoxCategories.Name = "listBoxCategories";
            this.listBoxCategories.Size = new System.Drawing.Size(159, 196);
            this.listBoxCategories.TabIndex = 4;
            // 
            // btnRemoveCategoria
            // 
            this.btnRemoveCategoria.Location = new System.Drawing.Point(496, 367);
            this.btnRemoveCategoria.Margin = new System.Windows.Forms.Padding(4);
            this.btnRemoveCategoria.Name = "btnRemoveCategoria";
            this.btnRemoveCategoria.Size = new System.Drawing.Size(100, 28);
            this.btnRemoveCategoria.TabIndex = 7;
            this.btnRemoveCategoria.Text = "Remover";
            this.btnRemoveCategoria.UseVisualStyleBackColor = true;
            this.btnRemoveCategoria.Click += new System.EventHandler(this.btnRemoveCategoria_Click);
            // 
            // GerirCategorias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnRemoveCategoria);
            this.Controls.Add(this.listBoxCategories);
            this.Controls.Add(this.btnAddCategoria);
            this.Controls.Add(this.txtCategoria);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "GerirCategorias";
            this.Text = "GerirCategorias";
            this.Load += new System.EventHandler(this.GerirCategorias_Load);
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
    }
}