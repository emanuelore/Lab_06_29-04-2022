using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Business;
using Entity;
using System.Text.RegularExpressions;

namespace Semana06
{
    /// <summary>
    /// Lógica de interacción para ManProducto.xaml
    /// </summary>
    public partial class ManProducto : Window
    {
        public int ID { get; set; }
        public ManProducto(int Id)
        {
            InitializeComponent();
            ID = Id;
            if (ID > 0)
            {
                BProducto bProducto = new BProducto();
                List<Producto> productos = new List<Producto>();
                productos = bProducto.Listar(ID);
                if (productos.Count > 0)
                {
                    lblIdProducto.Content = productos[0].IdProducto.ToString();
                    txtNombreProducto.Text = productos[0].NombreProducto;
                    txtIdProveedor.Text = productos[0].IdProveedor.ToString();
                    txtIdCategoria.Text = productos[0].IdCategoria.ToString();
                    txtCantidadPorUnidad.Text = productos[0].CantidadPorUnidad;
                    txtPrecioUnidad.Text = productos[0].PrecioUnidad.ToString();
                    txtUnidadesEnExistencia.Text = productos[0].UnidadesEnExistencia.ToString();
                    txtUnidadesEnPedido.Text = productos[0].UnidadesEnPedido.ToString();
                    txtNivelNuevoPedido.Text = productos[0].NivelNuevoPedido.ToString();
                    txtSuspendido.Text = productos[0].Suspendido.ToString();
                    txtCategoriaProducto.Text = productos[0].CategoriaProducto;
                }
            }
        }

        private void BtnGrabar_Click(object sender, RoutedEventArgs e)
        {
            BProducto BProducto = null;
            bool result = true;
            try
            {
                BProducto = new BProducto();
                if (ID > 0)
                    result = BProducto.Actualizar(new Producto
                    {
                        IdProducto = ID,
                        NombreProducto = txtNombreProducto.Text,
                        IdProveedor = Convert.ToInt32(txtIdProveedor.Text),
                        IdCategoria = Convert.ToInt32(txtIdCategoria.Text),
                        CantidadPorUnidad = txtCantidadPorUnidad.Text,
                        PrecioUnidad = Convert.ToDouble(txtPrecioUnidad.Text),
                        UnidadesEnExistencia = Convert.ToInt32(txtUnidadesEnExistencia.Text),
                        UnidadesEnPedido = Convert.ToInt32(txtUnidadesEnPedido.Text),
                        NivelNuevoPedido = Convert.ToInt32(txtNivelNuevoPedido.Text),
                        Suspendido = Convert.ToInt32(txtSuspendido.Text),
                        CategoriaProducto = txtCategoriaProducto.Text,

                    });
                else
                    result = BProducto.Insertar(new Producto
                    {
                        NombreProducto = txtNombreProducto.Text,
                        IdProveedor = Convert.ToInt32(txtIdProveedor.Text),
                        IdCategoria = Convert.ToInt32(txtIdCategoria.Text),
                        CantidadPorUnidad = txtCantidadPorUnidad.Text,
                        PrecioUnidad = Convert.ToDouble(txtPrecioUnidad.Text),
                        UnidadesEnExistencia = Convert.ToInt32(txtUnidadesEnExistencia.Text),
                        UnidadesEnPedido = Convert.ToInt32(txtUnidadesEnPedido.Text),
                        NivelNuevoPedido = Convert.ToInt32(txtNivelNuevoPedido.Text),
                        Suspendido = Convert.ToInt32(txtSuspendido.Text),
                        CategoriaProducto = txtCategoriaProducto.Text,

                    });

                if (!result)
                    MessageBox.Show("Comunicarse con el Administrador");

                Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Comunicarse con el Administrador");
            }
            finally
            {
                BProducto = null;
            }
        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            BProducto BProducto = null;
            bool result = true;
            try
            {
                BProducto = new BProducto();
                if (ID > 0)
                    result = BProducto.Eliminar(ID);
                if (!result)
                    MessageBox.Show("Comunicarse con el Administrador");

                Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Comunicarse con el Administrador");
            }
            finally
            {
                BProducto = null;
            }
        }

        private void BtnCerrar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private new void PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

    }
}
