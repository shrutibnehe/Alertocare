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

namespace AlertToCareUI
{
    /// <summary>
    /// Interaction logic for ICU002_Rectangular_10.xaml
    /// </summary>
    public partial class ICU002_Rectangular_10 : Window
    {
        public ICU002_Rectangular_10()
        {
            InitializeComponent();
            AdmissionAndDischarge admission = new AdmissionAndDischarge("ICU005");//ICU002
            Rectangular_10 rectangular = new Rectangular_10("ICU002");
        }
    }
}
