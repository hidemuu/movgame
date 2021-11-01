using movgame.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace movgame.WinForm.ViewModels
{
    public class Game
    {

        #region フィールド
        public int uw = 40, uh = 40;
        public Keys keyCode = 0;
        public List<GameElem> elems;
        public List<Alien> aliens;
        public int[,] map;

        int w, h;
        Task task;
        bool active = true;
        Bitmap screenBmp;
        bool building = false;
        Form form;
        #endregion

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Game(Form form)
        {
            this.form = form;
            w = GameMap.c * uw;
            h = GameMap.r * uh;
            this.form.ClientSize = new Size(w, h);
            screenBmp = new Bitmap(w, h);
            elems = new List<GameElem>();
            aliens = new List<Alien>();
        }

        /// <summary>
        /// 初期化処理
        /// </summary>
        public virtual void Init()
        {
            map = GameMap.MakeMap();
            AddElems(elems, map);
            SortElems(new int[] { GameElem.WALL, GameElem.ALIEN, GameElem.PLAYER });
        }

        /// <summary>
        /// キャラクターソート
        /// </summary>
        /// <param name="order"></param>
        public void SortElems(int[] order)
        {
            var dic = new Dictionary<int, int>();
            var val = 0;
            foreach (var t in order)
            {
                dic.Add(t, val++);
            }
            elems.Sort(delegate (GameElem x, GameElem y)
            {
                var dif = dic[x.typ] - dic[y.typ];
                if (dif > 0) return 1;
                else if (dif < 0) return -1;
                return 0;
            });
        }

        /// <summary>
        /// 起動処理
        /// </summary>
        public void Run()
        {
            Init();
            var g = Graphics.FromImage(screenBmp);

            task = Task.Run(() => 
            {
                var sw = Stopwatch.StartNew();
                sw.Start();
                while (active)
                {
                    foreach (var e in elems)
                    {
                        if (e.typ >= GameElem.PLAYER) e.Move();
                    }
                    building = true;
                    g.Clear(this.form.BackColor);
                    foreach(var e in elems)
                    {
                        if (e.typ != GameElem.ROAD) e.Draw(g);
                    }
                    building = false;
                    this.form.Invalidate();
                    while (sw.ElapsedMilliseconds < 10) ;
                    sw.Restart();
                }
                g.Dispose();
            });
        }

        /// <summary>
        /// 終了処理
        /// </summary>
        public void End()
        {
            active = false;
            task.Wait();
        }

        /// <summary>
        /// 描画処理
        /// </summary>
        /// <param name="g"></param>
        public void Draw(Graphics g)
        {
            if (building) return;
            g.DrawImage(screenBmp, 0, 0);
        }

        public void Draw()
        {

        }

        /// <summary>
        /// キャラクター追加
        /// </summary>
        /// <param name="elems"></param>
        /// <param name="m"></param>
        protected void AddElems(List<GameElem> elems, int[,] m)
        {
            var row = m.GetLength(0);
            var col = m.GetLength(1);
            for (var r = 0; r < row; r++)
            {
                for (var c = 0; c < col; c++)
                {
                    var typ = m[r, c];
                    if (typ != GameElem.ROAD)
                    {
                        var e = MakeElem(typ);
                        e.SetPos(c * uw, r * uh);
                        elems.Add(e);
                        if (typ == GameElem.ALIEN)
                        {
                            aliens.Add((Alien)e);
                        }
                    }
                }
            }
        }

        protected void AddElems(List<GameElem> elems, GameElem[] targets)
        {
            foreach (var e in targets)
            {
                elems.Add(e);
            }
        }

        protected void AddElems(List<GameElem> elems, GameElem e)
        {
            elems.Add(e);
        }

        protected virtual GameElem MakeElem(int typ)
        {
            switch (typ)
            {
                case GameElem.WALL: return new Wall(this);
                case GameElem.PLAYER: return new Player(this);
                case GameElem.ALIEN: return new Alien(this);
                default: return null;
            }
        }

        public bool IsWall(int x, int y)
        {
            var r1 = y / uh;
            var c1 = x / uw;
            var r2 = (y + uh - 1) / uh;
            var c2 = (x + uw - 1) / uw;
            return map[r1, c1] == GameElem.WALL ||
                   map[r1, c2] == GameElem.WALL ||
                   map[r2, c1] == GameElem.WALL ||
                   map[r2, c2] == GameElem.WALL;
        }

        public int GetCollision(GameElem me, int x, int y)
        {
            foreach (var other in elems)
            {
                if (other.typ > GameElem.WALL && other != me)
                {
                    if (Math.Abs(other.x - x) < uw && Math.Abs(other.y - y) < uh)
                    {
                        return other.typ;
                    }
                }
            }
            return -1;
        }
    }
}
