namespace prueba_inicio
{
    partial class FormActualizarFactura
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
            this.dtpFechaFacturaActualizar = new System.Windows.Forms.DateTimePicker();
            this.btnCancelarActualizarFactura = new System.Windows.Forms.Button();
            this.btnConfirmarActualizarFactura = new System.Windows.Forms.Button();
            this.txtMontoFacturaActualizar = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbActividadFacturaActualizar = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtClienteFacturaActualizar = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // dtpFechaFacturaActualizar
            // 
            this.dtpFechaFacturaActualizar.Location = new System.Drawing.Point(53, 165);
            this.dtpFechaFacturaActualizar.Name = "dtpFechaFacturaActualizar";
            this.dtpFechaFacturaActualizar.Size = new System.Drawing.Size(200, 20);
            this.dtpFechaFacturaActualizar.TabIndex = 56;
            // 
            // btnCancelarActualizarFactura
            // 
            this.btnCancelarActualizarFactura.Location = new System.Drawing.Point(173, 291);
            this.btnCancelarActualizarFactura.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelarActualizarFactura.Name = "btnCancelarActualizarFactura";
            this.btnCancelarActualizarFactura.Size = new System.Drawing.Size(56, 19);
            this.btnCancelarActualizarFactura.TabIndex = 55;
            this.btnCancelarActualizarFactura.Text = "Cancelar";
            this.btnCancelarActualizarFactura.UseVisualStyleBackColor = true;
            // 
            // btnConfirmarActualizarFactura
            // 
            this.btnConfirmarActualizarFactura.Location = new System.Drawing.Point(53, 291);
            this.btnConfirmarActualizarFactura.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfirmarActualizarFactura.Name = "btnConfirmarActualizarFactura";
            this.btnConfirmarActualizarFactura.Size = new System.Drawing.Size(56, 19);
            this.btnConfirmarActualizarFactura.TabIndex = 54;
            this.btnConfirmarActualizarFactura.Text = "Confirmar";
            this.btnConfirmarActualizarFactura.UseVisualStyleBackColor = true;
            this.btnConfirmarActualizarFactura.Click += new System.EventHandler(this.btnConfirmarActualizarFactura_Click);
            // 
            // txtMontoFacturaActualizar
            // 
            this.txtMontoFacturaActualizar.Location = new System.Drawing.Point(160, 112);
            this.txtMontoFacturaActualizar.Margin = new System.Windows.Forms.Padding(2);
            this.txtMontoFacturaActualizar.Name = "txtMontoFacturaActualizar";
            this.txtMontoFacturaActualizar.Size = new System.Drawing.Size(76, 20);
            this.txtMontoFacturaActualizar.TabIndex = 53;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 149);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 13);
            this.label4.TabIndex = 52;
            this.label4.Text = "Fecha de Emision";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 112);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 51;
            this.label3.Text = "Monto";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 218);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 50;
            this.label2.Text = "Actividad";
            // 
            // cmbActividadFacturaActualizar
            // 
            this.cmbActividadFacturaActualizar.FormattingEnabled = true;
            this.cmbActividadFacturaActualizar.Items.AddRange(new object[] {
            "Activo",
            "Inactivo"});
            this.cmbActividadFacturaActualizar.Location = new System.Drawing.Point(144, 218);
            this.cmbActividadFacturaActualizar.Margin = new System.Windows.Forms.Padding(2);
            this.cmbActividadFacturaActualizar.Name = "cmbActividadFacturaActualizar";
            this.cmbActividadFacturaActualizar.Size = new System.Drawing.Size(92, 21);
            this.cmbActividadFacturaActualizar.TabIndex = 49;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 72);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 48;
            this.label1.Text = "Cliente";
            // 
            // txtClienteFacturaActualizar
            // 
            this.txtClienteFacturaActualizar.Location = new System.Drawing.Point(134, 69);
            this.txtClienteFacturaActualizar.Margin = new System.Windows.Forms.Padding(2);
            this.txtClienteFacturaActualizar.Name = "txtClienteFacturaActualizar";
            this.txtClienteFacturaActualizar.Size = new System.Drawing.Size(76, 20);
            this.txtClienteFacturaActualizar.TabIndex = 47;
            // 
            // FormActualizarFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(267, 378);
            this.Controls.Add(this.dtpFechaFacturaActualizar);
            this.Controls.Add(this.btnCancelarActualizarFactura);
            this.Controls.Add(this.btnConfirmarActualizarFactura);
            this.Controls.Add(this.txtMontoFacturaActualizar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbActividadFacturaActualizar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtClienteFacturaActualizar);
            this.Name = "FormActualizarFactura";
            this.Text = "FormActualizarFactura";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpFechaFacturaActualizar;
        private System.Windows.Forms.Button btnCancelarActualizarFactura;
        private System.Windows.Forms.Button btnConfirmarActualizarFactura;
        private System.Windows.Forms.TextBox txtMontoFacturaActualizar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbActividadFacturaActualizar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtClienteFacturaActualizar;
    }
}