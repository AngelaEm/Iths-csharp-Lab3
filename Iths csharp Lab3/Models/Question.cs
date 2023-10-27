using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Iths_csharp_Lab3.Models
{
    public class Question
    {    
        
        public string Category { get; set; }
        public string Statement { get; set; }     
        public int CorrectAnswer { get; }
        public string[] Answers { get; set; }
        public string ImagePath { get; set; } = "\\Images\\questionmark.png";

        public Question(string category, string statement, int correctAnswer, params string[] answers)
        {     
            Category = category;
            Statement = statement;          
            CorrectAnswer = correctAnswer;
            Answers = answers;
        }

        public Question(string category, string statement, int correctAnswer, string imagePath, params string[] answers)
        {
            Category = category;
            Statement = statement;
            CorrectAnswer = correctAnswer;
            Answers = answers;
            ImagePath = imagePath;
        }

    }
}

