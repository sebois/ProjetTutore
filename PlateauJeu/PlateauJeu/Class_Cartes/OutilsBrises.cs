using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlateauJeu.Class_Cartes
{
    class OutilsBrises : Action
    {
        private Outils m_outils;

        public OutilsBrises(System.Drawing.Bitmap p_imgRecto, Outils p_outils): base(p_imgRecto)
        {
            m_outils = p_outils;
        }

        public void Utiliser(Joueur joueur)
        {
            joueur.Briser(m_outils);
        }


    }
}
