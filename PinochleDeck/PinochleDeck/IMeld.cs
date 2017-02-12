using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinochleDeck
{
    public interface IMeld
    {
        MeldType MeldType { get; set; }
        MeldCombination MeldCombination { get; set; }
        int Multiplier { get; set; }
    }
}
