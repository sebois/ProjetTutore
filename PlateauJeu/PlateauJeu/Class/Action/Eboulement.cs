using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlateauJeu.Class_Cartes
{
    /// <summary>
    /// Classe Eboulement héritant de Action
    /// </summary>
    class Eboulement : Action
    {
        #region Constructeur
        /// <summary>
        /// Constructeur de Eboulement
        /// </summary>
        /// <param name="p_imgRecto">Image de la carte</param>
        public Eboulement(System.Drawing.Bitmap p_imgRecto): base(p_imgRecto)
        {
            //TO DO
        }
        #endregion

        #region Méthodes
        public override void Utiliser(object p_Plateau)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
