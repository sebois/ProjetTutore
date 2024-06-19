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
            Console.WriteLine("Liste des voisins de la carte : " + p_carteId);
            List<CartePlacable> voisins = new List<CartePlacable>();
            for(int i = 0; i< m_matrice.GetLength(1); i++)
            {
                CartePlacable[] adjacence = m_matrice[p_carteId, i];
                if (!(adjacence == null))
                {
                    voisins.Add(adjacence[1]);
                    Console.Write(adjacence[1] + " / ");
                }
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

        /// <summary>
        /// Parcours en profondeur des cartes contenues dans la matrice d'adjacence
        /// --> Vérification de l'existence d'un chemin vers la carte finale
        /// --> Capture des pepites libres sur le chemin
        /// </summary>
        /// <param name="p_joueur"></param>
        /// <param name="p_carte"></param>
        /// <param name="p_carteParent"></param>
        /// <param name="p_carteFinale"></param>
        /// <param name="p_cartesMarquees"></param>
        /// <returns></returns>
        public bool explorerCartes(Joueur p_joueur, CartePlacable p_carte, CartePlacable p_carteParent, CartePlacable p_carteFinale, List<CartePlacable> p_cartesMarquees, List<Pepite> p_pepitesCollectees)
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

                        Pepite pepite = carteVoisine.Pepite;
                        
                        //Si une pépite est sur la carte voisine on essaye de la récupérer
                        if (pepite != null && pepite.Proprietaire == null)
                        {
                            if(testAccesPepite(p_carte, carteVoisine))
                            {
                                pepite.Proprietaire = p_joueur;
                                Console.WriteLine("Le joueur " + p_joueur.NumeroJoueur + " a récupéré une pépite !");
                                p_joueur.NbPepites++;
                            } else
                            {
                                Console.WriteLine("Le joueur " + p_joueur.NumeroJoueur + " a trouvé une pépite mais ne peut pas la prendre !");
                            }
                        }
                        if (p_carteParent != null)
                        {
                            cheminExistant = testCheminCartes(p_carte, p_carteParent, carteVoisine);
                        }
                        if (cheminExistant)
                            carteFinaleTrouvee = explorerCartes(p_joueur, cartesVoisines.ElementAt(i), p_carte, p_carteFinale, p_cartesMarquees, p_pepitesCollectees);
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

        public bool testAccesPepite (CartePlacable p_carte, CartePlacable p_carteVoisine)
        {
            Pepite pepite = p_carteVoisine.Pepite;
            bool pepiteCapturable = false;
            int colonneVoisinDiff = p_carteVoisine.M_colonnePlateau - p_carte.M_colonnePlateau;
            int ligneVoisinDiff = p_carteVoisine.M_lignePlateau - p_carte.M_lignePlateau;
            switch (colonneVoisinDiff)
            {
                //Carte parent sur la même colonne
                case 0:
                    //Carte parent au-dessus
                    if (ligneVoisinDiff == 1)
                    {
                        switch (pepite.Position)
                        {
                            case Position.Haut:
                                pepiteCapturable = p_carteVoisine.M_haut;
                                break;
                            case Position.Droite:
                                pepiteCapturable = p_carteVoisine.M_l_HautDroite;
                                break;
                            case Position.Bas:
                                pepiteCapturable = p_carteVoisine.M_l_HautBas;
                                break;
                            case Position.Gauche:
                                pepiteCapturable = p_carteVoisine.M_l_HautGauche;
                                break;
                        }
                    }
                    //Carte parent en-dessous
                    else
                    {
                        switch (pepite.Position)
                        {
                            case Position.Haut:
                                pepiteCapturable = p_carteVoisine.M_l_HautBas;
                                break;
                            case Position.Droite:
                                pepiteCapturable = p_carteVoisine.M_l_BasDroite;
                                break;
                            case Position.Bas:
                                pepiteCapturable = p_carteVoisine.M_bas;
                                break;
                            case Position.Gauche:
                                pepiteCapturable = p_carteVoisine.M_l_BasGauche;
                                break;
                        }
                    }
                    break;
                //Carte parent à droite
                case -1:
                    switch (pepite.Position)
                    {
                        case Position.Haut:
                            pepiteCapturable = p_carteVoisine.M_l_HautDroite;
                            break;
                        case Position.Droite:
                            pepiteCapturable = p_carteVoisine.M_droite;
                            break;
                        case Position.Bas:
                            pepiteCapturable = p_carteVoisine.M_l_BasDroite;
                            break;
                        case Position.Gauche:
                            pepiteCapturable = p_carteVoisine.M_l_GaucheDroite;
                            break;
                    }
                    break;
                //Carte parent à gauche
                case 1:
                    switch (pepite.Position)
                    {
                        case Position.Haut:
                            pepiteCapturable = p_carteVoisine.M_l_HautGauche;
                            break;
                        case Position.Droite:
                            pepiteCapturable = p_carteVoisine.M_l_GaucheDroite;
                            break;
                        case Position.Bas:
                            pepiteCapturable = p_carteVoisine.M_l_BasGauche;
                            break;
                        case Position.Gauche:
                            pepiteCapturable = p_carteVoisine.M_gauche;
                            break;
                    }
                    break;
            }
            return pepiteCapturable;
        }
        #endregion
    }
}
