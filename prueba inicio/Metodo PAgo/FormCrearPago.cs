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
    public partial class FormCrearPago : Form
    {
        // Cadena de conexión a la base de datos
        private string connectionString = "Server=localhost\\SQLEXPRESS;Database=ProyectoRestaurante;Trusted_Connection=True;";

        public FormCrearPago()
        {
            InitializeComponent();
            this.Load += FormCrearPago_Load;
        }

        private void FormCrearPago_Load(object sender, EventArgs e)
        {
            txtMetodoPago.Focus(); // Autofoco en el TextBox al cargar el formulario
        }

        private void btnConfirmarPago_Click(object sender, EventArgs e)
        {
            // Obtener el nombre del método de pago ingresado
            string nombreMetodo = txtMetodoPago.Text.Trim();

            // Validar que el nombre no esté vacío
            if (string.IsNullOrEmpty(nombreMetodo))
            {
                MessageBox.Show("Por favor, ingresa el nombre del método de pago.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar la longitud del nombre
            if (nombreMetodo.Length > 255)
            {
                MessageBox.Show("El nombre del método de pago no debe exceder los 255 caracteres.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Verificar si el método de pago ya existe
            if (MetodoPagoExiste(nombreMetodo))
            {
                MessageBox.Show("El método de pago ingresado ya existe. Por favor, ingresa un nombre diferente.", "Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Insertar el nuevo método de pago en la base de datos
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO dbo.Métodos_de_Pago (nombre) VALUES (@nombre)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Usar parámetros para evitar SQL Injection
                        cmd.Parameters.AddWithValue("@nombre", nombreMetodo);

                        conn.Open();
                        int filasAfectadas = cmd.ExecuteNonQuery();

                        if (filasAfectadas > 0)
                        {
                            MessageBox.Show("Método de pago creado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close(); // Cerrar el formulario después de la creación exitosa
                        }
                        else
                        {
                            MessageBox.Show("No se pudo crear el método de pago. Inténtalo nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores
                MessageBox.Show($"Ocurrió un error al crear el método de pago: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool MetodoPagoExiste(string nombreMetodo)
        {
            bool existe = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT COUNT(*) FROM dbo.Métodos_de_Pago WHERE nombre = @nombre";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nombre", nombreMetodo);
                        conn.Open();
                        int count = (int)cmd.ExecuteScalar();
                        existe = count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al verificar existencia del método de pago: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return existe;
        }

        private void btnCancelarPago_Click(object sender, EventArgs e)
        {
            this.Close(); // Cerrar el formulario sin realizar ninguna acción
        }
    }
}

