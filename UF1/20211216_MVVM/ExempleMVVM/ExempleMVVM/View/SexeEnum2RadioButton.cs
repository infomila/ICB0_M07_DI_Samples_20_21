using ExempleMVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace ExempleMVVM.View
{
    public class SexeEnum2RadioButton: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            string radio = (string)parameter;
            SexeEnum s = (SexeEnum)value;
            return 
                (radio.Equals("D") && s == SexeEnum.DONA) ||
                (radio.Equals("H") && s == SexeEnum.HOME) ||
                (radio.Equals("N") && s == SexeEnum.NO_DEFINIT);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            string radio = (string)parameter;
            bool isChecked = (bool)value;
            if(isChecked)
            {
                switch(radio)
                {
                    case "D": return SexeEnum.DONA;
                    case "H": return SexeEnum.HOME;
                    case "N": return SexeEnum.NO_DEFINIT;
                }
            }
            return null;
        }
    }
}
