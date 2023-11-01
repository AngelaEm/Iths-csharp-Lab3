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


namespace Iths_csharp_Lab3
{
    // <summary>
    // Interaction logic for AddQuizWindow.xaml
    // </summary>
    public partial class AddQuizWindow : Window
    {
        public Quiz currentQuiz { get; set; } = new Quiz();

        public AddQuizWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Clears textboxes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text.Contains("Enter") || textBox.Text.Contains("Answer"))
            {
                textBox.Text = "";
                textBox.Foreground = Brushes.Black;
            }
        }
    

        /// <summary>
        /// Add question to current quiz and save updated quiz to textfile.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddQuestion_Click(object sender, RoutedEventArgs e)
        {
            
            string statement = AddQuestionTB.Text;
            string[] answers = new string[] { Answer1TB.Text, Answer2TB.Text, Answer3TB.Text };
            string imagePath = ImageTB.Text;

            int correct = -1;

            List<string> placeholders = new List<string>

            { "Enter quizname here", "Enter question here", "Answer 1", "Answer 2", "Answer 3" };


            if (string.IsNullOrEmpty(statement) || placeholders.Contains(statement) || answers.Any(answer => string.IsNullOrWhiteSpace(answer) || placeholders.Contains(answer)))
            {
                MessageBox.Show("Please enter text in all fields!");
                return;
            }
            if (Answer1RB.IsChecked == true)
            {
                correct = 0;
            }
            else if (Answer2RB.IsChecked == true)
            {
                correct = 1;
            }
            else if (Answer3RB.IsChecked == true)
            {
                correct = 2;
            }

            if (correct == -1)
            {
                MessageBox.Show("Please choose correct answer!");
                return;
            }

            currentQuiz.AddQuestion(statement, correct, imagePath, answers);
            
            HandleQuizzes.SaveQuizzesToFile(HandleQuizzes.ListWithAllQuizzes);

            MessageBox.Show($"Question successfully added!");
           
            AddQuestionTB.Text = string.Empty;
            ImageTB.Text = "\\Images\\questionmark.png";
            Answer1TB.Text = string.Empty;
            Answer2TB.Text = string.Empty;
            Answer3TB.Text = string.Empty;
            Answer1RB.IsChecked = false;
            Answer2RB.IsChecked = false;
            Answer3RB.IsChecked = false;

        }


        /// <summary>
        /// Checks if quiz already exists, if it has a title and if it has at least one question and then add quiz to list with all quizzes and save this list to textfile.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddQuiz_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();

            bool quizExist = false;

            foreach (var quiz in HandleQuizzes.ListWithAllQuizzes)
            {
                if (quiz.Title == QuizNameTB.Text)
                {
                    currentQuiz = quiz;
                    quizExist = true;
                    break;
                }
            }

            if (quizExist)
            {
                MessageBox.Show($"Quiz already exists. Please add another question or press another button.");
                return;
                
            }

            if (string.IsNullOrEmpty(QuizNameTB.Text))
            {
                MessageBox.Show($"Please add a name!");
                return;
            }

            if (currentQuiz.Questions.Count == 0)
            {
                MessageBox.Show($"Please add at least one question!");
                return;
            }

            currentQuiz.Title = QuizNameTB.Text;

            HandleQuizzes.ListWithAllQuizzes.Add(currentQuiz);
            HandleQuizzes.SaveQuizzesToFile(HandleQuizzes.ListWithAllQuizzes);
            MessageBox.Show($"Quiz added with title: {currentQuiz.Title}");
            mainWindow.Show();
            this.Close();

        }


        /// <summary>
        /// Checks if QuizTitle written in QuisNameTB exist in ListWithAllQuizzes and print message that question will be added in existing quiz.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QuizNameTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            foreach (var quizz in HandleQuizzes.ListWithAllQuizzes)
            {
                if (QuizNameTB.Text == quizz.Title)
                {                   
                    MessageBox.Show($"Your questions will be added to the already existing quiz {quizz.Title}!");
                    break;
                }
            }
        }


        /// <summary>
        /// Click event go to choose quiz window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoToChooseQuiz_Click(object sender, RoutedEventArgs e)
        {
            ChooseQuizWindow chooseQuizWindow = new ChooseQuizWindow();
            chooseQuizWindow.Show();
            this.Close();
        }


        /// <summary>
        /// Click event to edit quiz window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditQuizWindow_Click(object sender, RoutedEventArgs e)
        {
            EditQuizWindow editQuizWindow = new EditQuizWindow();
            editQuizWindow.Show();
            this.Close();
        }
    }
}
