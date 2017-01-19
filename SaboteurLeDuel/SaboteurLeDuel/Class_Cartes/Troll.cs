using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaboteurLeDuel.Class_Cartes
{
    class Troll : CarteChemin
    {
        private String position;
        private Boolean ouvert;

        public Troll(Boolean hb, Boolean gd, Boolean hg, Boolean hd, Boolean bg, Boolean bd, String pos) : base(hb, gd, hg, hd, bg, bd, false)
        {
            position = pos;
            ouvert = false;
        }
    }
}
