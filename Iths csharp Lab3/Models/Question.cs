using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Iths_csharp_Lab3.Models
{
    class Question
    {
       
        public int Id { get; }
        public string Category { get; set; }
        public string Statement { get; set; }     
        public int CorrectAnswer { get; }
        public string[] Answers { get; set; }
        public string ImagePath { get; set; }

        public Question(int id, string category, string statement, int correctAnswer, string[] answers)
        {
            Id = id;
            Category = category;
            Statement = statement;          
            CorrectAnswer = correctAnswer;
            Answers = answers;
        }
    }
}

