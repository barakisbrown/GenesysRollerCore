using System;

namespace GenesysRoller
{
    public class Program
    {
        static void Main(string[] args)
        {
            const string about = "Genesys Python Dice Roller by Matthew Brown, @2018";
            const string question1 = "How many boost dice? (return for 0) => ";
            const string question2 = "How many setback dice (return for 0) => ";
            const string question3 = "How many Ability dice (return for 0) => ";
            const string question4 = "How many Difficulty dice (return for 0) => ";
            const string question5 = "How many Proficiency dice (return for 0) => ";
            const string question6 = "How many Challenge dice (return for 0) => ";

            Console.WriteLine(about);
            Console.WriteLine("Genesys RPG created by Fantasy Flight Games @2018");

            // BOOST DICE
            var blue = QuestionAnswer(question1);            
            // SETBACK DICE
            var black = QuestionAnswer(question2);
            // ABILITY DICE
            var green = QuestionAnswer(question3);
            // DIFFICULTY DICE
            var purple = QuestionAnswer(question4);
            // PROFICIENCY DICE
            var yellow = QuestionAnswer(question5);
            // CHALLENGE DICE
            var red = QuestionAnswer(question6);
            
            // 
            while (true)
            {
                if (blue + black + green + purple + yellow + red != 0)
                {
                    var diceRolled = new Roller(blue, black, green, purple, yellow, red);
                    diceRolled.DisplayResults();
                    break;
                }
                // Tell the user that you can not roll nothing
                Console.WriteLine("Oops. I see nothing to roll. Try again?");
                // BOOST DICE
                blue = QuestionAnswer(question1);            
                // SETBACK DICE
                black = QuestionAnswer(question2);
                // ABILITY DICE
                green = QuestionAnswer(question3);
                // DIFFICULTY DICE
                purple = QuestionAnswer(question4);
                // PROFICIENCY DICE
                yellow = QuestionAnswer(question5);
                // CHALLENGE DICE
                red = QuestionAnswer(question6);
            }

            Console.In.Read();
        }

        static int QuestionAnswer(string question)
        {
            Console.Write(question);
            var dice = Console.ReadLine();

            return int.TryParse(dice, out var result) ? result : 0;
        }
    }
}
