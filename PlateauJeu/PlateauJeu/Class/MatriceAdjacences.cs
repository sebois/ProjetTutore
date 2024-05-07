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
        #region Attributs
        /// <summary>
        /// Matrice à 2 dimensions (42 cartes maximum)
        /// </summary>
        private CartePlacable[,][] m_matrice;
        /// <summary>
        /// Liste des dernières adjacences ajoutées (permet de les supprimer en cas d'annulation)
        /// </summary>
        private List<CartePlacable[]> m_listeNouvellesAdjacences;

        #endregion

        #region Constructeur
        public MatriceAdjacences()
        {
            m_matrice = new CartePlacable[42, 42][];
        }
        #endregion

        #region Accesseur
        public CartePlacable[,][] Matrice { get => m_matrice; set => m_matrice = value; }

        public List<CartePlacable[]> ListeNouvellesAdjacences { get => m_listeNouvellesAdjacences; set => m_listeNouvellesAdjacences = value; }
        #endregion

        #region Méthodes
        /// <summary>
        /// Liste les cartes ayant une adjacence avec la carte dont l'id est donné
        /// </summary>
        /// <param name="p_carteId"></param>
        /// <returns></returns>
        public List<CartePlacable> listeCartesVoisines(int p_carteId)
        {
            List<CartePlacable> voisins = new List<CartePlacable>();
            for(int i = 0; i< m_matrice.GetLength(1); i++)
            {
                CartePlacable[] adjacence = m_matrice[p_carteId, i];
                if (!(adjacence == null))
                    voisins.Add(adjacence[1]);
            }
            return voisins;
        }

        /// <summary>
        /// Ajoute une adjacence dans la matrice dans les lignes et colonnes associées
        /// </summary>
        /// <param name="p_adjacence"></param>
        /// <param name="p_carteCoordX"></param>
        /// <param name="p_carteCoordY"></param>
        public void setAdjacence(CartePlacable[] p_adjacence, int p_carteCoordX, int p_carteCoordY)
        {
            m_matrice.SetValue(p_adjacence, p_carteCoordX, p_carteCoordY);
            m_matrice.SetValue(p_adjacence != null ? (new CartePlacable[] { p_adjacence[1], p_adjacence[0] }) : p_adjacence, p_carteCoordY, p_carteCoordX);
            //m_matriceLiaison.SetValue(1, p_carteCoordX, p_carteCoordY, p_accesJoueur);
            //m_matriceLiaison.SetValue(1, p_carteCoordY, p_carteCoordX, p_accesJoueur);
        }

        /// <summary>
        /// Retire les adjacences testées lors du placement de la carte
        /// </summary>
        public void retirerNouvellesAdjacences()
        {
            foreach (CartePlacable[] adjacence in m_listeNouvellesAdjacences)
            {
                setAdjacence(null, adjacence[0].Id, adjacence[1].Id);
            }
            m_listeNouvellesAdjacences.Clear();
        }


        /* 
         * Méthode obsolète
         * 
        public bool verifCheminLargeur(int p_carteCoordX, int p_carteCoordY)
        {
            Console.WriteLine("Parcours en largeur");
            bool v_flagChemin = false;
            int x = p_carteCoordX;
            int y = p_carteCoordY;
            int nbVoisins = 0;

            //Création de la file et ajout de la première carte
            Queue<int> file = new Queue<int>();
            file.Enqueue(x);
            //Marquage de la première carte
            List<int> cartesMarquees = new List<int>();
            cartesMarquees.Add(x);
            //Liste de chemins

            //Tant que la file n'est pas vide et qu'on n'a pas atteint la carte à atteindre on parcoure la file
            while (!v_flagChemin && file.Count != 0)
            {
                int carteActuelle = file.Dequeue();
                Console.WriteLine("Carte actuelle : " + carteActuelle);
                List<int> voisins = listeVoisins(carteActuelle);
                nbVoisins = voisins.Count();
                Console.Write("Voisins de la carte " + carteActuelle + " : [");
                //List<List<int>> niveauPrecedent = listeChemins.ElementAt(0);
                for (int j = 0; j < voisins.Count; j++)
                {
                    int voisin = voisins.ElementAt(j);
                    Console.Write(voisin + " ");
                    j++;
                }
                Console.WriteLine("]");
                foreach (int carteVoisine in voisins)
                {
                    if (carteVoisine == p_carteCoordY)
                    {
                        v_flagChemin = true;
                        Console.WriteLine("Carte de fin trouvée : " + p_carteCoordY);
                        cartesMarquees.Add(carteVoisine);
                    } 
                    else
                    {
                        bool estMarquee = false;
                        int indiceCarte = 0;

                        //On vérifie que la carte n'a pas déjà été parcourue
                        while (!estMarquee && indiceCarte < cartesMarquees.Count)
                        {
                            int carteParcourue = cartesMarquees.ElementAt(indiceCarte);
                            if (carteVoisine == carteParcourue)
                            {
                                estMarquee = true;
                            }
                            indiceCarte++;
                        }
                        //Si ce n'est pas le cas on marque la carte comme parcourue et on l'ajoute à la file
                        if (!estMarquee)
                        {
                            file.Enqueue(carteVoisine);
                            cartesMarquees.Add(carteVoisine);
                        }
                    }
                    Console.Write("Cartes marquées : [");
                    foreach (int carteParcourue in cartesMarquees)
                    {
                        Console.Write(carteParcourue + " ");
                    }
                    Console.WriteLine("]");
                }
            }
            return v_flagChemin;
        }
        */

        /// <summary>
        /// Affiche le contenu de la matrice d'adjacence
        /// </summary>
        public void afficherMatriceAdjacence ()
        {
            Console.WriteLine();
            for (int carteCoordX = 0; carteCoordX < 42; carteCoordX++)
            {
                Console.Write("[ ");
                for (int carteCoordY = 0; carteCoordY < 42; carteCoordY++)
                {
                    CartePlacable[] v_cartesPlacables = Matrice[carteCoordX, carteCoordY];
                    //Console.Write(v_cartesPlacables == null ? "0 " : "1 ");
                    if (v_cartesPlacables == null)
                    {
                        Console.Write("0 ");
                    }
                    else
                    {
                        Console.Write("(");
                        foreach (CartePlacable cartePlacable in v_cartesPlacables)
                        {
                            Console.Write(cartePlacable.Id + ", ");
                        }
                        Console.Write(")");
                    }
                    //m_matriceLiaison[carteCoordX, carteCoordY, accesJoueur] = 0;
                }
                Console.Write("] (ligne " + carteCoordX + ")\n");
            }
        }

        /*
         * Méthode obsolète
         * 
        public void majMatriceLiaison(int p_carteDepart)
        {

            //explorer(p_carteDepart);
        }
        */

        /*
         * Méthode obsolète
         * 
        public bool explorer(CartePlacable p_carte, CartePlacable p_carteFinale, List<int> p_cartesMarquees)
        {
            int v_carteId = p_carte.Id;
            int v_carteFinaleId = p_carteFinale.Id;
            p_cartesMarquees.Add(v_carteId);
            Console.WriteLine(v_carteId);
            bool carteFinaleTrouvee = (v_carteId == v_carteFinaleId);
            if (!carteFinaleTrouvee)
            {
                List<CartePlacable> cartesVoisines = listeCartesVoisines(v_carteId);
                int i = 0;
                while (!carteFinaleTrouvee && (i < cartesVoisines.Count))
                {
                    int voisin = cartesVoisines.ElementAt(i).Id;
                    bool estMarquee = false;
                    int indiceCarte = 0;

                    //On vérifie que la carte n'a pas déjà été parcourue
                    while (!estMarquee && indiceCarte < p_cartesMarquees.Count)
                    {
                        int carteParcourue = p_cartesMarquees.ElementAt(indiceCarte);
                        if (voisin == carteParcourue)
                        {
                            estMarquee = true;
                        }
                        indiceCarte++;
                    }
                    //Si ce n'est pas le cas on marque la carte comme parcourue et on l'ajoute à la file
                    if (!estMarquee)
                    {
                        carteFinaleTrouvee = explorer(cartesVoisines.ElementAt(i), p_carteFinale, p_cartesMarquees);
                    }
                    i++;
                }
            }
            return carteFinaleTrouvee;
        }
        */

        /// <summary>
        /// Parcours en profondeur des cartes contenues dans la matrice d'adjacence pour vérifier l'existence d'un chemin vers la carte finale
        /// </summary>
        /// <param name="p_carte"></param>
        /// <param name="p_carteParent"></param>
        /// <param name="p_carteFinale"></param>
        /// <param name="p_cartesMarquees"></param>
        /// <returns></returns>
        public bool explorerCartes(CartePlacable p_carte, CartePlacable p_carteParent, CartePlacable p_carteFinale, List<CartePlacable> p_cartesMarquees)
        {
            int v_carteId = p_carte.Id;
            //int v_carteParentId = p_carteParent.Id;
            int v_carteFinaleId = p_carteFinale.Id;
            p_cartesMarquees.Add(p_carte);
            Console.WriteLine(v_carteId);
            bool carteFinaleTrouvee = (v_carteId == v_carteFinaleId);
            if (!carteFinaleTrouvee)
            {
                List<CartePlacable> cartesVoisines = listeCartesVoisines(v_carteId);
                int i = 0;
                while (!carteFinaleTrouvee && (i < cartesVoisines.Count))
                {
                    CartePlacable carteVoisine = cartesVoisines.ElementAt(i);
                    int carteVoisineId = carteVoisine.Id;
                    bool estMarquee = false;
                    int indiceCarte = 0;

                    //On vérifie que la carte n'a pas déjà été parcourue
                    while (!estMarquee && indiceCarte < p_cartesMarquees.Count)
                    {
                        int carteParcourueId = p_cartesMarquees.ElementAt(indiceCarte).Id;
                        if (carteVoisineId == carteParcourueId)
                        {
                            estMarquee = true;
                        }
                        indiceCarte++;
                    }
                    //Si ce n'est pas le cas on marque la carte comme parcourue et on l'ajoute à la file
                    if (!estMarquee)
                    {
                        bool cheminExistant = true;
                        if (p_carteParent != null)
                        {
                            cheminExistant = testCheminCartes(p_carte, p_carteParent, carteVoisine);
                        }
                        if (cheminExistant)
                            carteFinaleTrouvee = explorerCartes(cartesVoisines.ElementAt(i), p_carte, p_carteFinale, p_cartesMarquees);
                        //S'il n'y a pas de chemin sur la carte actuelle, on ne peut pas trouver un chemin vers la carte finale
                        else
                            carteFinaleTrouvee = false;
                    }
                    i++;
                }
            }
            return carteFinaleTrouvee;
        }

        /// <summary>
        /// Vérifie s'il existe un chemin sur la carte actuelle permettant de relier la carte précédente et suivante dans le parcours du chemin
        /// </summary>
        /// <param name="p_carte"></param>
        /// <param name="p_carteParent"></param>
        /// <param name="p_carteVoisine"></param>
        /// <returns></returns>
        public bool testCheminCartes(CartePlacable p_carte, CartePlacable p_carteParent, CartePlacable p_carteVoisine)
        {
            bool cheminExistant = false;
            int colonneParentDiff = p_carteParent.M_colonnePlateau - p_carte.M_colonnePlateau;
            int ligneParentDiff = p_carteParent.M_lignePlateau - p_carte.M_lignePlateau;
            int colonneVoisinDiff = p_carteVoisine.M_colonnePlateau - p_carte.M_colonnePlateau;
            int ligneVoisinDiff = p_carteVoisine.M_lignePlateau - p_carte.M_lignePlateau;

            switch (colonneParentDiff)
            {
                //Carte parent sur la même colonne
                case 0:
                    //Carte parent au-dessus
                    if (ligneParentDiff == -1)
                    {
                        switch (colonneVoisinDiff)
                        {
                            //Carte voisine en-dessous
                            case 0:
                                cheminExistant = p_carte.M_l_HautBas;
                                break;
                            //Carte voisine à gauche
                            case -1:
                                cheminExistant = p_carte.M_l_HautGauche;
                                break;
                            //Carte voisine à droite
                            case 1:
                                cheminExistant = p_carte.M_l_HautDroite;
                                break;
                        }
                    }
                    //Carte parent en-dessous
                    else
                    {
                        switch (colonneVoisinDiff)
                        {
                            //Carte voisine au-dessus
                            case 0:
                                cheminExistant = p_carte.M_l_HautBas;
                                break;
                            //Carte voisine à gauche
                            case -1:
                                cheminExistant = p_carte.M_l_BasGauche;
                                break;
                            //Carte voisine à droite
                            case 1:
                                cheminExistant = p_carte.M_l_BasDroite;
                                break;
                        }
                    }
                    break;
                //Carte parent à gauche
                case -1:
                    //Carte voisine sur la même colonne
                    if (colonneVoisinDiff == 0)
                    {
                        //Carte voisine au-dessus
                        if (ligneVoisinDiff == -1)
                        {
                            cheminExistant = p_carte.M_l_HautGauche;
                        }
                        //Carte voisine en-dessous
                        else
                        {
                            cheminExistant = p_carte.M_l_BasGauche;
                        }
                    }
                    //Carte voisine à droite
                    else
                    {
                        cheminExistant = p_carte.M_l_GaucheDroite;
                    }
                    break;
                //Carte parent à droite
                case 1:
                    //Carte voisine sur la même colonne
                    if (colonneVoisinDiff == 0)
                    {
                        //Carte voisine au-dessus
                        if (ligneVoisinDiff == -1)
                        {
                            cheminExistant = p_carte.M_l_HautDroite;
                        }
                        //Carte voisine en-dessous
                        else
                        {
                            cheminExistant = p_carte.M_l_BasDroite;
                        }
                    }
                    //Carte voisine à gauche
                    else
                    {
                        cheminExistant = p_carte.M_l_GaucheDroite;
                    }
                    break;
            }
            return cheminExistant;
        }
        #endregion
    }
}
