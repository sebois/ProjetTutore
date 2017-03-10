using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlateauJeu.Class_Cartes
{
    class Cle : Action
    {
        public Cle(System.Drawing.Bitmap p_imgRecto): base(p_imgRecto)
        {

        }

        public bool utiliser(Porte p)
        {
            return p.ouvrir();
        }
    }
}
