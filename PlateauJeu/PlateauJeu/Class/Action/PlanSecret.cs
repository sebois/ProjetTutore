using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlateauJeu.Class_Cartes
{
    /// <summary>
    /// Classe PlanSecret héritant de Action
    /// </summary>
    class PlanSecret : Action
    {
        #region Constructeur
        /// <summary>
        /// Constructeur de PlanSecret
        /// </summary>
        /// <param name="p_imgRecto">Image de la carte</param>
        public PlanSecret(System.Drawing.Bitmap p_imgRecto): base(p_imgRecto)
        {
            //TO DO
        }
        #endregion


        /// <summary>
        /// Utilisation de la carte
        /// </summary>
        /// <param name="p_pointeur"></param>
        override
        public void Utiliser(object p_CartePointeur)
        {
            //TO DO
        }
    }
}
