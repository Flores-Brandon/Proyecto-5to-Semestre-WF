using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace prueba_inicio
{
    public partial class FormCruds : Form
    {
        private string usuario;
        public FormCruds(string usuario)
        {
            InitializeComponent();
            this.usuario=usuario;
        }

        //conectamos la base de datos
        static string connectionString = "Server=localhost\\SQLEXPRESS;Database=ProyectoRestaurante;Trusted_Connection=True;";

        private void btnLeerCliente_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Solo mostrar clientes con actividad 'Activo'
                    string query = "SELECT * FROM Clientes WHERE actividad = 'Activo'";
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();

                    // Llenar el DataTable con los datos de la base de datos
                    dataAdapter.Fill(dataTable);

                    // Asignar el DataTable al DataGridView
                    dataGridViewClientes.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar los clientes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Crear cliente
        private void btnCrearCliente_Click(object sender, EventArgs e)
        {

                // Abrir el formulario para crear cliente
                FormCrearCliente crearClienteForm = new FormCrearCliente();
                crearClienteForm.ShowDialog();  // Mostrar el formulario como un 
        }

        // Abrir formulario para actualizar cliente
        private void btnActualizarCliente_Click(object sender, EventArgs e)
        {
            if (dataGridViewClientes.SelectedRows.Count > 0)
            {
                // Obtener el ID del cliente seleccionado
                int clienteId = Convert.ToInt32(dataGridViewClientes.SelectedRows[0].Cells["id"].Value);

                // Crear el formulario de actualización y pasar el ID del cliente
                FormActualizarCliente actualizarClienteForm = new FormActualizarCliente(clienteId);
                actualizarClienteForm.ShowDialog();  // Mostrar el formulario de actualización
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un cliente para actualizar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private string CargarUsuario(string usuario)
        {
            string puesto = string.Empty;
            // Establecer la conexión y ejecutar la consulta
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT Puesto FROM Empleados WHERE usuario = @usuario";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Agregar parámetro para evitar inyección SQL
                        command.Parameters.AddWithValue("@usuario", usuario);

                        // Ejecutar la consulta y obtener el resultado
                        object result = command.ExecuteScalar();

                        if (result != null)
                        {
                            puesto = result.ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ocurrió un error: {ex.Message}");
                }
            }
            return puesto;
        }
        private void CargarClientes()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM Clientes";
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    // Asignar los datos al DataGridView
                    dataGridViewClientes.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar los clientes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCrearEmpleado_Click(object sender, EventArgs e)
        {
            string puesto = CargarUsuario(usuario);
            if (puesto == "Gerente")
            {
                // Abrir el formulario de creación de empleado
                FormCrearEmpleado crearEmpleadoForm = new FormCrearEmpleado();
                crearEmpleadoForm.ShowDialog();  // Abrir como modal para esperar la acción
            }
        }

        private void btnLeerEmpleado_Click(object sender, EventArgs e)
        {
            string connectionString = "Server=localhost\\SQLEXPRESS;Database=ProyectoRestaurante;Trusted_Connection=True;";
            string query = "SELECT * FROM Empleados WHERE actividad = 'Activo'"; // Solo empleados activos

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();

                    dataAdapter.Fill(dataTable);

                    // Asignamos el DataTable al DataGridView
                    dataGridViewEmpleados.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar empleados: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnActualizarEmpleado_Click(object sender, EventArgs e)
        {
            string puesto = CargarUsuario(usuario);
            if (puesto == "Gerente")
            {
                // Asegúrate de que haya una fila seleccionada en el DataGridView
                if (dataGridViewEmpleados.SelectedRows.Count > 0)
                {
                    // Obtener el ID del empleado seleccionado
                    int empleadoId = Convert.ToInt32(dataGridViewEmpleados.SelectedRows[0].Cells["id"].Value);

                    // Crear el formulario de actualización y pasar el ID del empleado
                    FormActualizarEmpleado formActualizar = new FormActualizarEmpleado(empleadoId);
                    formActualizar.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Por favor selecciona un empleado para actualizar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnCrearMesa_Click(object sender, EventArgs e)
        {
            // Crear e inicializar el formulario FormCrearMesa
            FormCrearMesa crearMesaForm = new FormCrearMesa();
            crearMesaForm.ShowDialog();  // Mostrar el formulario como un diálogo bloqueante
        }

        private void InsertarMesa(string numero, string capacidad, string estado)
        {
            // Conexión a la base de datos
            string connectionString = "Server=localhost;Database=PruebaProyecto;Integrated Security=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Consulta SQL para insertar los datos de la mesa
                    string query = "INSERT INTO Mesas (numero, capacidad, estado) VALUES (@numero, @capacidad, @estado)";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        // Agregar los parámetros con los valores obtenidos de FormCrearMesa
                        cmd.Parameters.AddWithValue("@numero", numero);
                        cmd.Parameters.AddWithValue("@capacidad", capacidad);
                        cmd.Parameters.AddWithValue("@estado", estado);

                        // Ejecutar la consulta
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Mesa creada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al crear la mesa: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }       

        private void btnLeerMesa_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Consulta para obtener todas las mesas
                    string query = "SELECT * FROM Mesas";
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();

                    // Llenar el DataTable con los datos de la base de datos
                    dataAdapter.Fill(dataTable);

                    // Asignar el DataTable al DataGridView
                    dataGridViewMesa.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar las mesas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnActualizarMesa_Click(object sender, EventArgs e)
        {
            // Verificar que se haya seleccionado una mesa del DataGridView
            if (dataGridViewMesa.SelectedRows.Count > 0)
            {
                // Obtener el ID de la mesa seleccionada
                int mesaId = Convert.ToInt32(dataGridViewMesa.SelectedRows[0].Cells["id"].Value);

                // Crear el formulario de actualización y pasarle el ID de la mesa
                FormActualizarMesa actualizarMesaForm = new FormActualizarMesa(mesaId);
                actualizarMesaForm.ShowDialog(); // Mostrar el formulario como un diálogo
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una mesa para actualizar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void CargarMesas()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Consulta para obtener todas las mesas
                    string query = "SELECT * FROM Mesas WHERE actividad = 'Activo'"; // Solo mostrar mesas activas
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();

                    // Llenar el DataTable con los datos de la base de datos
                    dataAdapter.Fill(dataTable);

                    // Asignar el DataTable al DataGridView
                    dataGridViewMesa.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar las mesas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCrearPlato_Click(object sender, EventArgs e)
        {
            FormCrearPlato crearPlatoForm = new FormCrearPlato();
            crearPlatoForm.ShowDialog();

        }

        private void btnLeerPlato_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Consulta para obtener todas las platos
                    string query = "SELECT * FROM Platos";
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();

                    // Llenar el DataTable con los datos de la base de datos
                    dataAdapter.Fill(dataTable);

                    // Asignar el DataTable al DataGridView
                    dataGridViewPlato.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar los platos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnActualizarPlato_Click(object sender, EventArgs e)
        {
            // Verificamos si se seleccionó un plato
            if (dataGridViewPlato.SelectedRows.Count > 0)
            {
                int idPlato = Convert.ToInt32(dataGridViewPlato.SelectedRows[0].Cells["id"].Value);

                // Crear el formulario de actualización
                FormActualizarPlato formActualizarPlato = new FormActualizarPlato(idPlato);

                // Mostrar el formulario
                formActualizarPlato.ShowDialog();
            }
            else
            {
                MessageBox.Show("Por favor seleccione un plato para actualizar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCrearReserva_Click(object sender, EventArgs e)
        {
            // Abrir el formulario para crear una nueva reserva
            FormCrearReserva crearReservaForm = new FormCrearReserva();
            crearReservaForm.ShowDialog();  // Abrir como un diálogo para esperar la confirmación
        }

        private void btnLeerReserva_Click(object sender, EventArgs e)
        {
            // Query para leer todas las reservas, incluyendo los detalles del cliente y la mesa
            string query = "SELECT r.id, c.nombre AS Cliente, m.numero AS Mesa, r.fecha_hora AS 'Fecha y Hora', r.estado " +
                           "FROM Reservas r " +
                           "JOIN Clientes c ON r.cliente_id = c.id " +
                           "JOIN Mesas m ON r.mesa_id = m.id";

            // Abrir conexión con la base de datos y cargar los datos en el DataGridView
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridViewReservas.DataSource = dt;
            }
        }

        private void btnActualizarReserva_Click(object sender, EventArgs e)
        {
            // Verificar que se haya seleccionado una reserva
            if (dataGridViewReservas.SelectedRows.Count > 0)
            {
                // Obtener el ID de la reserva seleccionada
                int idReserva = Convert.ToInt32(dataGridViewReservas.SelectedRows[0].Cells["id"].Value);

                // Abrir el formulario de actualización
                FormActualizarReserva actualizarReservaForm = new FormActualizarReserva();
                actualizarReservaForm.CargarReserva(idReserva); // Cargar los datos de la reserva
                actualizarReservaForm.ShowDialog(); // Mostrar el formulario como diálogo
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una reserva para actualizar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCrearPedido_Click(object sender, EventArgs e)
        {
            // Crear una instancia de FormCrearPedido
            FormCrearPedido formCrearPedido = new FormCrearPedido();

            // Mostrar el formulario como diálogo
            formCrearPedido.ShowDialog();
        }

        private void btnCrearPago_Click(object sender, EventArgs e)
        {
            // Crear una instancia del formulario FormCrearPago
            FormCrearPago formCrearPago = new FormCrearPago();

            // Mostrar el formulario como diálogo modal
            formCrearPago.ShowDialog();

            // Refrescar la lista de métodos de pago después de cerrar FormCrearPago
            CargarMetodosPago();
        }

        // Evento Click del botón Actualizar Pago
        private void btnActualizarPago_Click(object sender, EventArgs e)
        {
            // Verificar si hay una fila seleccionada en el DataGridView
            if (dataGridViewPagos.SelectedRows.Count > 0)
            {
                // Obtener la fila seleccionada
                DataGridViewRow filaSeleccionada = dataGridViewPagos.SelectedRows[0];

                // Obtener los datos de la fila seleccionada
                int idMetodoPago = Convert.ToInt32(filaSeleccionada.Cells["ID"].Value);
                string nombreMetodoPago = filaSeleccionada.Cells["Método de Pago"].Value.ToString();
                string actividadMetodoPago = filaSeleccionada.Cells["Actividad"].Value.ToString();

                // Crear una instancia del formulario FormActualizarPago pasando los datos seleccionados
                FormActualizarMetodoPago formActualizarPago = new FormActualizarMetodoPago(idMetodoPago, nombreMetodoPago, actividadMetodoPago);

                // Mostrar el formulario como diálogo modal
                formActualizarPago.ShowDialog();

                // Refrescar la lista de métodos de pago después de cerrar FormActualizarPago
                CargarMetodosPago();
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un método de pago para actualizar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Método para cargar y mostrar los métodos de pago en el DataGridView
        private void CargarMetodosPago()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    // Consulta SQL para obtener los métodos de pago
                    string query = "SELECT id AS 'ID', nombre AS 'Método de Pago', actividad AS 'Actividad' FROM dbo.Métodos_de_Pago";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable metodosPago = new DataTable();
                    adapter.Fill(metodosPago);

                    // Asignar el DataTable al DataGridView
                    dataGridViewPagos.DataSource = metodosPago;

                    // Opcional: Ajustar el ancho de las columnas
                    dataGridViewPagos.Columns["ID"].Width = 50;
                    dataGridViewPagos.Columns["Método de Pago"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridViewPagos.Columns["Actividad"].Width = 100;

                    // Depuración: Verificar el número de métodos de pago cargados
                    Console.WriteLine($"Número de métodos de pago cargados: {metodosPago.Rows.Count}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar métodos de pago: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine($"Error al cargar métodos de pago: {ex.Message}");
                }
            }
        }

        private void btnLeerPago_Click(object sender, EventArgs e)
        {
            CargarMetodosPago();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string puesto = CargarUsuario(usuario);
            if (puesto == "Gerente")
            {
                // Crear una instancia del formulario FormCrearProveedor
                FormCrearProveedor formCrearProveedor = new FormCrearProveedor();

                // Mostrar el formulario como diálogo modal
                formCrearProveedor.ShowDialog();

                // Refrescar la lista de proveedores después de cerrar FormCrearProveedor
                CargarProveedores();
            }
        }

        private void btnLeerProveedor_Click(object sender, EventArgs e)
        {
            CargarProveedores();

        }

        private void btnActualizarProveedor_Click(object sender, EventArgs e)
        {
            string puesto = CargarUsuario(usuario);
            if (puesto == "Gerente")
            {
                // Verificar si hay una fila seleccionada en el DataGridView
                if (dataGridViewProveedores.SelectedRows.Count > 0)
                {
                    // Obtener la fila seleccionada
                    DataGridViewRow filaSeleccionada = dataGridViewProveedores.SelectedRows[0];

                    // Obtener los datos de la fila seleccionada
                    int idProveedor = Convert.ToInt32(filaSeleccionada.Cells["ID"].Value);
                    string nombreProveedor = filaSeleccionada.Cells["Nombre"].Value.ToString();
                    string telefonoProveedor = filaSeleccionada.Cells["Teléfono"].Value.ToString();
                    string correoProveedor = filaSeleccionada.Cells["Correo Electrónico"].Value.ToString();
                    string direccionProveedor = filaSeleccionada.Cells["Dirección"].Value.ToString();
                    string actividadProveedor = filaSeleccionada.Cells["Actividad"].Value.ToString();

                    // Crear una instancia del formulario FormActualizarProveedor pasando los datos seleccionados
                    FormActualizarProveedor formActualizarProveedor = new FormActualizarProveedor(idProveedor, nombreProveedor, telefonoProveedor, correoProveedor, direccionProveedor, actividadProveedor);

                    // Mostrar el formulario como diálogo modal
                    formActualizarProveedor.ShowDialog();

                    // Refrescar la lista de proveedores después de cerrar FormActualizarProveedor
                    CargarProveedores();
                }
                else
                {
                    MessageBox.Show("Por favor, selecciona un proveedor para actualizar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void CargarProveedores()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    // Consulta SQL para obtener los proveedores
                    string query = "SELECT id AS 'ID', nombre AS 'Nombre', telefono AS 'Teléfono', correo_electronico AS 'Correo Electrónico', direccion AS 'Dirección', actividad AS 'Actividad' FROM dbo.proveedores";

                    // Crear un SqlDataAdapter para ejecutar la consulta
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);

                    // Crear un DataTable para almacenar los resultados
                    DataTable proveedores = new DataTable();

                    // Llenar el DataTable con los resultados de la consulta
                    adapter.Fill(proveedores);

                    // Asignar el DataTable al DataGridView
                    dataGridViewProveedores.DataSource = proveedores;

                    // Opcional: Ajustar el ancho de las columnas
                    dataGridViewProveedores.Columns["ID"].Width = 50;
                    dataGridViewProveedores.Columns["Nombre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridViewProveedores.Columns["Teléfono"].Width = 100;
                    dataGridViewProveedores.Columns["Correo Electrónico"].Width = 150;
                    dataGridViewProveedores.Columns["Dirección"].Width = 200;
                    dataGridViewProveedores.Columns["Actividad"].Width = 100;

                    // Depuración: Verificar el número de proveedores cargados
                    Console.WriteLine($"Número de proveedores cargados: {proveedores.Rows.Count}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar proveedores: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine($"Error al cargar proveedores: {ex.Message}");
                }
            }
        }

        private void btnCrearFactura_Click(object sender, EventArgs e)
        {
            FormCrearFactura formCrearFacturas = new FormCrearFactura();
            formCrearFacturas.ShowDialog();
            // Aquí puedes llamar a un método para recargar las facturas

        }

        // Evento Click del botón Leer Facturas
        private void btnLeerFactura_Click(object sender, EventArgs e)
        {
            // Consulta SQL para obtener todas las facturas
            string query = "SELECT f.id, c.nombre AS Cliente, f.monto, f.fecha, f.actividad " +
                           "FROM Facturas f " +
                           "INNER JOIN Clientes c ON f.cliente_id = c.id";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conn);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                // Establecer la fuente de datos del DataGridView
                dataGridViewFacturas.DataSource = dataTable;
            }
        }

        // Evento Click del botón Actualizar Factura
        private void btnActualizarFactura_Click(object sender, EventArgs e)
        {
            // Asegúrate de que haya una fila seleccionada en el DataGridView
            if (dataGridViewFacturas.SelectedRows.Count > 0)
            {
                // Obtener el ID del empleado seleccionado
                int facturaID = Convert.ToInt32(dataGridViewFacturas.SelectedRows[0].Cells["id"].Value);

                // Crear el formulario de actualización y pasar el ID del empleado
                FormActualizarFactura actualizarFacturaForm = new FormActualizarFactura(facturaID);
                actualizarFacturaForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Por favor selecciona un empleado para actualizar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }

}

