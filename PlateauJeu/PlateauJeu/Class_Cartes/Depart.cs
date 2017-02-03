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

        public Depart(
            System.Drawing.Bitmap p_imgRecto,
            string p_couleurJoueur,
            bool p_l_HautBas = false, bool p_l_GaucheDroite = false,
            bool p_l_HautDroite = false, bool p_l_HautGauche = false,
            bool p_l_BasDroite = false, bool p_l_BasGauche = false,
            bool p_haut = false, bool p_bas = false,
            bool p_droite = false, bool p_gauche = false) : base(
                p_imgRecto, 
                p_l_HautBas, p_l_GaucheDroite, 
                p_l_HautDroite, p_l_HautGauche, 
                p_l_BasDroite, p_l_BasGauche,
                p_haut, p_bas,
                p_droite, p_gauche)
        {
            m_couleurJoueur = p_couleurJoueur;
            m_type = "Depart";
        }
    }
}
