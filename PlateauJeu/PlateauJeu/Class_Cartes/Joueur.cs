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
        private String m_couleurJoueur;

        //Les differents outils du joueur (si true = en bon état)
        private Boolean m_Pioche = true;
        private Boolean m_Chariot = true;
        private Boolean m_Lampe = true;

        //C'est la liste de carte du joueur
        private List<Carte> m_mainJoueur;
        //C'est la liste des cartes qui entrave le jeu de l'utilisateur
        private List<OutilsBrises> m_cartesEntraveJoueur;


        public Joueur(String p_nom, String p_couleur)
        {
            NomJoueur = p_nom;
            m_nbPepites = 0;

            if (p_nom == "Bleu" | p_nom == "Vert")
                m_couleurJoueur = p_couleur;
        }

        public void Piocher()
        {
            //ATTENTION!!! ??? monPlateau ???
            Carte tmp = monPlateau.PrendreCarte();
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
