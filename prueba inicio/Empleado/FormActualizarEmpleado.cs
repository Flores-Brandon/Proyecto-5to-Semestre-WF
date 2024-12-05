using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prueba_inicio
{
    public partial class FormActualizarEmpleado : Form
    {
        public int EmpleadoId { get; set; } // Variable para almacenar el ID del empleado a actualizar

        public FormActualizarEmpleado(int empleadoId)
        {
            InitializeComponent();
            EmpleadoId = empleadoId;  // Guardamos el ID del empleado
        }

        private void FormActualizarEmpleado_Load(object sender, EventArgs e)
        {
            CargarDatosEmpleado();
        }

        private void CargarDatosEmpleado()
        {
            // Cadena de conexión a la base de datos
            string connectionString = "Server=localhost\\SQLEXPRESS;Database=ProyectoRestaurante;Trusted_Connection=True;";

            // Consulta SQL para obtener los datos del empleado
            string query = "SELECT nombre, salario, usuario, contrasena, puesto, actividad FROM Empleados WHERE id = @EmpleadoId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                dataAdapter.SelectCommand.Parameters.AddWithValue("@EmpleadoId", EmpleadoId);

                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                {
                    // Asignamos los valores a los controles
                    txtActualizarNombreEmpleado.Text = dataTable.Rows[0]["nombre"].ToString();
                    txtActualizarSalarioEmpleado.Text = dataTable.Rows[0]["salario"].ToString();
                    txtActualizarUsuarioEmpleado.Text = dataTable.Rows[0]["usuario"].ToString();
                    txtActualizarContraseñaEmpleado.Text = dataTable.Rows[0]["contrasena"].ToString();
                    cmbActualizarPuestoEmpleado.SelectedItem = dataTable.Rows[0]["puesto"].ToString();
                    cmbActividad.SelectedItem = dataTable.Rows[0]["actividad"].ToString();
                }
            }
        }
        private void btnActualizarEmpleado_Click(object sender, EventArgs e)
        {
            string nombre = txtActualizarNombreEmpleado.Text;
            string salario = txtActualizarSalarioEmpleado.Text;
            string usuario = txtActualizarUsuarioEmpleado.Text;
            string contrasena = txtActualizarContraseñaEmpleado.Text;
            string puesto = cmbActualizarPuestoEmpleado.SelectedItem.ToString();
            string actividad = cmbActividad.SelectedItem.ToString(); // "Activo" o "Inactivo"

            // Actualizar en la base de datos
            string connectionString = "Server=localhost\\SQLEXPRESS;Database=ProyectoRestaurante;Trusted_Connection=True;";
            string query = "UPDATE Empleados SET nombre = @nombre, salario = @salario, usuario = @usuario, contrasena = @contrasena, puesto = @puesto, actividad = @actividad WHERE id = @id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@salario", salario);
                        cmd.Parameters.AddWithValue("@usuario", usuario);
                        cmd.Parameters.AddWithValue("@contrasena", contrasena);
                        cmd.Parameters.AddWithValue("@puesto", puesto);
                        cmd.Parameters.AddWithValue("@actividad", actividad);
                        cmd.Parameters.AddWithValue("@id", EmpleadoId); // Usamos el ID del empleado

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


        private void btnCancelarActualizacionEmpleado_Click(object sender, EventArgs e)
        
        {
            this.Close();
        }
    }
}
