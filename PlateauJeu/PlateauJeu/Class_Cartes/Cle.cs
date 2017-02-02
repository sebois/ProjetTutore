using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlateauJeu.Class_Cartes
{
    class Cle
    {
        public Cle()
        {

        }

        public bool utiliser(Porte p)
        {
            return p.ouvrir();
        }
    }
}
