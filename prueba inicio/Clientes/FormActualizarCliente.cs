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
    public partial class FormActualizarCliente : Form
    {
        private int clienteId; // ID del cliente que se va a actualizar

        public FormActualizarCliente(int id)
        {
            InitializeComponent();
            clienteId = id;
        }
        static string connectionString = "Server=localhost\\SQLEXPRESS;Database=ProyectoRestaurante;Trusted_Connection=True;";
        private void FormsActualizarCliente_Load(object sender, EventArgs e)
        {
            // Al cargar el formulario, cargar los datos del cliente seleccionado
            CargarDatosCliente();
        }

        private void CargarDatosCliente()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM Clientes WHERE id = @id";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@id", clienteId);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        txtActualizarNombreCliente.Text = reader["nombre"].ToString();
                        txtActualizarTelefonoCliente.Text = reader["telefono"].ToString();
                        txtActualizarEmailCliente.Text = reader["email"].ToString();
                        txtActualizarDireccionCliente.Text = reader["direccion"].ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar los datos del cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Evento para actualizar los datos del cliente
        private void btnActualizarCliente_Click(object sender, EventArgs e)
        {
            string nombre = txtActualizarNombreCliente.Text;
            string telefono = txtActualizarTelefonoCliente.Text;
            string email = txtActualizarEmailCliente.Text;
            string direccion = txtActualizarDireccionCliente.Text;
            string actividad = cmbEstadoCliente.SelectedItem.ToString();  // Obtener el estado del ComboBox

            // Verificar que los campos no estén vacíos
            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(telefono) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(direccion))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Actualizar los datos del cliente en la base de datos
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "UPDATE Clientes SET nombre = @nombre, telefono = @telefono, email = @email, direccion = @direccion, actividad = @actividad WHERE id = @id";

                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@telefono", telefono);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@direccion", direccion);
                    cmd.Parameters.AddWithValue("@actividad", actividad);  // Actualizar el estado del cliente
                    cmd.Parameters.AddWithValue("@id", clienteId);  // ID del cliente a actualizar

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Cliente actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();  // Cerrar el formulario después de la actualización
                    }
                    else
                    {
                        MessageBox.Show("No se encontraron registros para actualizar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar el cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Evento para cancelar la actualización
        private void btnCancelarActualizacionCliente_Click(object sender, EventArgs e)
        {
            this.Close(); // Cerrar el formulario sin realizar cambios
        }

        private void chkActividadCliente_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}

