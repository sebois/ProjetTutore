using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlateauJeu.Class_Cartes
{
    abstract class CartePlacable : Carte
    {
        protected Pepite m_Pepite;
        protected int id;
        private bool l_HautBas;
        private bool l_GaucheDroite;
        protected bool m_l_HautDroite;
        protected bool m_l_HautGauche;
        protected bool m_l_BasDroite;
        protected bool m_l_BasGauche;
        protected bool m_haut;
        protected bool m_bas;
        protected bool m_droite;
        protected bool m_gauche;

        protected bool L_HautBas
        {
            get
            {
                return l_HautBas;
            }

            private set
            {
                l_HautBas = value;
            }
        }

        protected bool L_GaucheDroite
        {
            get
            {
                return l_GaucheDroite;
            }

            set
            {
                l_GaucheDroite = value;
            }
        }

        public CartePlacable(
            bool p_l_HautBas, bool p_l_GaucheDroite,
            bool p_l_HautDroite, bool p_l_HautGauche,
            bool p_l_BasDroite, bool p_l_BasGauche,
            Pepite p_Pepite = null) 
        {
            #region Initialisation liaisons
            L_HautBas = p_l_HautBas;
            L_GaucheDroite = p_l_GaucheDroite;
            m_l_HautGauche = p_l_HautGauche;
            m_l_HautDroite = p_l_HautDroite;
            m_l_BasGauche = p_l_BasGauche;
            m_l_BasDroite = p_l_BasDroite;
            #endregion

            #region Initialisation acces
            if (L_HautBas || m_l_HautDroite || m_l_HautGauche)
            {
                m_haut = true;
            }
            else
            {
                m_haut = false;
            }

            if (L_HautBas || m_l_BasDroite || m_l_BasGauche)
            {
                m_bas = true;
            }
            else
            {
                m_bas = false;
            }

            if (L_GaucheDroite || m_l_HautDroite || m_l_BasDroite)
            {
                m_droite = true;
            }
            else
            {
                m_droite = false;
            }

            if (L_GaucheDroite || m_l_HautGauche || m_l_BasGauche)
            {
                m_gauche = true;
            }
            else
            {
                m_gauche = false;
            }
            #endregion

            #region initialisation pepites
            if (p_Pepite != null)
            {
                m_Pepite = p_Pepite;
            }
            #endregion

            #region initialisation du type
            if (((p_l_BasDroite && p_l_HautGauche) || (p_l_BasGauche && p_l_HautDroite)) && (!p_l_HautBas))
            {
                m_type = "Double-virage";
            }
            if (p_l_HautBas && p_l_GaucheDroite && !p_l_HautDroite)
            {
                m_type = "Pont";
            }
            #endregion
        }

        public void placer(int x, int y)
        {
            new Exception("CarteChemin placée : non implémenté");
        }

        public bool verifPlacement(int x, int y)
        {
            new Exception("CarteChemin verifPlacement : non implémenté");
            return false;
        }
    }
}
