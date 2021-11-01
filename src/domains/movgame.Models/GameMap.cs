using System;

namespace movgame.Models
{
    public class GameMap
    {
        public const string ROAD = "＿";
        public const string WALL = "＃";
        public const string PALYER = "○";
        public const string ALIEN = "＠";

        static int[,] map;
        static string mark =  ROAD + WALL + PALYER + ALIEN;
        static string[] mapData =
        {
            "＃＃＃＃＃＃＃＃＃＃＃＃",
            "＃＠＿＿＿＿＃＃＿＿＠＃",
            "＃＿＃＿＃＿＿＿＿＃＿＃",
            "＃＿＃＿＃＃＿＃＃＃＿＃",
            "＃＿＿＿＿＃＿＃＿＿＿＃",
            "＃＃＿＿＿＿＿＃＿＃＃＃",
            "＃＿＿＿＃＿＿＿＿＿＿＃",
            "＃＿＃＿＃＃＃＿＃＃＿＃",
            "＃＿＃＿＿＿＿＿＿＃＿＃",
            "＃＿＃＃＿＃＿＃＿＃＿＃",
            "＃＠＿＿＿＃＿＿＿＿○＃",
            "＃＃＃＃＃＃＃＃＃＃＃＃",
        };

        public static int r = mapData.Length;
        public static int c = mapData[0].Length;

        public static int[,] MakeMap()
        {
            map = new int[r, c];
            for (var i = 0; i < r; i++)
            {
                for (var j = 0; j < c; j++)
                {
                    map[i, j] = mark.IndexOf(mapData[i][j]);
                }
            }
            return map;
        }
    }
}
