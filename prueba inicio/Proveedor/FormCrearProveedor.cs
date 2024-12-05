using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prueba_inicio
{
    public partial class FormCrearProveedor : Form
    {
        // Cadena de conexión a la base de datos
        private string connectionString = "Server=localhost\\SQLEXPRESS;Database=ProyectoRestaurante;Trusted_Connection=True;";

        public FormCrearProveedor()
        {
            InitializeComponent();
            this.Load += FormCrearProveedor_Load;
        }

        private void FormCrearProveedor_Load(object sender, EventArgs e)
        {
            // Inicializar el ComboBox de Actividad
            cmbActividadProveedor.Items.Add("Activo");
            cmbActividadProveedor.Items.Add("Inactivo");
            cmbActividadProveedor.SelectedIndex = 0; // Seleccionar "Activo" por defecto

            // Autofoco en el TextBox de Nombre
            txtNombreProveedor.Focus();
        }

        private void btnConfirmarCrearProveedor_Click(object sender, EventArgs e)
        {
            // Obtener los datos ingresados por el usuario
            string nombre = txtNombreProveedor.Text.Trim();
            string telefono = txtTelefonoProveedor.Text.Trim();
            string correo = txtCorreoProveedor.Text.Trim();
            string direccion = txtDireccionProveedor.Text.Trim();
            string actividad = cmbActividadProveedor.SelectedItem.ToString();

            // Validaciones
            if (string.IsNullOrEmpty(nombre) ||
                string.IsNullOrEmpty(telefono) ||
                string.IsNullOrEmpty(correo) ||
                string.IsNullOrEmpty(direccion))
            {
                MessageBox.Show("Por favor, completa todos los campos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (nombre.Length > 255 || telefono.Length > 255 || correo.Length > 255 || direccion.Length > 255)
            {
                MessageBox.Show("Los campos no deben exceder los 255 caracteres.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Insertar el nuevo proveedor en la base de datos
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO dbo.proveedores (nombre, telefono, correo_electronico, direccion, actividad) VALUES (@nombre, @telefono, @correo, @direccion, @actividad)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Usar parámetros para evitar SQL Injection
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@telefono", telefono);
                        cmd.Parameters.AddWithValue("@correo", correo);
                        cmd.Parameters.AddWithValue("@direccion", direccion);
                        cmd.Parameters.AddWithValue("@actividad", actividad);

                        conn.Open();
                        int filasAfectadas = cmd.ExecuteNonQuery();

                        if (filasAfectadas > 0)
                        {
                            MessageBox.Show("Proveedor creado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close(); // Cerrar el formulario después de la creación exitosa
                        }
                        else
                        {
                            MessageBox.Show("No se pudo crear el proveedor. Inténtalo nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores
                MessageBox.Show($"Ocurrió un error al crear el proveedor: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelarCrearProveedor_Click(object sender, EventArgs e)
        {
            this.Close(); // Cerrar el formulario sin realizar ninguna acción
        }
    }
}