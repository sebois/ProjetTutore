using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlateauJeu.Class_Cartes
{
    /// <summary>
    /// Classe CarteObjectif héritant de CartePlacable
    /// </summary>
    class CarteObjectif : CartePlacable
    {
        #region Attributs
        /// <summary>
        /// Objet Pepite si présent
        /// </summary>
        private Pepite m_Pepite;

        /// <summary>
        /// Flag levé si la carte Objectif est découverte
        /// </summary>
        private bool m_decouvert;
        #endregion

        #region Constructeur
        /// <summary>
        /// Constructeur de la CarteObjectif (paramètres initialisés à false ou null sauf p_imgRecto)
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
        public CarteObjectif(
            System.Drawing.Bitmap p_imgRecto,
            bool p_l_HautBas = false, bool p_l_GaucheDroite = false,
            bool p_l_HautDroite = false, bool p_l_HautGauche = false,
            bool p_l_BasDroite = false, bool p_l_BasGauche = false,
            bool p_haut = false, bool p_bas = false,
            bool p_droite = false, bool p_gauche = false,
            Pepite p_Pepite = null,
            Porte p_Porte = null) : base(
                p_imgRecto, 
                p_l_HautBas, p_l_GaucheDroite, 
                p_l_HautDroite, p_l_HautGauche, 
                p_l_BasDroite, p_l_BasGauche, 
                p_haut, p_bas,
                p_droite, p_gauche)
        {
            #region initialisation flag découverte
            m_decouvert = false;
            #endregion
        }
        #endregion
    }
}
