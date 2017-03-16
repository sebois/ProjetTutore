using PlateauJeu.Class_Cartes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlateauJeu
{
    class MatriceAdjacences
    {
        private int[,,,] matrice = new int[11, 15, 11, 15];
        private List<CarteChemin> CarteVérifié;

        public MatriceAdjacences()
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

        public void ajoutCarte(CarteChemin nouvCarte, int x, int y)
        {
            matrice[x, y, x, y] = 1;
            /*
            if (nouvCarte.M_haut == true)
            {
                if (true) //getCarteById(TableauJeu[x,y+1] != null;
                {
                    matrice[x, y, x, y + 1] = 1;
                    matrice[x, y + 1, x, y] = 1;

                    for (int i = 0; i < 11; i++)
                    {
                        for (int j = 0; j < 15; j++)
                        {
                            if (matrice[x, y + 1, i, j] > 0 && matrice[x, y, i, j] != 1)
                            {
                                matrice[x, y, i, j] = 2;
                                matrice[i, j, x, y] = 2;
                            }
                        }
                    }
                }
            }

            if (nouvCarte.M_bas == true)
            {
                if (true) //getCarteById(TableauJeu[x,y-1]) != null;
                {
                    matrice[x, y, x, y - 1] = 1;
                    matrice[x, y - 1, x, y] = 1;

                    for (int i = 0; i < 11; i++)
                    {
                        for (int j = 0; j < 15; j++)
                        {
                            if (matrice[x, y - 1, i, j] > 0 && matrice[x, y, i, j] != 1)
                            {
                                matrice[x, y, i, j] = 2;
                                matrice[i, j, x, y] = 2;
                            }
                        }
                    }
                }
            }

            if (nouvCarte.M_droite == true)
            {
                if (true) //getCarteById(TableauJeu[x+1,y]) != null;
                {
                    matrice[x, y, x + 1, y] = 1;
                    matrice[x + 1, y, x, y] = 1;

                    for (int i = 0; i < 11; i++)
                    {
                        for (int j = 0; j < 15; j++)
                        {
                            if (matrice[x + 1, y, i, j] > 0 && matrice[x, y, i, j] != 1)
                            {
                                matrice[x, y, i, j] = 2;
                                matrice[i, j, x, y] = 2;
                            }
                        }
                    }
                }
            }
            if (nouvCarte.M_gauche == true)
            {
                if (true) //getCarteById(TableauJeu[x-1,y] != null;
                {
                    matrice[x, y, x - 1, y] = 1;
                    matrice[x - 1, y, x, y] = 1;

                    for (int i = 0; i < 11; i++)
                    {
                        for (int j = 0; j < 15; j++)
                        {
                            if (matrice[x - 1, y , i, j] > 0 && matrice[x, y, i, j] != 1)
                            {
                                matrice[x, y, i, j] = 2;
                                matrice[i, j, x, y] = 2;
                            }
                        }
                    }
                }
            }
            */
        }

        public void retirerCarte(CarteChemin supprCarte, int x, int y)
        {
            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    matrice[x, y, i, j] = 0;
                    matrice[i, j, x, y] = 0;
                }
            }
        }

        public Boolean VérifChemin(int x, int y, int xD, int yD)
        {
            Boolean resultat;
            if(matrice[x, y, xD, yD]>0) {resultat = true;}
            else { resultat = false; }
            return resultat;
        }
    }
}
