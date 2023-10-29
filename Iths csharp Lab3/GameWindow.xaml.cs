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

        private Question currentQuestion = null;

        private int answeredQuestions = 0;

        private double correctAnsweredQuestions = 0;

        private double questionsInQuiz = 0;

        double percentage;


        public GameWindow()
        {
            InitializeComponent();

            
            if (HandleQuizzes.ListWithCurrentCategories.Count != 0)

            {
                foreach (var question in HandleQuizzes.LoadQuestions())
                {
                    foreach (var category in HandleQuizzes.ListWithCurrentCategories)
                    {
                        if (question.Category == category)
                        {
                            HandleQuizzes.ListWithCurrentQuestions.Add(question);
                        }
                    }                 
                }
                while (HandleQuizzes.ListWithCurrentQuestions.Count > 10)
                {
                    HandleQuizzes.ListWithCurrentQuestions.Remove(GetRandomQuestionFromList(HandleQuizzes.ListWithCurrentQuestions));
                }
            }
            else
            {
                

                foreach (var question in HandleQuizzes.SelectedQuiz.Questions)
                {
                    HandleQuizzes.ListWithCurrentQuestions.Add(question);
                }              
            }

            questionsInQuiz = HandleQuizzes.ListWithCurrentQuestions.Count;

            SetQuestionImage("\\Images\\questionmark.png");
            
        }
            

        private void Question_Click(object sender, RoutedEventArgs e)
        {
            QuestionButton.Content = "Score";
                     
            LoadNextQuestion();
        }


        private void Answer1Button_Click(object sender, RoutedEventArgs e)
        {
            answeredQuestions++;

            if (currentQuestion.CorrectAnswer == 0)
            {
                correctAnsweredQuestions++;

            }

            DisplayResult();
            LoadNextQuestion();

        }

        private void Answer2Button_Click(object sender, RoutedEventArgs e)
        {
            answeredQuestions++;

            if (currentQuestion.CorrectAnswer == 1)
            {
                correctAnsweredQuestions++;

            }

            DisplayResult();
            LoadNextQuestion();

        }

        private void Answer3Button_Click(object sender, RoutedEventArgs e)
        {
            answeredQuestions++;

            if (currentQuestion.CorrectAnswer == 2)
            {
                correctAnsweredQuestions++;

            }
           
            DisplayResult();
            LoadNextQuestion();

        }

      

        private void DisplayResult()
        {
            QuestionButton.Content = $"{correctAnsweredQuestions}/{answeredQuestions}";
            percentage = (correctAnsweredQuestions / answeredQuestions) * 100;
            ScoreTB.Text = $"{Math.Round(percentage, 2)}%";
            MadeQuestionProgressBar.Value += 100 / questionsInQuiz;
        }
       

        private void LoadNextQuestion()
        {

            if (HandleQuizzes.ListWithCurrentQuestions.Count != 0)
            {

                currentQuestion = GetRandomQuestionFromList(HandleQuizzes.ListWithCurrentQuestions);

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
                MessageBox.Show($"Well done! You scored {correctAnsweredQuestions}/{answeredQuestions}!");
                correctAnsweredQuestions = 0;
                answeredQuestions = 0;
                HandleQuizzes.ListWithCurrentQuestions.Clear();
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
        }

        public void RemoveQuestionFromList(Question question)
        {
            HandleQuizzes.ListWithCurrentQuestions.Remove(question);
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
            HandleQuizzes.ListWithCurrentQuestions.Clear();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();

        }           
    }
}
