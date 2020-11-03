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
    /// Interaction logic for ICU2Beds10Window.xaml
    /// </summary>
    public partial class ICU2Beds10Window : Window
    {
        public ICU2Beds10Window()
        {
            InitializeComponent();
            AdmissionAndDischarge admission = new AdmissionAndDischarge("ICU002");
            Rectangular_10 rectangle = new Rectangular_10("ICU002");//ICU001
            //AlertManagerView alertManagerView = new AlertManagerView("ICU002");
        }
    }
}
