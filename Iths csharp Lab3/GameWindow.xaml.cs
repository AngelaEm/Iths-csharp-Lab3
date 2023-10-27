using Iths_csharp_Lab3.Models;
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
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.Linq;


namespace Iths_csharp_Lab3
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        
        Question currentQuestion;

        Quiz currentQuiz = new Quiz();

        public List<Question> currentList = new List<Question>();

        public Quiz SelectedQuiz { get; set; }

        private int answeredQuestions = 0;

        private double corrextAnsweredQuestions = 0;

        private double questionsInQuiz = 0;

        double percentage;


        public GameWindow()
        {
            InitializeComponent();

            SetQuestionImage("\\Images\\questionmark.png");
            
        }
            

        private void Question_Click(object sender, RoutedEventArgs e)
        {
            QuestionButton.Content = "Score";
            

            if (SelectedQuiz != null)
            {
                currentQuiz = SelectedQuiz;
                foreach (var question in currentQuiz.Questions)
                {
                    currentList.Add(question);
                }
            }         

            questionsInQuiz = currentList.Count;
            LoadNextQuestion();
        }



        private void Answer1Button_Click(object sender, RoutedEventArgs e)
        {
            answeredQuestions++;

            if (currentQuestion.CorrectAnswer == 0)
            {
                corrextAnsweredQuestions++;

            }

            DisplayResult();
            LoadNextQuestion();

        }

        private void Answer2Button_Click(object sender, RoutedEventArgs e)
        {
            answeredQuestions++;

            if (currentQuestion.CorrectAnswer == 1)
            {
                corrextAnsweredQuestions++;

            }

            DisplayResult();
            LoadNextQuestion();

        }

        private void Answer3Button_Click(object sender, RoutedEventArgs e)
        {
            answeredQuestions++;

            if (currentQuestion.CorrectAnswer == 2)
            {
                corrextAnsweredQuestions++;

            }
           
            DisplayResult();
            LoadNextQuestion();

        }

      

        private void DisplayResult()
        {
            QuestionButton.Content = $"{corrextAnsweredQuestions}/{answeredQuestions}";
            percentage = (corrextAnsweredQuestions / answeredQuestions) * 100;
            ScoreTB.Text = $"{Math.Round(percentage, 2)}%";
            MadeQuestionProgressBar.Value += 100 / questionsInQuiz;
        }
       

        private void LoadNextQuestion()
        {

            if (currentQuiz != null && currentList.Count != 0)
            {

                currentQuestion = GetRandomQuestionFromList(currentList);

                if (currentQuestion.ImagePath != null)
                {
                    SetQuestionImage(currentQuestion.ImagePath);
                }

                QuestionTB.Text = currentQuestion.Statement;

                Answer1Button.Content = currentQuestion.Answers[0];
                Answer2Button.Content = currentQuestion.Answers[1];
                Answer3Button.Content = currentQuestion.Answers[2];

                RemoveQuestionFromList(currentQuestion);
            }

            else
            {


                MessageBox.Show($"Well done! You scored {corrextAnsweredQuestions}/{answeredQuestions}!");
                corrextAnsweredQuestions = 0;
                answeredQuestions = 0;
               
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
        }

        public void RemoveQuestionFromList(Question question)
        {
            currentList.Remove(question);
        }

        public Question GetRandomQuestionFromList(List<Question> listWithQuestions)
        {
            if (listWithQuestions.Count != 0)
            {
                Random random = new Random();
                int randomIndex = random.Next(0, listWithQuestions.Count);
                return listWithQuestions[randomIndex];
            }

            return null;
 
        }

        private void SetQuestionImage(string imagePath)
        {
            try
                {
                    BitmapImage image = new BitmapImage();
                    image.BeginInit();
                    image.UriSource = new Uri(imagePath, UriKind.RelativeOrAbsolute);

                    if (imagePath.StartsWith("http://") || imagePath.StartsWith("https://"))
                    {
                        image.CacheOption = BitmapCacheOption.OnLoad;
                    }

                    image.EndInit();
                    QuestionImage.Source = image;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Det gick inte att ladda bilden: {ex.Message}");
                }
            
        }


        private void BackToMainWindow_Click(object sender, RoutedEventArgs e)
        {
            
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();

        }
    }
}
