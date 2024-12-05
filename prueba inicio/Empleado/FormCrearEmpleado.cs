using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace prueba_inicio
{
    public partial class FormCrearEmpleado : Form
    {
        public FormCrearEmpleado()
        {
            InitializeComponent();
        }

        // Cadena de conexión a la base de datos
        static string connectionString = "Server=localhost\\SQLEXPRESS;Database=ProyectoRestaurante;Trusted_Connection=True;";

        // Método para verificar si el restaurante principal existe y crear uno si no
        private void VerificarYCrearRestaurantePrincipal()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Verificar si el restaurante principal con id = 1 ya existe
                    string checkQuery = "SELECT COUNT(*) FROM Restaurante WHERE id = 1";
                    SqlCommand checkCmd = new SqlCommand(checkQuery, connection);
                    int count = (int)checkCmd.ExecuteScalar();

                    if (count == 0) // Si no existe, crear el restaurante principal
                    {
                        string insertQuery = "INSERT INTO Restaurante (nombre, direccion, telefono) VALUES ('Restaurante Principal', 'Dirección Principal', '1234567890')";
                        SqlCommand insertCmd = new SqlCommand(insertQuery, connection);
                        insertCmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al verificar o crear el restaurante principal: " + ex.Message);
                }
            }
        }

        // Método para encriptar la contraseña con SHA256
        public static string EncriptarConSHA256(string texto)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(texto));
                StringBuilder hashStringBuilder = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    hashStringBuilder.Append(b.ToString("x2"));
                }
                return hashStringBuilder.ToString();
            }
        }

        // Evento para crear el nuevo empleado
        private void btnConfirmarEmpleado_Click(object sender, EventArgs e)
        {
            string nombre = txtNombreEmpleado.Text;
            string puesto = cmbPuestoEmpleado.SelectedItem.ToString();
            string salario = txtSalarioEmpleado.Text;
            string usuario = txtUsuarioEmpleado.Text;
            string contrasena = txtContraseñaEmpleado.Text;

            // Validar que los campos no estén vacíos
            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(puesto) ||
                string.IsNullOrWhiteSpace(salario) || string.IsNullOrWhiteSpace(usuario) ||
                string.IsNullOrWhiteSpace(contrasena))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Encriptamos la contraseña
            string contrasenaEncriptada = EncriptarConSHA256(contrasena);

            // Verificar si el restaurante principal existe y crear uno si no
            VerificarYCrearRestaurantePrincipal();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Obtenemos el id del restaurante principal
                    string selectRestauranteId = "SELECT id FROM Restaurante WHERE nombre = 'Restaurante Principal'";
                    SqlCommand selectCmd = new SqlCommand(selectRestauranteId, connection);
                    int restauranteId = (int)selectCmd.ExecuteScalar();

                    // Insertamos el nuevo empleado
                    string insertQuery = "INSERT INTO Empleados (nombre, puesto, salario, usuario, contrasena, restaurante_id, actividad) " +
                                         "VALUES (@nombre, @puesto, @salario, @usuario, @contrasena, @restaurante_id, @actividad)";

                    SqlCommand insertCmd = new SqlCommand(insertQuery, connection);
                    insertCmd.Parameters.AddWithValue("@nombre", nombre);
                    insertCmd.Parameters.AddWithValue("@puesto", puesto);
                    insertCmd.Parameters.AddWithValue("@salario", salario);
                    insertCmd.Parameters.AddWithValue("@usuario", usuario);
                    insertCmd.Parameters.AddWithValue("@contrasena", contrasenaEncriptada);
                    insertCmd.Parameters.AddWithValue("@restaurante_id", restauranteId);  // Asociar con el restaurante principal
                    insertCmd.Parameters.AddWithValue("@actividad", "Activo");  // Nuevo empleado se crea con actividad activa

                    insertCmd.ExecuteNonQuery();

                    MessageBox.Show("Empleado creado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();  // Cerrar el formulario al guardar
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al crear el empleado: " + ex.Message);
                }
            }
        }

        // Evento para cancelar la creación del empleado
        private void btnCancelarEmpleado_Click(object sender, EventArgs e)
        {
            this.Close();  // Cerrar el formulario sin guardar
        }
    }
}
