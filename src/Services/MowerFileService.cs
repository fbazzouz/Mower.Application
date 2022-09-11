using Mower.Application.Helpers;
using Mower.Application.Models;

namespace Mower.Application.Services
{
    public class MowerFileService
    {
        private List<string> LoadMowersLinesFromFile(string fileAbsolutePath)
        {
            try {
                List<string> fileLines = File.ReadAllLines(fileAbsolutePath).ToList();
                return fileLines;
            } catch (IOException e) {
                throw new FileLoadException("Unable to read input file", e);
            }
        }

        public Lawn LoadLawnGridFromFile(string fileAbsolutePath)
        {
            var inputLines = this.LoadMowersLinesFromFile(fileAbsolutePath);
            return MowerInputHelper.getLawnGrid(inputLines[0]);
        }

        public List<MowerElement> LoadMowersFromList(string fileAbsolutePath)
        {
            var inputLines = this.LoadMowersLinesFromFile(fileAbsolutePath);
            var mowers = new List<MowerElement>();

            if ((inputLines.Count - 1)%2 != 0)
            {
                throw new Exception("Commands for Lawn Mower missing");
            }

            for (int i = 1; i < inputLines.Count; i = i + 2)
            {
                var mowerElement = MowerInputHelper.getLawnMowerPosition(inputLines[i]);
                mowerElement.Commands = MowerInputHelper.getLawnMowerCommands(inputLines[i + 1]);
                mowers.Add(mowerElement);
            }

            return mowers;
        }
    }
}