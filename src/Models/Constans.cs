namespace Mower.Application.Models
{
    public static class Constants{
        public const string LAWN_SIZE_REGEX = @"^(\d+)\s*(\d+)$";
        public const string MOWER_POSITION_REGEX = @"^(\d+) (\d+) ([NEWS])$";
        
    }
    public enum Orientation { N, E, S, W }
    public enum Command { L, R, F }
}
