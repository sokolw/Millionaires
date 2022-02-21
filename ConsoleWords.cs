using System;
using System.Collections.Generic;
using System.Text;

namespace Millionaires
{
    public static class ConsoleWords
    {
        public static string NewLine = Environment.NewLine;
        public static string GameDescription = $"Правила игры \"Кто хочет стать миллионером\":{NewLine}{NewLine}Эта игра подразумевает серию вопросов,{NewLine}" +
                $"в которой правильный ответ на каждый следующий вопрос удваивает количество денег, полученных игроком.{NewLine}" +
                $"Первй правильный ответ приносит 100BYN. Каждый вопрос подразумевает наличие 4х вариантов ответа.{NewLine}" +
                $"Один из которых является верным.{NewLine}{NewLine}" +
                $"Всего 10 вопросов glhf){NewLine}{NewLine}" +
                $"Для ответа на вопрос вводить цифру в диапазоне 1-4 .{NewLine}{NewLine}";
    }
}
