using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.IO;
using System.Windows;

namespace Iths_csharp_Lab3.Models
{
    class Quiz
    {
        private List<Question> _questions;

        private string _title = string.Empty;
        public IEnumerable<Question> Questions => _questions;
        public string Title => _title;

        public Quiz()
        {
            _questions = new List<Question>();
        }

        public Question GetRandomQuestion()
        {
            Random random = new Random();
            int randomIndex = random.Next(0, _questions.Count);

            return _questions[randomIndex];

            //throw new NotImplementedException("A random Question needs to be returned here!");
        }

        public void AddQuestion(int id, string category, string statement, int correctAnswer, params string[] answers)
        {
            var newQuestion = new Question(id, category, statement, correctAnswer, answers);
            _questions.Add(newQuestion);

            // throw new NotImplementedException("Question need to be instantiated and added to list of questions here!");
        }

        public void RemoveQuestion(int index)
        {
            throw new NotImplementedException("Question at requested index need to be removed here!");
        }

       

        public void GenerateFolderAndTextFile()
        {
            GenerateQuestions();
            string folderName = "MyQuiz";
            string localFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string folderPath = Path.Combine(localFolderPath, folderName);
            
            var json = JsonConvert.SerializeObject(_questions, Formatting.Indented);
            


            try
            {
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                string fileName = "myQuestions";
                string filePath = Path.Combine(folderPath, fileName);
                File.WriteAllText(filePath, json);
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }
        }

        public void GenerateQuestions()
        {
            AddQuestion(1, "Programming", "What does HTML stand for?", 0, new string[] {
            "Hypertext Markup Language",
            "Hyper Transfer Markup Language",
            "Hypertext Transfer Mode Language"});

            AddQuestion(2, "Programming", "Which programming language is known for its simplicity and readability?", 2, new string[] {
            "C++",
            "Java",
            "Python"});


            AddQuestion(3, "Programming", "What is the symbol for a single-line comment in C#?", 0, new string[] {
            "//",
            "/*",
            "#"});


            AddQuestion(4, "Mathematics", "What is the result of 7 multiplied by 8?", 1, new string[] {
            "48",
            "56",
            "64"});


            AddQuestion(5, "Mathematics", "What is the square root of 144?", 0, new string[] {
            "12",
            "14",
            "16"});


            AddQuestion(6, "Music", "Which instrument has black and white keys and is commonly used in classical music?", 2, new string[] {
            "Guitar",
            "Violin",
            "Piano"});


            AddQuestion(7, "Music", "Which Beatles album is often considered one of the greatest albums of all time?", 1, new string[] {
            "Please Please Me",
            "Sgt. Pepper's Lonely Hearts Club Band",
            "Let It Be"});


            AddQuestion(8, "Animals & Nature", "What is the largest species of penguin?", 0, new string[] {
            "Emperor Penguin",
            "African Penguin",
            "Little Blue Penguin"});

            AddQuestion(9, "Animals & Nature", "What is the world's largest land mammal?", 1, new string[] {
            "Giraffe",
            "African Elephant",
            "Rhinoceros"});

            AddQuestion(10, "Animals & Nature", "What is the capital city of Australia?", 2, new string[] {
            "Melbourne",
            "Sydney",
            "Canberra"});


            AddQuestion(11, "Programming", "What is the most widely used programming language for web development?", 1, new string[] {
            "Java",
            "JavaScript",
            "Python"});


            AddQuestion(12, "Programming", "Which data type is used to store a single character in C#?", 2, new string[] {
            "int",
            "float",
            "char"});


            AddQuestion(13, "Mathematics", "What is the value of Pi (π) to two decimal places?", 0, new string[] {
            "3.14",
            "3.16",
            "3.18"});


            AddQuestion(14, "Mathematics", "How many sides does a hexagon have?", 0, new string[] {
            "6",
            "5",
            "7"});

        
            AddQuestion(15, "Music", "Which instrument is known as the 'King of Instruments'?", 2, new string[] {
            "Guitar",
            "Violin",
            "Pipe Organ"});


            AddQuestion(16, "Music", "Who is often referred to as the 'Queen of Pop'?", 0, new string[] {
            "Madonna",
            "Whitney Houston",
            "Celine Dion"});


            AddQuestion(17, "Animals & Nature", "What is the largest species of shark?", 0, new string[] {
            "Whale Shark",
            "Great White Shark",
            "Hammerhead Shark"});


            AddQuestion(18, "Animals & Nature", "What is the national bird of the United States?", 0, new string[] {
            "Bald Eagle",
            "Turkey",
            "Pigeon"
});

            AddQuestion(19, "Animals & Nature", "Which gas do plants absorb from the atmosphere during photosynthesis?", 1, new string[] {
            "Oxygen",
            "Carbon Dioxide",
            "Nitrogen"
});

            AddQuestion(20, "Animals & Nature", "What is the world's largest and heaviest species of penguin?", 0, new string[] {
            "Emperor Penguin",
            "King Penguin",
            "Little Blue Penguin"
});



        }
    }
}
