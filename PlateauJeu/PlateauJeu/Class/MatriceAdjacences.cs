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
        /// <summary>
        /// Matrice à 3 dimensions (42 cartes maximum, 2 joueurs)
        /// </summary>
        private int[,,] m_matriceAdjacence = new int[42, 42, 2];

        private int[,,] m_matriceLiaison = new int[42, 42, 2];

        public MatriceAdjacences()
        {
            for(int carteCoordX=0; carteCoordX<42; carteCoordX++)
            {
                for(int carteCoordY=0; carteCoordY<42; carteCoordY++)
                {
                    for(int accesJoueur=0; accesJoueur<2; accesJoueur++)
                    {
                        m_matriceAdjacence[carteCoordX, carteCoordY, accesJoueur] = 0;
                        m_matriceLiaison[carteCoordX, carteCoordY, accesJoueur] = 0;
                    }
                }
            }
        }

        public int[,,] MatriceAdjacence
        {
            get
            {
                return m_matriceAdjacence;
            }

            set
            {
                m_matriceAdjacence = value;
            }
        }

        public int[,,] MatriceLiaison
        {
            get
            {
                return m_matriceLiaison;
            }

            set
            {
                m_matriceLiaison = value;
            }
        }

        public void ajoutAdjacence(int p_carteCoordX, int p_carteCoordY, int p_accesJoueur)
        {
            m_matriceAdjacence.SetValue(1, p_carteCoordX, p_carteCoordY, p_accesJoueur);
            m_matriceAdjacence.SetValue(1, p_carteCoordY, p_carteCoordX, p_accesJoueur);
            m_matriceLiaison.SetValue(1, p_carteCoordX, p_carteCoordY, p_accesJoueur);
            m_matriceLiaison.SetValue(1, p_carteCoordY, p_carteCoordX, p_accesJoueur);
        }

        public void retirerAdjacence(int p_carteCoordX, int p_carteCoordY, int p_accesJoueur)
        {
            m_matriceAdjacence.SetValue(0, p_carteCoordX, p_carteCoordY, p_accesJoueur);
        }

        public bool verifChemin(int p_carteCoordX, int p_carteCoordY, int p_accesJoueur)
        {
            bool v_flagChemin = false;
            int x = p_carteCoordX;
            int y = p_carteCoordY;
            while (!v_flagChemin)
            {
                if(v_flagChemin = m_matriceAdjacence[p_carteCoordX, p_carteCoordY, p_accesJoueur] == 1)
                {
                    v_flagChemin = true;
                }
                else
                {
                    x = 0;
                    while(m_matriceAdjacence[p_carteCoordX, p_carteCoordY, p_accesJoueur] != 1 || x< m_matriceAdjacence.GetLength(0))
                    {
                        x++;
                    }
                }
            }
            return v_flagChemin;
        }

        public void majMatriceLiaison(int p_carteDepart)
        {

            explorer(p_carteDepart);
        }

        private void explorer(int p_sommet)
        {
            if(m_matriceAdjacence[p_sommet, 0, 0] == 1)
            {

            }
        }
    }
}
