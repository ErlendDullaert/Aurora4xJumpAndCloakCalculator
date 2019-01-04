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
using Aurora4xJumpCloakCalculator.src;

namespace Aurora4xJumpCloakCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Calculator _calculator = new Calculator();
        private readonly TextBlock _jWeight, _cWeight, _sWeight;
        private readonly TextBox _jValue, _cValue, _compValue;

        public MainWindow()
        {
            InitializeComponent();
            _jWeight = (TextBlock) this.FindName("JWeight");
            _cWeight = (TextBlock) this.FindName("CWeight");
            _sWeight = (TextBlock) this.FindName("SWeight");
            _jValue = (TextBox) this.FindName("JumpValue");
            _cValue = (TextBox) this.FindName("CloakValue");
            _compValue = (TextBox) this.FindName("CompValue");
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(_compValue.Text, out int compValue))
                compValue = 0;
            if (!int.TryParse(_jValue.Text, out int jValue))
                jValue = 0;
            if (!int.TryParse(_cValue.Text, out int cValue))
                cValue = 0;

            int[] result = _calculator.shipCalc(compValue, jValue, cValue);
            if (result.Length != 3)
                throw new Exception("Unexpected Array Length");
            _sWeight.Text = result[2].ToString();
            _jWeight.Text = result[0].ToString();
            _cWeight.Text = result[1].ToString();
        }
    }
}
