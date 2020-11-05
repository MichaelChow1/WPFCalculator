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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private enum SelectedOperator
        {
            Addition,
            Subtraction,
            Multiplication,
            Division
        }

        double lastNumber;
        double result;
        SelectedOperator selectedOperator;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Number_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button) sender;
            DisplayResult.Text = b.Content.ToString();
            
        }
    }
}
