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
    public partial class FormCrearMesa : Form
    {
        // Conexión a la base de datos
        static string connectionString = "Server=localhost\\SQLEXPRESS;Database=ProyectoRestaurante;Trusted_Connection=True;";

        public FormCrearMesa()
        {
            InitializeComponent();
            if (cmbEstadoMesa.Items.Count > 1)
            {
                cmbEstadoMesa.SelectedIndex = 1;
            }
        }

        // Evento para confirmar la creación de la mesa
        private void btnConfirmarMesa_Click(object sender, EventArgs e)
        {
            // Verificar que todos los campos estén llenos
            if (string.IsNullOrWhiteSpace(txtNumeroMesa.Text) ||
                string.IsNullOrWhiteSpace(txtCapacidadMesa.Text) ||
                cmbEstadoMesa.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Obtener los valores de los controles
            int numeroMesa = Convert.ToInt32(txtNumeroMesa.Text);
            int capacidadMesa = Convert.ToInt32(txtCapacidadMesa.Text);
            string estadoMesa = cmbEstadoMesa.SelectedItem.ToString();

            // Asignar el restaurante_id (por ejemplo, el restaurante principal tiene el id 1)
            int restauranteId = 1;  // Esto debe ser dinámico si tienes más de un restaurante

            // Conectar a la base de datos
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Crear la consulta para insertar una nueva mesa
                    string query = "INSERT INTO Mesas (numero, capacidad, restaurante_id, actividad) VALUES (@numero, @capacidad, @restaurante_id, @actividad)";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        // Definir los parámetros para la consulta
                        cmd.Parameters.AddWithValue("@numero", numeroMesa);
                        cmd.Parameters.AddWithValue("@capacidad", capacidadMesa);
                        cmd.Parameters.AddWithValue("@restaurante_id", restauranteId);
                        cmd.Parameters.AddWithValue("@actividad", estadoMesa);

                        // Ejecutar la consulta
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Mesa creada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Cerrar el formulario de creación de mesa
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al crear mesa: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        // Evento para cancelar la creación de la mesa
        private void btnCancelarMesa_Click(object sender, EventArgs e)
        {
            this.Close(); // Cerrar el formulario sin hacer cambios
        }
    }
}