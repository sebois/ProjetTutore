﻿using System;
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
        private byte m_nbPepite;

        /// <summary>
        /// Position des pépites
        /// </summary>
        private Position m_posPepite;
        #endregion

        #region Constructeur
        /// <summary>
        /// Constructeur de Pépite
        /// </summary>
        /// <param name="p_nbPepite">Nombre de pépites</param>
        /// <param name="p_posPepite">Position des pépites</param>
        public Pepite(byte p_nbPepite, Position p_posPepite)
        {
            m_nbPepite = p_nbPepite;
            m_posPepite = p_posPepite;
        }

        public byte NbPepite { get => m_nbPepite; set => m_nbPepite = value; }
        public Position PosPepite { get => m_posPepite; set => m_posPepite = value; }
        #endregion
    }
}
