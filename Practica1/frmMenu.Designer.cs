namespace Practica1
{
    partial class frmMenu
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
            this.btnAreaP = new System.Windows.Forms.Button();
            this.btnInventarioP = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnAreaP
            // 
            this.btnAreaP.Location = new System.Drawing.Point(24, 53);
            this.btnAreaP.Name = "btnAreaP";
            this.btnAreaP.Size = new System.Drawing.Size(75, 23);
            this.btnAreaP.TabIndex = 0;
            this.btnAreaP.Text = "AREAS";
            this.btnAreaP.UseVisualStyleBackColor = true;
            this.btnAreaP.Click += new System.EventHandler(this.btnAreaP_Click);
            // 
            // btnInventarioP
            // 
            this.btnInventarioP.Location = new System.Drawing.Point(186, 53);
            this.btnInventarioP.Name = "btnInventarioP";
            this.btnInventarioP.Size = new System.Drawing.Size(90, 23);
            this.btnInventarioP.TabIndex = 1;
            this.btnInventarioP.Text = "INVENTARIO";
            this.btnInventarioP.UseVisualStyleBackColor = true;
            this.btnInventarioP.Click += new System.EventHandler(this.btnInventarioP_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(75, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "¿Cual tabla desea administrar?";
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 150);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnInventarioP);
            this.Controls.Add(this.btnAreaP);
            this.Name = "frmMenu";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAreaP;
        private System.Windows.Forms.Button btnInventarioP;
        private System.Windows.Forms.Label label1;
    }
}

