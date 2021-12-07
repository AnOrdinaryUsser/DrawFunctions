using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Microsoft.Win32;
using System.Reflection;

namespace Práctica2020
{
    public partial class addManuallyWindow : Window
    {
        Collection<Coordinates>[] listManual;
        private SolidColorBrush lc;
        private int count;

        public addManuallyWindow()
        {
            InitializeComponent();

            // Color seleccionado en el comboBox
            cmbColors.ItemsSource = typeof(Colors).GetProperties();

            // Lista de coordenadas introducidas manualmente
            listManual = new Collection<Coordinates>[100];
            for (int i = 0; i < listManual.Length; i++)
                listManual[i] = new Collection<Coordinates>();
            count = Indice;

            ListViewManual.ItemsSource = listManual[count];
        }

        // Constructor para devolver la lista a la Ventana Principal
        public Collection<Coordinates>[] ListaManual
        {
            get { return listManual; }
            set { listManual = value; }
        }

        // Constructor para devolver el color a la Ventana Principal
        public SolidColorBrush ColorLinea
        {
            get { return lc; }
            set { lc = value; cmbColors.SelectedItem = lc; }
        }

        // Constructor para devolver el count (contador de las colecciones)
        public int Indice
        {
            get { return count; }
            set { count = value; }
        }

        // Metodo para mostrar un elemento de la ListView en el TextBoxListView
        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListViewManual.SelectedIndex < 0)
            {
                TextBlockListView.Text = "";
            } else 
            {
                TextBlockListView.Text = ListViewManual.SelectedItem.ToString();
            }
        }

        // Metodo para activar el boton modificar si se introduce algun valor y para añadir
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TextBoxX.Text.Length > 0 && TextBoxY.Text.Length > 0)
            {
                BotonModificar.IsEnabled = true;
                BotonAniadir.IsEnabled = true;
            }
            else
            {
                BotonModificar.IsEnabled = false;
                BotonAniadir.IsEnabled = false;
            }
        }

        // Metodo para el cambio de seleccion de item en la comboBox de colores
        private void cmbColors_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            //https://www.wpf-tutorial.com/es/73/controles-de-lista/the-combobox-control/
            Color selectedColor = (Color)(cmbColors.SelectedItem as PropertyInfo).GetValue(lc);
            lc = new SolidColorBrush(selectedColor);
        }

        // Metodo para añadir la coordenada a la ListView
        private void addOneElement(object sender, RoutedEventArgs e)
        {
            Coordinates listItem = new Coordinates(double.Parse(TextBoxX.Text), double.Parse(TextBoxY.Text));
            listManual[count].Add(listItem);

            //https://es.stackoverflow.com/questions/309251/la-operaci%C3%B3n-no-es-v%C3%A1lida-mientras-itemssource-est%C3%A9-en-uso-obtenga-acceso-y-mo
            ListViewManual.Items.Refresh();
            ListViewManual.ItemsSource = listManual[count];

            if (ListViewManual.Items.Count > 0)
            {
                BotonEliminarUno.IsEnabled = true;
            }
            else if (ListViewManual.Items.Count > 1)
            {
                BotonEliminarTodos.IsEnabled = true;
            }
        }

        // Metodo para modificar una coordenada
        private void modifyCoordinate(object sender, RoutedEventArgs e)
        {
            listManual[ListViewManual.SelectedIndex][count].CoordinateX = double.Parse(TextBoxX.Text);
            listManual[ListViewManual.SelectedIndex][count].CoordinateY = double.Parse(TextBoxY.Text);
            TextBlockListView.Text = ListViewManual.SelectedItem.ToString();
        }

        // Metodo para eliminar un unico elemento de la ListView
        private void deleteOneElement(object sender, RoutedEventArgs e)
        {
            int aElminar = ListViewManual.SelectedIndex;
            listManual[count].RemoveAt(aElminar);
            ListViewManual.Items.Refresh();
            ListViewManual.ItemsSource = listManual[count];
        }

        // Metodo para eliminar todos los puntos de la ListView
        private void deleteAllElements(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < listManual[count].Count; i++)
            {
                listManual[count].RemoveAt(i);
                i--;
            }
            ListViewManual.Items.Refresh();
            ListViewManual.ItemsSource = listManual[count];
        }

        // Metodo para añadir los puntos al canvas
        private void addPointsToCanvas(object sender, RoutedEventArgs e)
        {
            if (sender == butonAniadirPoints)
            {
                DialogResult = true;
            }
            else
            {
                DialogResult = false;
            }
        }
    }
}
