using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Reflection;
using System.Windows.Documents;

namespace Práctica2020
{
    public partial class addAutomaticallyWindow : Window
    {

        Collection<Coordinates>[] listAutomatic;
        private randomRange rg;
        private double rangoMinimo, rangoMaximo;
        private double paso;
        private double gradoCubico, gradoCuadrado, grado, termIndp;
        private SolidColorBrush lc;
        private int operation;
        private int count;

        public addAutomaticallyWindow()
        {
            InitializeComponent();

            // Color seleccionado en el comboBox
            cmbColors.ItemsSource = typeof(Colors).GetProperties();

            // Inicializacion de las distintas variables
            rg = null;
            rangoMinimo = 0.0;
            rangoMaximo = 0.0;
            paso = 0.1;
            operation = 3;

            // Lista de coordenadas generadas automaticamente
            listAutomatic = new Collection<Coordinates>[100];
            for (int i = 0; i < listAutomatic.Length; i++)
                listAutomatic[i] = new Collection<Coordinates>();
            count = Indice;

            ListViewAutomatic.ItemsSource = listAutomatic[count];
        }

        // Constructor para devolver la lista a la Ventana Principal
        public Collection<Coordinates>[] ListaAutomatica
        {
            get { return listAutomatic; }
            set { listAutomatic = value; }
        }

        // Constructor para devolver el color a la Ventana Principal
        public SolidColorBrush Colorlinea
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
            if (ListViewAutomatic.SelectedIndex < 0)
            {
                TextBlockListView.Text = "";
            } else
            {
                TextBlockListView.Text = ListViewAutomatic.SelectedItem.ToString();
            }
        }

        // Metodo para activar el boton modificar si se introduce algun valor
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TextBoxX.Text.Length > 0 && TextBoxY.Text.Length > 0)
            {
                BotonModificar.IsEnabled = true;
            }
            else
            {
                BotonModificar.IsEnabled = false;
            }
        }

        // Metodo para el cambio de seleccion de item en la comboBox de colores
        private void comboBoxColorsSelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            //https://www.wpf-tutorial.com/es/73/controles-de-lista/the-combobox-control/
            Color selectedColor = (Color)(cmbColors.SelectedItem as PropertyInfo).GetValue(lc);
            lc = new SolidColorBrush(selectedColor);
        }

        // Metodo para el cambio de seleccion de item en la comboBox de funciones
        private void comboBoxFunctionsSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int selectedOperation = cmbFunciones.SelectedIndex;
            operation = selectedOperation;
        }
        
        // Metodo para modificar una coordenada
        private void modifyCoordinate(object sender, RoutedEventArgs e)
        {
            listAutomatic[count][ListViewAutomatic.SelectedIndex].CoordinateX = double.Parse(TextBoxX.Text);
            listAutomatic[count][ListViewAutomatic.SelectedIndex].CoordinateY = double.Parse(TextBoxY.Text);
            TextBlockListView.Text = ListViewAutomatic.SelectedItem.ToString();
        }

        // Metodo para eliminar un unico elemento de la ListView
        private void deleteOneElement(object sender, RoutedEventArgs e)
        {
            int aElminar = ListViewAutomatic.SelectedIndex;
            listAutomatic[count].RemoveAt(aElminar);
            ListViewAutomatic.Items.Refresh();
            ListViewAutomatic.ItemsSource = listAutomatic[count];
        }

        // Metodo para eliminar todos los puntos de la ListView
        private void deleteAllElements(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < listAutomatic[count].Count; i++)
            {
                listAutomatic[count].RemoveAt(i);
                i--;
            }
            ListViewAutomatic.Items.Refresh();
            ListViewAutomatic.ItemsSource = listAutomatic[count];
            ListViewAutomatic.Items.Refresh();
        }

        // Metodo para generar las coordenadas de forma automaticamente
        private void generatePoints(object sender, RoutedEventArgs e)
        {
            switch (operation)
            {
                case 0:
                    for (double x = rangoMinimo; x <= rangoMaximo; x += paso)
                    {
                        Coordinates listItem = new Coordinates(Math.Round(x, 2), Math.Round(Math.Cos(gradoCuadrado * x) + termIndp, 2));
                        listAutomatic[count].Add(listItem);
                    }
                    ListViewAutomatic.ItemsSource = listAutomatic[count];
                    ListViewAutomatic.Items.Refresh();
                    break;
                case 1:
                    for (double x = rangoMinimo; x <= rangoMaximo; x += paso)
                    {
                        Coordinates listItem = new Coordinates(Math.Round(x, 2), Math.Round(Math.Sin(gradoCuadrado * x) + termIndp, 2));
                        listAutomatic[count].Add(listItem);
                    }
                    ListViewAutomatic.ItemsSource = listAutomatic[count];
                    ListViewAutomatic.Items.Refresh();
                    break;
                case 2:
                    for (double x = rangoMinimo; x <= rangoMaximo; x += paso)
                    {
                        Coordinates listItem = new Coordinates(x, Math.Round(gradoCubico * Math.Pow(x, 3) + gradoCuadrado * Math.Pow(x, 2) + grado * x + termIndp, 2));
                        listAutomatic[count].Add(listItem);
                    }
                    ListViewAutomatic.ItemsSource = listAutomatic[count];
                    ListViewAutomatic.Items.Refresh();
                    break;
                default:
                    for (double x = rangoMinimo; x <= rangoMaximo; x += paso)
                    {
                        Coordinates listItem = new Coordinates(x, Math.Round(gradoCubico * Math.Pow(x, 3) + gradoCuadrado * Math.Pow(x, 2) + grado * x + termIndp, 2));
                        listAutomatic[count].Add(listItem);
                    }
                    ListViewAutomatic.ItemsSource = listAutomatic[count];
                    ListViewAutomatic.Items.Refresh();
                    break;
            }
            if (ListViewAutomatic.Items.Count > 0)
            {
                BotonEliminarUno.IsEnabled = true;
                BotonEliminarTodos.IsEnabled = true;
            }
        }

        // Metodo que nos permite configurar la expresion para generar cualquiera de las funciones del comboBox
        private void configureExpresion(object sender, RoutedEventArgs e)
        {
            //https://stackoverflow.com/questions/24546604/how-to-check-for-empty-textbox
            if (BotonExpresion.Content.ToString().Equals("Aceptar"))
            {
                if (String.IsNullOrEmpty(grado3.Text))
                    gradoCubico = 0.0;
                else
                    gradoCubico = double.Parse(grado3.Text);

                if (String.IsNullOrEmpty(grado2.Text))
                    gradoCuadrado = 0.0;
                else
                    gradoCuadrado = double.Parse(grado2.Text);

                if (String.IsNullOrEmpty(grado1.Text))
                    grado = 0.0;
                else
                    grado = double.Parse(grado1.Text);

                if (String.IsNullOrEmpty(terminoIndependiente.Text))
                    termIndp = 0.0;
                else
                    termIndp = double.Parse(terminoIndependiente.Text);
            }
        }

        // Metodo para seleccionar un rangoMinimo y un rangoMaximo
        private void selectRange(object sender, RoutedEventArgs e)
        {
            if (sender == BotonRandom)
            {
                rg = new randomRange();
                rg.Owner = this;
                rg.Minimo = rangoMinimo;
                rg.Maximo = rangoMaximo;
                rg.ShowDialog();
                if (rg.DialogResult == true)
                {
                    rangoMinimo = rg.Minimo;
                    rangoMaximo = rg.Maximo;
                }
            }
        }

        // Metodo para añadir los puntos al canvas o a la grafica de barras
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
