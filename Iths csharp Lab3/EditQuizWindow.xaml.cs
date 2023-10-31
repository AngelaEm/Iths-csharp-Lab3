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


        /// <summary>
        /// Check if selected item in combobox is selected quiz and sets current quiz to selected quiz and its questions to itemsource in listbox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditQuizCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (EditQuizCB.SelectedItem is Quiz selectedQuiz)
            {
                currentQuiz = selectedQuiz;
                this.DataContext = currentQuiz;
            }

            QuestionLB.ItemsSource = currentQuiz.Questions;
        }


        /// <summary>
        /// Check if selected item in listbox is selected question and sets current question to selected question and set fields and radiobuttons with question content.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QuestionLB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (QuestionLB.SelectedItem is Question selectedQuestion)
            {
                currentQuestion = selectedQuestion;
                this.DataContext = currentQuestion;
            }

            SetRadiobuttons();

        }


        /// <summary>
        /// Checks radiobuttons and set correct answer to the selected radiobutton and save updated quiz to file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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


        /// <summary>
        /// Clears all question fields
        /// </summary>
        private void ResetFields()
        {
            ChangeQuestionTB.Text = string.Empty;
            ChangeAnswer1TB.Text = string.Empty;
            ChangeAnswer2TB.Text = string.Empty;
            ChangeAnswer3TB.Text = string.Empty;
            Answer1RB.IsChecked = false;
            Answer2RB.IsChecked = false;
            Answer3RB.IsChecked = false;
        }

 
        /// <summary>
        /// Sets radiobuttons so that correct answer is marked from start when you edit question
        /// </summary>
        private void SetRadiobuttons()
        {       
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

       
        /// <summary>
        /// Click event that remove current question and reset all fields and save quizzes to file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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


        /// <summary>
        /// Click event that sets CuizTitle to current quiz title in add quiz window and opets add quiz window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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


        /// <summary>
        /// Click event for the main window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }


        /// <summary>
        /// Click event for the choose quiz window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoToChooseQuiz_Click(object sender, RoutedEventArgs e)
        {
            ChooseQuizWindow chooseQuizWindow = new ChooseQuizWindow();
            chooseQuizWindow.Show();
            this.Close();
        }
    }
}
