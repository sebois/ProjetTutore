using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlateauJeu.Class_Cartes
{
    /// <summary>
    /// Classe Pépite
    /// </summary>
    class Pepite
    {
        #region Attributs
        /// <summary>
        /// Nombre de pépites
        /// </summary>
        private byte m_nombre;

        /// <summary>
        /// Position des pépites
        /// </summary>
        private Position m_position;

        /// <summary>
        /// Propriétaire de la pépite
        /// </summary>
        private Joueur m_proprietaire;
        #endregion

        #region Constructeur
        /// <summary>
        /// Constructeur de Pépite
        /// </summary>
        /// <param name="p_nbPepite">Nombre de pépites</param>
        /// <param name="p_posPepite">Position des pépites</param>
        public Pepite(byte p_nbPepite, Position p_posPepite)
        {
            m_nombre = p_nbPepite;
            m_position = p_posPepite;
        }

        public byte Nombre { get => m_nombre; set => m_nombre = value; }
        public Position Position { get => m_position; set => m_position = value; }
        public Joueur Proprietaire { get => m_proprietaire; set => m_proprietaire = value; }
        #endregion
    }
}
