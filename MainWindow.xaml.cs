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

namespace CryptoProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public String Algorithm { get; set; }

        private List<String> options;
        private bool isKeyRequired = true;
        private bool isStepRequired = false;
        private String chosenAlgorithm;

        public Crypto.Crypto currentAlgorithm;

        public MainWindow()
        {
            this.currentAlgorithm = new Crypto.MonoAlphabetic("zyxwvutsrqponmlkjihgfedcba");
            this.options = new List<String>();
            Choose chooseModal = new Choose();

            bool? res = chooseModal.ShowDialog();

            switch (res)
            {
                case true:
                    this.Algorithm = chooseModal.Algorithm;

                    {
                        switch (this.Algorithm)
                        {
                            case "permute":
                                options.Add("Zig Zag");
                                options.Add("Grille avec clé");
                                break;
                            case "substitute":
                                options.Add("mono-alphabetique");
                                options.Add("mono-alphabetique de cesar");
                                options.Add("mono-alphabetique a cle");
                                options.Add("poly-alphabetique");
                                options.Add("vigenere");
                                break;
                            case "mixed":
                                break;
                            default:
                                break;
                        }
                    }

                    break;
                case false:
                    this.Close();
                    break;
                default:
                    this.Close();
                    break;
            }

            InitializeComponent();
            this.Title = this.Title  + Algorithm;

            if (options.Count <= 0)
            {
                Approche.Visibility = Visibility.Hidden;
                KeyInput.IsEnabled = true;
            } else
            {
                foreach (String item in options)
                {
                    Approach.Items.Add(item);
                }
            }
        }


        private void Approach_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.chosenAlgorithm = Approach.SelectedItem.ToString();
            switch (chosenAlgorithm)
            {
                case "mono-alphabetique a cle": case "vigenere": case "Grille avec clé":
                    isKeyRequired = true;
                    KeyInput.IsEnabled = true;
                    break;
                default:
                    isKeyRequired = false;
                    KeyInput.IsEnabled = false;
                    break;
            }
        }

        private void EncryptBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(RawText.Text);
            MessageBox.Show(currentAlgorithm.encrypt(RawText.Text));
        }
    }
}
