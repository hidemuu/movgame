using System;

namespace movgame.Maps
{
    public class GameMap
    {
        static int[,] map;
        static string mark = "＿＃○＠";
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

        static public int[,] MakeMap()
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
