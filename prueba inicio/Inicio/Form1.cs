using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Text;

namespace prueba_inicio
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            txtContraseña.PasswordChar = '*'; // Para enmascarar la contraseña
        }

        // Cadena de conexión a la base de datos
        static string connectionString = "Server=localhost\\SQLEXPRESS;Database=ProyectoRestaurante;Trusted_Connection=True;";

        // Método para encriptar la contraseña utilizando SHA256
        static string EncriptarContrasena(string contrasena)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Convertir la contraseña a bytes y hacer el hash
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(contrasena));

                // Convertir los bytes a un string hexadecimal
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }

                return builder.ToString();
            }
        }

        // Evento para el botón de iniciar sesión
        private void btnIniciarSersion_Click(object sender, EventArgs e)
        {
            string usuario = txtNombreUsuario.Text;
            string contrasena = txtContraseña.Text;
            string actividad;
            string puesto;
            int empleadoId;
            // Validar que los campos no estén vacíos
            if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(contrasena))
            {
                MessageBox.Show("Por favor ingrese ambos campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (AutenticarUsuario(usuario, contrasena, out empleadoId, out actividad, out puesto))
            {
                MessageBox.Show("felicidades lograste entrar");
                FormCruds formCruds = new FormCruds(usuario);
                formCruds.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("no se a podido acceder");
                return;
            }
        }
        private bool AutenticarUsuario(string usuario, string contrasena, out int empleadoId, out string actividad, out string puesto)
        {
            empleadoId = 0;
            actividad = string.Empty;
            puesto = string.Empty;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Consulta SQL para verificar el usuario y la contraseña en la tabla 'empleado'
                string query = "SELECT id, actividad, puesto FROM empleados WHERE usuario = @usuario AND contrasena = @contrasena";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@usuario", usuario);
                    cmd.Parameters.AddWithValue("@contrasena", EncriptarContrasena(contrasena));

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            empleadoId = reader.GetInt32(0); // Obtener el ID del empleado
                            actividad = reader.GetString(1);
                            puesto = reader.GetString(2);
                            return true; // Usuario autenticado
                        }
                    }
                }
            }

            return false; // Si no se encuentra el usuario, autenticación fallida
        }
    }
}
