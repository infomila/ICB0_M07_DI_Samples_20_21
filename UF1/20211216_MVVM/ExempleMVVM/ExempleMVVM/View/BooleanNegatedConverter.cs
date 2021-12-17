using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace ExempleMVVM.View
{
    public class BooleanNegatedConverter :IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return !((Boolean)value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            // value és el valor de la propietat a la interfície gràfica

            bool isChecked = (bool)value;
            return !isChecked;                        
        }
    }
}
