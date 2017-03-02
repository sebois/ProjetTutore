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

        public void ajoutCarte(int id_nouvCartes, int x, int y)
        {
            
        }

        public void retirerCarte(int id_supprCarte, int x, int y)
        {

        }

        public Boolean VérifChemin(int x, int y)
        {
            return false;
        }
    }
}
