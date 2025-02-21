﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using GestioDequips.Model;
// La plantilla de elemento Control de usuario está documentada en https://go.microsoft.com/fwlink/?LinkId=234236

namespace GestioDequips.View
{
    public sealed partial class UIEquipRow : UserControl
    {





        public Equip UnEquip
        {
            get { return (Equip)GetValue(UnEquipProperty); }
            set { SetValue(UnEquipProperty, value); }
        }

        // Using a DependencyProperty as the backing store for UnEquip.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UnEquipProperty =
            DependencyProperty.Register("UnEquip", typeof(Equip), typeof(UIEquipRow), new PropertyMetadata(null));




        public UIEquipRow()
        {
            this.InitializeComponent();
        }
    }
}
