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
    /// Interaction logic for selectquestion.xaml
    /// </summary>
    public partial class selectquestion : Page
    {
        public selectquestion()
        {
            InitializeComponent();
            foreach (string file in questions.Keys)
            {
                quizzes.Items.Add(file);
            }
        }

        public static Dictionary<string, string[]> questions = new Dictionary<string, string[]>();
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            questionedit q = new questionedit();
            foreach(string key in questions.Keys)
            {
                if((string)quizzes.SelectedItem == key)
                {
                    q.qtext.Text = key;
                    q.A1text.Text = questions[key][0];
                    q.A2text.Text = questions[key][1];
                    q.A3text.Text = questions[key][2];
                    q.A4text.Text = questions[key][3];
                    questions.Remove(key);
                }
            }

            back.Content = q;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
