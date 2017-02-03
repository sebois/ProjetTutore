using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlateauJeu.Class_Cartes
{
    class CarteChemin : CartePlacable
    {
        private Porte m_Porte;
        private Troll m_Troll;
        private Echelle m_Echelle;

        internal Porte Porte
        {
            get
            {
                return m_Porte;
            }

            set
            {
                m_Porte = value;
            }
        }

        internal Troll Troll
        {
            get
            {
                return m_Troll;
            }

            set
            {
                m_Troll = value;
            }
        }

        internal Echelle Echelle
        {
            get
            {
                return m_Echelle;
            }

            set
            {
                m_Echelle = value;
            }
        }

        public CarteChemin(
            System.Drawing.Bitmap p_imgRecto,
            bool p_l_HautBas = false, bool p_l_GaucheDroite = false,
            bool p_l_HautDroite = false, bool p_l_HautGauche = false,
            bool p_l_BasDroite = false, bool p_l_BasGauche = false,
            bool p_haut = false, bool p_bas = false,
            bool p_droite = false, bool p_gauche = false,
            Pepite p_Pepite = null, 
            Porte p_Porte = null, 
            Troll p_Troll = null,
            Echelle p_Echelle = null) : base(
                p_imgRecto, 
                p_l_HautBas, p_l_GaucheDroite, 
                p_l_HautDroite, p_l_HautGauche, 
                p_l_BasDroite, p_l_BasGauche,
                p_haut, p_bas,
                p_droite, p_gauche,
                p_Pepite)
        {

            #region initialisation du type
            if (p_Porte != null)
            {
                m_Porte = p_Porte;
                m_type = "Porte";
            }
            else if (p_Troll != null)
            {
                m_Troll = p_Troll;
                m_type = "Troll";
            }
            else if (p_Echelle != null)
            {
                m_Echelle = p_Echelle;
                m_type = "Echelle";
            }
            #endregion

        }

        public void Rotation()
        {
            #region Rotation180
            bool tempo;

            tempo = m_l_HautGauche;
            m_l_HautGauche = m_l_BasDroite;
            m_l_BasDroite = tempo;

            tempo = m_l_HautDroite;
            m_l_HautDroite = m_l_BasGauche;
            m_l_BasGauche = tempo;

            tempo = m_haut;
            m_haut = m_bas;
            m_bas = tempo;

            tempo = m_gauche;
            m_gauche = m_droite;
            m_droite = tempo;
            #endregion

        }

        public void retirer()
        {
            new Exception("CarteChemin retirée : non implémenté");
        }       
    }
}
