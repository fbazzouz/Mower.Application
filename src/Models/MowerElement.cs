namespace Mower.Application.Models
{
    public class MowerElement
    {
        public Orientation MowerOrientation { get; set; }
        public Coordinates MowerCoordinates { get; set; }
        public Queue<Command> Commands { get; set; } = new Queue<Command>();
        public MowerElement(string orientation, int x, int y)
        {
            var output = Orientation.N;
            Enum.TryParse<Orientation>(orientation, out output);
            MowerOrientation = output;
            MowerCoordinates = new Coordinates(x, y);
        }

        /// <summary>
        /// Changing the mower orientation.
        /// L and R turn the mower 90° left or right without moving the mower.
        /// </summary>
        /// <param name="command">Orientation command</param>
        public void ChangeOrientation(Command command)
        {
            
            if (command != Command.L && command != Command.R)
            {
                throw new ArgumentException("Invalid orientation command");
            }

            switch (command)
            {
                case Command.L:
                    switch (MowerOrientation)
                    {
                        case Orientation.N:
                            MowerOrientation = Orientation.W;
                            break;
                        case Orientation.W:
                            MowerOrientation = Orientation.S;
                            break;
                        case Orientation.S:
                            MowerOrientation = Orientation.E;
                            break;
                        case Orientation.E:
                            MowerOrientation = Orientation.N;
                            break;
                    }
                    break;
                case Command.R:
                    switch (MowerOrientation)
                    {
                        case Orientation.N:
                            MowerOrientation = Orientation.E;
                            break;
                        case Orientation.E:
                            MowerOrientation = Orientation.S;
                            break;
                        case Orientation.S:
                            MowerOrientation = Orientation.W;
                            break;
                        case Orientation.W:
                            MowerOrientation = Orientation.N;
                            break;
                    }
                    break;
            }
        }

        public void MoveMower()
        {
            switch (MowerOrientation)
            {
                case Orientation.N:
                    MowerCoordinates.Y += 1;
                    break;
                case Orientation.W:
                    MowerCoordinates.X -= 1;
                    break;
                case Orientation.S:
                    MowerCoordinates.Y -= 1;
                    break;
                case Orientation.E:
                    MowerCoordinates.X += 1;
                    break;
                default:
                    throw new Exception("Invalid orientation");
            }
        }

        public bool isMouvementAllowed(Lawn lawnGrid) {
            Coordinates nextPosition = new Coordinates(this.MowerCoordinates.X, this.MowerCoordinates.Y);
            switch (MowerOrientation)
            {
                case Orientation.N:
                    nextPosition.Y += 1;
                    break;
                case Orientation.W:
                    nextPosition.X -= 1;
                    break;
                case Orientation.S:
                    nextPosition.Y -= 1;
                    break;
                case Orientation.E:
                    nextPosition.X += 1;
                    break;
                default:
                    throw new Exception("Invalid orientation");
            }
            return lawnGrid.IsPositionInsideLawn(nextPosition) && !lawnGrid.LawnGrid[nextPosition.X,nextPosition.Y].OccupiedByMown;
        }

        public override string ToString()
        {
            return MowerCoordinates.X + " " + MowerCoordinates.Y + " " + " " + MowerOrientation;
        }
    }
}