using System;

namespace movgame.Models.Maps
{
    /// <summary>
    /// マップ生成情報
    /// </summary>
    public class GameMap
    {
        #region 定数
        /// <summary>
        /// 道
        /// </summary>
        public const string ROAD = "＿";
        /// <summary>
        /// 壁
        /// </summary>
        public const string WALL = "＃";
        /// <summary>
        /// プレイヤー
        /// </summary>
        public const string PALYER = "○";
        /// <summary>
        /// NPC
        /// </summary>
        public const string ALIEN = "＠";
        #endregion

        #region フィールド
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

        /// <summary>
        /// 行サイズ
        /// </summary>
        public static int row = mapData.Length;
        /// <summary>
        /// 列サイズ
        /// </summary>
        public static int col = mapData[0].Length;
        #endregion

        #region メソッド
        /// <summary>
        /// マップ構築
        /// </summary>
        /// <returns></returns>
        public static int[,] MakeMap()
        {
            map = new int[row, col];
            for (var i = 0; i < row; i++)
            {
                for (var j = 0; j < col; j++)
                {
                    map[i, j] = mark.IndexOf(mapData[i][j]);
                }
            }
            return map;
        }
        #endregion
    }
}
