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
    /// Interaction logic for ICU1Beds12Window.xaml
    /// </summary>
    public partial class ICU1Beds12Window : Window
    {
        public ICU1Beds12Window()
        {
            InitializeComponent();
            AdmissionAndDischarge admission = new AdmissionAndDischarge("ICU003");
            LLayout_12 rectangle = new LLayout_12("ICU003");
            AlertManagerView alertManagerView = new AlertManagerView("ICU003");
        }
    }
}
