using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace Millionaires
{
    class IOGameData
    {
        private string PathQuestions { get; set; }
        private string PathSaves { get; }

        public Question[] LoadQuestions()
        {
            if (ChooseTypeLoad()) 
            {
                var result = LocalLoadQuestions();
                if (result == null)
                {
                    return null;
                }
                return result.ToArray();
            }
            else
            {
                return WebLoadQuestions().ToArray();
            }
        }

        private bool ChooseTypeLoad()
        {
            Console.WriteLine($"Выберите тип загрузки вопросов:{Environment.NewLine}1. Из файла.{Environment.NewLine}2. Из Web.{Environment.NewLine}Для выбора ввести: 1 или 2.");
            string key;
            while ((key = Console.ReadLine()) != "1" && !key.Equals("2"));
            switch (key)
            {
                case "1":
                    return true;
                case "2":
                    return false;
            }
            return true;
        }

        private List<Question> LocalLoadQuestions()
        {
            //проверяем наличие файла с вопросами
            PathQuestions = Path.Combine(Directory.GetCurrentDirectory(), "questions.txt");
            if (!File.Exists(PathQuestions))
            {
                Console.WriteLine("Файл с вопросам не найден. Поместите его рядом с исполняемым файлом игры. Название файла: questions.txt");
                return null;
            }
            //загружаем вопросы из файла
            List<Question> questions = new List<Question>();
            using (StreamReader readQuestions = File.OpenText(PathQuestions))
            {
                string stringLine;
                while (readQuestions.Peek() != -1)
                {
                    stringLine = readQuestions.ReadLine();
                    if (stringLine.Contains("<q>"))
                    {
                        questions.Add(new Question(stringLine.Substring(3), new List<Answer>()));
                        continue;
                    }
                    if (stringLine.Contains("<true>"))
                    {
                        questions[questions.Count - 1].Answers.Add(new CorrectAnswer(stringLine.Substring(6)));
                        continue;
                    }
                    if (stringLine.Contains("<false>"))
                    {
                        questions[questions.Count - 1].Answers.Add(new WrongAnswer(stringLine.Substring(7)));
                        continue;
                    }
                }
            }
            return questions;
        }

        private List<Question> WebLoadQuestions()
        {
            List<Question> questions = new List<Question>();
            string url = "https://freeit.blob.core.windows.net/millionairegame/";
            for (int i = 1; i <=10; i++)
            {
                HttpWebRequest request = WebRequest.CreateHttp(string.Concat(url,"q",i,".json"));
                request.Method = "GET";
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                using (StreamReader streamReader = new StreamReader(response.GetResponseStream()))
                {
                    string jsontext = streamReader.ReadToEnd();
                    WebQusetion WebQuestion = JsonConvert.DeserializeObject<WebQusetion>(jsontext);
                    questions.Add(Question.ConvertFromWeb(WebQuestion));
                }
            }
            return questions;
        }
    }
}
