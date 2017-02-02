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
            bool p_l_HautBas, bool p_l_GaucheDroite, 
            bool p_l_HautDroite, bool p_l_HautGauche, 
            bool p_l_BasDroite, bool p_l_BasGauche, 
            Pepite p_Pepite = null, 
            Porte p_Porte = null, 
            Troll p_Troll = null,
            Echelle p_Echelle = null) : base(p_l_HautBas, p_l_GaucheDroite, p_l_HautDroite, p_l_HautGauche, p_l_BasDroite, p_l_BasGauche, p_Pepite)
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
