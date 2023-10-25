using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Iths_csharp_Lab3.Models
{
    public class AllQuizzes
    {
        public static List<Quiz> ListWithAllQuizzes { get; set; } = new List<Quiz>();

        public static List<string> SelectedCategories { get; set; } = new List<string>();

        public static Quiz SelectedQuiz { get; set; }
     
        /// <summary>
        /// Uploads new quiz to combobox
        /// </summary>
        /// <param name="comboBox">Combobox</param>
        public static void LoadQuizzesIntoComboBox(ComboBox comboBox)
        {
            comboBox.Items.Clear();

            foreach (var quiz in ListWithAllQuizzes)
            {
                comboBox.Items.Add(quiz.Title);
            }
        }

        public static void LoadQuestionsIntoListBox(ListBox listBox)
        {
            listBox.Items.Clear();

            foreach (var question in SelectedQuiz.Questions)
            {
                listBox.Items.Add(question.Statement);
            }
        }
    }    
}
