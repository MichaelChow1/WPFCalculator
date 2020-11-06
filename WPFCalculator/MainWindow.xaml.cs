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
        private static SelectedOperator? _selectedOperator;

        private enum SelectedOperator
        {
            Addition,
            Subtraction,
            Multiplication,
            Division
        }
        double firstNumber;
        double lastNumber;
        double result;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Number_Click(object sender, RoutedEventArgs e)
        {

            Button b = (Button)sender;
            string number = b.Content.ToString();

            if (DisplayResult.Text == "0")
            {
                DisplayResult.Text = "";
            }
            else if (DisplayResult.Text == lastNumber.ToString())
            {
                DisplayResult.Text = "";
                
            }
            DisplayResult.Text += number;
            firstNumber = double.Parse(DisplayResult.Text);


        }

        private void Operator_Handle(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            string op = b.Content.ToString();


            if (_selectedOperator == null)
            {
                switch (op)
                {
                    case "+":
                        _selectedOperator = SelectedOperator.Addition;
                        lastNumber = double.Parse(DisplayResult.Text);
                        DisplayResult.Text = lastNumber.ToString();
                        break;
                    case "-":
                        _selectedOperator = SelectedOperator.Subtraction;
                        lastNumber = double.Parse(DisplayResult.Text);
                        DisplayResult.Text = lastNumber.ToString();
                        break;
                    case "/":
                        _selectedOperator = SelectedOperator.Division;
                        lastNumber = double.Parse(DisplayResult.Text);
                        DisplayResult.Text = lastNumber.ToString();
                        break;
                    case "*":
                        _selectedOperator = SelectedOperator.Multiplication;
                        lastNumber = double.Parse(DisplayResult.Text);
                        DisplayResult.Text = lastNumber.ToString();
                        break;
                }
            }

        }

        private void Equals_Handle(object sender, RoutedEventArgs e)
        {
            if (_selectedOperator == SelectedOperator.Addition)
            {
                result = MathService.Addition(firstNumber, lastNumber);
                DisplayResult.Text = result.ToString();
                
            }
            else if (_selectedOperator == SelectedOperator.Subtraction)
            {
                result = MathService.Subtract(lastNumber, firstNumber);
                DisplayResult.Text = result.ToString();
               
            }
            else if (_selectedOperator == SelectedOperator.Division)
            {
                result = MathService.Divide(lastNumber, firstNumber);
                DisplayResult.Text = result.ToString();
                if (firstNumber == 0)
                {
                    MessageBox.Show("Cannot divide by 0", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    DisplayResult.Text = "0";
                    firstNumber = 0;
                    lastNumber = 0;
                    _selectedOperator = null;
                }
                
            }
            else if (_selectedOperator == SelectedOperator.Multiplication)
            {
                result = MathService.Multiply(lastNumber, firstNumber);
                DisplayResult.Text = result.ToString();
            }

            lastNumber = result;
            _selectedOperator = null;

        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            _selectedOperator = null;
            DisplayResult.Text = "0";
            firstNumber = 0;
            lastNumber = 0;
            result = 0;
        }

        private void Percent_Click(object sender, RoutedEventArgs e)
        {

            if (lastNumber != 0)
            {
                string number = DisplayResult.Text;
                DisplayResult.Text = ((lastNumber / 100) * double.Parse(number)).ToString();
                firstNumber= double.Parse(DisplayResult.Text);
            }
            else if(lastNumber == 0)
            {
                DisplayResult.Text = (firstNumber * 0.01).ToString();
                firstNumber = double.Parse(DisplayResult.Text);
            }
        }
        private void Negative_Positive_Click(object sender, RoutedEventArgs e)
        {
            double number = double.Parse(DisplayResult.Text) * -1;
            DisplayResult.Text = number.ToString() ;
        }

        private void Period_Click(object sender, RoutedEventArgs e)
        {
            if (!DisplayResult.Text.Contains("."))
                DisplayResult.Text += ".";
        }
    }
}
