using System;
using System.Collections.Generic;

namespace GenesysRollerCore
{
    public class Roller
    {
        private readonly LookupTable _lookupTable = new LookupTable();
        private readonly int _blueDice;
        private readonly int _blackDice;
        private readonly int _greenDice;
        private readonly int _purpleDice;
        private readonly int _yellowDice;
        private readonly int _redDice;
        private readonly Random _random = new Random();

        private int _success;
        private int _failures;
        private int _advantages;
        private int _threats;
        private int _triumps;
        private int _dispairs;
        private int _netSuccess;
        private int _netAdvantages;
        private List<string> _displayDiceRolled;
        
        public Roller(int blue, int black, int green, int purple, int yellow, int red)
        {
            _blueDice = blue;
            _blackDice = black;
            _greenDice = green;
            _purpleDice = purple;
            _yellowDice = yellow;
            _redDice = red;
            _displayDiceRolled = new List<string>();
        }

        /// <summary>
        /// Determines how well the user did on the dice roll and then displays those results to the user
        /// via the console
        /// </summary>
        public void DisplayResults()
        {
            Console.WriteLine();
            var rolledStr =
                $"Dice Rolled => (B/S/A/D/P/C):({_blueDice}/{_blackDice}/{_greenDice}/{_purpleDice}/{_yellowDice}/{_redDice})";
            Console.WriteLine(rolledStr);            
            // ROLL THOSE DICE SO THAT WE CAN DISPLAY THEM
            RollDice(_blueDice,_lookupTable.Boost);
            RollDice(_blackDice, _lookupTable.Setback);
            RollDice(_greenDice, _lookupTable.Ability);
            RollDice(_purpleDice, _lookupTable.Difficulty);
            RollDice(_yellowDice, _lookupTable.Proficiency);
            RollDice(_redDice, _lookupTable.Challenge);
            // LETS DISPLAY THEM NOW
            Console.WriteLine($"You rolled the following => {FormatDisplayString()}");
            Console.WriteLine();
            Console.WriteLine("Detailed Results");

            var goodResults = $"Success => {_success}    Advantages => {_advantages}    Triumps => {_triumps}";
            var badResults = $"Failures => {_failures}    Threats => {_threats}    Dispairs => {_dispairs}";
            // NET RESULTS BREAKDOWN
            var netResults = PrintOutResults();

            // DISPLAY THESE
            Console.WriteLine(goodResults);
            Console.WriteLine(badResults);
            Console.WriteLine();
            Console.WriteLine(netResults);
        }

        /// <summary>
        /// Rolls dice from the type list number of times
        /// </summary>
        /// <param name="times">Number of Dicew being Rolled</param>
        /// <param name="type">Dice Lookuptable to be used</param>
        private void RollDice(int times, string[] type)
        {
            for (int index = 0; index < times; index++)
            {
                var dice = _random.Next(1, type.Length);
                var rolled = type[dice];
                DetermineResults(rolled);
            }
        }

        /// <summary>
        /// Takes a string of what was rolled and then interpret them so then it can be displayed correctly
        /// </summary>
        /// <param name="rolled">list of what was rolled that needs to be interpreted</param>
        private void DetermineResults(string rolled)
        {
            _displayDiceRolled.Add(rolled);
            switch (rolled)
            {
                case "X":
                {
                    _success++;
                    break;
                }
                case "XX":
                {
                    _success += 2;
                    break;
                }
                case "XA":
                {
                    _success++;
                    _advantages++;
                    break;
                }
                case "A":
                {
                    _advantages++;
                    break;
                }
                case "AA":
                {
                    _advantages += 2;
                    break;
                }
                case "F":
                {
                    _failures++;
                    break;
                }
                case "FF":
                {
                    _failures += 2;
                    break;
                }
                case "FT":
                {
                    _failures++;
                    _threats++;
                    break;
                }
                case "T":
                {
                    _threats++;
                    break;
                }
                case "TT":
                {
                    _threats += 2;
                    break;
                }
                case "TP":
                {
                    _success++;
                    _triumps++;
                    break;
                }
                case "DR":
                {
                    _failures++;
                    _dispairs++;
                    break;
                }
                default:
                    return;
            }
            // COMPUTE NET INFORMATION
            _netSuccess = _success - _failures;
            _netAdvantages = _advantages - _threats;
        }

        private string FormatDisplayString()
        {
            var retStringValue = string.Empty;

            retStringValue = string.Join(",", _displayDiceRolled);

            return retStringValue;
        }

        private string PrintOutResults()
        {
            var netResults = string.Empty;

            if (_netSuccess > 0)
                netResults += $"Congrats. You succeeded at your task by rolling a total of {_netSuccess} successes";
            else if (_netSuccess == 0)
                netResults += $"Your roll did not either succeed or fail since you did not roll any successes or failures";
            else
                netResults += $"Sorry. You failed at this task by rolling a total of {Math.Abs(_netSuccess)} failures";                   
            if (_netAdvantages < 0)
                netResults += $". Alsp, you generated a total of {Math.Abs(_netAdvantages)} threats";
            else
                netResults += $". Alsp, you generated a total of {Math.Abs(_netAdvantages)} advantages";

            return netResults;
        }
    }
}