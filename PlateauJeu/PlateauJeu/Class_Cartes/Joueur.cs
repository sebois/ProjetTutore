using System;
using System.Collections.Generic;
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
            m_nomJoueur = p_nomJoueur;
            m_nbPepites = 0;
            m_couleurJoueur = p_couleurJoueur;
            //for(int i = 0; i<6; i++)
            //{
            //    Piocher(p_plateau);
            //}
        }

        public void Piocher(Plateau p_plateau)
        {
            Carte tmp = p_plateau.PrendreCarte();
            m_mainJoueur.Add(tmp);
        }


        public void Briser(Outils OutilABriser)
        {
            switch (OutilABriser)
            {
                case Outils.Chariot :
                    //Le chariot est cassé
                    m_Chariot = false;
                    //TODO : Ajouter a la liste de carte qui entrave
                    //m_cartesEntraveJoueur.Add()
                    break;

                case Outils.Lampe :
                    //La lampe est cassé
                    m_Lampe = false;
                    break;

                case Outils.Pioche :
                    //La pioche est cassé
                    m_Pioche = false;
                    break;

            }
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
    }
}
