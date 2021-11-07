using movgame.Models.Maps;
using System;
using System.Collections.Generic;
using System.Text;

namespace movgame.Repository
{
    public interface ILandMarkRepository
    {
        IDictionary<int, LandMark> Get();
    }
}
