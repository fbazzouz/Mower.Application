namespace Mower.Application.Models
{
    public class MowerElement
    {
        public Orientation MowerOrientation { get; set; }
        public Coordinates MowerCoordinates { get; set; }
        public LinkedList<Command> Commands = new LinkedList<Command>();
        public MowerElement(Orientation orientation, int x, int y)
        {
            MowerOrientation = orientation;
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
                    switch (this.MowerOrientation)
                    {
                        case Orientation.N:
                            this.MowerOrientation = Orientation.W;
                            break;
                        case Orientation.W:
                            this.MowerOrientation = Orientation.S;
                            break;
                        case Orientation.S:
                            this.MowerOrientation = Orientation.E;
                            break;
                        case Orientation.E:
                            this.MowerOrientation = Orientation.N;
                            break;
                    }
                    break;
                case Command.R:
                    switch (this.MowerOrientation)
                    {
                        case Orientation.N:
                            this.MowerOrientation = Orientation.E;
                            break;
                        case Orientation.E:
                            this.MowerOrientation = Orientation.S;
                            break;
                        case Orientation.S:
                            this.MowerOrientation = Orientation.W;
                            break;
                        case Orientation.W:
                            this.MowerOrientation = Orientation.N;
                            break;
                    }
                    break;
            }
        }

        public Coordinates MoveMower()
        {
            Coordinates nextPosition = new Coordinates(this.MowerCoordinates.X, this.MowerCoordinates.Y);
            switch (this.MowerOrientation)
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
            return nextPosition;
        }

        public override string ToString()
        {
            return MowerCoordinates.X + " " + MowerCoordinates.Y + " " + " " + MowerOrientation;
        }
    }
}