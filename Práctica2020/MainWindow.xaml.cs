using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Controls.DataVisualization.Charting;
using System.Linq;

namespace Práctica2020
{
    public partial class MainWindow : Window
    {
        // Ventanas
        private addManuallyWindow addManuallyWindow;
        private addAutomaticallyWindow addAutomaticallyWindow;

        // Ejes
        private Line axisX;
        private Line axisY;

        // Variables de escalado
        private double width, height;
        private ScaleTransform sc;
        private TranslateTransform tt;
        private TransformGroup tg;

        // Draw
        private PointCollection pointsCollection = null;
        private SolidColorBrush lineColor;

        // Coleccion
        Collection<Coordinates>[] ListaCordenadasPuntos;
        private int indice;

        // Flags
        private bool mouseDown = false;
        private bool purgeModeBool;

        // Variables para el purgado
        Point mouseClickDown;
        Point mouseClickUp;
        Point rectCornerDown;
        Point rectCornerUp;

        // Rangos de dibujado
        private double minimumRange = -50.0;
        private double maximumRange = 50.0;

        public MainWindow()
        {
            InitializeComponent();

            //Realizamos el cargado de los ejes
            this.Loaded += loadAxis;

            //Inicializamos las ventanas
            addManuallyWindow = null;
            addAutomaticallyWindow = null;

            //Representacion la inicializamos a true para que por defecto se pinte en el canvas
            purgeModeBool = false;

            //Inicializamos la coleccion de coordenadas
            ListaCordenadasPuntos = new Collection<Coordinates>[100];
            for (int i = 0; i < ListaCordenadasPuntos.Length; i++)
                ListaCordenadasPuntos[i] = new Collection<Coordinates>();

            //Inicializamos el indice
            indice = 0;

            //Inicializamos el TransformGroup
            sc = new ScaleTransform();
            tt = new TranslateTransform();
            tg = new TransformGroup();
            tg.Children.Add(tt);
            tg.Children.Add(sc);
        }

        // Metodo para cargar los datos en la grafica de barras
        private void loadChartData()
        {
            ((ColumnSeries)BarChar.Series[0]).ItemsSource = ListaCordenadasPuntos[indice];
        }

        // Metodo para cargar los ejes al comenzar el programa
        private void loadAxis(object sender, EventArgs e)
        {
            axisX = null;
            axisY = null;
            drawAxis();
        }

        // Metodo para dibujar los ejes
        private void drawAxis()
        {
            axisX = new Line();
            axisY = new Line();

            axisX.Stroke = Brushes.Black;
            axisX.StrokeThickness = 100 / width;
            axisX.X1 = -50;
            axisX.Y1 = 0;
            axisX.X2 = 50;
            axisX.Y2 = 0;

            axisX.RenderTransform = tg;

            GraphicPanel.Children.Add(axisX);

            axisY.Stroke = Brushes.Black;
            axisY.StrokeThickness = 100 / width;
            axisY.X1 = 0;
            axisY.Y1 = -50;
            axisY.X2 = 0;
            axisY.Y2 = 50;

            axisY.RenderTransform = tg;

            GraphicPanel.Children.Add(axisY);
        }

        // Metodo para dibujar polilineas en el canvas
        private void drawCanvas()
        {
            double width, height;

            width = GraphicPanel.ActualWidth;
            height = GraphicPanel.ActualHeight;

            // Inicializamos la coleccion de puntos
            pointsCollection = new PointCollection();
            pointsCollection.Clear();

            Point p;
            for (int i = 0; i < ListaCordenadasPuntos[indice].Count; i++)
            {
                p = new Point();
                p.X = ListaCordenadasPuntos[indice][i].CoordinateX;
                p.Y = -ListaCordenadasPuntos[indice][i].CoordinateY;
                if ((p.X > minimumRange && p.X < maximumRange) && (p.Y > minimumRange && p.Y < maximumRange))
                    pointsCollection.Add(p);
            }

            // Creamos la polilinea
            Polyline line = new Polyline();

            line.Points = pointsCollection;
            line.Stroke = lineColor;
            line.StrokeThickness = 100.0 / width;
            line.RenderTransform = tg;

            GraphicPanel.Children.Add(line);
        }

        // Metodo para introducir de manera manual las coordenadas
        private void aniadirManualmente(object sender, RoutedEventArgs e)
        {
            if (sender == introduccionManual)
            {
                addManuallyWindow = new addManuallyWindow();
                addManuallyWindow.Owner = this;
                addManuallyWindow.ListaManual = ListaCordenadasPuntos;
                addManuallyWindow.ColorLinea = lineColor;
                addManuallyWindow.Indice = indice;
                addManuallyWindow.ShowDialog();

                if (addManuallyWindow.DialogResult == true)
                {
                    ListaCordenadasPuntos = addManuallyWindow.ListaManual;
                    lineColor = addManuallyWindow.ColorLinea;
                    if (lineColor == null)
                        lineColor = Brushes.Black;
                    //https://social.msdn.microsoft.com/Forums/vstudio/en-US/fe69e294-e15e-4a71-9d6d-2c54b0f304ce/how-to-test-if-a-menu-item-has-been-checked?forum=wpf
                    if (GraphicLine.IsChecked == true)
                    {
                        drawCanvas();
                    }
                    if (GraphicChart.IsChecked == true)
                    {
                        loadChartData();
                    }
                    indice++;
                    addManuallyWindow.Indice = indice;
                }
            }
        }

        // Metodo para introducir de manera automatica las coordenadas
        private void aniadirAutomaticamente(object sender, RoutedEventArgs e)
        {
            if (sender == introduccionAutomatica)
            {
                addAutomaticallyWindow = new addAutomaticallyWindow();
                addAutomaticallyWindow.Owner = this;
                addAutomaticallyWindow.ListaAutomatica = ListaCordenadasPuntos;
                addAutomaticallyWindow.Colorlinea = lineColor;
                addAutomaticallyWindow.Indice = indice;
                addAutomaticallyWindow.ShowDialog();

                if (addAutomaticallyWindow.DialogResult == true)
                {
                    ListaCordenadasPuntos = addAutomaticallyWindow.ListaAutomatica;
                    lineColor = addAutomaticallyWindow.Colorlinea;
                    if (lineColor == null)
                        lineColor = Brushes.Black;
                    //https://social.msdn.microsoft.com/Forums/vstudio/en-US/fe69e294-e15e-4a71-9d6d-2c54b0f304ce/how-to-test-if-a-menu-item-has-been-checked?forum=wpf
                    if (GraphicLine.IsChecked == true)
                    {
                        drawCanvas();
                    }
                    if (GraphicChart.IsChecked == true)
                    {
                        loadChartData();
                    }
                    indice++;
                    addAutomaticallyWindow.Indice = indice;

                }
            }
        }

        

        private void purgeModeOn(object sender, RoutedEventArgs e)
        {
            if (sender == purgeMode)
            {
                if (purgeMode.IsChecked == true)
                    purgeModeBool = true;
            }
        }

        // Metodo para el resize de la ventana
        private void GraphicPanel_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            width = GraphicPanel.ActualWidth;
            height = GraphicPanel.ActualHeight;

            tt.X = 50;
            tt.Y = 50;

            sc.ScaleX = width / 100;
            sc.ScaleY = height / 100;
        }

        // Metodo para eliminar la ultima polilinea dibujada en el canvas
        private void deleteLineOnCanvas(object sender, RoutedEventArgs e)
        {
            if (GraphicPanel.Children.Count > 3)
            {
                ListaCordenadasPuntos[indice - 1].Clear();

                GraphicPanel.Children.RemoveAt(GraphicPanel.Children.Count - 1);
                indice--;
                if (addManuallyWindow != null)
                    addManuallyWindow.ListaManual = ListaCordenadasPuntos;

                if (addAutomaticallyWindow != null)
                    addAutomaticallyWindow.ListaAutomatica = ListaCordenadasPuntos;

            }
        }

        // Metodo para limpiar el grafico donde representamos las graficas de barras
        private void deleteBarCharOnChart(object sender, RoutedEventArgs e)
        {
            ((ColumnSeries)BarChar.Series[0]).ItemsSource = null;
        }

        // Metodos para guardar la ventana en un png
        private static void saveWindowToFile(Window window, int dpi, string filename)
        {
            var rtb = new RenderTargetBitmap((int)window.Width, (int)window.Width, dpi, dpi, PixelFormats.Pbgra32);
            rtb.Render(window);
            SaveRTBAsPNGBMP(rtb, filename);
        }

        private void saveWindowToPng(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "Image";
            dlg.DefaultExt = ".png";
            dlg.Filter = "PNG File (.png)|*.png";

            // Show save file dialog box
            Nullable<bool> result = dlg.ShowDialog();

            // Process save file dialog box results
            if (result == true)
            {
                // Save document
                string filename = dlg.FileName;
                saveWindowToFile(this, 196, filename);
            }
        }

        private static void SaveRTBAsPNGBMP(RenderTargetBitmap bmp, string filename)
        {
            var enc = new System.Windows.Media.Imaging.PngBitmapEncoder();
            enc.Frames.Add(System.Windows.Media.Imaging.BitmapFrame.Create(bmp));

            using (var stm = System.IO.File.Create(filename))
            {
                enc.Save(stm);
            }
        }

        // Metodos para el purgado de los puntos fuera del rectangulo 
        private void purgeMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (purgeModeBool == true && GraphicPanel.Children.Count > 3)
            {
                // Cogemos el punto donde hemos clicado con el raton
                mouseDown = true;
                mouseClickDown = e.GetPosition(GraphicPanel);
                GraphicPanel.CaptureMouse();

                // Inicializamos el rectangulo para la purga      
                Canvas.SetLeft(rectPurge, mouseClickDown.X);
                Canvas.SetTop(rectPurge, mouseClickDown.Y);
                rectPurge.Width = 0;
                rectPurge.Height = 0;
                rectPurge.Visibility = Visibility.Visible;

                // Recalculamos los click del raton para que coincidan con los puntos del canvas
                rectCornerDown.X = (mouseClickDown.X) / (width / 100) - 50;
                rectCornerDown.Y = -((mouseClickDown.Y) / (height / 100) - 50);
            }
        }

        //https://stackoverflow.com/questions/1838163/click-and-drag-selection-box-in-wpf
        private void purgeMouseUp(object sender, MouseButtonEventArgs e)
        {
            if (purgeModeBool == true && GraphicPanel.Children.Count > 3)
            {
                width = GraphicPanel.ActualWidth;
                height = GraphicPanel.ActualHeight;

                // Soltamos el click del raton
                mouseDown = false;
                GraphicPanel.ReleaseMouseCapture();
                rectPurge.Visibility = Visibility.Collapsed;

                // Cogemos el otro click del raton en diagonal
                mouseClickUp = e.GetPosition(GraphicPanel);

                // Volvemos a recalcular el punto de este click de raton para que coincida con los del canvas
                rectCornerUp.X = ((mouseClickUp.X) / (width / 100) - 50);
                rectCornerUp.Y = -((mouseClickUp.Y) / (height / 100) - 50);


                // Asignamos los puntos recogidos por el raton a un array de cuatro puntos (que es el rectangulo)
                Point[] rectangle = new Point[] { rectCornerDown, new Point { X = rectCornerUp.X, Y = rectCornerDown.Y }, rectCornerUp, new Point { X = rectCornerDown.X, Y = rectCornerUp.Y } };

                // Comprobamos punto por punto de nuestra coleccion de coordenadas si estan fuera o dentro del rectangulo
                for (int i = 0; i < ListaCordenadasPuntos[indice - 1].Count; i++)
                {
                    // Punto que vamos a comprobar
                    Point pointToCheck = new Point(ListaCordenadasPuntos[indice - 1][i].CoordinateX, ListaCordenadasPuntos[indice - 1][i].CoordinateY);

                    //http://ltuttini.blogspot.com/2010/04/c-eliminar-items-en-una-lista.html
                    if (!IsPointInRectangle(rectangle, pointToCheck))
                    {
                        ListaCordenadasPuntos[indice - 1].RemoveAt(i);
                        i--;
                    }
                }
                GraphicPanel.Children.RemoveAt(indice + 2);
                indice--;
                drawCanvas();
                indice++;
            }
        }

        private void purgeMouseMouve(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                Point mousePos = e.GetPosition(GraphicPanel);

                if (mouseClickDown.X < mousePos.X)
                {
                    Canvas.SetLeft(rectPurge, mouseClickDown.X);
                    rectPurge.Width = mousePos.X - mouseClickDown.X;
                }
                else
                {
                    Canvas.SetLeft(rectPurge, mousePos.X);
                    rectPurge.Width = mouseClickDown.X - mousePos.X;
                }

                if (mouseClickDown.Y < mousePos.Y)
                {
                    Canvas.SetTop(rectPurge, mouseClickDown.Y);
                    rectPurge.Height = mousePos.Y - mouseClickDown.Y;
                }
                else
                {
                    Canvas.SetTop(rectPurge, mousePos.Y);
                    rectPurge.Height = mouseClickDown.Y - mousePos.Y;
                }
            }
        }

        //https://stackoverflow.com/questions/4243042/c-sharp-point-in-polygon
        // Metodo para comprobar si un punto esta contenido en el rectangulo
        public static bool IsPointInRectangle(Point[] rectangle, Point pointToCheck)
        {
            bool result = false;
            int j = rectangle.Count() - 1;
            for (int i = 0; i < rectangle.Count(); i++)
            {
                if (rectangle[i].Y < pointToCheck.Y && rectangle[j].Y >= pointToCheck.Y || rectangle[j].Y < pointToCheck.Y && rectangle[i].Y >= pointToCheck.Y)
                {
                    if (rectangle[i].X + (pointToCheck.Y - rectangle[i].Y) / (rectangle[j].Y - rectangle[i].Y) * (rectangle[j].X - rectangle[i].X) < pointToCheck.X)
                    {
                        result = !result;
                    }
                }
                j = i;
            }
            return result;
        }
    }
}
