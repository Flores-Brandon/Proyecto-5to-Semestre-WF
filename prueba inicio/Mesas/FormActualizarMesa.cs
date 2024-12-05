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
    public partial class FormActualizarMesa : Form
    {
        private int mesaId; // ID de la mesa a actualizar

        // Conexión a la base de datos
        static string connectionString = "Server=localhost\\SQLEXPRESS;Database=ProyectoRestaurante;Trusted_Connection=True;";

        // Constructor que recibe el ID de la mesa
        public FormActualizarMesa(int mesaId)
        {
            InitializeComponent();
            this.mesaId = mesaId;
        }

        private void FormActualizarMesa_Load(object sender, EventArgs e)
        {
            // Cargar los datos actuales de la mesa seleccionada en los TextBox y ComboBox
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Consulta para obtener los datos de la mesa
                    string query = "SELECT * FROM Mesas WHERE id = @mesaId";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@mesaId", mesaId);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        // Rellenar los controles con los datos de la mesa
                        txtActualizarNumeroMesa.Text = reader["numero"].ToString();
                        txtActualizarCapacidadMesa.Text = reader["capacidad"].ToString();
                        cmbActualizarEstadoMesa.SelectedItem = reader["actividad"].ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar los datos de la mesa: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnConfirmarActualizarMesa_Click(object sender, EventArgs e)
        {
            // Validar los campos
            if (string.IsNullOrWhiteSpace(txtActualizarNumeroMesa.Text) || string.IsNullOrWhiteSpace(txtActualizarCapacidadMesa.Text) || cmbActualizarEstadoMesa.SelectedItem == null)
            {
                MessageBox.Show("Por favor complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Obtener los valores de los controles
            int numeroMesa = Convert.ToInt32(txtActualizarNumeroMesa.Text);
            int capacidadMesa = Convert.ToInt32(txtActualizarCapacidadMesa.Text);
            string estadoMesa = cmbActualizarEstadoMesa.SelectedItem.ToString();

            // Actualizar la mesa en la base de datos
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Consulta para actualizar la mesa
                    string query = "UPDATE Mesas SET numero = @numero, capacidad = @capacidad, actividad = @actividad WHERE id = @mesaId";

                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@numero", numeroMesa);
                    cmd.Parameters.AddWithValue("@capacidad", capacidadMesa);
                    cmd.Parameters.AddWithValue("@actividad", estadoMesa);
                    cmd.Parameters.AddWithValue("@mesaId", mesaId);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Mesa actualizada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Cerrar el formulario de actualización
                    this.Close();

                    // Llamar al método para actualizar el DataGridView en el formulario principal
                    ((FormCruds)this.Owner).CargarMesas(); // Suponiendo que tienes un método en FormCruds para cargar las mesas
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar la mesa: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancelarActualizacionMesa_Click(object sender, EventArgs e)
        {
            // Cerrar el formulario sin hacer cambios
            this.Close();
        }
    }
}
