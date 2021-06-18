using System.Drawing;

namespace GeminiChessServer
{
    class Utils
    {
        public const int NUMBER_OF_ROWS = 8;
        public const int NUMBER_OF_COLLUMNS = 10;
        public static Color BLACK = Color.FromArgb(207, 137, 72);
        public static Color WHITE = Color.FromArgb(255, 204, 156);

        public static string[] yCoordinates = { "8", "7", "6", "5", "4", "3", "2", "1" };
        public static string[] xCoordinates = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j" };
    }
}
