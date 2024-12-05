using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace prueba_inicio
{
    public partial class FormActualizarFactura : Form
    {
        public int FacturaId { get; set; } // Variable para almacenar el ID del empleado a actualizar
        // Constructor que recibe los datos de la factura seleccionada
        public FormActualizarFactura(int facturaId)
        {
            InitializeComponent();
            FacturaId = facturaId;
        }

        private void FormActualizarFactura_Load(object sender, EventArgs e)
        {
            // Cargar los clientes en cmbClienteFacturaActualizar (ejemplo)
            CargarClientes();
        }

        private void CargarClientes()
        {
            // Cadena de conexión a la base de datos
            string connectionString = "Server=localhost\\SQLEXPRESS;Database=ProyectoRestaurante;Trusted_Connection=True;";

            // Consulta SQL para obtener los datos del empleado
            string query = "SELECT cliente_id, monto, fecha, actividad FROM Facturas";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                dataAdapter.SelectCommand.Parameters.AddWithValue("@FactursId", FacturaId);

                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                {
                    // Asignamos los valores a los controles
                    txtClienteFacturaActualizar.Text = dataTable.Rows[0]["cliente_id"].ToString();
                    txtMontoFacturaActualizar.Text = dataTable.Rows[0]["monto"].ToString();
                    dtpFechaFacturaActualizar.Text = dataTable.Rows[0]["fecha"].ToString();
                    cmbActividadFacturaActualizar.SelectedItem = dataTable.Rows[0]["actividad"].ToString();               
                }
            }
        }

        // Evento del botón Confirmar Actualización
        private void btnConfirmarActualizarFactura_Click(object sender, EventArgs e)
        {
            string cliente_id = txtClienteFacturaActualizar.Text;
            string monto = txtMontoFacturaActualizar.Text;
            string fecha = dtpFechaFacturaActualizar.Text;
            string actividad = cmbActividadFacturaActualizar.SelectedItem.ToString();

            // Actualizar en la base de datos
            string connectionString = "Server=localhost\\SQLEXPRESS;Database=ProyectoRestaurante;Trusted_Connection=True;";
            string query = "UPDATE Facturas SET cliente_id = @cliente_id, monto = @monto, fecha = @fecha, actividad = @actividad";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@cliente_id", cliente_id);
                        cmd.Parameters.AddWithValue("@monto", monto);
                        cmd.Parameters.AddWithValue("@fecha", fecha);
                        cmd.Parameters.AddWithValue("@actividad", actividad);
                        cmd.Parameters.AddWithValue("@id", FacturaId); // Usamos el ID del empleado

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Empleado actualizado exitosamente", "Actualización", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close(); // Cerrar el formulario de actualización
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar empleado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}

