using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using GeneratoryParser.Models;
using Newtonsoft.Json;
using JsonReader = GeneratoryParser.Utils.JsonReader;

namespace GeneratoryParser
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var jsonText = new JsonReader("../../data.json").readFile();

            JsonData data = JsonConvert.DeserializeObject<JsonData>(jsonText);

            var questionsList = data.data.ToList();

            var result = new List<string>();

            // foreach (var question in questionsList)
            // {
            //     result.Add("<b>" + question.question + "</b>");
            //     foreach (var answer in question.answers.Where(p => p.correct))
            //     {
            //         Console.Write(answer.answer);
            //         result.Add("<p>" + answer.answer + "</p>");
            //     }
            //     result.Add("<br />");
            // }

            // foreach (var r in result)
            // {
            //     Console.WriteLine(r);
            // }
            
            // File.WriteAllLines("../../index.html", result);
            
            foreach (var question in questionsList)
            {
                var correctAnswers = question.answers.Where(p => p.correct).ToList();
                var chooseByUserAnswer = new List<Answer>();
                
                Console.WriteLine(question.question);

                int counter = 0;
                foreach (var answer in question.answers)
                {
                    Console.WriteLine((counter + 1) + ". " + answer.answer);
                    counter++;
                }

                var number = Convert.ToInt32(Console.ReadLine());
                
                do
                {
                    if (number != 0 && number <= question.answers.ToList().Count)
                    {
                        chooseByUserAnswer.Add(question.answers.ToList()[number - 1]);
                    }
                    
                    number = Convert.ToInt32(Console.ReadLine());
                    
                } while (number != 0);

                var differencesCorrect = correctAnswers.Except(chooseByUserAnswer);
                Console.WriteLine("\nNie zaznaczono poprawnej: ");
                foreach (var answer in differencesCorrect)
                {
                    Console.WriteLine(answer.answer);
                }
                
                var correct = chooseByUserAnswer.Intersect(correctAnswers);
                Console.WriteLine("\nPoprawne: ");
                foreach (var answer in correct)
                {
                    Console.WriteLine(answer.answer);
                    // if (!answer.correct)
                    //     Console.WriteLine(answer.answer);
                }

                var differencesIncorrect = chooseByUserAnswer.Intersect(question.answers.Where(p => p.correct == false));
                Console.WriteLine("\nNiepoprawne: ");
                foreach (var answer in differencesIncorrect)
                {
                    Console.WriteLine(answer.answer);
                    // if (!answer.correct)
                    //     Console.WriteLine(answer.answer);
                }

                
                do
                {
                    Console.WriteLine("\nNacisnij enter, aby przejsc dalej!\n");
                } while (Console.ReadKey().Key != ConsoleKey.Enter);
                
            }

            
            
        }
    }
}