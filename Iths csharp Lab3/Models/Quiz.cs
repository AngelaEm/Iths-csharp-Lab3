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
        private List<Question> _questions;
        public List<Question> Questions => _questions;
        private string _title = string.Empty;
        public string Title { get; set; }

        public Quiz(string title)
        {
            Title = title;
            _questions = new List<Question>();
         
        }

        public Quiz()
        {
            _questions = new List<Question>();
        }




        /// <summary>
        /// Get a random question 
        /// </summary>
        /// <returns>a random question</returns>
        public Question GetRandomQuestion()
        {
            Random random = new Random();
            int randomIndex = random.Next(0, _questions.Count);

            return _questions[randomIndex];
            
        }

        /// <summary>
        /// Add question to List with questions
        /// </summary>
        /// <param name="category">Question category</param>
        /// <param name="statement">Question statement</param>
        /// <param name="correctAnswer">Question correct answer</param>
        /// <param name="answers">params with answers</param>
        public void AddQuestion(string category, string statement, int correctAnswer, string[] answers)
        {
            Question newQuestion = new Question(category, statement, correctAnswer, answers);
            _questions.Add(newQuestion);
            
        }

        public void AddQuestion(string statement, int correctAnswer, string imagePath, string[] answers)
        {
            Question newQuestion = new Question(statement, correctAnswer, imagePath, answers);
            _questions.Add(newQuestion);

        }

        /// <summary>
        /// Add question to List with questions
        /// </summary>
        /// <param name="category">Question category</param>
        /// <param name="statement">Question statement</param>
        /// <param name="correctAnswer">Question correct answer</param>
        /// <param name="imagePath">Question imagepath</param>
        /// <param name="answers">params with answers</param>
        public void AddQuestion(string category, string statement, int correctAnswer, string imagePath, string[] answers)
        {
            Question newQuestion = new Question(category, statement, correctAnswer, imagePath, answers);
            _questions.Add(newQuestion);

        }

        /// <summary>
        /// Add question to Quiz
        /// </summary>
        /// <param name="question">Question</param>
        public void AddQuestion(Question question)
        {
            _questions.Add(question);
        }

       
        /// <summary>
        /// Remove from quiz
        /// </summary>
        /// <param name="question">Question</param>
        public void RemoveQuestion(Question question)
        {
            _questions.Remove(question);
        }

        
        


        /// <summary>
        /// Generate questions and add question to list
        /// </summary>
        public void GenerateQuestions()
        {
            // Programming
            AddQuestion("Programming", "What does HTML stand for?", 0, "\\Images\\ImageProgramming.png", new string[] { "Hypertext Markup Language", "Hyper Transfer Markup Language", "Hypertext Transfer Mode Language" });
            AddQuestion("Programming", "Which programming language is known for its simplicity and readability?", 2, "\\Images\\ImageProgramming.png", new string[] { "C++", "Java", "Python" });
            AddQuestion("Programming", "What is the symbol for a single-line comment in C#?", 0, "\\Images\\ImageProgramming.png", new string[] { "//", "/*", "#" });
            AddQuestion("Programming", "Which language is primarily used for iOS and macOS applications?", 2, "\\Images\\ImageProgramming.png", new string[] { "Python", "Java", "Swift" });
            AddQuestion("Programming", "Which of the following is not a database?", 2, "\\Images\\ImageProgramming.png", new string[] { "MySQL", "PostgreSQL", "JavaScript" });
            AddQuestion("Programming", "Which database is known for using structured query language?", 1, "\\Images\\ImageProgramming.png", new string[] { "MongoDB", "SQLite", "Redis" });
            AddQuestion("Programming", "Which keyword is used to define a class in Java?", 0, "\\Images\\ImageProgramming.png", new string[] { "class", "define", "new" });
            AddQuestion("Programming", "What is the primary purpose of a web server?", 1, "\\Images\\ImageProgramming.png", new string[] { "Run desktop applications", "Serve web pages", "Store files" });
            AddQuestion("Programming", "Which tag is used to create a hyperlink in HTML?", 1, "\\Images\\ImageProgramming.png", new string[] { "<hl>", "<a>", "<link>" });
            AddQuestion("Programming", "What is the main use of JavaScript?", 0, "\\Images\\ImageProgramming.png", new string[] { "Web development", "Operating system development", "Embedded systems" });

            // Mathematics
            AddQuestion("Mathematics", "What is the result of 7 multiplied by 8?", 1, "\\Images\\ImagePi.png", new string[] { "48", "56", "64" });
            AddQuestion("Mathematics", "What is the square root of 144?", 0, "\\Images\\ImagePi.png", new string[] { "12", "14", "16" });
            AddQuestion("Mathematics", "If a circle's diameter is 8 units, what is its radius?", 1, "\\Images\\ImagePi.png", new string[] { "4 units", "8 units", "16 units" });
            AddQuestion("Mathematics", "Which of these numbers is an irrational number?", 2, "\\Images\\ImagePi.png", new string[] { "4", "2/3", "√2" });
            AddQuestion("Mathematics", "What comes next in the sequence: 2, 4, 8, 16, ...?", 2, "\\Images\\ImagePi.png", new string[] { "18", "20", "32" });
            AddQuestion("Mathematics", "How many degrees are in a right angle?", 0, "\\Images\\ImagePi.png", new string[] { "90", "45", "180" });
            AddQuestion("Mathematics", "Which of these is not a prime number?", 2, "\\Images\\ImagePi.png", new string[] { "13", "17", "21" });
            AddQuestion("Mathematics", "Which of the following shapes has the most sides?", 2, "\\Images\\ImagePi.png", new string[] { "Triangle", "Square", "Pentagon" });
            AddQuestion("Mathematics", "What is the smallest two-digit prime number?", 0, "\\Images\\ImagePi.png", new string[] { "11", "12", "10" });
            AddQuestion("Mathematics", "How many vertices does a cube have?", 2, "\\Images\\ImagePi.png", new string[] { "6", "12", "8" });

            // Music
            AddQuestion("Music", "Which instrument has black and white keys and is commonly used in classical music?", 2, "\\Images\\ImageGKlav.png", new string[] { "Guitar", "Violin", "Piano" });
            AddQuestion("Music", "Which Beatles album is often considered one of the greatest albums of all time?", 1, "\\Images\\ImageGKlav.png", new string[] { "Please Please Me", "Sgt. Pepper's Lonely Hearts Club Band", "Let It Be" });
            AddQuestion("Music", "Who is known as the 'King of Rock and Roll'?", 0, "\\Images\\ImageGKlav.png", new string[] { "Elvis Presley", "Michael Jackson", "Freddie Mercury" });
            AddQuestion("Music", "Which musical instrument is said to have a total of 88 keys?", 2, "\\Images\\ImageGKlav.png", new string[] { "Guitar", "Violin", "Piano" });
            AddQuestion("Music", "In which decade did The Beatles become famous?", 0, "\\Images\\ImageGKlav.png", new string[] { "1960s", "1970s", "1980s" });
            AddQuestion("Music", "Which famous singer is known for hits like 'Purple Rain' and 'When Doves Cry'?", 1, "\\Images\\ImageGKlav.png", new string[] { "Michael Jackson", "Prince", "David Bowie" });
            AddQuestion("Music", "Which musical term indicates a chord where the notes are played one after the other, rather than all together?", 2, "\\Images\\ImageGKlav.png", new string[] { "Chorus", "Bridge", "Arpeggio" });
            AddQuestion("Music", "Which of these instruments is a woodwind instrument?", 1, "\\Images\\ImageGKlav.png", new string[] { "Violin", "Flute", "Trombone" });
            AddQuestion("Music", "Which composer wrote the famous 'Moonlight Sonata'?", 2, "\\Images\\ImageGKlav.png", new string[] { "Mozart", "Handel", "Beethoven" });
            AddQuestion("Music", "Which of these is NOT a string instrument?", 0, "\\Images\\ImageGKlav.png", new string[] { "Trumpet", "Guitar", "Cello" });

            // Nature
            AddQuestion("Nature", "What is the largest species of penguin?", 0, "\\Images\\ImageBlomma.png", new string[] { "Emperor Penguin", "African Penguin", "Little Blue Penguin" });
            AddQuestion("Nature", "What is the world's largest land mammal?", 1, "\\Images\\ImageBlomma.png", new string[] { "Giraffe", "African Elephant", "Rhinoceros" });
            AddQuestion("Nature", "Which plant is known for its ability to retain water in arid conditions?", 2, "\\Images\\ImageBlomma.png", new string[] { "Fern", "Sunflower", "Cactus" });
            AddQuestion("Nature", "Which plant is known to have a soothing effect on burns?", 0, "\\Images\\ImageBlomma.png", new string[] { "Aloe Vera", "Tulip", "Rose" });
            AddQuestion("Nature", "Which of these animals is a marsupial?", 2, "\\Images\\ImageBlomma.png", new string[] { "Lion", "Elephant", "Kangaroo" });
            AddQuestion("Nature", "Which planet is known as the 'Red Planet'?", 0, "\\Images\\ImageBlomma.png", new string[] { "Mars", "Venus", "Jupiter" });
            AddQuestion("Nature", "What is the largest animal ever known to exist on Earth?", 1, "\\Images\\ImageBlomma.png", new string[] { "Tyrannosaurus Rex", "Blue Whale", "African Elephant" });
            AddQuestion("Nature", "Which bird is capable of true sustained flight?", 2, "\\Images\\ImageBlomma.png", new string[] { "Ostrich", "Penguin", "Eagle" });
            AddQuestion("Nature", "What is the main gas found in the Earth's atmosphere?", 0, "\\Images\\ImageBlomma.png", new string[] { "Nitrogen", "Oxygen", "Carbon Dioxide" });
            AddQuestion("Nature", "Which animal is known as the 'King of the Jungle'?", 1, "\\Images\\ImageBlomma.png", new string[] { "Tiger", "Lion", "Elephant" });

        }

        public void GenerateQuizzes()
        {


            Quiz nature = new Quiz("Nature");
            Quiz mathematics = new Quiz("Mathematics");
            Quiz programming = new Quiz("Programming");
            Quiz music = new Quiz("Music");
            

            HandleQuizzes.ListWithAllQuizzes.Add(nature);
            HandleQuizzes.ListWithAllQuizzes.Add(mathematics);
            HandleQuizzes.ListWithAllQuizzes.Add(programming);
            HandleQuizzes.ListWithAllQuizzes.Add(music);
            

            foreach (var question in _questions)
            {
                //megaQuiz.AddQuestion(question);
                
                switch (question.Category)
                {
                    case "Nature":

                        nature.AddQuestion(question);
                        break;

                    case "Mathematics":
                        mathematics.AddQuestion(question);
                        break;

                    case "Programming":
                        programming.AddQuestion(question);
                        break;

                    case "Music":
                        music.AddQuestion(question);
                        break;

                }
            }
        }      
    }
}
