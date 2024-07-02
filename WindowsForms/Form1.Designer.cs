namespace WindowsForms
{
    partial class F_Principal
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(F_Principal));
            this.add = new System.Windows.Forms.Button();
            this.lb = new System.Windows.Forms.Label();
            this.lista = new System.Windows.Forms.TextBox();
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.inputName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // add
            // 
            this.add.BackColor = System.Drawing.SystemColors.Highlight;
            this.add.Cursor = System.Windows.Forms.Cursors.Hand;
            this.add.ForeColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.add, "add");
            this.add.Name = "add";
            this.add.UseVisualStyleBackColor = false;
            this.add.Click += new System.EventHandler(this.button1_Click);
            // 
            // lb
            // 
            resources.ApplyResources(this.lb, "lb");
            this.lb.Name = "lb";
            this.lb.Click += new System.EventHandler(this.label1_Click);
            // 
            // lista
            // 
            this.lista.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.lista, "lista");
            this.lista.Name = "lista";
            // 
            // inputName
            // 
            resources.ApplyResources(this.inputName, "inputName");
            this.inputName.Name = "inputName";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Highlight;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.ForeColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // F_Principal
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.inputName);
            this.Controls.Add(this.lista);
            this.Controls.Add(this.lb);
            this.Controls.Add(this.add);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "F_Principal";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button add;
        private System.Windows.Forms.Label lb;
        private System.Windows.Forms.TextBox lista;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private System.Windows.Forms.TextBox inputName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}

