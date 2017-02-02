using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlateauJeu.Class_Cartes
{
    class CarteObjectif : CartePlacable
    {
        private bool m_decouvert;

        public CarteObjectif(
            string p_type,
            bool p_l_HautBas, bool p_l_GaucheDroite, 
            bool p_l_HautDroite, bool p_l_HautGauche, 
            bool p_l_BasDroite, bool p_l_BasGauche,
            Pepite p_Pepite = null) : base(p_l_HautBas, p_l_GaucheDroite, p_l_HautDroite, p_l_HautGauche, p_l_BasDroite, p_l_BasGauche, p_Pepite)
        {
            m_decouvert = false;
        }
    }
}
