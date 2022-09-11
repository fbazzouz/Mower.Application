namespace Mower.Application.Models
{
    public class Lawn {
        public int RightMaxCoordinate { get; set;}
        public int TopMaxCoordinate { get; set;}

        public Lawn(int rightMaxCoordinate, int topMaxCoordinate)
        {
            RightMaxCoordinate = rightMaxCoordinate;
            TopMaxCoordinate = topMaxCoordinate;
        }

        public bool IsPositionInsideLawn(Coordinates position)
        {
            return position.X >= 0
                && position.X <= RightMaxCoordinate
                && position.Y >= 0
                && position.Y <= TopMaxCoordinate;
        }
    }
}