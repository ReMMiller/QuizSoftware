using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;

namespace testapp
{
    /// <summary>
    /// Interaction logic for load.xaml
    /// </summary>
    public partial class load : Page
    {
        private static string fiile = "";
        public load()
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
            else {
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

        private static List<string> temp = new List<string>();
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string t = "";
            foreach(string s in temp)
            {
                if(System.IO.Path.GetFileName(s) == (string)quizzes.SelectedItem)
                {
                    t = s;
                }
            }
            MainWindow.fil = t;
            back.Content = new MainWindow();
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog fdb = new FolderBrowserDialog();

            if (fdb.ShowDialog() == DialogResult.OK)
            {
                fiile = fdb.SelectedPath;
                string[] files = Directory.GetFiles(fdb.SelectedPath);
                quizzes.Items.Clear();
                foreach (string file in files)
                {
                    quizzes.Items.Add(System.IO.Path.GetFileName(file));
                    temp.Add(file);
                }
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            back.Content = new MainWindow();
        }
    }
}
