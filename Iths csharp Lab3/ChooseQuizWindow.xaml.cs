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
      

        public ChooseQuizWindow()
        {
            InitializeComponent();
            AllQuizzes.LoadQuizzesIntoComboBox(ChooseQuizCB);
        }


        /// <summary>
        /// Event handler for checkbox checked events. Clears the SelectedCategories list and then adds categories based 
        /// on which checkboxes are checked.
        /// </summary>
        /// <param name="sender">The checkbox that initiated the event</param>
        /// <param name="e">Event arguments</param>
        private void CategoryChecked(object sender, RoutedEventArgs e)
        {
            if (AllQuizzes.SelectedCategories != null)
            {
                AllQuizzes.SelectedCategories.Clear();

            }

            if (ProgrammingCB.IsChecked == true)
            {
                AllQuizzes.SelectedCategories.Add("Programming");
            }
            if (MusicCB.IsChecked == true)
            {
                AllQuizzes.SelectedCategories.Add("Music");
            }
            if (NatureCB.IsChecked == true)
            {
                AllQuizzes.SelectedCategories.Add("Nature");
            }
            if (MathematicsCB.IsChecked == true)
            {
                AllQuizzes.SelectedCategories.Add("Mathematics");
            }
            if (MixedQuestionsCB.IsChecked == true)
            {
                AllQuizzes.SelectedCategories.Add("Mixed Questions");
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
            if (AllQuizzes.SelectedCategories != null)
            {
                if (ProgrammingCB.IsChecked == false)
                {
                    AllQuizzes.SelectedCategories.Remove("Programming");
                }
                if (MusicCB.IsChecked == false)
                {
                    AllQuizzes.SelectedCategories.Remove("Music");
                }
                if (NatureCB.IsChecked == false)
                {
                    AllQuizzes.SelectedCategories.Remove("Nature");
                }
                if (MathematicsCB.IsChecked == false)
                {
                    AllQuizzes.SelectedCategories.Remove("Mathematics");
                }
                if (MixedQuestionsCB.IsChecked == false)
                {
                    AllQuizzes.SelectedCategories.Remove("Mixed Questions");
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
            if (ChooseQuizCB.SelectedItem != null)
            {
                string selectedTitle = ChooseQuizCB.SelectedItem.ToString();

                Quiz selectedQuiz = null;

                foreach (var quiz in AllQuizzes.ListWithAllQuizzes)
                {
                    if (quiz.Title == selectedTitle)
                    {
                        selectedQuiz = quiz;
                        break;
                    }
                }

                if (selectedQuiz != null)
                {
                    AllQuizzes.SelectedQuiz = selectedQuiz;
                }
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
            GameWindow gameWindow = new GameWindow();

            if (AllQuizzes.SelectedQuiz != null)
            {
                gameWindow.SelectedQuiz = AllQuizzes.SelectedQuiz;
            }
            else
            {
                gameWindow.SelectedCategories = AllQuizzes.SelectedCategories;
            }

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
