using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for quizm.xaml
    /// </summary>
    public partial class quizm : Page
    {
        public static int num = 0;
        private static int l = 0;
        public static string sfile = "";
        private static string ques = "";
        private static string[] ans = new string[5];
        public quizm()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ans[4] = A1text.Text;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ans[4] = A2text.Text;

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ans[4] = A3text.Text;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            ans[4] = A4text.Text;
        }

        public static Dictionary<string, string[]> questions = new Dictionary<string, string[]>();
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            ques = qtext.Text;
            ans[0] = A1text.Text;
            ans[1] = A2text.Text;
            ans[2] = A3text.Text;
            ans[3] = A4text.Text;
            questions.Add(ques, ans);
            l++;
            update();
        }

        public void update()
        {
            if (l >= num)
            {
                using (StreamWriter file = new StreamWriter($@".\QuizinatorQuizzes\{sfile}.txt", false))
                    foreach (String key in questions.Keys)
                    {
                        file.Write($"{key} @@ ");
                        int temp = 1;
                        foreach (String item in questions[key])
                        {
                            if (temp == 5)
                            {
                                file.Write($"{item} ");
                            }
                            else
                            {
                                file.Write($"{item} ~~ ");
                                temp++;
                            }
                        }
                        file.WriteLine();
                    }
                make.Content = new mbetween();
            }
            else
            {
                quizm q = new quizm();
                q.qtext.Text = "";
                q.A1text.Text = "";
                q.A2text.Text = "";
                q.A3text.Text = "";
                q.A4text.Text = "";
                make.Content = new quizm();
            }
        }
    }
}
