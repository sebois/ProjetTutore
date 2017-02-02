using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlateauJeu.Class_Cartes
{
    class Depart : CartePlacable
    {
        private string m_couleurJoueur;

        public Depart(string p_couleurJoueur,
            bool p_l_HautBas, bool p_l_GaucheDroite,
            bool p_l_HautDroite, bool p_l_HautGauche,
            bool p_l_BasDroite, bool p_l_BasGauche) : base(p_l_HautBas, p_l_GaucheDroite, p_l_HautDroite, p_l_HautGauche, p_l_BasDroite, p_l_BasGauche)
        {
            m_couleurJoueur = p_couleurJoueur;
            m_type = "Depart";
        }
    }
}
