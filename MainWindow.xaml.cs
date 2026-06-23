using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NetCalc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string[] arr;

        private string calculate(string s)
        {
            string result = "";
            int count = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (int.TryParse(s[i].ToString(), out int n))
                {
                    arr[count] = s[i].ToString();
                }
                else
                {
                    count++;
                    arr[count] = s[i].ToString();
                    count++;
                }
            }
            while (arr.Length > 1)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] == "*")
                    {
                        arr[i - 1] = (Convert.ToInt32(arr[i - 1]) * Convert.ToInt32(arr[i + 1])).ToString();
                        arr = arr.Where((source, index) => index != i && index != i + 1).ToArray();
                    }
                    else if (arr[i] == "/")
                    {
                        arr[i - 1] = (Convert.ToInt32(arr[i - 1]) / Convert.ToInt32(arr[i + 1])).ToString();
                        arr = arr.Where((source, index) => index != i && index != i + 1).ToArray();
                    }
                }
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] == "+")
                    {
                        arr[i - 1] = (Convert.ToInt32(arr[i - 1]) + Convert.ToInt32(arr[i + 1])).ToString();
                        arr = arr.Where((source, index) => index != i && index != i + 1).ToArray();
                    }
                    else if (arr[i] == "-")
                    {
                        arr[i - 1] = (Convert.ToInt32(arr[i - 1]) - Convert.ToInt32(arr[i + 1])).ToString();
                        arr = arr.Where((source, index) => index != i && index != i + 1).ToArray();
                    }
                }
            }

            result = arr[0];
            return result;
        }
    


        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ACBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void subBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void eqlBtn_Click(object sender, RoutedEventArgs e)
        {
            string x = calculate(answerBox.Text);
            answerBox.Text = x;
        }
    }
}