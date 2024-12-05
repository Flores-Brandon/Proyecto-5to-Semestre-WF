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
    public partial class FormActualizarMetodoPago : Form
    {
        // Cadena de conexión a la base de datos
        private string connectionString = "Server=localhost\\SQLEXPRESS;Database=ProyectoRestaurante;Trusted_Connection=True;";

        // Variables para almacenar los datos del método de pago a actualizar
        private int idMetodoPago;
        private string nombreActual;
        private string actividadActual;

        // Constructor que recibe los datos del método de pago seleccionado
        public FormActualizarMetodoPago(int id, string nombre, string actividad)
        {
            InitializeComponent();
            idMetodoPago = id;
            nombreActual = nombre;
            actividadActual = actividad;
        }

        // Evento Load del formulario para inicializar los controles
        private void FormActualizarPago_Load(object sender, EventArgs e)
        {
            // Asignar los valores actuales a los controles
            txtActualizarMetodoPago.Text = nombreActual;
            cmbActividad.SelectedItem = actividadActual;

            // Validar que cmbActividad tenga un valor seleccionado
            if (cmbActividad.SelectedItem == null)
            {
                cmbActividad.SelectedIndex = 0; // Seleccionar "Activo" por defecto
            }

            txtActualizarMetodoPago.Focus(); // Autofoco en el TextBox al cargar el formulario
        }

        // Evento Click del botón Confirmar Actualización
        private void btnConfirmarActualizarPago_Click(object sender, EventArgs e)
        {
            // Obtener los valores ingresados por el usuario
            string nuevoNombre = txtActualizarMetodoPago.Text.Trim();
            string nuevaActividad = cmbActividad.SelectedItem.ToString();

            // Validar que el nombre no esté vacío
            if (string.IsNullOrEmpty(nuevoNombre))
            {
                MessageBox.Show("Por favor, ingresa el nombre del método de pago.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtActualizarMetodoPago.Focus();
                return;
            }

            // Validar la longitud del nombre
            if (nuevoNombre.Length > 255)
            {
                MessageBox.Show("El nombre del método de pago no debe exceder los 255 caracteres.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtActualizarMetodoPago.Focus();
                return;
            }

            // Verificar si el método de pago ya existe (si el nombre ha cambiado)
            if (!nuevoNombre.Equals(nombreActual, StringComparison.OrdinalIgnoreCase))
            {
                if (MetodoPagoExiste(nuevoNombre))
                {
                    MessageBox.Show("El método de pago ingresado ya existe. Por favor, ingresa un nombre diferente.", "Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtActualizarMetodoPago.Focus();
                    return;
                }
            }

            // Actualizar el método de pago en la base de datos
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE dbo.Métodos_de_Pago SET nombre = @nombre, actividad = @actividad WHERE id = @id";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Usar parámetros para evitar SQL Injection
                        cmd.Parameters.AddWithValue("@nombre", nuevoNombre);
                        cmd.Parameters.AddWithValue("@actividad", nuevaActividad);
                        cmd.Parameters.AddWithValue("@id", idMetodoPago);

                        conn.Open();
                        int filasAfectadas = cmd.ExecuteNonQuery();

                        if (filasAfectadas > 0)
                        {
                            MessageBox.Show("Método de pago actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close(); // Cerrar el formulario después de la actualización exitosa
                        }
                        else
                        {
                            MessageBox.Show("No se pudo actualizar el método de pago. Inténtalo nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores
                MessageBox.Show($"Ocurrió un error al actualizar el método de pago: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento Click del botón Cancelar Actualización
        private void btnCancelarActualizarPago_Click(object sender, EventArgs e)
        {
            this.Close(); // Cerrar el formulario sin realizar ninguna acción
        }

        // Método para verificar si un método de pago con el mismo nombre ya existe
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
    }
}

