using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaboteurLeDuel.Class_Cartes
{
    class Reparer : Action
    {
        private Outils outils;

        public Reparer(Outils type)
        {
            outils = type;
        }
    }
}
