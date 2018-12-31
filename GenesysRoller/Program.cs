using System;

namespace GenesysRollerCore
{
    public class Program
    {
        static void Main(string[] args)
        {            
            bool answered = false;
            do 
            {
                Console.WriteLine(Questions.about);
                Console.WriteLine(Questions.copyright);
                // BOOST DICE
                var blue = QuestionAnswer(Questions.question1);            
                // SETBACK DICE
                var black = QuestionAnswer(Questions.question2);
                // ABILITY DICE
                var green = QuestionAnswer(Questions.question3);
                // DIFFICULTY DICE
                var purple = QuestionAnswer(Questions.question4);
                // PROFICIENCY DICE
                var yellow = QuestionAnswer(Questions.question5);
                // CHALLENGE DICE
                var red = QuestionAnswer(Questions.question6);
                // Take the dice given and display it to the screen
                if (blue + black + green + purple + yellow + red != 0)
                {
                    var diceRolled = new Roller(blue,black,green,purple, yellow, red);
                    diceRolled.DisplayResults();
                    break;
                }
                else 
                {
                    Console.WriteLine("There is no dice to be rolled. Please add some dice to be rolled.");                    System.Console.WriteLine();
                    System.Console.WriteLine();
                    answered = true;
                }

            }while(answered);
        }

        static int QuestionAnswer(string question)
        {
            Console.Write(question);
            var dice = Console.ReadLine();

            return int.TryParse(dice, out var result) ? result : 0;
        }
    }
}
