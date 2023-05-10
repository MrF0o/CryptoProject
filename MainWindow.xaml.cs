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
            this.Title = this.Title + Algorithm;

            if (options.Count <= 0)
            {
                Approche.IsEnabled = false;
                KeyInput.IsEnabled = true;
                Approach.Text = "Mixed";

                isKeyRequired = true;
                currentAlgorithm = new Crypto.MixedCipher();

            }
            else
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
                case "mono-alphabetique a cle":
                    isKeyRequired = true;
                    KeyInput.IsEnabled = true;
                    break;
                case "vigenere":
                    {
                        isKeyRequired = true;
                        KeyInput.IsEnabled = true;
                        currentAlgorithm = new Crypto.VigenereCipher();
                    }
                    break;
                case "Grille avec clé":
                    {
                        isKeyRequired = true;
                        KeyInput.IsEnabled = true;
                    }
                    break;
                case "Zig Zag":
                    {
                        isKeyRequired = false;
                        KeyInput.IsEnabled = false;

                        Prompt p = new Prompt("ZigZag depth? (profondeur)");
                        bool? res = p.ShowDialog();
                        currentAlgorithm = new Crypto.ZigZag(p.value);
                    }
                    break;
                case "mono-alphabetique de cesar":
                    {
                        isKeyRequired = false;
                        KeyInput.IsEnabled = false;

                        Prompt p = new Prompt("Shift Value? (k)");
                        bool? res = p.ShowDialog();
                        currentAlgorithm = new Crypto.CesarMonoAlphabetic(p.value);
                    }
                    break;
                default:
                    MessageBox.Show("somehow you didn't select a valid algorithm");
                    break;
            }
        }

        private void EncryptBtn_Click(object sender, RoutedEventArgs e)
        {

            if (isKeyRequired)
            {
                if (KeyInput.Text != "")
                {
                    currentAlgorithm.Key = KeyInput.Text;
                }
                else
                {
                    MessageBox.Show("Key cannot be empty for " + Approach.Text, "Error", MessageBoxButton.OK);
                    return;
                }
            }

            this.Result.Text = currentAlgorithm.encrypt(RawText.Text);
            Copy.IsEnabled = true;
        }

        private void DecryptBtn_Click(object sender, RoutedEventArgs e)
        {
            if (isKeyRequired)
            {
                if (KeyInput.Text != "")
                {
                    currentAlgorithm.Key = KeyInput.Text;
                }
                else
                {
                    MessageBox.Show("Key cannot be empty for " + Approach.Text, "Error", MessageBoxButton.OK);
                    return;
                }
            }

            this.Result.Text = currentAlgorithm.decrypt(RawText.Text);
            Copy.IsEnabled = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(Result.Text);
        }
    }
}
