using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace prueba_inicio
{
    public partial class FormActualizarReserva : Form
    {
        public FormActualizarReserva()
        {
            InitializeComponent();
        }

        // Cadena de conexión a la base de datos
        static string connectionString = "Server=localhost\\SQLEXPRESS;Database=ProyectoRestaurante;Trusted_Connection=True;";

        private int reservaId; // ID de la reserva a actualizar

        // Método para cargar la reserva seleccionada
        public void CargarReserva(int idReserva)
        {
            reservaId = idReserva;

            // Llenar los ComboBoxes de Clientes, Mesas y Estado con los datos de la base de datos
            LlenarComboBoxClientes();
            LlenarComboBoxMesas();
            LlenarComboBoxEstado();

            // Cargar los datos de la reserva
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT ClienteId, MesaId, FechaHora, Estado FROM Reservas WHERE Id = @reservaId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@reservaId", reservaId);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        // Asignar los valores a los controles
                        cmbActualizarClientes.SelectedValue = reader["ClienteId"];
                        cmbActualizarMesas.SelectedValue = reader["MesaId"];
                        dtpActualizarFechaHora.Value = Convert.ToDateTime(reader["FechaHora"]);
                        cmbActualizarEstadoReserva.SelectedItem = reader["Estado"].ToString();
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar la reserva: " + ex.Message);
                }
            }
        }

        // Método para llenar el ComboBox de Clientes
        private void LlenarComboBoxClientes()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Id, Nombre FROM Clientes WHERE Actividad = 'Activo'";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dtClientes = new DataTable();
                adapter.Fill(dtClientes);

                cmbActualizarClientes.DisplayMember = "Nombre";
                cmbActualizarClientes.ValueMember = "Id";
                cmbActualizarClientes.DataSource = dtClientes;
            }
        }

        // Método para llenar el ComboBox de Mesas
        private void LlenarComboBoxMesas()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Id, Numero FROM Mesas WHERE Actividad = 'Activo'";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dtMesas = new DataTable();
                adapter.Fill(dtMesas);

                cmbActualizarMesas.DisplayMember = "Numero";
                cmbActualizarMesas.ValueMember = "Id";
                cmbActualizarMesas.DataSource = dtMesas;
            }
        }

        // Método para llenar el ComboBox de Estado de la Reserva
        private void LlenarComboBoxEstado()
        {
            // Agregar las opciones de estado al ComboBox
            cmbActualizarEstadoReserva.Items.Add("Confirmada");
            cmbActualizarEstadoReserva.Items.Add("Cancelada");
            cmbActualizarEstadoReserva.Items.Add("Pendiente");
            cmbActualizarEstadoReserva.SelectedIndex = 0; // Selecciona "Confirmada" por defecto
        }

        // Método para actualizar la reserva
        private void btnConfirmarActualizarReserva_Click(object sender, EventArgs e)
        {
            string query = "UPDATE Reservas SET ClienteId = @clienteId, MesaId = @mesaId, FechaHora = @fechaHora, Estado = @estado WHERE Id = @reservaId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@clienteId", cmbActualizarClientes.SelectedValue);
                command.Parameters.AddWithValue("@mesaId", cmbActualizarMesas.SelectedValue);
                command.Parameters.AddWithValue("@fechaHora", dtpActualizarFechaHora.Value);
                command.Parameters.AddWithValue("@estado", cmbActualizarEstadoReserva.SelectedItem.ToString());
                command.Parameters.AddWithValue("@reservaId", reservaId);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Reserva actualizada correctamente.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar la reserva: " + ex.Message);
                }
            }
        }
        private void btnCancelarReserva_Click(object sender, EventArgs e)
        {
            this.Close(); // Cerrar el formulario sin realizar cambios
        }
    }
}
