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

namespace prueba_inicio
{
    public partial class FormCrearCliente : Form
    {
        public FormCrearCliente()
        {
            InitializeComponent();
        }
        //conectamos la base de datos
        static string connectionString = "Server=localhost\\SQLEXPRESS;Database=ProyectoRestaurante;Trusted_Connection=True;";

        private void btnCrearCliente_Click(object sender, EventArgs e)
        {
            // Validar los campos antes de guardar
            if (string.IsNullOrWhiteSpace(txtNombreCliente.Text) || string.IsNullOrWhiteSpace(txtTelefonoCliente.Text) ||
                string.IsNullOrWhiteSpace(txtEmailCliente.Text) || string.IsNullOrWhiteSpace(txtDireccionCliente.Text))
            {
                MessageBox.Show("Por favor complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Si todo está correcto, cerramos el formulario y pasamos los datos de vuelta
            this.DialogResult = DialogResult.OK;
            this.Close();

            // Conexión a la base de datos
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Crear la consulta para insertar un nuevo cliente
                    string query = "INSERT INTO Clientes (nombre, email, telefono, direccion) VALUES (@nombre, @email, @telefono, @direccion)";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        // Definir los parámetros para la consulta
                        cmd.Parameters.AddWithValue("@nombre", txtNombreCliente.Text);
                        cmd.Parameters.AddWithValue("@email", txtEmailCliente.Text);
                        cmd.Parameters.AddWithValue("@telefono", txtTelefonoCliente.Text);
                        cmd.Parameters.AddWithValue("@direccion", txtDireccionCliente.Text); // Añadido el parámetro para la dirección

                        // Ejecutar la consulta
                        cmd.ExecuteNonQuery();
                    }

                    // Mostrar mensaje de éxito
                    MessageBox.Show("Cliente guardado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Opcional: Cerrar el formulario después de guardar
                    this.Close();  // Cierra el formulario actual (FormCrearCliente)
                }
                catch (Exception ex)
                {
                    // Mostrar error si algo sale mal
                    MessageBox.Show("Error al guardar el cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnCancelarCliente_Click(object sender, EventArgs e)
        {
            // Cerrar el formulario 
            this.Close();
        }
    }
}
