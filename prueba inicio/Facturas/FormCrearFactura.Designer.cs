namespace prueba_inicio
{
    partial class FormCrearFactura
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
            this.cmbClienteFactura = new System.Windows.Forms.ComboBox();
            this.dtpFechaFactura = new System.Windows.Forms.DateTimePicker();
            this.btnCancelarCrearFactura = new System.Windows.Forms.Button();
            this.btnConfirmarCrearFactura = new System.Windows.Forms.Button();
            this.txtMontoFactura = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbActividad = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmbClienteFactura
            // 
            this.cmbClienteFactura.FormattingEnabled = true;
            this.cmbClienteFactura.Location = new System.Drawing.Point(130, 29);
            this.cmbClienteFactura.Name = "cmbClienteFactura";
            this.cmbClienteFactura.Size = new System.Drawing.Size(121, 21);
            this.cmbClienteFactura.TabIndex = 55;
            // 
            // dtpFechaFactura
            // 
            this.dtpFechaFactura.Location = new System.Drawing.Point(25, 139);
            this.dtpFechaFactura.Name = "dtpFechaFactura";
            this.dtpFechaFactura.Size = new System.Drawing.Size(200, 20);
            this.dtpFechaFactura.TabIndex = 54;
            // 
            // btnCancelarCrearFactura
            // 
            this.btnCancelarCrearFactura.Location = new System.Drawing.Point(180, 251);
            this.btnCancelarCrearFactura.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelarCrearFactura.Name = "btnCancelarCrearFactura";
            this.btnCancelarCrearFactura.Size = new System.Drawing.Size(56, 19);
            this.btnCancelarCrearFactura.TabIndex = 53;
            this.btnCancelarCrearFactura.Text = "Cancelar";
            this.btnCancelarCrearFactura.UseVisualStyleBackColor = true;
            this.btnCancelarCrearFactura.Click += new System.EventHandler(this.btnCancelarCrearFactura_Click);
            // 
            // btnConfirmarCrearFactura
            // 
            this.btnConfirmarCrearFactura.Location = new System.Drawing.Point(60, 251);
            this.btnConfirmarCrearFactura.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfirmarCrearFactura.Name = "btnConfirmarCrearFactura";
            this.btnConfirmarCrearFactura.Size = new System.Drawing.Size(56, 19);
            this.btnConfirmarCrearFactura.TabIndex = 52;
            this.btnConfirmarCrearFactura.Text = "Confirmar";
            this.btnConfirmarCrearFactura.UseVisualStyleBackColor = true;
            this.btnConfirmarCrearFactura.Click += new System.EventHandler(this.btnConfirmarCrearFactura_Click);
            // 
            // txtMontoFactura
            // 
            this.txtMontoFactura.Location = new System.Drawing.Point(167, 72);
            this.txtMontoFactura.Margin = new System.Windows.Forms.Padding(2);
            this.txtMontoFactura.Name = "txtMontoFactura";
            this.txtMontoFactura.Size = new System.Drawing.Size(76, 20);
            this.txtMontoFactura.TabIndex = 51;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 123);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 13);
            this.label4.TabIndex = 50;
            this.label4.Text = "Fecha de Emision";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 72);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 49;
            this.label3.Text = "Monto";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 48;
            this.label1.Text = "Cliente";
            // 
            // cmbActividad
            // 
            this.cmbActividad.FormattingEnabled = true;
            this.cmbActividad.Items.AddRange(new object[] {
            "Activa",
            "Inactiva"});
            this.cmbActividad.Location = new System.Drawing.Point(130, 179);
            this.cmbActividad.Name = "cmbActividad";
            this.cmbActividad.Size = new System.Drawing.Size(121, 21);
            this.cmbActividad.TabIndex = 56;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 179);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 57;
            this.label2.Text = "Actividad";
            // 
            // FormCrearFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(267, 378);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbActividad);
            this.Controls.Add(this.cmbClienteFactura);
            this.Controls.Add(this.dtpFechaFactura);
            this.Controls.Add(this.btnCancelarCrearFactura);
            this.Controls.Add(this.btnConfirmarCrearFactura);
            this.Controls.Add(this.txtMontoFactura);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "FormCrearFactura";
            this.Text = "FormCrearFactura";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbClienteFactura;
        private System.Windows.Forms.DateTimePicker dtpFechaFactura;
        private System.Windows.Forms.Button btnCancelarCrearFactura;
        private System.Windows.Forms.Button btnConfirmarCrearFactura;
        private System.Windows.Forms.TextBox txtMontoFactura;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbActividad;
        private System.Windows.Forms.Label label2;
    }
}