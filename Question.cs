using System;
using System.Collections.Generic;
using System.Text;

namespace Millionaires
{
    class Question
    {
        public string QuestionText { get; private set; }
        public List<Answer> Answers { get; private set; }

        public Question(string questionText, List<Answer> answers)
        {
            QuestionText = questionText;
            Answers = answers;
        }

        public static Question ConvertFromWeb(WebQusetion webQusetion)
        {
            List<Answer> convertedAnswers = new List<Answer>();
            foreach (WebAnswer answer in webQusetion.Answers)
            {
                if (answer.Correct)
                {
                    convertedAnswers.Add(new CorrectAnswer(answer.Text));
                }
                else
                {
                    convertedAnswers.Add(new WrongAnswer(answer.Text));
                }
            }
            return new Question(webQusetion.Question, convertedAnswers);
        }
    }
}
