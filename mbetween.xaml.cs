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

namespace testapp
{
    /// <summary>
    /// Interaction logic for mbetween.xaml
    /// </summary>
    public partial class mbetween : Page
    {
        public mbetween()
        {
            InitializeComponent();
        }

        private void new_Click(object sender, RoutedEventArgs e)
        {
            quizm q = new quizm();
            quizm.num = int.Parse(numofquestions.Text);
            maker.Content = new quizm();
            
        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {
            maker.Content = new editquiz();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string tString = numofquestions.Text;
            if (tString.Trim() == "") return;
            for (int i = 0; i < tString.Length; i++)
            {
                if (!char.IsNumber(tString[i]))
                {
                    MessageBox.Show("Please enter a valid number");
                    numofquestions.Text = "";
                    return;
                }
                @new.IsEnabled = true;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            quizm.sfile = quizname.Text;
            numofquestions.IsEnabled = true;
            sub.IsEnabled = true;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            maker.Content = new MainWindow();
        }
    }
}
