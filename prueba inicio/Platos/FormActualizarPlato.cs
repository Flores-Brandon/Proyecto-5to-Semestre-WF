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
    public partial class FormActualizarPlato : Form
    {
        private int _idPlato;

        public FormActualizarPlato(int idPlato)
        {
            InitializeComponent();
            _idPlato = idPlato; // Guardamos el id del plato
            CargarDatosPlato();
        }
        static string connectionString = "Server=localhost\\SQLEXPRESS;Database=ProyectoRestaurante;Trusted_Connection=True;";
        // Método para cargar los datos del plato seleccionado
        private void CargarDatosPlato()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Platos WHERE id = @idPlato";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@idPlato", _idPlato);

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    txtActualizarNombrePlato.Text = reader["nombre"].ToString();
                    txtActualizarDescripcionPlato.Text = reader["descripcion"].ToString();
                    txtActualizarPrecioPlato.Text = reader["precio"].ToString();

                    // Si la columna "actividad" es "Activo", seleccionamos "Activo" en el combo
                    if (reader["actividad"].ToString() == "Activo")
                    {
                        cmbActividadPlato.SelectedIndex = 0; // Activo
                    }
                    else
                    {
                        cmbActividadPlato.SelectedIndex = 1; // Inactivo
                    }
                }
                reader.Close();
            }
        }

        // Evento del botón para confirmar la actualización
        private void btnConfirmarPlato_Click(object sender, EventArgs e)
        {
            string nombre = txtActualizarNombrePlato.Text;
            string descripcion = txtActualizarDescripcionPlato.Text;
            decimal precio = decimal.Parse(txtActualizarPrecioPlato.Text);
            string actividad = cmbActividadPlato.SelectedItem.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "UPDATE Platos SET nombre = @nombre, descripcion = @descripcion, precio = @precio, actividad = @actividad WHERE id = @idPlato";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@nombre", nombre);
                command.Parameters.AddWithValue("@descripcion", descripcion);
                command.Parameters.AddWithValue("@precio", precio);
                command.Parameters.AddWithValue("@actividad", actividad);
                command.Parameters.AddWithValue("@idPlato", _idPlato);

                try
                {
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("El plato se ha actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close(); // Cerrar el formulario de actualización
                    }
                    else
                    {
                        MessageBox.Show("No se pudo actualizar el plato.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar el plato: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Evento del botón de cancelar
        private void btnCancelarPlato_Click(object sender, EventArgs e)
        {
            this.Close(); // Cerrar el formulario sin hacer nada
        }
    }
}
