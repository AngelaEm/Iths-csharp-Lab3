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

        public static Quiz SelectedQuiz { get; set; }

       
    }    
}
