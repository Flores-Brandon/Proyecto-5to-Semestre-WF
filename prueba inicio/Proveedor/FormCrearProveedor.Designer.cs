namespace prueba_inicio
{
    partial class FormCrearProveedor
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
            this.label2 = new System.Windows.Forms.Label();
            this.cmbActividadProveedor = new System.Windows.Forms.ComboBox();
            this.btnCancelarCrearProveedor = new System.Windows.Forms.Button();
            this.btnConfirmarCrearProveedor = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNombreProveedor = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTelefonoProveedor = new System.Windows.Forms.TextBox();
            this.txtCorreoProveedor = new System.Windows.Forms.TextBox();
            this.txtDireccionProveedor = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 194);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Actividad";
            // 
            // cmbActividadProveedor
            // 
            this.cmbActividadProveedor.FormattingEnabled = true;
            this.cmbActividadProveedor.Items.AddRange(new object[] {
            "Activo",
            "Inactivo"});
            this.cmbActividadProveedor.Location = new System.Drawing.Point(140, 194);
            this.cmbActividadProveedor.Margin = new System.Windows.Forms.Padding(2);
            this.cmbActividadProveedor.Name = "cmbActividadProveedor";
            this.cmbActividadProveedor.Size = new System.Drawing.Size(92, 21);
            this.cmbActividadProveedor.TabIndex = 14;
            // 
            // btnCancelarCrearProveedor
            // 
            this.btnCancelarCrearProveedor.Location = new System.Drawing.Point(170, 263);
            this.btnCancelarCrearProveedor.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelarCrearProveedor.Name = "btnCancelarCrearProveedor";
            this.btnCancelarCrearProveedor.Size = new System.Drawing.Size(56, 19);
            this.btnCancelarCrearProveedor.TabIndex = 13;
            this.btnCancelarCrearProveedor.Text = "Cancelar";
            this.btnCancelarCrearProveedor.UseVisualStyleBackColor = true;
            this.btnCancelarCrearProveedor.Click += new System.EventHandler(this.btnCancelarCrearProveedor_Click);
            // 
            // btnConfirmarCrearProveedor
            // 
            this.btnConfirmarCrearProveedor.Location = new System.Drawing.Point(50, 263);
            this.btnConfirmarCrearProveedor.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfirmarCrearProveedor.Name = "btnConfirmarCrearProveedor";
            this.btnConfirmarCrearProveedor.Size = new System.Drawing.Size(56, 19);
            this.btnConfirmarCrearProveedor.TabIndex = 12;
            this.btnConfirmarCrearProveedor.Text = "Confirmar";
            this.btnConfirmarCrearProveedor.UseVisualStyleBackColor = true;
            this.btnConfirmarCrearProveedor.Click += new System.EventHandler(this.btnConfirmarCrearProveedor_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 48);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Nombre del Proveedor";
            // 
            // txtNombreProveedor
            // 
            this.txtNombreProveedor.Location = new System.Drawing.Point(156, 43);
            this.txtNombreProveedor.Margin = new System.Windows.Forms.Padding(2);
            this.txtNombreProveedor.Name = "txtNombreProveedor";
            this.txtNombreProveedor.Size = new System.Drawing.Size(76, 20);
            this.txtNombreProveedor.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 88);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Teléfono";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 125);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Correo Electrónico";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 161);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Dirección";
            // 
            // txtTelefonoProveedor
            // 
            this.txtTelefonoProveedor.Location = new System.Drawing.Point(156, 88);
            this.txtTelefonoProveedor.Margin = new System.Windows.Forms.Padding(2);
            this.txtTelefonoProveedor.Name = "txtTelefonoProveedor";
            this.txtTelefonoProveedor.Size = new System.Drawing.Size(76, 20);
            this.txtTelefonoProveedor.TabIndex = 19;
            // 
            // txtCorreoProveedor
            // 
            this.txtCorreoProveedor.Location = new System.Drawing.Point(156, 125);
            this.txtCorreoProveedor.Margin = new System.Windows.Forms.Padding(2);
            this.txtCorreoProveedor.Name = "txtCorreoProveedor";
            this.txtCorreoProveedor.Size = new System.Drawing.Size(76, 20);
            this.txtCorreoProveedor.TabIndex = 20;
            // 
            // txtDireccionProveedor
            // 
            this.txtDireccionProveedor.Location = new System.Drawing.Point(156, 161);
            this.txtDireccionProveedor.Margin = new System.Windows.Forms.Padding(2);
            this.txtDireccionProveedor.Name = "txtDireccionProveedor";
            this.txtDireccionProveedor.Size = new System.Drawing.Size(76, 20);
            this.txtDireccionProveedor.TabIndex = 21;
            // 
            // FormCrearProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(267, 378);
            this.Controls.Add(this.txtDireccionProveedor);
            this.Controls.Add(this.txtCorreoProveedor);
            this.Controls.Add(this.txtTelefonoProveedor);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbActividadProveedor);
            this.Controls.Add(this.btnCancelarCrearProveedor);
            this.Controls.Add(this.btnConfirmarCrearProveedor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNombreProveedor);
            this.Name = "FormCrearProveedor";
            this.Text = "FormCrearProveedor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbActividadProveedor;
        private System.Windows.Forms.Button btnCancelarCrearProveedor;
        private System.Windows.Forms.Button btnConfirmarCrearProveedor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNombreProveedor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTelefonoProveedor;
        private System.Windows.Forms.TextBox txtCorreoProveedor;
        private System.Windows.Forms.TextBox txtDireccionProveedor;
    }
}