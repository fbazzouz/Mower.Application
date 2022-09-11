using System.ComponentModel.Design;
using Mower.Application.Models;

namespace Mower.Application.Services
{
    public class MowerMouvementService
    {
        public MowerElement MoverMowerByCommands(MowerElement mower, Lawn lawnGrid)
        {
           while(mower.Commands.Count > 0) {
                var command = mower.Commands.Dequeue();
                switch (command)
                {
                    case Command.R:
                    case Command.L:
                        mower.ChangeOrientation(command);
                        break;
                    case Command.F:
                        if(mower.isMouvementAllowed(lawnGrid)) mower.MoveMower();
                        break;
                    default:
                        throw new Exception($"Invalid Lawn Mower command: {command}");
                }
            }
            lawnGrid.LawnGrid[mower.MowerCoordinates.X, mower.MowerCoordinates.Y].OccupiedByMown = true;
            return mower;
        }
    }
}