using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlateauJeu.Class_Cartes
{
    /// <summary>
    /// Classe Porte
    /// </summary>
    class Porte
    {
        #region Attributs
        /// <summary>
        /// Position de la porte
        /// </summary>
        private Position m_pos;

        /// <summary>
        /// Couleur de la porte
        /// </summary>
        private Couleur m_couleurJoueur;

        /// <summary>
        /// Flag d'ouverture de la porte
        /// </summary>
        private bool m_ouvert;
        #endregion

        #region Constructeur
        /// <summary>
        /// Constructeur de Porte 
        /// </summary>
        /// <param name="p_pos">Position de la porte</param>
        /// <param name="p_couleurJoueur">Couleur de la porte</param>
        public Porte(Position p_pos, Couleur p_couleurJoueur)
        {
            m_pos = p_pos;
            m_couleurJoueur = p_couleurJoueur;
            /*
             * Porte fermée
             */
            m_ouvert = false;
        }
        #endregion

        #region Méthodes
        public bool ouvrir()
        {
            if (m_ouvert == false)
            {
                m_ouvert = true;
                return true;            
            }
            MessageBox.Show("La porte est déjà ouverte", "ERREUR :", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;              
        }
        #endregion
    }
}
