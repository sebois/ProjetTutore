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
        private List<Carte> m_cartesEntraveJoueur;
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
            m_cartesEntraveJoueur = new List<Carte>();
            m_nomJoueur = p_nomJoueur;
            NbPepites = 0;
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
        public bool Briser(Joueur p_joueur, OutilsBrises p_CarteOutilABriser)
        {
            switch (p_CarteOutilABriser.Outils)
            {
                case Outils.Chariot :
                    //Le chariot est cassé
                    if (p_joueur.m_Chariot)
                    {
                        p_joueur.m_Chariot = false;
                    }
                    else
                        return false;
                    break;

                case Outils.Lampe :
                    //La lampe est cassée
                    if (p_joueur.m_Lampe)
                    {
                        p_joueur.m_Lampe = false;
                    }
                    else
                        return false;
                    break;

                case Outils.Pioche :
                    //La pioche est cassée
                    if (p_joueur.m_Pioche)
                    {
                        p_joueur.m_Pioche = false;
                    }
                    else
                        return false;
                    break;
            }
            //Ajoute l'entrave au joueur
            p_joueur.m_cartesEntraveJoueur.Add(p_CarteOutilABriser);
            return true;
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
                    m_Chariot = true;
                    foreach (OutilsBrises outilBrise in m_cartesEntraveJoueur)
                    {
                        if (outilBrise.Outils == Outils.Chariot)
                            m_cartesEntraveJoueur.Remove(outilBrise);
                    }
                    break;

                case Outils.Lampe:
                    //La lampe est cassé
                    m_Lampe = true;
                    foreach (OutilsBrises outilBrise in m_cartesEntraveJoueur)
                    {
                        if (outilBrise.Outils == Outils.Lampe)
                            m_cartesEntraveJoueur.Remove(outilBrise);
                    }
                    break;

                case Outils.Pioche:
                    //La pioche est cassé
                    m_Pioche = true;
                    foreach (OutilsBrises outilBrise in m_cartesEntraveJoueur)
                    {
                        if (outilBrise.Outils == Outils.Pioche)
                            m_cartesEntraveJoueur.Remove(outilBrise);
                    }
                    break;
            }
        }


        public void RetirerCarteDeLaMain(Plateau p_plateau, Carte p_carte)
        {
            m_mainJoueur.Remove(p_carte);
            p_plateau.Defausse.Add(p_carte);
        }

        public Carte getCarteAtPosition(List<Carte> liste, int position)
        {
            return liste.ElementAt(position);
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

        public int NbPepites
        {
            get
            {
                return m_nbPepites;
            }

            set
            {
                m_nbPepites = value;
            }
        }

        internal List<Carte> CartesEntraveJoueur
        {
            get
            {
                return m_cartesEntraveJoueur;
            }

            set
            {
                m_cartesEntraveJoueur = value;
            }
        }

        public bool Pioche
        {
            get
            {
                return m_Pioche;
            }

            set
            {
                m_Pioche = value;
            }
        }

        public bool Chariot
        {
            get
            {
                return m_Chariot;
            }

            set
            {
                m_Chariot = value;
            }
        }

        public bool Lampe
        {
            get
            {
                return m_Lampe;
            }

            set
            {
                m_Lampe = value;
            }
        }
        #endregion
    }
}
