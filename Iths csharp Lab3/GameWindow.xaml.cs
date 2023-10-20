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

namespace Iths_csharp_Lab3
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        
        Question currentQuestion = null;
        Quiz currentQuiz = new Quiz();
        


        public GameWindow()
        {
            InitializeComponent();
            
            currentQuiz = GenerateQuiz("Programming", "Mathematics");
        }

        private void Question_Click(object sender, RoutedEventArgs e)
        {
            LoadNextQuestion();
            


        }

        private void Answer1Button_Click(object sender, RoutedEventArgs e)
        {
            if (currentQuestion != null && currentQuestion.CorrectAnswer == 0)
            {
                MadeQuestionProgressBar.Value += 10;
            }
            
            LoadNextQuestion();
            

        }

        private void Answer2Button_Click(object sender, RoutedEventArgs e)
        {
            if (currentQuestion != null && currentQuestion.CorrectAnswer == 1)
            {
                
                MadeQuestionProgressBar.Value += 10;
            }
            
            LoadNextQuestion();
            
        }

        private void Answer3Button_Click(object sender, RoutedEventArgs e)
        {
            if (currentQuestion != null && currentQuestion.CorrectAnswer == 2)
            {
               
                MadeQuestionProgressBar.Value += 10;
            }
           
            LoadNextQuestion();
            
        }

        private void BackToMainWindow_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();

        }

        private Quiz GenerateQuiz(params string[] categories)
        {
            currentQuiz.GenerateQuestions();

            Quiz newQuiz = null;

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

                        newQuiz.AddToQuiz(question);

                    }
                }
            }
            
            return newQuiz;
        }

        private async void LoadNextQuestion()
        {
            if (currentQuiz != null && currentQuiz.Questions.Any())
            {
                currentQuestion = (currentQuiz.GetRandomQuestion());

                QuestionTB.Text = currentQuestion.Statement;

                Answer1Button.Content = currentQuestion.Answers[0];
                Answer2Button.Content = currentQuestion.Answers[1];
                Answer3Button.Content = currentQuestion.Answers[2];

                currentQuiz.RemoveQuestion(currentQuestion);
            }
 
            else
            {
                MessageBox.Show("Game is over");
            }
            
        }     

    }
}
