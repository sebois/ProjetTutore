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

        public List<Outils> Outils
        {
            get
            {
                return m_outils;
            }

            set
            {
                m_outils = value;
            }
        }

        public OutilsBrises Utiliser(object p_joueur, Outils p_outil)
        {
            try
            {
                Joueur v_joueur = (Joueur)p_joueur;
                //On répare l'outil sélectionné
                return v_joueur.Reparer(p_outil);
            }
            catch (InvalidCastException ex)
            {
                return null;
            } 
        }
    }
}
