namespace prueba_inicio
{
    partial class FormCrearPlato
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
            this.btnCancelarMesa = new System.Windows.Forms.Button();
            this.btnConfirmarPlato = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNombrePlato = new System.Windows.Forms.TextBox();
            this.txtDescripcionPlato = new System.Windows.Forms.TextBox();
            this.txtPrecioPlato = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnCancelarMesa
            // 
            this.btnCancelarMesa.Location = new System.Drawing.Point(152, 260);
            this.btnCancelarMesa.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelarMesa.Name = "btnCancelarMesa";
            this.btnCancelarMesa.Size = new System.Drawing.Size(56, 19);
            this.btnCancelarMesa.TabIndex = 15;
            this.btnCancelarMesa.Text = "Cancelar";
            this.btnCancelarMesa.UseVisualStyleBackColor = true;
            this.btnCancelarMesa.Click += new System.EventHandler(this.btnCancelarMesa_Click);
            // 
            // btnConfirmarPlato
            // 
            this.btnConfirmarPlato.Location = new System.Drawing.Point(55, 260);
            this.btnConfirmarPlato.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfirmarPlato.Name = "btnConfirmarPlato";
            this.btnConfirmarPlato.Size = new System.Drawing.Size(56, 19);
            this.btnConfirmarPlato.TabIndex = 14;
            this.btnConfirmarPlato.Text = "Confirmar";
            this.btnConfirmarPlato.UseVisualStyleBackColor = true;
            this.btnConfirmarPlato.Click += new System.EventHandler(this.btnConfirmarPlato_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(90, 192);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Precio";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 147);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Descripcion del plato";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 103);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Nombre del Plato";
            // 
            // txtNombrePlato
            // 
            this.txtNombrePlato.Location = new System.Drawing.Point(152, 98);
            this.txtNombrePlato.Margin = new System.Windows.Forms.Padding(2);
            this.txtNombrePlato.Name = "txtNombrePlato";
            this.txtNombrePlato.Size = new System.Drawing.Size(76, 20);
            this.txtNombrePlato.TabIndex = 9;
            // 
            // txtDescripcionPlato
            // 
            this.txtDescripcionPlato.Location = new System.Drawing.Point(152, 147);
            this.txtDescripcionPlato.Margin = new System.Windows.Forms.Padding(2);
            this.txtDescripcionPlato.Name = "txtDescripcionPlato";
            this.txtDescripcionPlato.Size = new System.Drawing.Size(76, 20);
            this.txtDescripcionPlato.TabIndex = 8;
            // 
            // txtPrecioPlato
            // 
            this.txtPrecioPlato.Location = new System.Drawing.Point(152, 192);
            this.txtPrecioPlato.Margin = new System.Windows.Forms.Padding(2);
            this.txtPrecioPlato.Name = "txtPrecioPlato";
            this.txtPrecioPlato.Size = new System.Drawing.Size(76, 20);
            this.txtPrecioPlato.TabIndex = 16;
            // 
            // FormCrearPlato
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(267, 378);
            this.Controls.Add(this.txtPrecioPlato);
            this.Controls.Add(this.btnCancelarMesa);
            this.Controls.Add(this.btnConfirmarPlato);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNombrePlato);
            this.Controls.Add(this.txtDescripcionPlato);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormCrearPlato";
            this.Text = "FormCrearPlato";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancelarMesa;
        private System.Windows.Forms.Button btnConfirmarPlato;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNombrePlato;
        private System.Windows.Forms.TextBox txtDescripcionPlato;
        private System.Windows.Forms.TextBox txtPrecioPlato;
    }
}