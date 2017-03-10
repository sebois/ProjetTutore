using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlateauJeu.Class_Cartes
{
    /// <summary>
    /// Classe Cle héritant de Action
    /// </summary>
    class Cle : Action
    {
        #region Constructeur
        /// <summary>
        /// Constructeur de Cle
        /// </summary>
        /// <param name="p_imgRecto">Image de la carte</param>
        public Cle(System.Drawing.Bitmap p_imgRecto): base(p_imgRecto)
        {

        }
        #endregion

        #region Méthode
        /// <summary>
        /// Ouvre la porte
        /// </summary>
        /// <param name="p_pointeur">Pointeur vers l'objet Porte</param>
        /// <returns></returns>
        override
        public void Utiliser(object p_pointeur)
        {
            try
            {
                Porte v_Porte = (Porte)p_pointeur;
                v_Porte.ouvrir();
            }   
            catch (InvalidCastException ex) { }
        }
        #endregion
    }
}
