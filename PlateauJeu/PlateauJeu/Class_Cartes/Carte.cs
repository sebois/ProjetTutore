using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlateauJeu.Class_Cartes
{
    /// <summary>
    /// Classe abstraite Carte
    /// </summary>
    abstract class Carte
    {
        #region Attributs
        /// <summary>
        /// Type de la carte
        /// </summary>
        protected Types m_type;

        /// <summary>
        /// Image de la carte
        /// </summary>
        protected System.Drawing.Bitmap m_imgRecto;
        #endregion

        #region Constructeur
        /// <summary>
        /// Constructeur de la Carte
        /// </summary>
        /// <param name="p_imgRecto">Image de la carte</param>
        public Carte(System.Drawing.Bitmap p_imgRecto)
        {
            #region Initialisation image carte
            m_imgRecto = p_imgRecto;
            #endregion
        }
        #endregion

        #region Accesseur
        public Bitmap ImgRecto
        {
            get
            {
                return m_imgRecto;
            }

            set
            {
                m_imgRecto = value;
            }
        }

        public Types Type
        {
            get
            {
                return m_type;
            }

            set
            {
                m_type = value;
            }
        }
        #endregion
    }
}
