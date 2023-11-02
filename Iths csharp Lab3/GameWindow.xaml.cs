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

        private Question CurrentQuestion { get; set; }

        private int answeredQuestions = 0;

        private double correctAnsweredQuestions = 0;

        private double questionsInQuiz = 0;

        double percentage;


        public GameWindow()
        {
            InitializeComponent();

            MakeQuizBasedOnUserChoice();

            if (questionsInQuiz == 0)
            {
                MessageBox.Show("This was an empty quiz. Please add questions to it or choose another quiz.");
                return;               
            }

            LoadNextQuestion();

            this.DataContext = CurrentQuestion;
        }


        /// <summary>
        /// Initializes quiz based on user choice of categories or a specific quiz.
        /// </summary>
        private void MakeQuizBasedOnUserChoice()
        {
            if (HandleQuizzes.ListWithCurrentCategories.Count != 0)

            {
                HandleQuizzes.ListWithAllQuizzes.Clear();
                HandleQuizzes.ListWithAllQuizzes = HandleQuizzes.LoadQuiz();

                foreach (var category in HandleQuizzes.ListWithCurrentCategories)
                {
                    foreach (var quiz in HandleQuizzes.ListWithAllQuizzes)
                    {
                        if (quiz.Title == category)
                        {
                            foreach (var question in quiz.Questions)
                            {
                                HandleQuizzes.ListWithCurrentQuestions.Add(question);
                            }
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


        /// <summary>
        /// Sets question image based on image path
        /// </summary>
        /// <param name="imagePath">The path to the image file</param>
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


        /// <summary>
        /// Loads next question in the quiz
        /// </summary>
        private void LoadNextQuestion()
        {

            if (HandleQuizzes.ListWithCurrentQuestions.Count != 0)
            {

                CurrentQuestion = GetRandomQuestionFromList(HandleQuizzes.ListWithCurrentQuestions);


                if (CurrentQuestion.ImagePath != null)
                {
                    SetQuestionImage(CurrentQuestion.ImagePath);
                }

                this.DataContext = CurrentQuestion;

                RemoveQuestionFromList(CurrentQuestion);
            }

            else
            {
                MessageBox.Show($"Well done! You scored {correctAnsweredQuestions}/{answeredQuestions}!");
                correctAnsweredQuestions = 0;
                answeredQuestions = 0;
                HandleQuizzes.ListWithCurrentQuestions.Clear();
                HandleQuizzes.ListWithCurrentCategories.Clear();
                HandleQuizzes.SelectedQuiz = null;
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
        }


        /// <summary>
        /// Gets a random question from list with questions
        /// </summary>
        /// <param name="listWithQuestions">List with questions</param>
        /// <returns>Random question</returns>
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


        /// <summary>
        /// Click event for first answer button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Answer1Button_Click(object sender, RoutedEventArgs e)
        {
            answeredQuestions++;

            if (CurrentQuestion.CorrectAnswer == 0)
            {
                correctAnsweredQuestions++;

            }

            DisplayResult();
            LoadNextQuestion();

        }


        /// <summary>
        /// Click event for second answer button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Answer2Button_Click(object sender, RoutedEventArgs e)
        {
            answeredQuestions++;

            if (CurrentQuestion.CorrectAnswer == 1)
            {
                correctAnsweredQuestions++;

            }

            DisplayResult();
            LoadNextQuestion();

        }


        /// <summary>
        /// Click event for third answer button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Answer3Button_Click(object sender, RoutedEventArgs e)
        {
            answeredQuestions++;

            if (CurrentQuestion.CorrectAnswer == 2)
            {
                correctAnsweredQuestions++;

            }
           
            DisplayResult();
            LoadNextQuestion();

        }


        /// <summary>
        /// Displays current score and updates progress bar
        /// </summary>
        private void DisplayResult()
        {
            ShowScoreTB.Text = $"{correctAnsweredQuestions}/{answeredQuestions}";
            percentage = (correctAnsweredQuestions / answeredQuestions) * 100;
            ScoreTB.Text = $"{Math.Round(percentage, 2)}%";
            MadeQuestionProgressBar.Value += 100 / questionsInQuiz;
        }     


        /// <summary>
        /// Removes current question
        /// </summary>
        /// <param name="question">Current question</param>
        public void RemoveQuestionFromList(Question question)
        {
            HandleQuizzes.ListWithCurrentQuestions.Remove(question);
        }  


        /// <summary>
        /// Click event for the choose quiz window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChooseQuizWindow_Click(object sender, RoutedEventArgs e)
        {
            HandleQuizzes.ListWithCurrentQuestions.Clear();
            HandleQuizzes.ListWithCurrentCategories.Clear();
            ChooseQuizWindow chooseQuizWindow = new ChooseQuizWindow();
            chooseQuizWindow.Show();
            this.Close();
        }


        /// <summary>
        /// Click event for the main menu window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackToMainWindow_Click(object sender, RoutedEventArgs e)
        {
            HandleQuizzes.ListWithCurrentQuestions.Clear();
            HandleQuizzes.ListWithCurrentCategories.Clear();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
