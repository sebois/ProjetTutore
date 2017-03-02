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
        private int[,,,] matrice = new int[11, 15, 11, 15];

        public Matrice_Adjacences()
        {
            for(int x1=0; x1<11; x1++)
            {
                for(int y1=0; y1<15; y1++)
                {
                    for(int x2=0; x2<11; x2++)
                    {
                        for(int y2=0; y1<15; y2++)
                        {
                            matrice[x1, y1, x2, y2] = 0;
                        }
                    }
                }
            }
        }

        public void ajoutCarte(CartePlacable nouvCarte, int x, int y)
        {
            if (nouvCarte.M_hAut == true)
            {
                if (true) //getCarteById(TableauJeu[x,y+1] != null;
                {
                    matrice[x, y, x, y + 1] = 1;
                    matrice[x, y + 1, x, y] = 1;
                }
            }

            if (nouvCarte.M_bas == true)
            {
                if (true) //getCarteById(TableauJeu[x,y-1] != null;
                {
                    matrice[x, y, x, y - 1] = 1;
                    matrice[x, y - 1, x, y] = 1;
                }
            }

            if (nouvCarte.M_droite == true)
                if (true) //getCarteById[x+1,y] != null;
                {
                    matrice[x, y, x + 1, y] = 1;
                    matrice[x + 1, y, x, y] = 1;
                }
            if (nouvCarte.M_l_gauche == true)
            {
                if (true) //getCarteById(TableauJeu[x-1,y] != null;
                {
                    matrice[x, y, x - 1, y] = 1;
                    matrice[x - 1, y, x, y] = 1;
                }
            }
        }

        public void retirerCarte(Carte supprCarte, int x, int y)
        {

        }

        public Boolean VérifChemin(int x, int y)
        {
            return false;
        }
    }
}
