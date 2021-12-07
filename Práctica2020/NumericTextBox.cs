using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.Globalization;
using System.Diagnostics;

namespace IntegerTextBox
{
    class NumericTextBox : TextBox
    {
        public NumericTextBox()
        {
            //this.PreviewTextInput += NumericTextBox_PreviewTextInput;
            /* Podemo usar el método escrito para gestionar el evento, en 
             * este caso, PreviewTextInput, o podemo usar el correspondiente
             * método virtual, OnPreviewTextInput. Es equivalente. 
             */
        }
        public int IntValue
        {
            get
            {
                return Int32.Parse(this.Text);
            }
        }

        public double DoubleValue
        {
            get
            {
                return Double.Parse(this.Text);
            }
        }

        public float FloatValue
        {
            get
            {
                return float.Parse(this.Text);
            }
        }

        protected override void OnPreviewTextInput(TextCompositionEventArgs e)
        {

            base.OnPreviewTextInput(e);
            NumberFormatInfo numberFormatInfo = System.Globalization.CultureInfo.CurrentCulture.NumberFormat;
            string decimalSeparator = numberFormatInfo.NumberDecimalSeparator;

            string negativeSign = numberFormatInfo.NegativeSign;

            string caracter = e.Text;

            if (Char.IsDigit(caracter[0]))
            {

            }
            else if (caracter.Equals(decimalSeparator) || caracter.Equals(negativeSign))
            {

            }
            else if (caracter == "\b")
            {

            }
            else
            {
                e.Handled = true;
            }
        }

        private void NumericTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            NumberFormatInfo numberFormatInfo = System.Globalization.CultureInfo.CurrentCulture.NumberFormat;
            string decimalSeparator = numberFormatInfo.NumberDecimalSeparator;

            string negativeSign = numberFormatInfo.NegativeSign;

            string caracter = e.Text;

            if (Char.IsDigit(caracter[0]))
            {

            }
            else if (caracter.Equals(decimalSeparator) || caracter.Equals(negativeSign))
            {

            }
            else if (caracter == "\b")
            {

            }
            else
            {
                e.Handled = true;
            }
        }
    }
}
