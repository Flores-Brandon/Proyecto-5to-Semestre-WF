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
    public partial class FormCrearPedido : Form
    {
        static string connectionString = "Server=localhost\\SQLEXPRESS;Database=ProyectoRestaurante;Trusted_Connection=True;";

        public FormCrearPedido()
        {
            InitializeComponent();
            CargarDatos();
        }

        private void CargarDatos()
        {
            CargarMesas();
            CargarClientes();
            CargarPlatos();
        }

        private void CargarMesas()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    // Filtrar mesas que están libres
                    string query = "SELECT id, numero, capacidad FROM dbo.mesas WHERE LOWER(TRIM(actividad)) = 'libre'";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable mesas = new DataTable();
                    adapter.Fill(mesas);

                    // Depuración: Verificar el número de mesas cargadas
                    Console.WriteLine($"Número de mesas libres cargadas: {mesas.Rows.Count}");
                    foreach (DataRow row in mesas.Rows)
                    {
                        Console.WriteLine($"Mesa ID: {row["id"]}, Número: {row["numero"]}");
                    }

                    // Limpiar DataSource y elementos existentes
                    cmbMesas.DataSource = null;
                    cmbMesas.Items.Clear();

                    // Asignar DisplayMember y ValueMember antes de asignar DataSource
                    cmbMesas.DisplayMember = "numero"; // Mostrar el número de la mesa
                    cmbMesas.ValueMember = "id";        // Valor subyacente es el ID de la mesa

                    // Asignar los datos al ComboBox
                    cmbMesas.DataSource = mesas;

                    // Verificar que el ComboBox se haya llenado
                    if (cmbMesas.Items.Count > 0)
                    {
                        Console.WriteLine("El ComboBox de mesas se ha llenado correctamente con mesas libres.");
                    }
                    else
                    {
                        Console.WriteLine("El ComboBox de mesas está vacío después de la carga de mesas libres.");
                        MessageBox.Show("No se encontraron mesas libres. Por favor, verifica los datos en la base de datos.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar mesas: " + ex.Message);
                    Console.WriteLine("Error al cargar mesas: " + ex.Message);
                }
            }
        }

        private void CargarClientes()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    string query = "SELECT id, nombre FROM dbo.clientes WHERE LOWER(TRIM(actividad)) = 'activo'";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable clientes = new DataTable();
                    adapter.Fill(clientes);

                    // Limpiar DataSource y elementos existentes
                    cmbClientes.DataSource = null;
                    cmbClientes.Items.Clear();

                    // Asignar DisplayMember y ValueMember antes de asignar DataSource
                    cmbClientes.DisplayMember = "nombre";
                    cmbClientes.ValueMember = "id";

                    // Asignar los datos al ComboBox
                    cmbClientes.DataSource = clientes;

                    // Verificar que el ComboBox se haya llenado
                    if (cmbClientes.Items.Count > 0)
                    {
                        Console.WriteLine($"Número de clientes activos cargados: {clientes.Rows.Count}");
                    }
                    else
                    {
                        Console.WriteLine("El ComboBox de clientes está vacío después de la carga de clientes activos.");
                        MessageBox.Show("No se encontraron clientes activos. Por favor, verifica los datos en la base de datos.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar clientes: " + ex.Message);
                    Console.WriteLine("Error al cargar clientes: " + ex.Message);
                }
            }
        }

        private void CargarPlatos()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    string query = "SELECT id, nombre, descripcion, precio FROM dbo.platos WHERE LOWER(TRIM(actividad)) = 'activo'";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable platos = new DataTable();
                    adapter.Fill(platos);

                    // Depuración: Verificar el número de platos cargados
                    Console.WriteLine($"Número de platos activos cargados: {platos.Rows.Count}");
                    foreach (DataRow row in platos.Rows)
                    {
                        string nombre = row["nombre"]?.ToString().Trim() ?? "Sin Nombre";
                        Console.WriteLine($"Plato ID: {row["id"]}, Nombre: {nombre}, Precio: {row["precio"]}");
                    }

                    // Verificar si la columna 'nombre' existe
                    if (!platos.Columns.Contains("nombre"))
                    {
                        MessageBox.Show("La columna 'nombre' no existe en la tabla de platos.");
                        return;
                    }

                    // Limpiar DataSource y elementos existentes
                    checkedListBoxPlatos.DataSource = null;
                    checkedListBoxPlatos.Items.Clear();

                    // Asignar DisplayMember y ValueMember antes de asignar DataSource
                    checkedListBoxPlatos.DisplayMember = "nombre"; // Nombre de la columna a mostrar
                    checkedListBoxPlatos.ValueMember = "id";        // Nombre de la columna del valor

                    // Asignar los datos al CheckedListBox
                    checkedListBoxPlatos.DataSource = platos;

                    // Verificar que el CheckedListBox se haya llenado
                    if (checkedListBoxPlatos.Items.Count > 0)
                    {
                        Console.WriteLine("El CheckedListBox de platos se ha llenado correctamente con platos activos.");
                    }
                    else
                    {
                        Console.WriteLine("El CheckedListBox de platos está vacío después de la carga de platos activos.");
                        MessageBox.Show("No se encontraron platos activos. Por favor, verifica los datos en la base de datos.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar platos: " + ex.Message);
                    Console.WriteLine("Error al cargar platos: " + ex.Message);
                }
            }
        }


        private void btnCancelarReserva_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirmarPedido_Click(object sender, EventArgs e)
        {
            // Validar que se hayan seleccionado platos
            if (checkedListBoxPlatos.CheckedItems.Count == 0)
            {
                MessageBox.Show("Por favor, selecciona al menos un plato.");
                return;
            }

            // Validar la cantidad
            int cantidad = (int)numericUpDownCantidad.Value;
            if (cantidad <= 0)
            {
                MessageBox.Show("La cantidad debe ser un número positivo.");
                return;
            }

            // Obtener los datos seleccionados
            int mesaId = (int)cmbMesas.SelectedValue;
            int clienteId = (int)cmbClientes.SelectedValue;
            DateTime fechaHora = dtpFechaHora.Value;

            // Verificar disponibilidad de la mesa
            if (!EsMesaDisponible(mesaId, fechaHora))
            {
                MessageBox.Show("La mesa seleccionada no está disponible en la fecha y hora elegidas.");
                return;
            }

            // Obtener camarero_id (ajusta esta lógica según tu aplicación)
            int camareroId = ObtenerCamareroId();

            // Obtener los platos seleccionados y calcular el total
            var platosSeleccionados = checkedListBoxPlatos.CheckedItems;
            decimal total = 0;

            foreach (DataRowView item in platosSeleccionados)
            {
                decimal precio = Convert.ToDecimal(item["precio"]);
                total += precio * cantidad;
            }

            // Insertar en la base de datos
            InsertarPedido(mesaId, camareroId, clienteId, platosSeleccionados, fechaHora, total, cantidad);

            MessageBox.Show("Pedido creado exitosamente.");
            this.Close();
        }

        private int ObtenerCamareroId()
        {
            // Implementa la lógica para obtener el camarero_id actual
            // Por ejemplo, podrías tenerlo almacenado en una sesión, variable estática, etc.
            return 1; // Valor de ejemplo
        }

        private bool EsMesaDisponible(int mesaId, DateTime fechaHora)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    string query = "SELECT COUNT(*) FROM dbo.pedidos WHERE mesa_id = @mesa_id AND fecha = @fecha";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@mesa_id", mesaId);
                    cmd.Parameters.AddWithValue("@fecha", fechaHora);

                    conn.Open();
                    int count = (int)cmd.ExecuteScalar();
                    return count == 0; // Si es 0, la mesa está disponible
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al verificar disponibilidad de la mesa: " + ex.Message);
                    Console.WriteLine("Error al verificar disponibilidad de la mesa: " + ex.Message);
                    return false;
                }
            }
        }

        private void InsertarPedido(int mesaId, int camareroId, int clienteId, CheckedListBox.CheckedItemCollection platos, DateTime fechaHora, decimal total, int cantidad)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    // Insertar el pedido principal
                    string insertPedidoQuery = "INSERT INTO dbo.pedidos (mesa_id, camarero_id, cliente_id, fecha, total) VALUES (@mesa_id, @camarero_id, @cliente_id, @fecha, @total); SELECT SCOPE_IDENTITY();";
                    SqlCommand cmdPedido = new SqlCommand(insertPedidoQuery, conn, transaction);
                    cmdPedido.Parameters.AddWithValue("@mesa_id", mesaId);
                    cmdPedido.Parameters.AddWithValue("@camarero_id", camareroId);
                    cmdPedido.Parameters.AddWithValue("@cliente_id", clienteId);
                    cmdPedido.Parameters.AddWithValue("@fecha", fechaHora);
                    cmdPedido.Parameters.AddWithValue("@total", total);
                    object result = cmdPedido.ExecuteScalar();
                    int pedidoId = Convert.ToInt32(result);

                    // Insertar cada plato asociado al pedido
                    string insertDetalleQuery = "INSERT INTO dbo.detalles_pedido (pedido_id, plato_id, cantidad, precio) VALUES (@pedido_id, @plato_id, @cantidad, @precio)";
                    foreach (DataRowView item in platos)
                    {
                        int platoId = (int)item["id"];
                        decimal precio = Convert.ToDecimal(item["precio"]);

                        SqlCommand cmdDetalle = new SqlCommand(insertDetalleQuery, conn, transaction);
                        cmdDetalle.Parameters.AddWithValue("@pedido_id", pedidoId);
                        cmdDetalle.Parameters.AddWithValue("@plato_id", platoId);
                        cmdDetalle.Parameters.AddWithValue("@cantidad", cantidad);
                        cmdDetalle.Parameters.AddWithValue("@precio", precio);
                        cmdDetalle.ExecuteNonQuery();
                    }

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Error al crear el pedido: " + ex.Message);
                    Console.WriteLine("Error al crear el pedido: " + ex.Message);
                }
            }
        }
    }
}
