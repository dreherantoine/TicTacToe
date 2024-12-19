using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    internal class AI
    {
        public static Boolean DisplayGameChoiceAndHeader()
        {
            Console.Clear();
            DisplayGameHeader();
            return DisplayGameChoice();
        }


        private static void DisplayGameHeader()
        {
            Console.WriteLine(new string('=', Console.WindowWidth));
            Console.WriteLine(".NET M2I".PadLeft(Console.WindowWidth / 2));
            Console.WriteLine(new string('=', Console.WindowWidth));
        }

        private static Boolean DisplayGameChoice()
        {
            Console.WriteLine("Would you like to play against an AI ? [Y/n]");

            string? input = Console.ReadLine();

            if (input == "n" || input == "N")
            {
                return false;
            }

            return true;
        }
    }
}
