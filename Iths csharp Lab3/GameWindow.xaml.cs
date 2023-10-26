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
        
        Question currentQuestion = null;

        Quiz currentQuiz = new Quiz();


        public List<string> SelectedCategories { get; set; }

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
            }
            else if (SelectedCategories != null && SelectedCategories.Count > 0)
            {         
               
                currentQuiz = GenerateQuiz(SelectedCategories);           
            }
            else
            {             
                MessageBox.Show("Please select a quiz or categories to proceed.");
                return;
            }

            questionsInQuiz = currentQuiz.Questions.Count();
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

       

        private Quiz GenerateQuiz(List<string> categories)
        {
            Quiz newQuiz = null;

            currentQuiz.GenerateQuestions();
         

            if (categories.Contains("Mixed Questions"))
            {
                newQuiz = new Quiz();

                for (int i = 0; i < 5; i++)
                {
                    newQuiz.AddToQuiz(currentQuiz.GetRandomQuestion());
                }

            }
            else
            {

                foreach (var category in categories)
                {
                    foreach (var question in currentQuiz.Questions)
                    {
                        if (question.Category == category)
                        {
                            if (newQuiz == null)
                            {
                                newQuiz = new Quiz();

                            }
                            else if (newQuiz.Questions.Count() < 5)
                            {
                                newQuiz.AddToQuiz(question);
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }
            }
            
            

            return newQuiz;
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
            if (currentQuiz != null && currentQuiz.Questions.Any())
            {
                
                currentQuestion = (currentQuiz.GetRandomQuestion());

                if (currentQuestion.ImagePath != null)
                {
                    SetQuestionImage(currentQuestion.ImagePath);
                }

                QuestionTB.Text = currentQuestion.Statement;

                Answer1Button.Content = currentQuestion.Answers[0];
                Answer2Button.Content = currentQuestion.Answers[1];
                Answer3Button.Content = currentQuestion.Answers[2];

                currentQuiz.RemoveQuestion(currentQuestion);
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
