namespace Snake
{
    public enum Direction { Up, Down, Left, Right};
    public class GameSettings
    {
        public static int Width { get; set; }
        public static int Height { get; set; }
        public static int Speed { get; set; }
        public static int Score { get; set; }
        public static int Points { get; set; }
        public static bool Gameover { get; set; }
        public static Direction Directions { get; set; }


        public GameSettings()
        {
            Width = 16;
            Height = 16;
            Speed = 16;
            Score = 0;
            Points = 10;
            Gameover = false;
            Directions = Direction.Down;
        }
    }
}
