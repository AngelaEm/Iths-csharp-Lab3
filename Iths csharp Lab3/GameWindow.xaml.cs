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
            currentQuiz.GenerateFolderAndTextFile();
        }

        private void Question_Click(object sender, RoutedEventArgs e)
        {
            currentQuestion = (currentQuiz.GetRandomQuestion());
            QuestionTB.Text = currentQuestion.Statement;

            Answer1Button.Content = currentQuestion.Answers[0];
            Answer2Button.Content = currentQuestion.Answers[1];
            Answer3Button.Content = currentQuestion.Answers[2];


        }

        private void Answer1Button_Click(object sender, RoutedEventArgs e)
        {
            if (currentQuestion != null && currentQuestion.CorrectAnswer == 0)
            {
                MessageBox.Show("Correct answer!");
            }
            else
            {
                MessageBox.Show("Wrong answer!");
            }

        }

        private void Answer2Button_Click(object sender, RoutedEventArgs e)
        {
            if (currentQuestion != null && currentQuestion.CorrectAnswer == 1)
            {
                MessageBox.Show("Correct answer!");
            }
            else
            {
                MessageBox.Show("Wrong answer!");
            }

        }

        private void Answer3Button_Click(object sender, RoutedEventArgs e)
        {
            if (currentQuestion != null && currentQuestion.CorrectAnswer == 2)
            {
                MessageBox.Show("Correct answer!");
            }
            else
            {
                MessageBox.Show("Wrong answer!");
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
