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
    public partial class FormCrearPlato : Form
    {
        public FormCrearPlato()
        {
            InitializeComponent();
        }

        // Cadena de conexión a la base de datos
        static string connectionString = "Server=localhost\\SQLEXPRESS;Database=ProyectoRestaurante;Trusted_Connection=True;";

        private void InsertarMenuPrincipal()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Verificar si el menú principal ya existe
                    string queryVerificar = "SELECT COUNT(*) FROM Menú WHERE id = 1";
                    SqlCommand commandVerificar = new SqlCommand(queryVerificar, connection);
                    int count = (int)commandVerificar.ExecuteScalar();

                    // Si no existe, insertamos el menú principal
                    if (count == 0)
                    {
                        string queryInsertarMenu = "INSERT INTO Menú (nombre, restaurante_id) VALUES ('Menú Principal', 1)";

                        SqlCommand commandInsertar = new SqlCommand(queryInsertarMenu, connection);
                        int rowsAffected = commandInsertar.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Menú principal insertado correctamente.");
                        }
                        else
                        {
                            MessageBox.Show("Error al insertar el menú principal.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("El menú principal ya existe.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al insertar el menú principal: " + ex.Message);
                }
            }
        }

        private bool VerificarMenuExistente()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Consulta para verificar si el menu_id = 1 existe
                    string query = "SELECT COUNT(*) FROM Menú WHERE id = 1";
                    SqlCommand command = new SqlCommand(query, connection);

                    int count = (int)command.ExecuteScalar(); // Devuelve la cantidad de registros encontrados

                    return count > 0; // Si existe, devuelve true; si no, false.
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al verificar el menú: " + ex.Message);
                    return false;
                }
            }
        }

        // Evento para el botón Confirmar Plato
        private void btnConfirmarPlato_Click(object sender, EventArgs e)
        {
            string nombre = txtNombrePlato.Text;
            string descripcion = txtDescripcionPlato.Text;
            decimal precio;

            // Validar que los campos no estén vacíos
            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(descripcion) || !decimal.TryParse(txtPrecioPlato.Text, out precio))
            {
                MessageBox.Show("Por favor complete todos los campos.");
                return;
            }

            // Verificar si el menu_id = 1 existe
            if (!VerificarMenuExistente())
            {
                // Si no existe, insertar el menú principal
                InsertarMenuPrincipal();
            }

            // Insertar el plato en la base de datos
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Crear la consulta para insertar el nuevo plato
                    string query = "INSERT INTO Platos (nombre, descripcion, precio, menu_id) VALUES (@nombre, @descripcion, @precio, 1)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Definir los parámetros para la consulta
                        command.Parameters.AddWithValue("@nombre", nombre);
                        command.Parameters.AddWithValue("@descripcion", descripcion);
                        command.Parameters.AddWithValue("@precio", precio);

                        command.ExecuteNonQuery(); // Ejecutar la inserción

                        MessageBox.Show("Plato agregado exitosamente.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar el plato: " + ex.Message);
                }
                this.Close();
            }
        }


        private void btnCancelarMesa_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
