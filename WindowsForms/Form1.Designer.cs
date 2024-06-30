namespace WindowsForms
{
    partial class Entrada
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
            this.meuBtn = new System.Windows.Forms.Button();
            this.lb = new System.Windows.Forms.Label();
            this.input = new System.Windows.Forms.TextBox();
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.SuspendLayout();
            // 
            // meuBtn
            // 
            this.meuBtn.BackColor = System.Drawing.SystemColors.Highlight;
            this.meuBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.meuBtn.ForeColor = System.Drawing.Color.White;
            this.meuBtn.Location = new System.Drawing.Point(12, 27);
            this.meuBtn.Name = "meuBtn";
            this.meuBtn.Size = new System.Drawing.Size(100, 33);
            this.meuBtn.TabIndex = 0;
            this.meuBtn.Text = "OK";
            this.meuBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.meuBtn.UseVisualStyleBackColor = false;
            this.meuBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // lb
            // 
            this.lb.AutoSize = true;
            this.lb.Location = new System.Drawing.Point(36, 63);
            this.lb.Name = "lb";
            this.lb.Size = new System.Drawing.Size(34, 13);
            this.lb.TabIndex = 1;
            this.lb.Text = "Teste";
            this.lb.Click += new System.EventHandler(this.label1_Click);
            // 
            // input
            // 
            this.input.Location = new System.Drawing.Point(12, 1);
            this.input.Name = "input";
            this.input.Size = new System.Drawing.Size(100, 20);
            this.input.TabIndex = 2;
            // 
            // Entrada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 512);
            this.Controls.Add(this.input);
            this.Controls.Add(this.lb);
            this.Controls.Add(this.meuBtn);
            this.Name = "Entrada";
            this.Text = "Meu Programa";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button meuBtn;
        private System.Windows.Forms.Label lb;
        private System.Windows.Forms.TextBox input;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
    }
}

