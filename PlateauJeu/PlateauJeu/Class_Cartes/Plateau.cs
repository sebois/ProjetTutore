using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlateauJeu.Class_Cartes
{
    class Plateau
    {
        private List<Carte> Pioche;
        private List<Carte> Defausse;

        public Plateau()
        {
            //On ajoute toute les cartes
            Pioche.Add();
            //etc...

        }

        public Carte PrendreCarte(Joueur joueur)
        {
            Random rnd = new Random();
            int nb_rnd = rnd.Next(Pioche.Count());

            Carte tmp = Pioche.ElementAt(nb_rnd);

            Pioche.Remove(tmp);
            return tmp;
        }
    }
}
