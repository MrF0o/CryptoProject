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

namespace CryptoProject
{
    /// <summary>
    /// Interaction logic for Choose.xaml
    /// </summary>
    public partial class Choose : Window
    {
        public String Algorithm { get; set; }

        public Choose()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Algorithm = "mixed";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Algorithm = "substitute";
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Algorithm = "permute";
        }
    }
}
