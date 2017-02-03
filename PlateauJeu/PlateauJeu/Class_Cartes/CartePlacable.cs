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
        private int id;
        private bool m_l_HautBas;
        private bool m_l_GaucheDroite;
        protected bool m_l_HautDroite;
        protected bool m_l_HautGauche;
        protected bool m_l_BasDroite;
        protected bool m_l_BasGauche;
        protected bool m_haut;
        protected bool m_bas;
        protected bool m_droite;
        protected bool m_gauche;

        #region Accesseur
        public bool M_l_HautBas
        {
            get
            {
                return m_l_HautBas;
            }

            private set
            {
                m_l_HautBas = value;
            }
        }

        public bool M_l_GaucheDroite
        {
            get
            {
                return m_l_GaucheDroite;
            }

            private set
            {
                m_l_GaucheDroite = value;
            }
        }

        public bool M_l_HautDroite
        {
            get
            {
                return m_l_HautDroite;
            }

            private set
            {
                m_l_HautDroite = value;
            }
        }

        public bool M_l_BasDroite
        {
            get
            {
                return m_l_BasDroite;
            }

            private set
            {
                m_l_BasDroite = value;
            }
        }

        public bool M_bas
        {
            get
            {
                return m_bas;
            }

            private set
            {
                m_bas = value;
            }
        }

        public bool M_droite
        {
            get
            {
                return m_droite;
            }

            private set
            {
                m_droite = value;
            }
        }

        public bool M_hAut
        {
            get
            {
                return m_haut;
            }

            private set
            {
                m_haut = value;
            }
        }

        public bool M_l_gauche
        {
            get
            {
                return m_gauche;
            }

            private set
            {
                m_gauche = value;
            }
        }

        public int Id
        {
            get
            {
                return id;
            }

            private set
            {
                id = value;
            }
        }
        #endregion

        public CartePlacable(
            bool p_l_HautBas, bool p_l_GaucheDroite,
            bool p_l_HautDroite, bool p_l_HautGauche,
            bool p_l_BasDroite, bool p_l_BasGauche,
            Pepite p_Pepite = null) 
        {
            #region Initialisation liaisons
            m_l_HautBas = p_l_HautBas;
            m_l_GaucheDroite = p_l_GaucheDroite;
            m_l_HautGauche = p_l_HautGauche;
            m_l_HautDroite = p_l_HautDroite;
            m_l_BasGauche = p_l_BasGauche;
            m_l_BasDroite = p_l_BasDroite;
            #endregion

            #region Initialisation acces
            if (m_l_HautBas || m_l_HautDroite || m_l_HautGauche)
            {
                m_haut = true;
            }
            else
            {
                m_haut = false;
            }

            if (m_l_HautBas || m_l_BasDroite || m_l_BasGauche)
            {
                m_bas = true;
            }
            else
            {
                m_bas = false;
            }

            if (m_l_GaucheDroite || m_l_HautDroite || m_l_BasDroite)
            {
                m_droite = true;
            }
            else
            {
                m_droite = false;
            }

            if (m_l_GaucheDroite || m_l_HautGauche || m_l_BasGauche)
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
