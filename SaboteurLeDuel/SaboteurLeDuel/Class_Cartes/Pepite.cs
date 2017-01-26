using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaboteurLeDuel.Class_Cartes
{
    class Pepite
    {
        private Byte nbPepite;

        public Pepite(Boolean hb, Boolean gd, Boolean hg, Boolean hd, Boolean bg, Boolean bd, Boolean obj, Byte p) : base(hb, gd, hg, hd, bg, bd, obj)
        {
            nbPepite = p;
        }
    }
}
