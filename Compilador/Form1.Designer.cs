namespace Compilador
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.lstTokens = new System.Windows.Forms.ListBox();
            this.lstErrores = new System.Windows.Forms.ListBox();
            this.lstFuente = new System.Windows.Forms.ListBox();
            this.lstSintac = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 26);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(172, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Cargar codigo";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lstTokens
            // 
            this.lstTokens.FormattingEnabled = true;
            this.lstTokens.Location = new System.Drawing.Point(425, 26);
            this.lstTokens.Name = "lstTokens";
            this.lstTokens.Size = new System.Drawing.Size(263, 82);
            this.lstTokens.TabIndex = 1;
            // 
            // lstErrores
            // 
            this.lstErrores.FormattingEnabled = true;
            this.lstErrores.Location = new System.Drawing.Point(425, 143);
            this.lstErrores.Name = "lstErrores";
            this.lstErrores.Size = new System.Drawing.Size(204, 108);
            this.lstErrores.TabIndex = 2;
            // 
            // lstFuente
            // 
            this.lstFuente.FormattingEnabled = true;
            this.lstFuente.Location = new System.Drawing.Point(199, 26);
            this.lstFuente.Name = "lstFuente";
            this.lstFuente.Size = new System.Drawing.Size(204, 225);
            this.lstFuente.TabIndex = 3;
            // 
            // lstSintac
            // 
            this.lstSintac.FormattingEnabled = true;
            this.lstSintac.Location = new System.Drawing.Point(35, 280);
            this.lstSintac.Name = "lstSintac";
            this.lstSintac.Size = new System.Drawing.Size(753, 95);
            this.lstSintac.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lstSintac);
            this.Controls.Add(this.lstFuente);
            this.Controls.Add(this.lstErrores);
            this.Controls.Add(this.lstTokens);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox lstTokens;
        private System.Windows.Forms.ListBox lstErrores;
        private System.Windows.Forms.ListBox lstFuente;
        private System.Windows.Forms.ListBox lstSintac;
    }
}

