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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Biblioclases;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        static List<Producto> coleccion = new List<Producto>();

        public MainWindow()
        {
            InitializeComponent();
        }

        bool Validar()
        {
            bool validado = true;

            if (txtId.Text == "")
            {
                validado = false;
                MessageBox.Show("Id no debe estar vacío");
            }
            else if (int.Parse(txtId.Text) < 0)
            {
                validado = false;
                MessageBox.Show("Id no debe ser negativo");
            }
            if (txtNombre.Text == "")
            {
                validado = false;
                MessageBox.Show("Nombre no debe estar vacío");
            }
            ////--------------------------------------------------------------------
            try
            {
                if (int.Parse(txtPrecio.Text) < 0)
                {
                    validado = false;
                    MessageBox.Show("El precio no debe ser menor a 0");
                }
            }
            catch (Exception)
            {
                validado = false;
                MessageBox.Show("Precio debe ser un número entero");
            }
            try
            {
                if (int.Parse(txtStock.Text) < 0)
                {
                    validado = false;
                    MessageBox.Show("No se admite stock negativo");
                }
            }
            catch (Exception)
            {
                validado = false;
                MessageBox.Show("Stock debe ser un número entero");
            }
            ////--------------------------------------------------------------------
            if (txtDescripcion.Text == "")
            {
                validado = false;
                MessageBox.Show("La descripción no debe estar vacía");
            }

            if (txtPrecio.Text == "")
            {
                validado = false;
                MessageBox.Show("Precio no debe estar vacío");
            }

            if (txtStock.Text == "")
            {
                validado = false;
                MessageBox.Show("Stock no debe estar vacío");
            }

            return validado;
        }

        public void Guardar(Producto nuevo)
        {
            if (Buscar(nuevo.Id) == -1)
            {
                coleccion.Add(nuevo);
            }
            else
            {
                MessageBox.Show("El ID del producto ya se encuentra en uso.");
            }
        }

        int Buscar(int id)
        {
            int index = -1;

            for (int i = 0; i < coleccion.Count; i++)
            {
                if (coleccion[i].Id == id)
                {
                    index = i;
                    break;
                }
            }

            return index;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool validado = Validar();

            if (validado == true)
            {
                Producto producto = new Producto();
                producto.Id = int.Parse(txtId.Text);
                producto.Nombre = txtNombre.Text;
                producto.Descripcion = txtDescripcion.Text;

                try
                {
                    producto.Precio = int.Parse(txtPrecio.Text);
                    producto.Stock = int.Parse(txtStock.Text);

                    Guardar(producto);

                    Dgv.ItemsSource = coleccion.Where(p => p != null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar el producto: " + ex.Message);
                }
            }
        }
    }
}