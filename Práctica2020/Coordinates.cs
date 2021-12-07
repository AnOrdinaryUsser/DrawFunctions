using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Práctica2020
{
    public class Coordinates : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        //Atributos
        private double coorX, coorY;

        //Constructor
        public Coordinates(double coordinateX, double coordinateY)
        {
            coorX = coordinateX;
            coorY = coordinateY;
        }

        // Propiedades
        public double CoordinateX
        { 
            get { return coorX; }
            set { coorX = value; OnPropertyChanged("CoordinateX"); }
        }
        public double CoordinateY
        {
            get { return coorY; }
            set { coorY = value; OnPropertyChanged("CoordinateY"); }
        }

        public override string ToString()
        {
            string res = coorX + " " + coorY;
            return res;
        }

        // Método que lanza el evento PropertyChanged cuando se cambia el valor de cualquier propiedad
        void OnPropertyChanged(String propertyname)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
        }

    }
}
