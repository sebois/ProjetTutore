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
        private bool[,,] m_matrice = new bool[2, 42, 42];
        /// <summary>
        /// Liste des dernières adjacences ajoutées (permet de les supprimer en cas d'annulation)
        /// </summary>
        private List<KeyValuePair<int, int>> m_listeNouvellesAdjacences;

        //private int[,,] m_matriceLiaison = new int[42, 42, 2];

        public MatriceAdjacences()
        {
            for(int numeroJoueur = 0; numeroJoueur < 2; numeroJoueur++)
            {
                for(int carteCoordX = 0; carteCoordX < 42; carteCoordX++)
                {
                    for(int carteCoordY = 0; carteCoordY < 42; carteCoordY++)
                    {
                        m_matrice[numeroJoueur, carteCoordX, carteCoordY] = false;
                        //m_matriceLiaison[carteCoordX, carteCoordY, accesJoueur] = 0;
                    }
                }
            }
            List<KeyValuePair<int, int>> v_listeAdjacences = new List<KeyValuePair<int, int>>();
        }

        public bool[,,] Matrice { get => m_matrice; set => m_matrice = value; }

        public List<KeyValuePair<int, int>> ListeNouvellesAdjacences { get => m_listeNouvellesAdjacences; set => m_listeNouvellesAdjacences = value; }

        /*
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
        */

        public List<int> listeVoisins(int p_accesJoueur, int p_carteCoordX)
        {
            List<int> voisins = new List<int>();
            for(int i = 0; i< m_matrice.GetLength(2); i++)
            {
                bool adjacence = m_matrice[p_accesJoueur, p_carteCoordX, i];
                if (adjacence)
                    voisins.Add(i);
            }
            return voisins;
        }

        public void setAdjacence(bool p_adjacence, int p_numeroJoueur, int p_carteCoordX, int p_carteCoordY)
        {
            m_matrice.SetValue(p_adjacence, p_numeroJoueur - 1, p_carteCoordX, p_carteCoordY);
            m_matrice.SetValue(p_adjacence, p_numeroJoueur - 1, p_carteCoordY, p_carteCoordX);
            //m_matriceLiaison.SetValue(1, p_carteCoordX, p_carteCoordY, p_accesJoueur);
            //m_matriceLiaison.SetValue(1, p_carteCoordY, p_carteCoordX, p_accesJoueur);
        }

        public void retirerNouvellesAdjacences(int p_numeroJoueur)
        {
            foreach (KeyValuePair<int, int> adjacence in m_listeNouvellesAdjacences)
            {
                setAdjacence(false, p_numeroJoueur, adjacence.Key, adjacence.Value);
            }
            m_listeNouvellesAdjacences.Clear();
        }

        public bool verifChemin(int p_accesJoueur, int p_carteCoordX, int p_carteCoordY)
        {
            bool v_flagChemin = false;
            int x = p_carteCoordX;
            int y = p_carteCoordY;
            List<int> cartesParcourues = new List<int>();
            Queue<int> file = new Queue<int>();
            file.Enqueue(x);
            cartesParcourues.Add(x);
            while (!v_flagChemin && file.Count != 0)
            {
                int carteActuelle = file.Dequeue();
                Console.WriteLine("Carte parcourue : " + carteActuelle);
                List<int> voisins = listeVoisins(p_accesJoueur, carteActuelle);
                foreach (int carteVoisine in voisins)
                {
                    if (carteVoisine == p_carteCoordY)
                    {
                        v_flagChemin = true;
                        Console.WriteLine("Carte de fin trouvée : " + p_carteCoordY);
                    } 
                    else
                    {
                        bool flag = false;
                        int i = 0;
                        while (!flag && i < cartesParcourues.Count)
                        {
                            int carteParcourue = cartesParcourues.ElementAt(i);
                            if (carteVoisine == carteParcourue)
                            {
                                flag = true;
                            }
                            i++;
                        }
                        if (!flag)
                        {
                            file.Enqueue(carteVoisine);
                            cartesParcourues.Add(carteVoisine);
                        }
                    }
                }
            }
            return v_flagChemin;
        }

        public void afficherMatriceAdjacence ()
        {
            for (int numeroJoueur = 0; numeroJoueur < 2; numeroJoueur++)
            {
                Console.WriteLine("Joueur " + (numeroJoueur + 1) + " : ");
                for (int carteCoordX = 0; carteCoordX < 42; carteCoordX++)
                {
                    Console.Write("[ ");
                    for (int carteCoordY = 0; carteCoordY < 42; carteCoordY++)
                    {
                        Console.Write(Matrice[numeroJoueur, carteCoordX, carteCoordY] ? "1 " : "0 ");
                        //m_matriceLiaison[carteCoordX, carteCoordY, accesJoueur] = 0;
                    }
                    Console.Write("] (ligne " + carteCoordX + ")\n");
                }
            }
        }

        public void majMatriceLiaison(int p_carteDepart)
        {

            explorer(p_carteDepart);
        }

        private void explorer(int p_sommet)
        {
            if(m_matrice[p_sommet, 0, 0])
            {

            }
        }
    }
}
