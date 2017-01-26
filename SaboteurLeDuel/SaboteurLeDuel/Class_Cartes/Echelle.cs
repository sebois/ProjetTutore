using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaboteurLeDuel.Class_Cartes
{
    class Echelle : CarteChemin
    {
        private Byte joueur;

        public Echelle(Boolean hb, Boolean gd, Boolean hg, Boolean hd, Boolean bg, Boolean bd, byte j) : base(hb, gd,hg,hd,bg,bd,false)
        {
            joueur = j;
        }
    }
}
