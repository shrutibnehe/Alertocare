using AlertToCareUI.ViewModel;
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
    /// Interaction logic for FirstWindow.xaml
    /// </summary>
    public partial class FirstWindow : Window
    {
        AlertManagerViewModel alertContext = new AlertManagerViewModel();
        public FirstWindow()
        {
            InitializeComponent();
            List<string> LayoutTypes = new List<string> { "L-Shaped", "Rectangular" };
            LayoutSelector.ItemsSource = LayoutTypes;
            List<string> NoOfBeds = new List<string> { "10", "12" };
            NoOfBedSelector.ItemsSource = NoOfBeds;
        }
        private void SelectLayout_Click(object sender, RoutedEventArgs e)
        { 
            if (LayoutSelector.SelectedItem.ToString() == "L-Shaped")
            {
                LayoutOneandOpenNextWindow();
            }
            else
            {

                LayoutTwoandOpenNextWindow();
            }
        }
        private void LayoutOneandOpenNextWindow()
        {
            ICU1Beds10Window obj1 = new ICU1Beds10Window();
            ICU1Beds12Window obj2 = new ICU1Beds12Window();
            
            if (NoOfBedSelector.SelectedItem.ToString() == "10")
            {
                alertContext.ICUID = "ICU004";
                obj1.Show();
                this.Close();
            }
            else
            {
                alertContext.ICUID = "ICU003";
                obj2.Show();
                this.Close();
            }
        }
        private void LayoutTwoandOpenNextWindow()
        {
            ICU2Beds12Window obj4 = new ICU2Beds12Window();
            ICU2Beds10Window obj3 = new ICU2Beds10Window();
            if (NoOfBedSelector.SelectedItem.ToString() == "10")
            {
                alertContext.ICUID = "ICU002";
                obj3.Show();
                this.Close();
            }
            else
            {
                alertContext.ICUID = "ICU001";
                obj4.Show();
                this.Close();
            }
        }
    }
}
