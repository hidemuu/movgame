using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace movgame.Wpf.Models
{
    public class ConfigModel
    {
        public ReactivePropertySlim<int> Index { get; } = new ReactivePropertySlim<int>();
    }
}
