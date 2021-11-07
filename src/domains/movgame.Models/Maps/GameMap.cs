using System;

namespace movgame.Models.Maps
{
    /// <summary>
    /// マップ生成情報
    /// </summary>
    public class GameMap
    {
        
        #region フィールド
        private static string mark = LandMark.ROAD + LandMark.WALL + LandMark.PALYER + LandMark.ALIEN;

        #endregion

        #region メソッド
        /// <summary>
        /// マップ構築
        /// </summary>
        /// <returns></returns>
        public static int[,] MakeMap(LandMark landMark)
        {
            var row = landMark.GetRow();
            var col = landMark.GetCol();
            var map = new int[row, col];
            for (var i = 0; i < row; i++)
            {
                for (var j = 0; j < col; j++)
                {
                    map[i, j] = mark.IndexOf(landMark.MarkRows[i][j]);
                }
            }
            return map;
        }
        #endregion
    }
}
