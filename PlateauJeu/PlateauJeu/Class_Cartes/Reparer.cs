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
            m_outils = new List<Outils>();
            //A la construction on ajoute a la liste M_OUTILS les outils que la carte peut reparer
            foreach (Outils outil in p_outils)
                m_outils.Add(outil);
        }

        override
        public void Utiliser(object p_joueur)
        {
            try
            {
                Joueur v_joueur = (Joueur)p_joueur;
                //On repare chaque outil qui est possible d'être réparé
                foreach (Outils outil in m_outils)
                    v_joueur.Reparer(outil);
            }
            catch(InvalidCastException ex) { }
            
        }
    }
}
