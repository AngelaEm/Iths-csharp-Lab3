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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Collections.ObjectModel;


namespace Iths_csharp_Lab3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Quiz newQuiz = new Quiz();

        public MainWindow()
        {
            InitializeComponent();
            
            newQuiz.GenerateFolderAndTextFile();
           
            
        }

       /// <summary>
       /// Click event for the GoToGame button. Opens GameWindow and closes current window.
       /// </summary>
       /// <param name="sender">The button that initiated the click event</param>
       /// <param name="e">Event arguments</param>
        private void GoToGameWindow_Click_1(object sender, RoutedEventArgs e)
        {
            ChooseQuizWindow chooseQuizWindow = new ChooseQuizWindow();
            chooseQuizWindow.Show();
            this.Close();
        }
      
        /// <summary>
        /// Click event for the GoToAddQuiz button. Opens AddQuizWindow and closes current window
        /// </summary>
        /// <param name="sender">The button that initiated the click event</param>
        /// <param name="e">Event arguments</param>
        private void GoToAddQuizWindow_Click(object sender, RoutedEventArgs e)
        {
            AddQuizWindow addQuizWindow = new AddQuizWindow();
            addQuizWindow.Show();
            this.Close();
        }

        /// <summary>
        /// Click event for the GoToEditQuiz button. Opens EditQuizWindow and closes current window.
        /// </summary>
        /// <param name="sender">The button that initiated the click event</param>
        /// <param name="e">Event arguments</param>
        private void GoToEditQuizWindow_Click(object sender, RoutedEventArgs e)
        {
            EditQuizWindow editQuizWindow = new EditQuizWindow();
            editQuizWindow.Show();
            this.Close();
        }

        
    }
}
