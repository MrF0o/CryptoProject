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
    /// Interaction logic for Prompt.xaml
    /// </summary>
    public partial class Prompt : Window
    {
        private string msg;
        public int value { get; set; }
        public Prompt(String msg)
        {
            this.msg = msg;
            InitializeComponent();
            this.Title.Content = msg;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Input.Text != "")
            {
                int v;
                int.TryParse(Input.Text, out v);
                this.value = v;
                this.DialogResult = true;
            } else
            {
                MessageBox.Show("Please fill in all values.");
            }
        }

        // only accept numbers
        private void Input_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var textBox = sender as TextBox;
            var fullText = textBox.Text.Insert(textBox.SelectionStart, e.Text);

            double val;
            e.Handled = !double.TryParse(fullText, out val);
        }
    }
}
