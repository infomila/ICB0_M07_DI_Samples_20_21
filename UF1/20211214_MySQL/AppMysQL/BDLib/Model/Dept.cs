using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BDLib
{
    public class Dept: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int dept_no;
        private string dnom;
        private string loc;

        public Dept(int dept_no, string dnom, string loc)
        {
            Dept_no = dept_no;
            Dnom = dnom;
            Loc = loc;
        }

        public int Dept_no { get => dept_no; set { 

                dept_no = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Dept_no"));
            } }
        public string Dnom { get => dnom; set { dnom = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Dnom"));
            }
        }
        public string Loc { get => loc; set { loc = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Loc"));
            }
        }

    }
}
