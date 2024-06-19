using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlateauJeu.Class_Cartes
{
    /// <summary>
    /// Classe CarteChemin héritant de CartePlacable
    /// </summary>
    class CarteChemin : CartePlacable
    {
        #region Attributs
        /// <summary>
        /// Objet Troll si l'objet est présent
        /// </summary>
        private Troll m_Troll;

        /// <summary>
        /// Objet Echelle si l'objet est présent
        /// </summary>
        private Echelle m_Echelle;
        #endregion

        #region Accesseurs
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
        #endregion

        #region Constructeur
        /// <summary>
        /// Constructeur de la CarteChemin (paramètres initialisés à false ou null sauf p_imgRecto)
        /// </summary>
        /// <param name="p_imgRecto">Image de la carte</param>
        /// <param name="p_l_HautBas">Etat de la liaison HautBas</param>
        /// <param name="p_l_GaucheDroite">Etat de la liaison GaucheDroite</param>
        /// <param name="p_l_HautDroite">Etat de la liaison HautDroite</param>
        /// <param name="p_l_HautGauche">Etat de la liaison HautGauche</param>
        /// <param name="p_l_BasDroite">Etat de la liaison BasDroite</param>
        /// <param name="p_l_BasGauche">Etat de la liaison BasGauche</param>
        /// <param name="p_haut">Etat de l'entrée/sortie Haut</param>
        /// <param name="p_bas">Etat de l'entrée/sortie Bas</param>
        /// <param name="p_droite">Etat de l'entrée/sortie Droite</param>
        /// <param name="p_gauche">Etat de l'entrée/sortie Gauche</param>
        /// <param name="p_Pepite">Objet Pepite si l'objet est présent</param>
        /// <param name="p_Porte">Objet Porte si l'objet est présent</param>
        /// <param name="p_Troll">Objet Troll si l'objet est présent</param>
        /// <param name="p_Echelle">Objet Echelle si l'objet est présent</param>
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
                p_Pepite,
                p_Porte)
        {
            #region initialisation du type
            if (p_Porte != null)
            {
                m_Porte = p_Porte;
                m_type = Types.Porte;
            }
            else if (p_Troll != null)
            {
                m_Troll = p_Troll;
                m_type = Types.Troll;
            }
            else if (p_Echelle != null)
            {
                m_Echelle = p_Echelle;
                m_type = Types.Echelle;
            }
            #endregion

        }
        #endregion

        #region Méthodes
        /// <summary>
        /// Rotation de la carte
        /// </summary>
        public void Rotation()
        {
            #region Init tempo
            bool tempo;
            #endregion

            #region Inversement HautGauche BasDroite
            tempo = m_l_HautGauche;
            m_l_HautGauche = m_l_BasDroite;
            m_l_BasDroite = tempo;
            #endregion

            #region Inversement HautDroite BasGauche
            tempo = m_l_HautDroite;
            m_l_HautDroite = m_l_BasGauche;
            m_l_BasGauche = tempo;
            #endregion

            #region Inversement Haut Bas
            tempo = m_haut;
            m_haut = m_bas;
            m_bas = tempo;
            #endregion

            #region Inversement Gauche Droite
            tempo = m_gauche;
            m_gauche = m_droite;
            m_droite = tempo;
            #endregion

            #region Changement position Porte
            if (m_Porte != null)
            {
                switch (m_Porte.Position)
                {
                    case Position.Haut:
                        m_Porte.Position = Position.Bas;
                        break;
                    case Position.Droite:
                        m_Porte.Position = Position.Gauche;
                        break;
                    case Position.Bas:
                        m_Porte.Position = Position.Haut;
                        break;
                    case Position.Gauche:
                        m_Porte.Position = Position.Droite;
                        break;
                }
            }
            #endregion

            #region Changement position Pepite
            if (m_Pepite != null)
            {
                switch (m_Pepite.Position)
                {
                    case Position.Haut:
                        m_Pepite.Position = Position.Bas;
                        break;
                    case Position.Droite:
                        m_Pepite.Position = Position.Gauche;
                        break;
                    case Position.Bas:
                        m_Pepite.Position = Position.Haut;
                        break;
                    case Position.Gauche:
                        m_Pepite.Position = Position.Droite;
                        break;
                }
            }
            #endregion
        }

        public void retirer()
        {
            new Exception("CarteChemin retirée : non implémenté");
        }
        #endregion
    }
}
