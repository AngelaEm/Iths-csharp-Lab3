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
using Iths_csharp_Lab3.Models;

namespace Iths_csharp_Lab3
{
    /// <summary>
    /// Interaction logic for EditQuizWindow.xaml
    /// </summary>
    public partial class EditQuizWindow : Window
    {
        Quiz currentQuiz = null;

        Question currentQuestion = null;

        public EditQuizWindow()
        {
            InitializeComponent();
            this.DataContext = currentQuiz;
            this.DataContext = currentQuestion;
            EditQuizCB.ItemsSource = HandleQuizzes.ListWithAllQuizzes;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void EditQuizCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (EditQuizCB.SelectedItem is Quiz selectedQuiz)
            {

                currentQuiz = selectedQuiz;
                this.DataContext = currentQuiz;

            }

            QuestionLB.ItemsSource = currentQuiz.Questions;

        }

        private void QuestionLB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (QuestionLB.SelectedItem is Question selectedQuestion)
            {

                currentQuestion = selectedQuestion;
                this.DataContext = currentQuestion;
            }

            SetFields();

        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {

            int correct = -1;


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

            currentQuestion.CorrectAnswer = correct;

            if (correct == -1)
            {
                MessageBox.Show("Please choose correct answer!");
                return;
            }

            HandleQuizzes.SaveQuizzesToFile(HandleQuizzes.ListWithAllQuizzes);

            MessageBox.Show("Sucessfully saved to quiz!");
        }

        private void ResetFields()
        {
            ChangeQuestionTB.Text = "";
            ChangeAnswer1TB.Text = "";
            ChangeAnswer2TB.Text = "";
            ChangeAnswer3TB.Text = "";
            Answer1RB.IsChecked = false;
            Answer2RB.IsChecked = false;
            Answer3RB.IsChecked = false;
        }

        private void SetFields()
        {
            ChangeQuestionTB.Text = currentQuestion.Statement;
            ChangeAnswer1TB.Text = currentQuestion.Answers[0];
            ChangeAnswer2TB.Text = currentQuestion.Answers[1];
            ChangeAnswer3TB.Text = currentQuestion.Answers[2];

            if (currentQuestion.CorrectAnswer == 0)
            {
                Answer1RB.IsChecked = true;
            }
            else if (currentQuestion.CorrectAnswer == 1)
            {
                Answer2RB.IsChecked = true;
            }
            else if (currentQuestion.CorrectAnswer == 2)
            {
                Answer3RB.IsChecked = true;
            }
        }

        private void GoToChooseQuiz_Click(object sender, RoutedEventArgs e)
        {
            ChooseQuizWindow chooseQuizWindow = new ChooseQuizWindow();
            chooseQuizWindow.Show();
            this.Close();
        }

        private void RemoveQuestionButton_Click(object sender, RoutedEventArgs e)
        {
            currentQuiz.Questions.Remove(currentQuestion);
            ResetFields();
            HandleQuizzes.SaveQuizzesToFile(HandleQuizzes.ListWithAllQuizzes);
            MessageBox.Show("Successfully removed from quiz");
            EditQuizWindow editQuizWindow = new EditQuizWindow();
            editQuizWindow.Show();
            this.Close();
            
        }

        private void AddQuestionButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentQuiz == null)
            {
                MessageBox.Show("Please select a quiz!");
            }

            else
            {
                AddQuizWindow addQuizWindow = new AddQuizWindow();
                addQuizWindow.currentQuiz = currentQuiz;
                addQuizWindow.QuizNameTB.Text = currentQuiz.Title;
                addQuizWindow.Show();
                this.Close();
            }
            
        }
    }
}
