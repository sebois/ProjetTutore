using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlateauJeu.Class_Cartes
{
    /// <summary>
    /// Classe abstraite CartePlacable héritant de Carte
    /// </summary>
    abstract class CartePlacable : Carte
    {
        #region Attributs
        /// <summary>
        /// Identifiant unique de la carte
        /// </summary>
        protected int m_id;

        /// <summary>
        /// Numéro de colonne de la carte sur le plateau
        /// </summary>
        protected int m_colonnePlateau;

        /// <summary>
        /// Numéro de ligne de la carte sur le plateau
        /// </summary>
        protected int m_lignePlateau;

        /// <summary>
        /// EtatEtat de la liaison HautBas
        /// </summary>
        protected bool m_l_HautBas;

        /// <summary>
        /// Etat de la liaison GaucheDroite
        /// </summary>
        protected bool m_l_GaucheDroite;

        /// <summary>
        /// Etat de la liaison HautDroite
        /// </summary>
        protected bool m_l_HautDroite;

        /// <summary>
        /// Etat de la liaison HautGauche
        /// </summary>
        protected bool m_l_HautGauche;

        /// <summary>
        /// Etat de la liaison BasDroite
        /// </summary>
        protected bool m_l_BasDroite;

        /// <summary>
        /// Etat de la liaison BasGauche
        /// </summary>
        protected bool m_l_BasGauche;

        /// <summary>
        /// Etat de l'entrée/sortie Haut
        /// </summary>
        protected bool m_haut;

        /// <summary>
        /// Etat de l'entrée/sortie Bas
        /// </summary>
        protected bool m_bas;

        /// <summary>
        /// Etat de l'entrée/sortie Droite
        /// </summary>
        protected bool m_droite;

        /// <summary>
        /// Etat de l'entrée/sortie Gauche
        /// </summary>
        protected bool m_gauche;

        /// <summary>
        /// Objet Pepite si présent
        /// </summary>
        protected Pepite m_Pepite;

        /// <summary>
        /// Objet Porte si l'objet est présent
        /// </summary>
        protected Porte m_Porte;
        #endregion
        #region Accesseurs
        public int M_colonnePlateau
        {
            get
            {
                return m_colonnePlateau;
            }

            set
            {
                m_colonnePlateau = value;
            }
        }
        public int M_lignePlateau
        {
            get
            {
                return m_lignePlateau;
            }

            set
            {
                m_lignePlateau = value;
            }
        }

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

        public bool M_l_HautGauche
        {
            get
            {
                return m_l_HautGauche;
            }

            set
            {
                m_l_HautGauche = value;
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

        public bool M_l_BasGauche
        {
            get
            {
                return m_l_BasGauche;
            }

            private set
            {
                m_l_BasGauche = value;
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

        public bool M_haut
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

        public bool M_gauche
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
                return m_id;
            }

            set
            {
                m_id = value;
            }
        }

        public Pepite Pepite { get => m_Pepite; set => m_Pepite = value; }
        public Porte Porte { get => m_Porte; set => m_Porte = value; }
        #endregion

        #region Constructeur
        /// <summary>
        /// Constructeur de CartePlacable (paramètres initialisés à false sauf p_imgRecto)
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
        public CartePlacable(
            System.Drawing.Bitmap p_imgRecto,
            bool p_l_HautBas = false, bool p_l_GaucheDroite = false,
            bool p_l_HautDroite = false, bool p_l_HautGauche = false,
            bool p_l_BasDroite = false, bool p_l_BasGauche = false,
            bool p_haut = false, bool p_bas = false,
            bool p_droite = false, bool p_gauche = false,
            Pepite p_Pepite = null,
            Porte p_Porte = null) : base(p_imgRecto)
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

            #region initialisation pepites
            if (p_Pepite != null)
            {
                m_Pepite = p_Pepite;
            }
            #endregion

            #region initialisation porte
            if (p_Porte != null)
            {
                m_Porte = p_Porte;
            }
            #endregion
        }
        #endregion

        #region Méthodes
        public void placer(TableLayoutPanel Panel, int x, int y)
        {
            PictureBox pic = (PictureBox) Panel.GetControlFromPosition(x, y);
            pic.Image = new Bitmap(m_imgRecto);
        }

        public bool verifPlacement(int x, int y)
        {
            new Exception("CarteChemin verifPlacement : non implémenté");
            return false;
        }
        #endregion
    }
}
