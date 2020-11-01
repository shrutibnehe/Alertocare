using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using AlertToCareUI.Models;
using AlertToCareUI.Views;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace AlertToCareUI
{
    /// <summary>
    /// Interaction logic for ICU001_Rectangular_12.xaml
    /// </summary>
    public partial class ICU001_Rectangular_12 : Window
    {
        public ICU001_Rectangular_12()
        {
            InitializeComponent();
            AdmissionAndDischarge admission = new AdmissionAndDischarge("ICU008");//ICU001
            Rectangular_12 rectangle = new Rectangular_12("ICU008");//ICU001
            //admission.IcuNo = "ICU008";
            
        }
    }
}
