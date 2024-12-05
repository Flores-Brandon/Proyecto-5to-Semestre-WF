namespace prueba_inicio
{
    partial class FormActualizarMesa
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
            this.btnCancelarActualizarMesa = new System.Windows.Forms.Button();
            this.btnConfirmarActualizarMesa = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbActualizarEstadoMesa = new System.Windows.Forms.ComboBox();
            this.txtActualizarNumeroMesa = new System.Windows.Forms.TextBox();
            this.txtActualizarCapacidadMesa = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnCancelarActualizarMesa
            // 
            this.btnCancelarActualizarMesa.Location = new System.Drawing.Point(218, 264);
            this.btnCancelarActualizarMesa.Name = "btnCancelarActualizarMesa";
            this.btnCancelarActualizarMesa.Size = new System.Drawing.Size(75, 23);
            this.btnCancelarActualizarMesa.TabIndex = 15;
            this.btnCancelarActualizarMesa.Text = "Cancelar";
            this.btnCancelarActualizarMesa.UseVisualStyleBackColor = true;
            // 
            // btnConfirmarActualizarMesa
            // 
            this.btnConfirmarActualizarMesa.Location = new System.Drawing.Point(88, 264);
            this.btnConfirmarActualizarMesa.Name = "btnConfirmarActualizarMesa";
            this.btnConfirmarActualizarMesa.Size = new System.Drawing.Size(75, 23);
            this.btnConfirmarActualizarMesa.TabIndex = 14;
            this.btnConfirmarActualizarMesa.Text = "Confirmar";
            this.btnConfirmarActualizarMesa.UseVisualStyleBackColor = true;
            this.btnConfirmarActualizarMesa.Click += new System.EventHandler(this.btnConfirmarActualizarMesa_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(69, 188);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 16);
            this.label3.TabIndex = 13;
            this.label3.Text = "Estado";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(68, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 16);
            this.label2.TabIndex = 12;
            this.label2.Text = "Capacidad de la mesa";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(69, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 16);
            this.label1.TabIndex = 11;
            this.label1.Text = "Numero Mesa";
            // 
            // cmbActualizarEstadoMesa
            // 
            this.cmbActualizarEstadoMesa.FormattingEnabled = true;
            this.cmbActualizarEstadoMesa.Items.AddRange(new object[] {
            "Ocupada",
            "Libre",
            "Reservada"});
            this.cmbActualizarEstadoMesa.Location = new System.Drawing.Point(197, 180);
            this.cmbActualizarEstadoMesa.Name = "cmbActualizarEstadoMesa";
            this.cmbActualizarEstadoMesa.Size = new System.Drawing.Size(121, 24);
            this.cmbActualizarEstadoMesa.TabIndex = 10;
            // 
            // txtActualizarNumeroMesa
            // 
            this.txtActualizarNumeroMesa.Location = new System.Drawing.Point(218, 65);
            this.txtActualizarNumeroMesa.Name = "txtActualizarNumeroMesa";
            this.txtActualizarNumeroMesa.Size = new System.Drawing.Size(100, 22);
            this.txtActualizarNumeroMesa.TabIndex = 9;
            // 
            // txtActualizarCapacidadMesa
            // 
            this.txtActualizarCapacidadMesa.Location = new System.Drawing.Point(218, 125);
            this.txtActualizarCapacidadMesa.Name = "txtActualizarCapacidadMesa";
            this.txtActualizarCapacidadMesa.Size = new System.Drawing.Size(100, 22);
            this.txtActualizarCapacidadMesa.TabIndex = 8;
            // 
            // FormActualizarMesa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 465);
            this.Controls.Add(this.btnCancelarActualizarMesa);
            this.Controls.Add(this.btnConfirmarActualizarMesa);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbActualizarEstadoMesa);
            this.Controls.Add(this.txtActualizarNumeroMesa);
            this.Controls.Add(this.txtActualizarCapacidadMesa);
            this.Name = "FormActualizarMesa";
            this.Text = "FormActualizarMesa";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancelarActualizarMesa;
        private System.Windows.Forms.Button btnConfirmarActualizarMesa;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbActualizarEstadoMesa;
        private System.Windows.Forms.TextBox txtActualizarNumeroMesa;
        private System.Windows.Forms.TextBox txtActualizarCapacidadMesa;
    }
}