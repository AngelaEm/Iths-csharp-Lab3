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
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace Iths_csharp_Lab3.Models
{
    public class Quiz
    {
        

        //private string _title = string.Empty;
        //public IEnumerable<Question> Questions => _questions;
        public string Title { get; set; }   
        
        public List<Question> Questions { get; set; }

        public Quiz()
        {
            Questions = new List<Question>();          
        }


        /// <summary>
        /// Get a random question 
        /// </summary>
        /// <returns>a random question</returns>
        public Question GetRandomQuestion()
        {
            Random random = new Random();
            int randomIndex = random.Next(0, Questions.Count);

            return Questions[randomIndex];
            
        }

        /// <summary>
        /// Add question to List with questions
        /// </summary>
        /// <param name="category">Question category</param>
        /// <param name="statement">Question statement</param>
        /// <param name="correctAnswer">Question correct answer</param>
        /// <param name="answers">params with answers</param>
        public void AddQuestion(string category, string statement, int correctAnswer, params string[] answers)
        {
            Question newQuestion = new Question(category, statement, correctAnswer, answers);
            Questions.Add(newQuestion);
            
        }

        /// <summary>
        /// Add question to List with questions
        /// </summary>
        /// <param name="category">Question category</param>
        /// <param name="statement">Question statement</param>
        /// <param name="correctAnswer">Question correct answer</param>
        /// <param name="imagePath">Question imagepath</param>
        /// <param name="answers">params with answers</param>
        public void AddQuestion(string category, string statement, int correctAnswer, string imagePath, params string[] answers)
        {
            Question newQuestion = new Question(category, statement, correctAnswer, imagePath, answers);
            Questions.Add(newQuestion);

        }

        /// <summary>
        /// Add question to Quiz
        /// </summary>
        /// <param name="question">Question</param>
        public void AddToQuiz(Question question)
        {
            Questions.Add(question);
        }

       
        /// <summary>
        /// Remove from quiz
        /// </summary>
        /// <param name="question">Question</param>
        public void RemoveQuestion(Question question)
        {
            Questions.Remove(question);
        }

        public void GenerateFolderAndTextFile()
        {
            if (Questions.Count == 0)
            {
                GenerateQuestions();
            }

            if(AllQuizzes.ListWithAllQuizzes.Count == 0)
            {
                GenerateMegaQuiz();
            }
           

            string folderName = "MyQuiz";
            string localFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string folderPath = Path.Combine(localFolderPath, folderName);

            var json = JsonConvert.SerializeObject(Questions, Formatting.Indented);

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

        

        //public List<Question> LoadQuestions()
        //{
        //    string folderName = "MyQuiz";
        //    string fileName = "MegaQuizWithAllQuestions.json";
        //    string localFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        //    string folderPath = Path.Combine(localFolderPath, folderName);
        //    string filePath = Path.Combine(folderPath, fileName);

        //    if (File.Exists(filePath))
        //    {
        //        string json = File.ReadAllText(filePath);
        //        Quiz loadedQuiz = JsonConvert.DeserializeObject<Quiz>(json);
        //        return loadedQuiz.Questions;
        //    }
        //    return new List<Question>();
        //}

        //public void LoadQuiz()
        //{
        //    string folderName = "MyQuiz";
        //    string fileName = "MegaQuizWithAllQuestions.json";
        //    string localFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        //    string folderPath = Path.Combine(localFolderPath, folderName);
        //    string filePath = Path.Combine(folderPath, fileName);

        //    if (File.Exists(filePath))
        //    {
        //        string json = File.ReadAllText(filePath);
        //        Quiz loadedQuiz = JsonConvert.DeserializeObject<Quiz>(json);
        //        this.Questions = loadedQuiz.Questions;

        //    }
            
        //}

       
        /// <summary>
        /// Generate questions and add question to list
        /// </summary>
        public void GenerateQuestions()
        {
            AddQuestion("Programming", "What does HTML stand for?", 0, "questionmark.png", new string[] {"Hypertext Markup Language", "Hyper Transfer Markup Language", "Hypertext Transfer Mode Language"});

            AddQuestion("Programming", "Which programming language is known for its simplicity and readability?", 2, "\\Images\\loggaQuiz1.png", new string[] {"C++", "Java", "Python"});

            AddQuestion("Programming", "What is the symbol for a single-line comment in C#?", 0, "\\Images\\quizLogga2.png", new string[] { "//", "/*", "#"});

            AddQuestion("Mathematics", "What is the result of 7 multiplied by 8?", 1, new string[] { "48", "56", "64"});

            AddQuestion("Mathematics", "What is the square root of 144?", 0, new string[] { "12", "14", "16"});

            AddQuestion("Music", "Which instrument has black and white keys and is commonly used in classical music?", 2, new string[] {"Guitar", "Violin", "Piano"});

            AddQuestion("Music", "Which Beatles album is often considered one of the greatest albums of all time?", 1, new string[] {"Please Please Me", "Sgt. Pepper's Lonely Hearts Club Band","Let It Be"});

            AddQuestion("Nature", "What is the largest species of penguin?", 0, new string[] {"Emperor Penguin", "African Penguin", "Little Blue Penguin"});

            AddQuestion("Nature", "What is the world's largest land mammal?", 1, new string[] {"Giraffe", "African Elephant", "Rhinoceros"});

            AddQuestion("Nature", "What is the capital city of Australia?", 2, new string[] {"Melbourne", "Sydney", "Canberra"});

            AddQuestion("Programming", "What is the most widely used programming language for web development?", 1, new string[] {"Java", "JavaScript", "Python"});

            AddQuestion("Programming", "Which data type is used to store a single character in C#?", 2, new string[] {"int", "float", "char"});

            AddQuestion("Mathematics", "What is the value of Pi (π) to two decimal places?", 0, new string[] {"3.14", "3.16", "3.18"});

            AddQuestion("Mathematics", "How many sides does a hexagon have?", 0, new string[] {"6", "5","7"});
       
            AddQuestion("Music", "Which instrument is known as the 'King of Instruments'?", 2, new string[] {"Guitar", "Violin", "Pipe Organ"});

            AddQuestion("Music", "Who is often referred to as the 'Queen of Pop'?", 0, new string[] {"Madonna", "Whitney Houston", "Celine Dion"});

            AddQuestion("Nature", "What is the largest species of shark?", 0, new string[] {"Whale Shark", "Great White Shark", "Hammerhead Shark"});

            AddQuestion("Nature", "What is the national bird of the United States?", 0, new string[] {"Bald Eagle", "Turkey","Pigeon"});

            AddQuestion("Nature", "Which gas do plants absorb from the atmosphere during photosynthesis?", 1, new string[] {"Oxygen", "Carbon Dioxide", "Nitrogen"});

            AddQuestion("Nature", "What is the world's largest and heaviest species of penguin?", 0, new string[] {"Emperor Penguin", "King Penguin", "Little Blue Penguin"});

        }

        public void GenerateMegaQuiz()
        {
            Quiz megaQuiz = new Quiz();
            megaQuiz.Title = "Quizzy Trivia MegaQuiz";
            megaQuiz.GenerateQuestions();
            AllQuizzes.ListWithAllQuizzes.Add(megaQuiz);
        }
    }
}
