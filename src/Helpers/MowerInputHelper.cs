using System.Text.RegularExpressions;
using Mower.Application.Models;

namespace Mower.Application.Helpers
{
    public static class MowerInputHelper
    {
        private static readonly Regex LawnSizeRegex = new Regex(Constants.LAWN_SIZE_REGEX);

        private static readonly Regex LawnMowerStateRegex = new Regex(Constants.MOWER_POSITION_REGEX);

        public static Lawn getLawnGrid(string input)
        {
            var match = LawnSizeRegex.Match(input);

            if (!match.Success)
            {
                throw new Exception("Lawn top corner coordinates is not in correct format");
            }

            try
            {
                int rightMaxPosition = int.Parse(match.Groups[1].Value);
                int topMaxPosition = int.Parse(match.Groups[2].Value);

                return new Lawn(rightMaxPosition, topMaxPosition);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static MowerElement getLawnMowerPosition(string mowerPosition)
        {
            var match = LawnMowerStateRegex.Match(mowerPosition);

            if (!match.Success)
            {
                throw new Exception($"Lawn mower initial position ({mowerPosition}) is not in correct format");
            }

            try
            {
                int x = int.Parse(match.Groups[1].Value);
                int y = int.Parse(match.Groups[2].Value);
                string orientation = match.Groups[3].Value;

                return new MowerElement(orientation, x, y);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static Queue<Command> getLawnMowerCommands(string commands)
        {
            var mowerCommands = new Queue<Command>();

            if (commands == "")
            {
                throw new Exception("Empty commands list");
            }

            foreach (var commandChar in commands)
            {
                switch (commandChar)
                {
                    case 'L':
                        mowerCommands.Enqueue(Command.L);
                        break;
                    case 'R':
                        mowerCommands.Enqueue(Command.R);
                        break;
                    case 'F':
                        mowerCommands.Enqueue(Command.F);;
                        break;
                    default:
                        throw new Exception($"Invalid Mower command: {commandChar}");
                }
            }

            return mowerCommands;
        }
    }
}
