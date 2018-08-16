using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace testapp
{
    /// <summary>
    /// Interaction logic for quizmaker.xaml
    /// </summary>
    public partial class quizmaker : Page
    {
        #region refrences
        public static Dictionary<string, string[]> questions = new Dictionary<string, string[]>();
        private static string q = "";
        private static string ra = "";
        private static string[] a = new string[4];
        private static int count = questions.Count;
        private static string[] qu = { };
        private static int l = 0;
        private static int correct = 0;
        private static int wrong = 0;
        #endregion

        public quizmaker()
        {

            InitializeComponent();
            l = 0;
            correct = 0;
            wrong = 0;
            qu = new string[questions.Count()];
                int c = 0;
                foreach (String key in questions.Keys)
                {
                    qu[c] = key;
                    q = key;                  
                    c+=1;
                }
                update();
        }

        private void A_Click(object sender, RoutedEventArgs e)
        {
            if((string)A.Content == ra)
            {
                MessageBox.Show("CORRECT");
                l++;
                correct++;
            }
            else
            {
                MessageBox.Show("WRONG");
                l++;
                wrong++;
            }
            update();
        }

        private void B_Click(object sender, RoutedEventArgs e)
        {
            if ((string)B.Content == ra)
            {
                MessageBox.Show("CORRECT");
                l++;
                correct++;
            }
            else
            {
                MessageBox.Show("WRONG");
                l++;
                wrong++;
            }
            update();
        }

        private void C_Click(object sender, RoutedEventArgs e)
        {
            if ((string)C.Content == ra)
            {
                MessageBox.Show("CORRECT");
                l++;
                correct++;
            }
            else
            {
                MessageBox.Show("WRONG");
                l++;
                wrong++;
            }
            update();
        }

        private void D_Click(object sender, RoutedEventArgs e)
        {
            if ((string)D.Content == ra)
            {
                MessageBox.Show("CORRECT");
                l++;
                correct++;
            }
            else
            {
                MessageBox.Show("WRONG");
                l++;
                wrong++;
            }
            update();
        }

        private void update()
        {
            if (l >= questions.Count())
            {
                MessageBox.Show($"Right: {correct}. Wrong: {wrong}");
                fram.Content = new MainWindow();
            }
            else
            {
                if (questions.ContainsKey(qu[l]))
                {
                    int b = 0;
                    foreach (String item in questions[qu[l]])
                    {
                        if (b >= 4)
                        {
                            ra = item;
                        }
                        else
                        {
                            a[b] = item;
                            b++;
                        }
                    }
                    question.Content = qu[l];
                    A.Content = a[0];
                    B.Content = a[1];
                    C.Content = a[2];
                    D.Content = a[3];
                }
            }
        }
    }

}
