using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlateauJeu.Class_Cartes
{
    /// <summary>
    /// Classe abstraite Action héritant de Carte
    /// </summary>
    abstract class Action : Carte
    {
        #region Constructeur
        /// <summary>
        /// Constructeur de la carte Action
        /// </summary>
        /// <param name="p_imgRecto">Image de la carte</param>
        public Action(System.Drawing.Bitmap p_imgRecto) : base(p_imgRecto)
        {

        }
        #endregion

        #region Methode
        virtual public void Utiliser(object p_pointeur)
        {

        }

        #endregion
    }
}
