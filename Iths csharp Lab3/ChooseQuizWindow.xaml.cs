using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Reflection.Metadata;

namespace Iths_csharp_Lab3
{
    /// <summary>
    /// Interaction logic for ChooseQuizWindow.xaml
    /// </summary>
    public partial class ChooseQuizWindow : Window
    {
        private List<string> selectedCategories = new List<string>();

        private List<Question> currentList = new List<Question>();

        private Quiz newQuiz = new Quiz();


        public ChooseQuizWindow()
        {
            InitializeComponent();
           
            ChooseQuizCB.ItemsSource = AllQuizzes.ListWithAllQuizzes;
            
        }


        /// <summary>
        /// Event handler for checkbox checked events. Clears the SelectedCategories list and then adds categories based 
        /// on which checkboxes are checked.
        /// </summary>
        /// <param name="sender">The checkbox that initiated the event</param>
        /// <param name="e">Event arguments</param>
        private void CategoryChecked(object sender, RoutedEventArgs e)
        {
            if (selectedCategories != null)
            {
                selectedCategories.Clear();
            }

            if (ProgrammingCB.IsChecked == true)
            {
                selectedCategories.Add("Programming");
            }
            if (MusicCB.IsChecked == true)
            {
                selectedCategories.Add("Music");
            }
            if (NatureCB.IsChecked == true)
            {
                selectedCategories.Add("Nature");
            }
            if (MathematicsCB.IsChecked == true)
            {
                selectedCategories.Add("Mathematics");
            }
            if (MixedQuestionsCB.IsChecked == true)
            {
                selectedCategories.Add("Mixed Questions");
            }

        }


        /// <summary>
        /// Event handler for checkbox unchecked events. Clears category in the SelectedCategories list based 
        /// on which checkboxes that are unchecked.
        /// </summary>
        /// <param name="sender">The checkbox that initiated the event</param>
        /// <param name="e">Event arguments</param>
        private void CategoryUnchecked(object sender, RoutedEventArgs e)
        {
            if (selectedCategories != null)
            {
                if (ProgrammingCB.IsChecked == false)
                {
                    selectedCategories.Remove("Programming");
                }
                if (MusicCB.IsChecked == false)
                {
                    selectedCategories.Remove("Music");
                }
                if (NatureCB.IsChecked == false)
                {
                    selectedCategories.Remove("Nature");
                }
                if (MathematicsCB.IsChecked == false)
                {
                    selectedCategories.Remove("Mathematics");
                }
                if (MixedQuestionsCB.IsChecked == false)
                {
                    selectedCategories.Remove("Mixed Questions");
                }
            }
        }


        /// <summary>
        /// Event handler for combobox. Select quiz based on which quiz that is selected.
        /// </summary>
        /// <param name="sender">The combobox that initiated the event</param>
        /// <param name="e">Event arguments</param>
        private void ChooseQuizCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ChooseQuizCB.SelectedItem is Quiz selectedQuiz)
            {
                AllQuizzes.SelectedQuiz = selectedQuiz;
              
            }           
        }


        /// <summary> 
        /// Click event for the GoToGame button. Opens the Game window and closes current window. If user selected a quiz 
        /// it sets the GameWindows selectedQuiz to this. Else it sets Game windows selectedCategories to this.
        /// </summary>
        /// <param name="sender">The button that initiated the click event</param>
        /// <param name="e">Event arguments</param>
        private void GoToGameWindow_Click(object sender, RoutedEventArgs e)
        {
            if (AllQuizzes.SelectedQuiz != null && selectedCategories != null)
            {
                MessageBox.Show("Please choose quiz or categories!");
                selectedCategories.Clear();

                return;
            }
            GameWindow gameWindow = new GameWindow();

            newQuiz.GenerateQuestions();
            
            if (AllQuizzes.SelectedQuiz != null)
            {
                gameWindow.SelectedQuiz = AllQuizzes.SelectedQuiz;
                
            }

            else
            {
               
                if (selectedCategories.Contains("Mixed Questions"))
                {
                    foreach (var question in newQuiz.Questions)
                    {
                        currentList.Add(question);
                    }

                }
                else
                {
                    foreach (var category in selectedCategories)
                    {
                        foreach (var question in newQuiz.Questions)
                        {
                            if (question.Category == category)
                            {
                                currentList.Add(question);
                            }
                        }
                    }
                }
            }

            gameWindow.currentList = currentList;

            gameWindow.Show();
            this.Close();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        
    }
}
