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
    /// <summary>
    /// Interaction logic for AddQuizWindow.xaml
    /// </summary>
    public partial class AddQuizWindow : Window
    {
        Quiz currentQuiz = new Quiz();
       
        public AddQuizWindow()
        {
            InitializeComponent();
            
        }

      
        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text.Contains("Enter") || textBox.Text.Contains("Answer"))
            {
                textBox.Text = "";
                textBox.Foreground = Brushes.Black;
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = "";
                
            }
        }


        private void AddQuiz_Click(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrEmpty(QuizNameTB.Text))
            {
                MessageBox.Show($"Please add a name!");
                return;
            }

            if (currentQuiz.Questions.Count() == 0)
            {
                MessageBox.Show($"Please add at least one question!");
                return;
            }

            bool quizExists = false;

            foreach (var quizz in AllQuizzes.ListWithAllQuizzes)
            {
                if (currentQuiz.Title == quizz.Title)
                {
                    quizExists = true;
                    break;
                }
            }

            if (quizExists)
            {
                MessageBox.Show($"Quiz already exits.");
            }
            else
            {
                currentQuiz.Title = QuizNameTB.Text;
                AllQuizzes.ListWithAllQuizzes.Add(currentQuiz);
                MessageBox.Show($"Quiz added with title: {currentQuiz.Title}");
                ChooseQuizWindow choosequizWindow = new ChooseQuizWindow();
                choosequizWindow.Show();
                this.Close();
            }    
        }

        private void GoToChooseQuiz_Click(object sender, RoutedEventArgs e)
        {
            ChooseQuizWindow chooseQuizWindow = new ChooseQuizWindow();
            chooseQuizWindow.Show();
            this.Close();
        }

        private void AddQuestion_Click(object sender, RoutedEventArgs e)
        {
            string category = CategoryNameTB.Text;
            string statement = AddQuestionTB.Text;
            string[] answers = new string[] { Answer1TB.Text, Answer2TB.Text, Answer3TB.Text };
            string imagePath = ImageTB.Text;

            int correct = -1;

            List<string> placeholders = new List<string>

            { "Enter quizname here", "Enter category here", "Enter question here", "Answer 1", "Answer 2", "Answer 3" };
    

            if (string.IsNullOrEmpty(category) || placeholders.Contains(category) || string.IsNullOrEmpty(statement) || placeholders.Contains(statement) || answers.Any(answer => string.IsNullOrWhiteSpace(answer) || placeholders.Contains(answer)))
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
                
            

            currentQuiz.AddQuestion(category, statement, correct, imagePath, answers);

            MessageBox.Show($"Question added with {category}, {statement}, {answers[0]}, {answers[1]}, {answers[2]}");

            CategoryNameTB.Text = string.Empty;
            AddQuestionTB.Text = string.Empty;
            ImageTB.Text = string.Empty;
            Answer1TB.Text = string.Empty;
            Answer2TB.Text = string.Empty;
            Answer3TB.Text = string.Empty;
            Answer1RB.IsChecked = false;
            Answer2RB.IsChecked=false;
            Answer3RB.IsChecked=false;


        }
        

    }
}
