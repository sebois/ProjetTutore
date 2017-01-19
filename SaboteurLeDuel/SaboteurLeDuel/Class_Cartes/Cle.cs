using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaboteurLeDuel.Class_Cartes
{
    class Cle
    {
        public Cle()
        {

        }

        public Boolean utiliser(Porte p)
        {
            return p.ouvrir();
        }
    }
}
