using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlateauJeu.Class_Cartes
{
    abstract class CartePlacable : Carte
    {
        protected int id;
        protected bool m_l_HautBas;
        protected bool m_l_GaucheDroite;
        protected bool m_l_HautDroite;
        protected bool m_l_HautGauche;
        protected bool m_l_BasDroite;
        protected bool m_l_BasGauche;
        protected bool m_haut;
        protected bool m_bas;
        protected bool m_droite;
        protected bool m_gauche;

        public CartePlacable(
            System.Drawing.Bitmap p_imgRecto,
            bool p_l_HautBas = false, bool p_l_GaucheDroite = false,
            bool p_l_HautDroite = false, bool p_l_HautGauche = false,
            bool p_l_BasDroite = false, bool p_l_BasGauche = false,
            bool p_haut = false, bool p_bas = false,
            bool p_droite = false, bool p_gauche = false) : base(p_imgRecto)
        {
            #region Initialisation image recto
            m_imgRecto = p_imgRecto;
            #endregion

            #region Initialisation liaisons
            m_l_HautBas = p_l_HautBas;
            m_l_GaucheDroite = p_l_GaucheDroite;
            m_l_HautGauche = p_l_HautGauche;
            m_l_HautDroite = p_l_HautDroite;
            m_l_BasGauche = p_l_BasGauche;
            m_l_BasDroite = p_l_BasDroite;
            #endregion

            #region Initialisation acces
            m_haut = p_haut;
            m_bas = p_bas;
            m_droite = p_droite;
            m_gauche = p_gauche;
            if (m_l_HautBas || m_l_HautDroite || m_l_HautGauche)
            {
                m_haut = true;
            }

            if (m_l_HautBas || m_l_BasDroite || m_l_BasGauche)
            {
                m_bas = true;
            }

            if (m_l_GaucheDroite || m_l_HautDroite || m_l_BasDroite)
            {
                m_droite = true;
            }

            if (m_l_GaucheDroite || m_l_HautGauche || m_l_BasGauche)
            {
                m_gauche = true;
            }

            #endregion

            #region initialisation du type
            if (((p_l_BasDroite && p_l_HautGauche) || (p_l_BasGauche && p_l_HautDroite)) && (!p_l_HautBas))
            {
                m_type = Types.DoubleVirage;
            }
            if (p_l_HautBas && p_l_GaucheDroite && !p_l_HautDroite)
            {
                m_type = Types.Pont;
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
