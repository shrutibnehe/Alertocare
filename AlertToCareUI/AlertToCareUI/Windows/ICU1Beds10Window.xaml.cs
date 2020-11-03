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
    /// Interaction logic for ICU1Beds10Window.xaml
    /// </summary>
    public partial class ICU1Beds10Window : Window
    {
        public ICU1Beds10Window()
        {
            
            InitializeComponent();
            AdmissionAndDischarge admission = new AdmissionAndDischarge("ICU004");//ICU001
            LLayout_10 rectangle = new LLayout_10("ICU004");//ICU001
            //AlertManagerView alertManagerView = new AlertManagerView("ICU004");

        }
    }
}
