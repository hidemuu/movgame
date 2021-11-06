using movgame.Models;
using movgame.Models.Characters;
using movgame.Models.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace movgame.Models
{
    public class GameEngine
    {
        #region 定数

        public const int KEY_CODE_LEFT = 37;
        public const int KEY_CODE_RIGHT = 39;
        public const int KEY_CODE_UP = 38;
        public const int KEY_CODE_DOWN = 40;

        #endregion

        #region フィールド
        /// <summary>
        /// ユニット幅
        /// </summary>
        public int unitWidth = 40;
        /// <summary>
        /// ユニット高さ
        /// </summary>
        public int unitHeight = 40;
        /// <summary>
        /// 入力キーコード
        /// </summary>
        public int keyCode = 0;
        /// <summary>
        /// キャラクタ配列
        /// </summary>
        public List<CharacterBase> characters;
        /// <summary>
        /// 敵キャラ配列
        /// </summary>
        public List<Alien> aliens;
        /// <summary>
        /// マップ情報
        /// </summary>
        public int[,] map;
        #endregion

        public GameEngine()
        {
            characters = new List<CharacterBase>();
            aliens = new List<Alien>();
        }

        #region メソッド

        /// <summary>
        /// 初期化処理
        /// </summary>
        public virtual void Initialize()
        {
            map = GameMap.MakeMap();
            AddCharacters(characters, map);
            SortCharacters(new int[] { CharacterBase.WALL, CharacterBase.ALIEN, CharacterBase.PLAYER });
        }

        /// <summary>
        /// キャラクターソート
        /// </summary>
        /// <param name="order">描画順</param>
        public void SortCharacters(int[] order)
        {
            var dic = new Dictionary<int, int>();
            var val = 0;
            foreach (var t in order)
            {
                dic.Add(t, val++);
            }
            characters.Sort(delegate (CharacterBase x, CharacterBase y)
            {
                var dif = dic[x.TypeCode] - dic[y.TypeCode];
                if (dif > 0) return 1;
                else if (dif < 0) return -1;
                return 0;
            });
        }

        /// <summary>
        /// マップからキャラクターを追加
        /// </summary>
        /// <param name="characters"></param>
        /// <param name="map"></param>
        protected void AddCharacters(List<CharacterBase> characters, int[,] map)
        {
            var row = map.GetLength(0);
            var col = map.GetLength(1);
            for (var r = 0; r < row; r++)
            {
                for (var c = 0; c < col; c++)
                {
                    var type = map[r, c];
                    if (type != CharacterBase.ROAD)
                    {
                        var character = MakeCharacter(type);
                        character.SetPos(c * unitWidth, r * unitHeight);
                        characters.Add(character);
                        if (type == CharacterBase.ALIEN)
                        {
                            aliens.Add((Alien)character);
                        }
                    }
                }
            }
        }
        /// <summary>
        /// キャラクターを追加
        /// </summary>
        /// <param name="characters"></param>
        /// <param name="targets"></param>
        protected void AddCharacters(List<CharacterBase> characters, CharacterBase[] targets)
        {
            foreach (var target in targets)
            {
                characters.Add(target);
            }
        }
        /// <summary>
        /// キャラクターを追加
        /// </summary>
        /// <param name="characters"></param>
        /// <param name="character"></param>
        protected void AddCharacters(List<CharacterBase> characters, CharacterBase character)
        {
            characters.Add(character);
        }
        /// <summary>
        /// キャラクターを生成
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        protected virtual CharacterBase MakeCharacter(int type)
        {
            switch (type)
            {
                case CharacterBase.WALL: return new Wall(this);
                case CharacterBase.PLAYER: return new Player(this);
                case CharacterBase.ALIEN: return new Alien(this);
                default: return null;
            }
        }
        /// <summary>
        /// 壁判定
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool IsWall(int x, int y)
        {
            var row1 = y / unitHeight;
            var col1 = x / unitWidth;
            var row2 = (y + unitHeight - 1) / unitHeight;
            var col2 = (x + unitWidth - 1) / unitWidth;
            return map[row1, col1] == CharacterBase.WALL ||
                   map[row1, col2] == CharacterBase.WALL ||
                   map[row2, col1] == CharacterBase.WALL ||
                   map[row2, col2] == CharacterBase.WALL;
        }
        /// <summary>
        /// 衝突検出
        /// </summary>
        /// <param name="target"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int GetCollision(CharacterBase target, int x, int y)
        {
            foreach (var character in characters)
            {
                if (character.TypeCode > CharacterBase.WALL && character != target)
                {
                    if (Math.Abs(character.X - x) < unitWidth && Math.Abs(character.Y - y) < unitHeight)
                    {
                        return character.TypeCode;
                    }
                }
            }
            return -1;
        }

        #endregion

    }
}
