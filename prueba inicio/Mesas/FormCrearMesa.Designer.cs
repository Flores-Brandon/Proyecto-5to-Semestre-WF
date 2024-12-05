namespace prueba_inicio
{
    partial class FormCrearMesa
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
            this.txtCapacidadMesa = new System.Windows.Forms.TextBox();
            this.txtNumeroMesa = new System.Windows.Forms.TextBox();
            this.cmbEstadoMesa = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnConfirmarMesa = new System.Windows.Forms.Button();
            this.btnCancelarMesa = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtCapacidadMesa
            // 
            this.txtCapacidadMesa.Location = new System.Drawing.Point(162, 115);
            this.txtCapacidadMesa.Name = "txtCapacidadMesa";
            this.txtCapacidadMesa.Size = new System.Drawing.Size(100, 22);
            this.txtCapacidadMesa.TabIndex = 0;
            // 
            // txtNumeroMesa
            // 
            this.txtNumeroMesa.Location = new System.Drawing.Point(162, 55);
            this.txtNumeroMesa.Name = "txtNumeroMesa";
            this.txtNumeroMesa.Size = new System.Drawing.Size(100, 22);
            this.txtNumeroMesa.TabIndex = 1;
            // 
            // cmbEstadoMesa
            // 
            this.cmbEstadoMesa.FormattingEnabled = true;
            this.cmbEstadoMesa.Items.AddRange(new object[] {
            "Ocupada",
            "Libre",
            "Reservada"});
            this.cmbEstadoMesa.Location = new System.Drawing.Point(141, 170);
            this.cmbEstadoMesa.Name = "cmbEstadoMesa";
            this.cmbEstadoMesa.Size = new System.Drawing.Size(121, 24);
            this.cmbEstadoMesa.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Numero Mesa";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Capacidad de la mesa";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 178);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Estado";
            // 
            // btnConfirmarMesa
            // 
            this.btnConfirmarMesa.Location = new System.Drawing.Point(32, 254);
            this.btnConfirmarMesa.Name = "btnConfirmarMesa";
            this.btnConfirmarMesa.Size = new System.Drawing.Size(75, 23);
            this.btnConfirmarMesa.TabIndex = 6;
            this.btnConfirmarMesa.Text = "Confirmar";
            this.btnConfirmarMesa.UseVisualStyleBackColor = true;
            this.btnConfirmarMesa.Click += new System.EventHandler(this.btnConfirmarMesa_Click);
            // 
            // btnCancelarMesa
            // 
            this.btnCancelarMesa.Location = new System.Drawing.Point(162, 254);
            this.btnCancelarMesa.Name = "btnCancelarMesa";
            this.btnCancelarMesa.Size = new System.Drawing.Size(75, 23);
            this.btnCancelarMesa.TabIndex = 7;
            this.btnCancelarMesa.Text = "Cancelar";
            this.btnCancelarMesa.UseVisualStyleBackColor = true;
            this.btnCancelarMesa.Click += new System.EventHandler(this.btnCancelarMesa_Click);
            // 
            // FormCrearMesa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 465);
            this.Controls.Add(this.btnCancelarMesa);
            this.Controls.Add(this.btnConfirmarMesa);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbEstadoMesa);
            this.Controls.Add(this.txtNumeroMesa);
            this.Controls.Add(this.txtCapacidadMesa);
            this.Name = "FormCrearMesa";
            this.Text = "FormCrearMesa";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCapacidadMesa;
        private System.Windows.Forms.TextBox txtNumeroMesa;
        private System.Windows.Forms.ComboBox cmbEstadoMesa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnConfirmarMesa;
        private System.Windows.Forms.Button btnCancelarMesa;
    }
}