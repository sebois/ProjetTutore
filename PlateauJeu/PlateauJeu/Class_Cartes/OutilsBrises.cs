using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlateauJeu.Class_Cartes
{
    /// <summary>
    /// Classe OutilsBrises héritant de Action
    /// </summary>
    class OutilsBrises : Action
    {
        #region Attributs
        /// <summary>
        /// Outil à briser
        /// </summary>
        private Outils m_outils;
        #endregion

        #region Constructeur
        /// <summary>
        /// Constructeur de OutilsBrises
        /// </summary>
        /// <param name="p_imgRecto">Image de la carte</param>
        /// <param name="p_outils">Outil à briser</param>
        public OutilsBrises(System.Drawing.Bitmap p_imgRecto, Outils p_outils): base(p_imgRecto)
        {
            m_outils = p_outils;
        }
        #endregion

        #region Accesseurs
        public Outils Outils
        {
            get
            {
                return m_outils;
            }

            set
            {
                m_outils = value;
            }
        }
        #endregion

        #region Méthodes
        /// <summary>
        /// Utilise la carte
        /// </summary>
        /// <param name="p_joueur">Joueur qui doit briser son outil</param>
        override
        public void Utiliser(object p_joueur)
        {
            try
            {
                Joueur v_Joueur = (Joueur)p_joueur;
                v_Joueur.Briser(v_Joueur, this);
            }
            catch (InvalidCastException ex) { };
        }
        #endregion
    }
}
