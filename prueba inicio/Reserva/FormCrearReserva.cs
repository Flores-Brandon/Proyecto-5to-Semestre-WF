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
    public partial class FormCrearReserva : Form
    {
        // Cadena de conexión a la base de datos
        static string connectionString = "Server=localhost\\SQLEXPRESS;Database=ProyectoRestaurante;Trusted_Connection=True;";

        public FormCrearReserva()
        {
            InitializeComponent();
            // Llamamos a la función para cargar los datos al iniciar el formulario
            CargarClientes();
            CargarMesas();
            cmbEstadoReserva.Items.Add("Confirmada");
            cmbEstadoReserva.Items.Add("Cancelada");
            cmbEstadoReserva.SelectedIndex = 0; // Estado por defecto "Confirmada"
        }

        // Método para cargar los clientes al ComboBox
        private void CargarClientes()
        {
            string query = "SELECT id, nombre FROM Clientes WHERE actividad = 'Activo'";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cmbClientes.DataSource = dt;
                cmbClientes.DisplayMember = "nombre";
                cmbClientes.ValueMember = "id";  // Aquí guardamos el ID del cliente
            }
        }

        // Método para cargar las mesas al ComboBox
        private void CargarMesas()
        {
            string query = "SELECT id, numero FROM Mesas WHERE actividad = 'Libre'";  // Solo mesas libres
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cmbMesas.DataSource = dt;
                cmbMesas.DisplayMember = "numero";
                cmbMesas.ValueMember = "id";  // Aquí guardamos el ID de la mesa
            }
        }

        // Método para guardar la reserva
        private void btnConfirmarReserva_Click(object sender, EventArgs e)
        {
            // Verificar si todos los campos están completos
            if (cmbClientes.SelectedItem == null || cmbMesas.SelectedItem == null || dtpFechaHora.Value == null)
            {
                MessageBox.Show("Por favor complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                int clienteId = Convert.ToInt32(cmbClientes.SelectedValue);
                int mesaId = Convert.ToInt32(cmbMesas.SelectedValue);
                DateTime fechaHora = dtpFechaHora.Value;
                string estado = cmbEstadoReserva.SelectedItem.ToString();

                // Consulta SQL para insertar la reserva
                string query = "INSERT INTO Reservas (cliente_id, mesa_id, fecha_hora, estado) " +
                               "VALUES (@cliente_id, @mesa_id, @fecha_hora, @estado)";

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@cliente_id", clienteId);
                    cmd.Parameters.AddWithValue("@mesa_id", mesaId);
                    cmd.Parameters.AddWithValue("@fecha_hora", fechaHora);
                    cmd.Parameters.AddWithValue("@estado", estado);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Reserva creada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();  // Cerrar el formulario después de guardar la reserva
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar la reserva: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para cancelar la reserva
        private void btnCancelarReserva_Click(object sender, EventArgs e)
        {
            this.Close();  // Solo cerrar el formulario sin hacer nada
        }
    }
}

