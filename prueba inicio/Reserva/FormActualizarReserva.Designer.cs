namespace prueba_inicio
{
    partial class FormActualizarReserva
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
            this.cmbActualizarActividad = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbActualizarEstadoReserva = new System.Windows.Forms.ComboBox();
            this.dtpActualizarFechaHora = new System.Windows.Forms.DateTimePicker();
            this.cmbActualizarMesas = new System.Windows.Forms.ComboBox();
            this.cmbActualizarClientes = new System.Windows.Forms.ComboBox();
            this.btnCancelarReserva = new System.Windows.Forms.Button();
            this.btnConfirmarActualizarReserva = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmbActualizarActividad
            // 
            this.cmbActualizarActividad.FormattingEnabled = true;
            this.cmbActualizarActividad.Items.AddRange(new object[] {
            "Activo",
            "Inactivo"});
            this.cmbActualizarActividad.Location = new System.Drawing.Point(201, 240);
            this.cmbActualizarActividad.Name = "cmbActualizarActividad";
            this.cmbActualizarActividad.Size = new System.Drawing.Size(121, 24);
            this.cmbActualizarActividad.TabIndex = 23;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(52, 240);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 16);
            this.label5.TabIndex = 22;
            this.label5.Text = "Actividad";
            // 
            // cmbActualizarEstadoReserva
            // 
            this.cmbActualizarEstadoReserva.FormattingEnabled = true;
            this.cmbActualizarEstadoReserva.Location = new System.Drawing.Point(201, 177);
            this.cmbActualizarEstadoReserva.Name = "cmbActualizarEstadoReserva";
            this.cmbActualizarEstadoReserva.Size = new System.Drawing.Size(121, 24);
            this.cmbActualizarEstadoReserva.TabIndex = 21;
            // 
            // dtpActualizarFechaHora
            // 
            this.dtpActualizarFechaHora.Location = new System.Drawing.Point(201, 129);
            this.dtpActualizarFechaHora.Name = "dtpActualizarFechaHora";
            this.dtpActualizarFechaHora.Size = new System.Drawing.Size(121, 22);
            this.dtpActualizarFechaHora.TabIndex = 20;
            // 
            // cmbActualizarMesas
            // 
            this.cmbActualizarMesas.FormattingEnabled = true;
            this.cmbActualizarMesas.Location = new System.Drawing.Point(201, 84);
            this.cmbActualizarMesas.Name = "cmbActualizarMesas";
            this.cmbActualizarMesas.Size = new System.Drawing.Size(121, 24);
            this.cmbActualizarMesas.TabIndex = 19;
            // 
            // cmbActualizarClientes
            // 
            this.cmbActualizarClientes.FormattingEnabled = true;
            this.cmbActualizarClientes.Location = new System.Drawing.Point(201, 23);
            this.cmbActualizarClientes.Name = "cmbActualizarClientes";
            this.cmbActualizarClientes.Size = new System.Drawing.Size(121, 24);
            this.cmbActualizarClientes.TabIndex = 18;
            // 
            // btnCancelarReserva
            // 
            this.btnCancelarReserva.Location = new System.Drawing.Point(201, 357);
            this.btnCancelarReserva.Name = "btnCancelarReserva";
            this.btnCancelarReserva.Size = new System.Drawing.Size(75, 23);
            this.btnCancelarReserva.TabIndex = 17;
            this.btnCancelarReserva.Text = "Cancelar";
            this.btnCancelarReserva.UseVisualStyleBackColor = true;
            this.btnCancelarReserva.Click += new System.EventHandler(this.btnCancelarReserva_Click);
            // 
            // btnConfirmarActualizarReserva
            // 
            this.btnConfirmarActualizarReserva.Location = new System.Drawing.Point(55, 357);
            this.btnConfirmarActualizarReserva.Name = "btnConfirmarActualizarReserva";
            this.btnConfirmarActualizarReserva.Size = new System.Drawing.Size(75, 23);
            this.btnConfirmarActualizarReserva.TabIndex = 16;
            this.btnConfirmarActualizarReserva.Text = "Confirmar";
            this.btnConfirmarActualizarReserva.UseVisualStyleBackColor = true;
            this.btnConfirmarActualizarReserva.Click += new System.EventHandler(this.btnConfirmarActualizarReserva_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(52, 177);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 16);
            this.label4.TabIndex = 15;
            this.label4.Text = "Estado";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(160, 16);
            this.label3.TabIndex = 14;
            this.label3.Text = "Seleccionar Fecha y hora";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 16);
            this.label2.TabIndex = 13;
            this.label2.Text = "Seleccionar Mesa";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 16);
            this.label1.TabIndex = 12;
            this.label1.Text = "Nombre Cliente";
            // 
            // FormActualizarReserva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 465);
            this.Controls.Add(this.cmbActualizarActividad);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbActualizarEstadoReserva);
            this.Controls.Add(this.dtpActualizarFechaHora);
            this.Controls.Add(this.cmbActualizarMesas);
            this.Controls.Add(this.cmbActualizarClientes);
            this.Controls.Add(this.btnCancelarReserva);
            this.Controls.Add(this.btnConfirmarActualizarReserva);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormActualizarReserva";
            this.Text = "FormActualizarReserva";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbActualizarActividad;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbActualizarEstadoReserva;
        private System.Windows.Forms.DateTimePicker dtpActualizarFechaHora;
        private System.Windows.Forms.ComboBox cmbActualizarMesas;
        private System.Windows.Forms.ComboBox cmbActualizarClientes;
        private System.Windows.Forms.Button btnCancelarReserva;
        private System.Windows.Forms.Button btnConfirmarActualizarReserva;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}