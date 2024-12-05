namespace prueba_inicio
{
    partial class FormActualizarMetodoPago
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
            this.btnCancelarActualizarPago = new System.Windows.Forms.Button();
            this.btnConfirmarActualizarPago = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtActualizarMetodoPago = new System.Windows.Forms.TextBox();
            this.cmbActividad = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCancelarActualizarPago
            // 
            this.btnCancelarActualizarPago.Location = new System.Drawing.Point(231, 158);
            this.btnCancelarActualizarPago.Name = "btnCancelarActualizarPago";
            this.btnCancelarActualizarPago.Size = new System.Drawing.Size(75, 23);
            this.btnCancelarActualizarPago.TabIndex = 7;
            this.btnCancelarActualizarPago.Text = "Cancelar";
            this.btnCancelarActualizarPago.UseVisualStyleBackColor = true;
            this.btnCancelarActualizarPago.Click += new System.EventHandler(this.btnCancelarActualizarPago_Click);
            // 
            // btnConfirmarActualizarPago
            // 
            this.btnConfirmarActualizarPago.Location = new System.Drawing.Point(71, 158);
            this.btnConfirmarActualizarPago.Name = "btnConfirmarActualizarPago";
            this.btnConfirmarActualizarPago.Size = new System.Drawing.Size(75, 23);
            this.btnConfirmarActualizarPago.TabIndex = 6;
            this.btnConfirmarActualizarPago.Text = "Confirmar";
            this.btnConfirmarActualizarPago.UseVisualStyleBackColor = true;
            this.btnConfirmarActualizarPago.Click += new System.EventHandler(this.btnConfirmarActualizarPago_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Actializar Metodo de Pago";
            // 
            // txtActualizarMetodoPago
            // 
            this.txtActualizarMetodoPago.Location = new System.Drawing.Point(206, 69);
            this.txtActualizarMetodoPago.Name = "txtActualizarMetodoPago";
            this.txtActualizarMetodoPago.Size = new System.Drawing.Size(100, 22);
            this.txtActualizarMetodoPago.TabIndex = 4;
            // 
            // cmbActividad
            // 
            this.cmbActividad.FormattingEnabled = true;
            this.cmbActividad.Items.AddRange(new object[] {
            "Activo",
            "Inactivo"});
            this.cmbActividad.Location = new System.Drawing.Point(185, 112);
            this.cmbActividad.Name = "cmbActividad";
            this.cmbActividad.Size = new System.Drawing.Size(121, 24);
            this.cmbActividad.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "Actividad";
            // 
            // FormActualizarMetodoPago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 465);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbActividad);
            this.Controls.Add(this.btnCancelarActualizarPago);
            this.Controls.Add(this.btnConfirmarActualizarPago);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtActualizarMetodoPago);
            this.Name = "FormActualizarMetodoPago";
            this.Text = "ActualizarMetodoPAgo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancelarActualizarPago;
        private System.Windows.Forms.Button btnConfirmarActualizarPago;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtActualizarMetodoPago;
        private System.Windows.Forms.ComboBox cmbActividad;
        private System.Windows.Forms.Label label2;
    }
}