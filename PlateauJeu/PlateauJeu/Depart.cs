using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaboteurLeDuel
{
    class Depart : CarteChemin
    {
        private Byte joueur;

        public Depart(Boolean hb, Boolean gd, Boolean hg, Boolean hd, Boolean bg, Boolean bd, Boolean obj, Byte j) : base(hb,gd,hg,hd,bg,bd,obj)
        {
            joueur = j;
        }
    }
}
