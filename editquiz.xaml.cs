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
    /// Interaction logic for editquiz.xaml
    /// </summary>
    public partial class editquiz : Page
    {
        private static string fiile = "";
        private static List<string> temp = new List<string>();
        private static Dictionary<string, string[]> questions = new Dictionary<string, string[]>();
        public editquiz()
        {
            InitializeComponent();
            if (fiile == "")
            {
                fiile = @".\QuizinatorQuizzes";
                if (!Directory.Exists(@".\QuizinatorQuizzes"))
                {
                    Directory.CreateDirectory(fiile);
                }

                string[] files = Directory.GetFiles(fiile);

                foreach (string file in files)
                {
                    if (file.Contains(".txt"))
                    {
                        quizzes.Items.Add(System.IO.Path.GetFileName(file));
                        temp.Add(file);
                    }
                }

            }
            else
            {
                string[] files = Directory.GetFiles(fiile);

                foreach (string file in files)
                {
                    if (file.Contains(".txt"))
                    {
                        quizzes.Items.Add(System.IO.Path.GetFileName(file));
                        temp.Add(file);
                    }
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            read(fiile + $"\\{(string)quizzes.SelectedItem}");
            questionedit.sfile = fiile + $"\\{(string)quizzes.SelectedItem}";
            selectquestion.questions = questions;
            back.Content = new selectquestion();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            back.Content = new mbetween();
        }

        private static void read(string fil)
        {
            string line;
            questions = new Dictionary<string, string[]>();
            System.IO.StreamReader file =
                new System.IO.StreamReader(fil);
            while ((line = file.ReadLine()) != null)
            {
                string[] temp = line.Trim().Split(new[] { "@@" }, StringSplitOptions.None);
                string[] temp2 = new string[5];
                if (temp.Length == 1)
                {
                    break;
                }
                else
                {
                    string[] antemp = temp[1].Split(new[] { "~~" }, StringSplitOptions.None);
                    for (int j = 0; j < 5; j++)
                    {
                        temp2[j] = antemp[j];
                    }
                    questions.Add(temp[0], temp2);
                }
            }

            file.Close();
        }
    }
}
