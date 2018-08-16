using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace testapp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Page
    {
        public MainWindow()
        {
            InitializeComponent();
            this.filefound.Content = System.IO.Path.GetFileName(fil) + " Loaded";
        }

        public static Dictionary<string, string[]> questions = new Dictionary<string, string[]>();
        public static string fil = "Nothing";


        private void create_Click(object sender, RoutedEventArgs e)
        {
            main.Content = new mbetween();
        }

        private void load_Click(object sender, RoutedEventArgs e)
        {
            main.Content = new load();
        }

        private static void tempthingy()
        {
                string line;
            try
            {
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
            catch (FileNotFoundException fnf)
            {
                
            }
            }


        private void play_Click(object sender, RoutedEventArgs e)
        {
            //Form1 f = new Form1();
            //f.ShowDialog();
            tempthingy();
            if (questions.Count() == 0)
            {
                MessageBox.Show("Not A Valid File");
            }
            else
            {
                Shuffle(questions);
                quizmaker.questions = questions;
                main.Content = new quizmaker();
            }
        }

        private static Random rng = new Random();

        public static void printQuestions(Dictionary<string, string[]> q)
        {
            string s = "";
            foreach (String key in q.Keys)
            {
                int a = (int)'A';
                int b = 0;
                s += $"Question: {key} \n";
                s += $"Answers: \n";
                foreach (String item in q[key])
                {
                    if (b >= 4)
                    {
                        s += $"Right Answer: {item} \n";
                    }
                    else
                    {
                        s += $"{(char)a}: {item} \n";
                        b++;
                        a++;
                    }
                }
                Console.WriteLine();
            }
            MessageBox.Show(s);
        }

        public static void Shuffle(Dictionary<string, string[]> q)
        {
            if (q.Count() == 0)
            {
                MessageBox.Show("There Is No Quiz Loaded");
            }
            else
            {

                questions = new Dictionary<string, string[]>();
                foreach (String key in q.Keys)
                {
                    string[] temp = new string[5];
                    int num = 0;

                    foreach (String item in q[key])
                    {
                        if (num >= 4)
                        {
                            temp[num] = item;
                            break;
                        }
                        else
                        {
                            temp[num] = item;
                            num++;
                        }
                    }
                    int n = temp.Length - 1;
                    for (int i = 0; i < n; i++)
                    {
                        int r = i + rng.Next(n - i);
                        string t = temp[r];
                        temp[r] = temp[i];
                        temp[i] = t;
                    }
                    questions.Add(key, temp);
                }

                questions = questions.OrderBy(x => rng.Next())
              .ToDictionary(item => item.Key, item => item.Value);
            }
        }
    }
}
