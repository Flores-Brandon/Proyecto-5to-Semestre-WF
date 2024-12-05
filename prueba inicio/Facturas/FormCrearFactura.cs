using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace prueba_inicio
{
    public partial class FormCrearFactura : Form
    {
        private readonly string connectionString = "Server=localhost\\SQLEXPRESS;Database=ProyectoRestaurante;Trusted_Connection=True;";

        public FormCrearFactura()
        {
            InitializeComponent();
            // Llamada a la función que carga los clientes en el ComboBox
            CargarClientes();
        }

        private void CargarClientes()
        {
            // Consulta SQL para obtener los clientes (ajustar según tu conexión)
            string query = "SELECT id, nombre FROM Clientes";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                // Llenar el ComboBox con los nombres de los clientes
                while (reader.Read())
                {
                    cmbClienteFactura.Items.Add(new { Text = reader["nombre"].ToString(), Value = reader["id"] });
                }

                reader.Close();
            }
        }

        private void btnConfirmarCrearFactura_Click(object sender, EventArgs e)
        {
            // Obtener los datos del formulario
            int clienteId = ((dynamic)cmbClienteFactura.SelectedItem).Value;
            decimal monto = Convert.ToDecimal(txtMontoFactura.Text);
            DateTime fecha = dtpFechaFactura.Value;
            string actividad = cmbActividad.SelectedItem.ToString();

            // Consulta SQL para insertar la factura
            string query = "INSERT INTO Facturas (cliente_id, monto, fecha, actividad) " +
                           "VALUES (@cliente_id, @monto, @fecha, @actividad)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);

                // Agregar parámetros a la consulta
                cmd.Parameters.AddWithValue("@cliente_id", clienteId);
                cmd.Parameters.AddWithValue("@monto", monto);
                cmd.Parameters.AddWithValue("@fecha", fecha);
                cmd.Parameters.AddWithValue("@actividad", actividad);

                try
                {
                    // Ejecutar la consulta
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Factura creada con éxito.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al crear la factura: " + ex.Message);
                }
            }
        }

        private void btnCancelarCrearFactura_Click(object sender, EventArgs e)
        {
            // Cerrar el formulario si el usuario cancela la creación
            this.Close();
        }
    }
}
