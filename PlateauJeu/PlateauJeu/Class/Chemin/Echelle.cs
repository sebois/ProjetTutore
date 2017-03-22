using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlateauJeu.Class_Cartes
{
    /// <summary>
    /// Classe Echelle
    /// </summary>
    class Echelle
    {
        #region Attributs
        /// <summary>
        /// Couleur du Joueur
        /// </summary>
        private Couleur m_couleurJoueur;
        #endregion

        #region Constructeur
        /// <summary>
        /// Constructeur de Echelle
        /// </summary>
        /// <param name="p_couleurJoueur">Couleur du Joueur</param>
        public Echelle(Couleur p_couleurJoueur)
        {
            #region Initialisation m_couleurJoueur
            m_couleurJoueur = p_couleurJoueur;
            #endregion
        }
        #endregion
    }
}
