using AlertToCareUI.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AlertToCareUI.Windows
{
    /// <summary>
    /// Interaction logic for ICU2Beds12Window.xaml
    /// </summary>
    public partial class ICU2Beds12Window : Window
    {
        public ICU2Beds12Window()
        {
            InitializeComponent();
            AdmissionAndDischarge admission = new AdmissionAndDischarge("ICU001");//ICU001
            Rectangular_12 rectangle = new Rectangular_12("ICU001");//ICU001
            //AlertManagerView alertManagerView = new AlertManagerView("ICU001");
        }
    }
}
