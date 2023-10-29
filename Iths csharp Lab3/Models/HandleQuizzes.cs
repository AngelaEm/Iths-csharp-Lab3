using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Iths_csharp_Lab3.Models
{
    public static class HandleQuizzes
    {
        public static List<Quiz> ListWithAllQuizzes { get; set; } = new List<Quiz>();
        public static List<Question> ListWithCurrentQuestions { get; set; } = new List<Question>();
        public static List<string> ListWithCurrentCategories { get; set; } = new List<string>();

        public static Quiz SelectedQuiz { get; set; }

        public static void GenerateFolderAndTextFile()
        {

            string folderName = "MyQuiz";
            string localFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string folderPath = Path.Combine(localFolderPath, folderName);

            try
            {
                if (!Directory.Exists(folderPath))
                {
                    Quiz quiz = new Quiz();
                    quiz.Title = "Megaquiz";
                    quiz.GenerateQuestions();
                    quiz.GenerateQuizzes();
                    var json = JsonConvert.SerializeObject(quiz.Questions, Formatting.Indented);
                    Directory.CreateDirectory(folderPath);
                    string questionFileName = "myQuestions.txt";
                    string questionFilePath = Path.Combine(folderPath, questionFileName);
                    File.WriteAllText(questionFilePath, json);
                    json = JsonConvert.SerializeObject(ListWithAllQuizzes, Formatting.Indented);
                    string quizFileName = "myQuizzes.txt";
                    string quizFilePath = Path.Combine(folderPath, quizFileName);
                    File.WriteAllText(quizFilePath, json);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public static void SaveQuestionsToFile(List<Question> listWithQuestions)
        {
            string folderName = "MyQuiz";
            string localFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string folderPath = Path.Combine(localFolderPath, folderName);
            var json = JsonConvert.SerializeObject(listWithQuestions, Formatting.Indented);
            string fileName = "myQuestions.txt";
            string filePath = Path.Combine(folderPath, fileName);
            File.WriteAllText(filePath, json);
        }

        public static void SaveQuizzesToFile(List<Quiz> listWithQuizzes)
        {
            string folderName = "MyQuiz";
            string localFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string folderPath = Path.Combine(localFolderPath, folderName);
            var json = JsonConvert.SerializeObject(listWithQuizzes, Formatting.Indented);
            string fileName = "myQuizzes.txt";
            string filePath = Path.Combine(folderPath, fileName);
            File.WriteAllText(filePath, json);
        }


        public static List<Question> LoadQuestions()
        {
            string folderName = "MyQuiz";
            string fileName = "myQuestions.txt";
            var localFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string folderPath = Path.Combine(localFolderPath, folderName);
            string filePath = Path.Combine(folderPath, fileName);

            if (File.Exists(filePath))
            {
                try
                {
                    var json = File.ReadAllText(filePath);
                    return JsonConvert.DeserializeObject<List<Question>>(json);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    
                }
                

            }
            return new List<Question>();
        }

        public static List<Quiz> LoadQuiz()
        {
            string folderName = "MyQuiz";
            string fileName = "myQuizzes.txt";
            string localFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string folderPath = Path.Combine(localFolderPath, folderName);
            string filePath = Path.Combine(folderPath, fileName);

            if (File.Exists(filePath))
            {
                try
                {
                    var json = File.ReadAllText(filePath);
                    return JsonConvert.DeserializeObject<List<Quiz>>(json);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                   
                }
            }
            return new List<Quiz>();

        }
    }
}

