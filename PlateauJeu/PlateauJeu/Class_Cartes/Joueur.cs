using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlateauJeu.Class_Cartes
{
    /// <summary>
    /// Classe Joueur
    /// </summary>
    class Joueur
    {
        #region Attributs
        /// <summary>
        /// Nom du joueur
        /// </summary>
        private string m_nomJoueur;

        /// <summary>
        /// Nombre de pépites du joueur
        /// </summary>
        private int m_nbPepites;

        /// <summary>
        /// Couleur du joueur
        /// </summary>
        private Couleur m_couleurJoueur;

        #region Outils du joueur
        /// <summary>
        /// Etat de la pioche du joueur (true = bon état)
        /// </summary>
        private bool m_Pioche = true;

        /// <summary>
        /// Etat du chariot du joueur (true = bon état)
        /// </summary>
        private bool m_Chariot = true;

        /// <summary>
        /// Etat de la lampe du joueur (true = bon état)
        /// </summary>
        private bool m_Lampe = true;
        #endregion

        /// <summary>
        /// Liste de Carte du joueur
        /// </summary>
        private List<Carte> m_mainJoueur;

        /// <summary>
        /// Liste d'OutilsBrises qui entravent le jeu de l'utilisateur
        /// </summary>
        private List<OutilsBrises> m_cartesEntraveJoueur;
        #endregion

        #region Constructeur
        /// <summary>
        /// Constructeur de Joueur
        /// </summary>
        /// <param name="p_nomJoueur">Nom du joueur</param>
        /// <param name="p_couleurJoueur">Couleur du joueur</param>
        /// <param name="p_plateau">Pointeur de Plateau</param>
        public Joueur(string p_nomJoueur, Couleur p_couleurJoueur, Plateau p_plateau)
        {
            #region Initialisation des attributs
            m_mainJoueur = new List<Carte>();
            m_cartesEntraveJoueur = new List<OutilsBrises>();
            m_nomJoueur = p_nomJoueur;
            m_nbPepites = 0;
            m_couleurJoueur = p_couleurJoueur;
            #endregion

            #region Pioche 6 cartes du Plateau
            for (int i = 0; i<6; i++)
            {
                Piocher(p_plateau, 1);
            }
            #endregion
        }
        #endregion

        #region Méthodes
        /// <summary>
        /// Pioche de 1 ou 2 cartes dans le Plateau
        /// </summary>
        /// <param name="p_plateau">Pointeur de Plateau</param>
        /// <param name="p_nbCarteAPiocher">Nombre de cartes à piocher</param>
        public void Piocher(Plateau p_plateau, int p_nbCarteAPiocher)
        {
            #region p_nbCarteAPiocher entre 1 et 2
            if (p_nbCarteAPiocher > 0 && p_nbCarteAPiocher < 3)
            {
                #region Boucle pour piocher
                for ( int i = 1; i <=p_nbCarteAPiocher; i++)
                {
                    Carte tmp = p_plateau.PrendreCarte(p_plateau.Pioche);
                    //La carte est déja retirée de la pioche 
                    m_mainJoueur.Add(tmp);
                }
                #endregion
            }
            #endregion
        }

        /// <summary>
        /// Brise l'outil ciblé du joueur
        /// </summary>
        /// <param name="p_joueur">Pointeur du joueur qui subit</param>
        /// <param name="p_CarteOutilABriser">Pointeur de la carte OutilsBrises</param>
        public void Briser(Joueur p_joueur, OutilsBrises p_CarteOutilABriser)
        {
            switch (p_CarteOutilABriser.Outils)
            {
                case Outils.Chariot :
                    //Le chariot est cassé
                    p_joueur.m_Chariot = false;
                    break;

                case Outils.Lampe :
                    //La lampe est cassée
                    p_joueur.m_Lampe = false;
                    break;

                case Outils.Pioche :
                    //La pioche est cassée
                    p_joueur.m_Pioche = false;
                    break;
            }
            //Ajoute l'entrave au joueur
            p_joueur.m_cartesEntraveJoueur.Add(p_CarteOutilABriser);
        } 

        /// <summary>
        /// Répare l'outil ciblé
        /// </summary>
        /// <param name="OutilAReparer"></param>
        public void Reparer(Outils OutilAReparer)
        {
            switch (OutilAReparer)
            {
                case Outils.Chariot:
                    //Le chariot est cassé
                    this.m_Chariot = true;
                    foreach (OutilsBrises outilBrisé in m_cartesEntraveJoueur)
                    {
                        if (outilBrisé.Outils == Outils.Chariot)
                            m_cartesEntraveJoueur.Remove(outilBrisé);
                    }
                    break;

                case Outils.Lampe:
                    //La lampe est cassé
                    this.m_Lampe = true;
                    foreach (OutilsBrises outilBrisé in m_cartesEntraveJoueur)
                    {
                        if (outilBrisé.Outils == Outils.Lampe)
                            m_cartesEntraveJoueur.Remove(outilBrisé);
                    }
                    break;

                case Outils.Pioche:
                    //La pioche est cassé
                    this.m_Pioche = true;
                    foreach (OutilsBrises outilBrisé in m_cartesEntraveJoueur)
                    {
                        if (outilBrisé.Outils == Outils.Pioche)
                            m_cartesEntraveJoueur.Remove(outilBrisé);
                    }
                    break;
            }
        }


        public void RetirerCarteDeLaMain(Plateau p_plateau, Carte p_carte)
        {
            m_mainJoueur.Remove(p_carte);
            p_plateau.Defausse.Add(p_carte);
        }

        public Carte getCarteAtPosition(int position)
        {
            return m_mainJoueur.ElementAt(position);
        }
        #endregion

        #region Accesseurs
        public string NomJoueur
        {
            get
            {
                return m_nomJoueur;
            }

            set
            {
                m_nomJoueur = value;
            }
        }

        internal List<Carte> MainJoueur
        {
            get
            {
                return m_mainJoueur;
            }

            set
            {
                m_mainJoueur = value;
            }
        }

        public Couleur CouleurJoueur
        {
            get
            {
                return m_couleurJoueur;
            }

            set
            {
                m_couleurJoueur = value;
            }
        }
        #endregion
    }
}
