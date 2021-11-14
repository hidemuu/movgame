using movgame.Models.Maps;
using System;
using System.Collections.Generic;
using System.Text;

namespace movgame.Repository.InMemory
{
    public class InMemoryLandMarkRepository : ILandMarkRepository
    {
        public IDictionary<int, LandMark> Get()
        {
            var result = new Dictionary<int, LandMark>();
            result.Add(0, new LandMark
            {
                MarkRows = new string[] {
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
                }
            });
            result.Add(1, new LandMark
            {
                MarkRows = new string[] {
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
                }
            });
            result.Add(2, new LandMark
            {
                MarkRows = new string[] {
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
                }
            });
            return result;
        }
    }
}
