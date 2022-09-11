namespace Mower.Application.Models
{
    public class Lawn {
        public int RightMaxCoordinate { get; set;}
        public int TopMaxCoordinate { get; set;}
        public LawnCell[,] LawnGrid;
        public Lawn(int rightMaxCoordinate, int topMaxCoordinate)
        {
            RightMaxCoordinate = rightMaxCoordinate;
            TopMaxCoordinate = topMaxCoordinate;
            LawnGrid = initializeGrid(rightMaxCoordinate + 1, topMaxCoordinate + 1);
        }

        private LawnCell[,] initializeGrid(int width, int height) {
        LawnCell[,] grid = new LawnCell[width, height];
        for (int i = 0; i < width; i++) {
            for (int j = 0; j < height; j++) {
                grid[i, j] = new LawnCell();
            }
        }

        return grid;
    }

        public bool IsPositionInsideLawn(Coordinates position)
        {
            return position.X >= 0
                && position.X <= RightMaxCoordinate
                && position.Y >= 0
                && position.Y <= TopMaxCoordinate;
        }

        public void placeMower(MowerElement mower) {
            if (!this.LawnGrid[mower.MowerCoordinates.X, mower.MowerCoordinates.Y].OccupiedByMown) {
                this.LawnGrid[mower.MowerCoordinates.X, mower.MowerCoordinates.Y].OccupiedByMown = true;
            }
        }
    }
}