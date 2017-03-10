using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlateauJeu.Class_Cartes
{
    class Joueur
    {
        private string m_nomJoueur;
        private int m_nbPepites;
        private Couleur m_couleurJoueur;

        //Les differents outils du joueur (si true = en bon état)
        private bool m_Pioche = true;
        private bool m_Chariot = true;
        private bool m_Lampe = true;

        //C'est la liste de carte du joueur
        private List<Carte> m_mainJoueur;
        //C'est la liste des cartes qui entrave le jeu de l'utilisateur
        private List<OutilsBrises> m_cartesEntraveJoueur;


        public Joueur(string p_nomJoueur, Couleur p_couleurJoueur, Plateau p_plateau)
        {
            m_mainJoueur = new List<Carte>();
            m_cartesEntraveJoueur = new List<OutilsBrises>();
            m_nomJoueur = p_nomJoueur;
            m_nbPepites = 0;
            m_couleurJoueur = p_couleurJoueur;
            for(int i = 0; i<6; i++)
            {
                Piocher(p_plateau, 1);
            }
        }


        public void Piocher(Plateau p_plateau, int nbCarteAPiocher)
        {
            if (nbCarteAPiocher > 0 && nbCarteAPiocher < 3)
            {
                for ( int i = 1; i <=nbCarteAPiocher; i++)
                {
                    Carte tmp = p_plateau.PrendreCarte();
                    //La carte est déja retirer de la pioche 
                    m_mainJoueur.Add(tmp);
                }
            }
        }


        public void Briser(Joueur joueur, OutilsBrises CarteOutilABriser)
        {
            switch (CarteOutilABriser.Outils)
            {
                case Outils.Chariot :
                    //Le chariot est cassé
                    joueur.m_Chariot = false;
                    break;

                case Outils.Lampe :
                    //La lampe est cassé
                    joueur.m_Lampe = false;
                    break;

                case Outils.Pioche :
                    //La pioche est cassé
                    joueur.m_Pioche = false;
                    break;
            }
            joueur.m_cartesEntraveJoueur.Add(CarteOutilABriser);
        } 


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
    }
}
