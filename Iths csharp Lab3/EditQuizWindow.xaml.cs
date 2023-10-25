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
            AllQuizzes.LoadQuizzesIntoComboBox(EditQuizCB);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void EditQuizCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            

            if (EditQuizCB.SelectedItem != null)
            {
                string selectedTitle = EditQuizCB.SelectedItem.ToString();

                foreach (var quizz in AllQuizzes.ListWithAllQuizzes)
                {
                    if (quizz.Title == selectedTitle)
                    {
                        currentQuiz = quizz;
                        break;
                    }
                }

                if (currentQuiz != null)
                {
                    AllQuizzes.SelectedQuiz = currentQuiz;
                }
            }

            AllQuizzes.LoadQuestionsIntoListBox(QuestionLB);
            

        }

        private void QuestionLB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (QuestionLB.SelectedItem != null)
            {
                string selectedStatement = QuestionLB.SelectedItem.ToString();

                foreach (var question in currentQuiz.Questions)
                {
                    if (question.Statement == selectedStatement)
                    {
                        currentQuestion = question;
                        break;
                    }
                }               
            }
            ChangeQuestionTB.Text = currentQuestion.Statement;
            ChangeAnswer1TB.Text = currentQuestion.Answers[0];
            ChangeAnswer2TB.Text = currentQuestion.Answers[1];
            ChangeAnswer3TB.Text = currentQuestion.Answers[2];

            if (true)
            {

            }
        }
    }
}
