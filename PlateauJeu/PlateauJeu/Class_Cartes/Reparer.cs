using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlateauJeu.Class_Cartes
{
    class Reparer : Action
    {
        private List<Outils> m_outils;

        public Reparer(System.Drawing.Bitmap p_imgRecto, List<Outils> p_outils) : base(p_imgRecto)
        {
            //A la construction on ajoute a la liste M_OUTILS les outils que la carte peut reparer
            foreach (Outils outil in p_outils)
                m_outils.Add(outil);
        }

        public void Utiliser(Joueur joueur)
        {
            //On repare chaque outil qui est possible d'être réparé
            foreach (Outils outil in m_outils)
                joueur.Reparer(outil);
        }
    }
}
