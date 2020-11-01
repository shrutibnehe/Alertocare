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
    /// Interaction logic for ICU003_LLayout_12.xaml
    /// </summary>
    public partial class ICU003_LLayout_12 : Window
    {
        public ICU003_LLayout_12()
        {
            InitializeComponent();
            AdmissionAndDischarge admission = new AdmissionAndDischarge("ICU003");
            LLayout_12 layout = new LLayout_12("ICU003");
        }
    }
}
