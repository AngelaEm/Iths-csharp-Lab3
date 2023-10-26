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
            EditQuizCB.ItemsSource = AllQuizzes.ListWithAllQuizzes;                   
            
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
            ChangeQuestionTB.Text = currentQuestion.Statement;
            ChangeAnswer1TB.Text = currentQuestion.Answers[0];
            ChangeAnswer2TB.Text = currentQuestion.Answers[1];
            ChangeAnswer3TB.Text = currentQuestion.Answers[2];

           
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            
            MessageBox.Show(currentQuestion.Statement);
            MessageBox.Show(currentQuestion.Answers[0]);
            MessageBox.Show(currentQuestion.Answers[1]);
            MessageBox.Show(currentQuestion.Answers[2]);
        }
    }
}
