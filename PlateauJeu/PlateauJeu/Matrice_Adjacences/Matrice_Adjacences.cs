using PlateauJeu.Class_Cartes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlateauJeu.Matrice_Adjacences
{
    class Matrice_Adjacences
    {
        private List<CartePlacable> carteAtteignables;
        private int xD, yD;
        private int xE, yE;
 
        /// <summary>
        /// Constructeur de la Matrice
        /// </summary>
        /// <param name="carteDépart">carte de départ du joueur</param>
        public Matrice_Adjacences(CartePlacable carteDépart)
        {
            carteAtteignables = new List<CartePlacable>();
            int idDépart = carteDépart.Id;
            int x = 0;
            while (x<11 && xD!=-1 && yD!=-1)
            {
                int y = 0;
                while (y<15 && xD!=-1 && yD!=-1)
                {
                    if(idDépart = tabID[x, y]) { xD = x;  yD = y; }
                    y++;
                }
                x++;
            }
            xE = -1;
            yE = -1;
            carteAtteignables.Add(carteDépart);
        }


        /// <summary>
        /// Méthode pour recalculer toute la liste -> EX : lors de l'utilisation de la carte Eboulement
        /// </summary>
        public void maj()
        {
            
        }

        /// <summary>
        /// Méthode à appler lorsqu'une carte et ajouté au plateau de jeu.
        /// </summary>
        /// <param name="nouvCarte"></param>
        public void ajoutCarte(CartePlacable nouvCarte)
        {
            int idnouvCarte = nouvCarte.Id;
            int x = -1;
            int y = -1;
            while (x < 11 && xD != -1 && yD != -1)
            {
                int y = 0;
                while (y < 15 && xD != -1 && yD != -1)
                {
                    if (idnouvCarte = tabID[x, y]) { xD = x; yD = y; }
                    y++;
                }
                x++;
            }
            
            // Vérifier si la carte placé et une carte échelle 
            // -> Si oui verifier à quels joueur elle appartient
            // -> Modifier les valeur de xE et yE pour le joueur correspondant

            

        }
    }
}
