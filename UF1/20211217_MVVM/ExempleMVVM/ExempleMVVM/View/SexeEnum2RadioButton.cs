using ExempleMVVM.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace ExempleMVVM.View
{
    public class SexeEnum2RadioButton: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            string radio = (string)parameter;
            SexeEnum s = (SexeEnum)value;
            
            bool IsCheched = 
                (radio.Equals("D") && s == SexeEnum.DONA) ||
                (radio.Equals("H") && s == SexeEnum.HOME) ||
                (radio.Equals("N") && s == SexeEnum.NO_DEFINIT);
            Debug.WriteLine("Convert " + s + " for radio=" + radio + ", IsChecked=" + IsCheched);
            return IsCheched;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            string radio = (string)parameter;
            bool isChecked = (bool)value;
            if(isChecked)
            {
                
                SexeEnum s = SexeEnum.NO_DEFINIT;
                switch (radio)
                {
                    case "D": s=SexeEnum.DONA;break;
                    case "H": s = SexeEnum.HOME; break;
                    case "N": s = SexeEnum.NO_DEFINIT; break;
                }
                Debug.WriteLine("ConvertBack  for radio=" + radio + ", IsChecked=" + value+ " sexe="+s);
                return s;
            }
            else
            {
                // CAS en el que el checkbox es desactiva.
                // Això indica que no es faci cap canvi de valor !!!!!
                return DependencyProperty.UnsetValue;
            }
        }
    }
}
