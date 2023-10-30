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

                        
            ChooseQuizCB.ItemsSource = HandleQuizzes.ListWithAllQuizzes;    
            

        }
        
        private void CategoryChecked(object sender, RoutedEventArgs e)
        {
            
            if (HandleQuizzes.ListWithCurrentCategories.Count != 0)
            {
                HandleQuizzes.ListWithCurrentCategories.Clear();
            }

            if (ProgrammingCB.IsChecked == true)
            {
                HandleQuizzes.ListWithCurrentCategories.Add("Programming");
            }
            if (MusicCB.IsChecked == true)
            {
                HandleQuizzes.ListWithCurrentCategories.Add("Music");
            }
            if (NatureCB.IsChecked == true)
            {
                HandleQuizzes.ListWithCurrentCategories.Add("Nature");
            }
            if (MathematicsCB.IsChecked == true)
            {
                HandleQuizzes.ListWithCurrentCategories.Add("Mathematics");
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
            if (HandleQuizzes.ListWithCurrentCategories != null)
            {
                if (ProgrammingCB.IsChecked == false)
                {
                    HandleQuizzes.ListWithCurrentCategories.Remove("Programming");
                }
                if (MusicCB.IsChecked == false)
                {
                    HandleQuizzes.ListWithCurrentCategories.Remove("Music");
                }
                if (NatureCB.IsChecked == false)
                {
                    HandleQuizzes.ListWithCurrentCategories.Remove("Nature");
                }
                if (MathematicsCB.IsChecked == false)
                {
                    HandleQuizzes.ListWithCurrentCategories.Remove("Mathematics");
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
                HandleQuizzes.SelectedQuiz = selectedQuiz;               
            }          
        }

        private void ResetChoices()
        {
            HandleQuizzes.ListWithCurrentCategories.Clear();
            ChooseQuizCB.SelectedItem = null;
            ProgrammingCB.IsChecked = false;
            MusicCB.IsChecked = false;
            NatureCB.IsChecked = false;
            MathematicsCB.IsChecked = false;
        }


        /// <summary> 
        /// Click event for the GoToGame button. Opens the Game window and closes current window. If user selected a quiz 
        /// it sets the GameWindows selectedQuiz to this. Else it sets Game windows selectedCategories to this.
        /// </summary>
        /// <param name="sender">The button that initiated the click event</param>
        /// <param name="e">Event arguments</param>
        private void GoToGameWindow_Click(object sender, RoutedEventArgs e)
        {
            if ((ChooseQuizCB.SelectedItem != null && HandleQuizzes.ListWithCurrentCategories.Count != 0) || (ChooseQuizCB.SelectedItem == null && HandleQuizzes.ListWithCurrentCategories.Count == 0))
            {
                MessageBox.Show("Please choose quiz or categories!");

                ResetChoices();
                
                
                return;
            }

            GameWindow gameWindow = new GameWindow();
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
