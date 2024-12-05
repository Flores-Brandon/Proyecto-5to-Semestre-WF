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
    public partial class FormActualizarProveedor : Form
    {
        // Cadena de conexión a la base de datos
        private string connectionString = "Server=localhost\\SQLEXPRESS;Database=ProyectoRestaurante;Trusted_Connection=True;";

        // Variables para almacenar los datos del proveedor a actualizar
        private int idProveedor;
        private string nombreActual;
        private string telefonoActual;
        private string correoActual;
        private string direccionActual;
        private string actividadActual;

        // Constructor que recibe los datos del proveedor seleccionado
        public FormActualizarProveedor(int id, string nombre, string telefono, string correo, string direccion, string actividad)
        {
            InitializeComponent();
            idProveedor = id;
            nombreActual = nombre;
            telefonoActual = telefono;
            correoActual = correo;
            direccionActual = direccion;
            actividadActual = actividad;
            this.Load += FormActualizarProveedor_Load;
        }

        private void FormActualizarProveedor_Load(object sender, EventArgs e)
        {
            // Asignar los valores actuales a los controles
            txtNombreProveedorActualizar.Text = nombreActual;
            txtTelefonoProveedorActualizar.Text = telefonoActual;
            txtCorreoProveedorActualizar.Text = correoActual;
            txtDireccionProveedorActualizar.Text = direccionActual;
            cmbActividadProveedorActualizar.Items.Add("Activo");
            cmbActividadProveedorActualizar.Items.Add("Inactivo");
            cmbActividadProveedorActualizar.SelectedItem = actividadActual;

            // Validar que cmbActividad tenga un valor seleccionado
            if (cmbActividadProveedorActualizar.SelectedItem == null)
            {
                cmbActividadProveedorActualizar.SelectedIndex = 0; // Seleccionar "Activo" por defecto
            }

            txtNombreProveedorActualizar.Focus(); // Autofoco en el TextBox de Nombre
        }

        private void btnConfirmarActualizarProveedor_Click(object sender, EventArgs e)
        {
            // Obtener los datos ingresados por el usuario
            string nuevoNombre = txtNombreProveedorActualizar.Text.Trim();
            string nuevoTelefono = txtTelefonoProveedorActualizar.Text.Trim();
            string nuevoCorreo = txtCorreoProveedorActualizar.Text.Trim();
            string nuevaDireccion = txtDireccionProveedorActualizar.Text.Trim();
            string nuevaActividad = cmbActividadProveedorActualizar.SelectedItem.ToString();

            // Validaciones
            if (string.IsNullOrEmpty(nuevoNombre) ||
                string.IsNullOrEmpty(nuevoTelefono) ||
                string.IsNullOrEmpty(nuevoCorreo) ||
                string.IsNullOrEmpty(nuevaDireccion))
            {
                MessageBox.Show("Por favor, completa todos los campos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (nuevoNombre.Length > 255 || nuevoTelefono.Length > 255 || nuevoCorreo.Length > 255 || nuevaDireccion.Length > 255)
            {
                MessageBox.Show("Los campos no deben exceder los 255 caracteres.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Verificar si el nombre ha cambiado y si el nuevo nombre ya existe
            if (!nuevoNombre.Equals(nombreActual, StringComparison.OrdinalIgnoreCase))
            {
                if (ProveedorExiste(nuevoNombre))
                {
                    MessageBox.Show("El proveedor ingresado ya existe. Por favor, ingresa un nombre diferente.", "Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNombreProveedorActualizar.Focus();
                    return;
                }
            }

            // Actualizar el proveedor en la base de datos
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE dbo.proveedores SET nombre = @nombre, telefono = @telefono, correo_electronico = @correo, direccion = @direccion, actividad = @actividad WHERE id = @id";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Usar parámetros para evitar SQL Injection
                        cmd.Parameters.AddWithValue("@nombre", nuevoNombre);
                        cmd.Parameters.AddWithValue("@telefono", nuevoTelefono);
                        cmd.Parameters.AddWithValue("@correo", nuevoCorreo);
                        cmd.Parameters.AddWithValue("@direccion", nuevaDireccion);
                        cmd.Parameters.AddWithValue("@actividad", nuevaActividad);
                        cmd.Parameters.AddWithValue("@id", idProveedor);

                        conn.Open();
                        int filasAfectadas = cmd.ExecuteNonQuery();

                        if (filasAfectadas > 0)
                        {
                            MessageBox.Show("Proveedor actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close(); // Cerrar el formulario después de la actualización exitosa
                        }
                        else
                        {
                            MessageBox.Show("No se pudo actualizar el proveedor. Inténtalo nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores
                MessageBox.Show($"Ocurrió un error al actualizar el proveedor: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ProveedorExiste(string nombreProveedor)
        {
            bool existe = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT COUNT(*) FROM dbo.proveedores WHERE nombre = @nombre";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nombre", nombreProveedor);
                        conn.Open();
                        int count = (int)cmd.ExecuteScalar();
                        existe = count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al verificar existencia del proveedor: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return existe;
        }

        private void btnCancelarActualizarProveedor_Click(object sender, EventArgs e)
        {
            this.Close(); // Cerrar el formulario sin realizar ninguna acción
        }
    }
}
