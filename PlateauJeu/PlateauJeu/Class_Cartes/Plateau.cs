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
        private List<Depart> Departs;
        private List<CarteObjectif> Objectifs;
        private List<Carte> Defausse;

        public Plateau()
        {
            Pioche.Add(new CarteChemin(p_imgRecto: new System.Drawing.Bitmap("../Cartes/CarteChemin/cc1"), p_l_GaucheDroite: true, p_l_HautGauche: true, p_l_HautDroite: true, p_Porte: new Porte("haut", "vert")));
            Pioche.Add(new CarteChemin(p_imgRecto: new System.Drawing.Bitmap("../Cartes/CarteChemin/cc2"), p_l_GaucheDroite: true, p_l_HautGauche: true, p_l_HautDroite: true, p_Troll: new Troll(1, "droite")));
            Pioche.Add(new CarteChemin(p_imgRecto: new System.Drawing.Bitmap("../Cartes/CarteChemin/cc3"), p_l_HautGauche: true));
            Pioche.Add(new CarteChemin(p_imgRecto: new System.Drawing.Bitmap("../Cartes/CarteChemin/cc4"), p_l_HautDroite: true));
            Pioche.Add(new CarteChemin(p_imgRecto: new System.Drawing.Bitmap("../Cartes/CarteChemin/cc5"), p_l_HautGauche: true, p_l_BasGauche: true, p_Pepite: new Pepite(1, "droite")));
            Pioche.Add(new CarteChemin(p_imgRecto: new System.Drawing.Bitmap("../Cartes/CarteChemin/cc6"), p_l_HautBas: true));
            Pioche.Add(new CarteChemin(p_imgRecto: new System.Drawing.Bitmap("../Cartes/CarteChemin/cc7"), p_l_HautBas: true));
            Pioche.Add(new CarteChemin(p_imgRecto: new System.Drawing.Bitmap("../Cartes/CarteChemin/cc8"), p_l_HautDroite: true, p_l_BasDroite: true, p_l_HautBas: true));
            Pioche.Add(new CarteChemin(p_imgRecto: new System.Drawing.Bitmap("../Cartes/CarteChemin/cc9"), p_l_BasDroite: true, p_haut: true));
            Pioche.Add(new CarteChemin(p_imgRecto: new System.Drawing.Bitmap("../Cartes/CarteChemin/cc10"), p_l_GaucheDroite: true, p_l_HautBas: true, p_Pepite : new Pepite(1, "haut")));
            Pioche.Add(new CarteChemin(p_imgRecto: new System.Drawing.Bitmap("../Cartes/CarteChemin/cc11"), p_l_HautDroite: true));
            Pioche.Add(new CarteChemin(p_imgRecto: new System.Drawing.Bitmap("../Cartes/CarteChemin/cc12"), p_l_HautGauche: true, p_Echelle : new Echelle("bleu")));
            Pioche.Add(new CarteChemin(p_imgRecto: new System.Drawing.Bitmap("../Cartes/CarteChemin/cc13"), p_l_HautBas: true, p_l_GaucheDroite: true));
            Pioche.Add(new CarteChemin(p_imgRecto: new System.Drawing.Bitmap("../Cartes/CarteChemin/cc14"), p_l_GaucheDroite: true, p_l_BasGauche: true, p_l_BasDroite: true, p_Pepite : new Pepite(1, "haut")));
            Pioche.Add(new CarteChemin(p_imgRecto: new System.Drawing.Bitmap("../Cartes/CarteChemin/cc15"), p_l_HautBas: true));
            Pioche.Add(new CarteChemin(p_imgRecto: new System.Drawing.Bitmap("../Cartes/CarteChemin/cc16"), p_l_HautBas: true, p_l_BasDroite: true, p_l_HautDroite: true, p_Porte: new Porte("haut", "vert")));
            Pioche.Add(new CarteChemin(p_imgRecto: new System.Drawing.Bitmap("../Cartes/CarteChemin/cc17"), p_l_HautGauche: true, p_l_BasDroite: true, p_Pepite: new Pepite(1, "droite")));
            Pioche.Add(new CarteChemin(p_imgRecto: new System.Drawing.Bitmap("../Cartes/CarteChemin/cc18"), p_l_HautBas: true, p_l_HautGauche: true, p_l_HautDroite: true, p_l_BasDroite: true, p_l_BasGauche: true, p_Troll: new Troll(1, "bas")));
            Pioche.Add(new CarteChemin(p_imgRecto: new System.Drawing.Bitmap("../Cartes/CarteChemin/cc19"), p_l_BasGauche: true, p_droite: true));
            Pioche.Add(new CarteChemin(p_imgRecto: new System.Drawing.Bitmap("../Cartes/CarteChemin/cc20"), p_l_BasGauche: true, p_Echelle : new Echelle("vert")));
            Pioche.Add(new CarteChemin(p_imgRecto: new System.Drawing.Bitmap("../Cartes/CarteChemin/cc21"), p_l_HautBas: true, p_droite: true));
            Pioche.Add(new CarteChemin(p_imgRecto: new System.Drawing.Bitmap("../Cartes/CarteChemin/cc22"), p_l_HautGauche: true, p_l_HautBas: true, p_l_BasGauche: true, p_Troll : new Troll(1, "bas")));
            Pioche.Add(new CarteChemin(p_imgRecto: new System.Drawing.Bitmap("../Cartes/CarteChemin/cc23"), p_l_HautDroite: true, p_l_BasGauche: true));
            Pioche.Add(new CarteChemin(p_imgRecto: new System.Drawing.Bitmap("../Cartes/CarteChemin/cc24"), p_l_HautDroite: true, p_l_HautBas: true, p_l_HautGauche: true, p_l_BasGauche: true, p_l_BasDroite: true, p_l_GaucheDroite: true, p_Porte: new Porte("droite", "vert")));
            Pioche.Add(new CarteChemin(p_imgRecto: new System.Drawing.Bitmap("../Cartes/CarteChemin/cc25"), p_l_HautDroite: true, p_l_HautGauche: true, p_Porte : new Porte("droite", "vert")));
            Pioche.Add(new CarteChemin(p_imgRecto: new System.Drawing.Bitmap("../Cartes/CarteChemin/cc26"), p_l_GaucheDroite: true, p_Pepite : new Pepite(1, "bas")));
            Pioche.Add(new CarteChemin(p_imgRecto: new System.Drawing.Bitmap("../Cartes/CarteChemin/cc27"), p_l_GaucheDroite: true));
            Pioche.Add(new CarteChemin(p_imgRecto: new System.Drawing.Bitmap("../Cartes/CarteChemin/cc28"), p_l_GaucheDroite: true));
            Pioche.Add(new CarteChemin(p_imgRecto: new System.Drawing.Bitmap("../Cartes/CarteChemin/cc29"), p_l_BasDroite: true, p_gauche: true));
            Pioche.Add(new CarteChemin(p_imgRecto: new System.Drawing.Bitmap("../Cartes/CarteChemin/cc30"), p_l_HautBas: true, p_l_HautGauche: true, p_l_HautDroite: true, p_l_BasGauche: true, p_l_BasDroite: true, p_Porte : new Porte("bas", "bleu")));
            Pioche.Add(new CarteChemin(p_imgRecto: new System.Drawing.Bitmap("../Cartes/CarteChemin/cc31"), p_l_HautDroite: true, p_bas: true));
            Pioche.Add(new CarteChemin(p_imgRecto: new System.Drawing.Bitmap("../Cartes/CarteChemin/cc32"), p_l_GaucheDroite: true));
            Pioche.Add(new CarteChemin(p_imgRecto: new System.Drawing.Bitmap("../Cartes/CarteChemin/cc33"), p_l_GaucheDroite: true));
            Pioche.Add(new CarteChemin(p_imgRecto: new System.Drawing.Bitmap("../Cartes/CarteChemin/cc34"), p_l_HautGauche: true));
            Pioche.Add(new CarteChemin(p_imgRecto: new System.Drawing.Bitmap("../Cartes/CarteChemin/cd3"), p_l_HautGauche: true, p_Echelle : new Echelle("bleu")));
            Pioche.Add(new CarteChemin(p_imgRecto: new System.Drawing.Bitmap("../Cartes/CarteChemin/cd4"), p_l_BasGauche: true, p_Echelle : new Echelle("vert")));

            Pioche.Add(new Reparer(p_imgRecto: new System.Drawing.Bitmap("../Cartes/CarteChemin/ca1"), p_outils: new List<Outils> { Outils.Pioche }));
            Pioche.Add(new OutilsBrises(p_imgRecto: new System.Drawing.Bitmap("../Cartes/CarteChemin/ca2"), p_outils: Outils.Pioche));
            Pioche.Add(new PlanSecret(p_imgRecto: new System.Drawing.Bitmap("../Cartes/CarteChemin/ca3")));
            Pioche.Add(new PlanSecret(p_imgRecto: new System.Drawing.Bitmap("../Cartes/CarteChemin/ca4")));
            Pioche.Add(new Cle(p_imgRecto: new System.Drawing.Bitmap("../Cartes/CarteChemin/ca5")));
            Pioche.Add(new Cle(p_imgRecto: new System.Drawing.Bitmap("../Cartes/CarteChemin/ca6")));
            Pioche.Add(new OutilsBrises(p_imgRecto: new System.Drawing.Bitmap("../Cartes/CarteChemin/ca7"), p_outils: Outils.Lampe));
            Pioche.Add(new OutilsBrises(p_imgRecto: new System.Drawing.Bitmap("../Cartes/CarteChemin/ca8"), p_outils: Outils.Pioche));
            Pioche.Add(new Reparer(p_imgRecto: new System.Drawing.Bitmap("../Cartes/CarteChemin/ca9"), p_outils: new List<Outils> { Outils.Chariot }));
            Pioche.Add(new OutilsBrises(p_imgRecto: new System.Drawing.Bitmap("../Cartes/CarteChemin/ca10"), p_outils: Outils.Chariot));
            Pioche.Add(new OutilsBrises(p_imgRecto: new System.Drawing.Bitmap("../Cartes/CarteChemin/ca11"), p_outils: Outils.Chariot));
            Pioche.Add(new Reparer(p_imgRecto: new System.Drawing.Bitmap("../Cartes/CarteChemin/ca12"), p_outils: new List<Outils> { Outils.Pioche, Outils.Chariot }));
            Pioche.Add(new Eboulement(p_imgRecto: new System.Drawing.Bitmap("../Cartes/CarteChemin/ca13")));
            Pioche.Add(new Reparer(p_imgRecto: new System.Drawing.Bitmap("../Cartes/CarteChemin/ca14"), p_outils: new List<Outils> { Outils.Chariot, Outils.Lampe }));
            Pioche.Add(new Reparer(p_imgRecto: new System.Drawing.Bitmap("../Cartes/CarteChemin/ca15"), p_outils: new List<Outils> { Outils.Lampe, Outils.Pioche }));
            Pioche.Add(new Reparer(p_imgRecto: new System.Drawing.Bitmap("../Cartes/CarteChemin/ca16"), p_outils: new List<Outils> { Outils.Lampe }));
            Pioche.Add(new OutilsBrises(p_imgRecto: new System.Drawing.Bitmap("../Cartes/CarteChemin/ca17"), p_outils: Outils.Lampe));
            Pioche.Add(new Eboulement(p_imgRecto: new System.Drawing.Bitmap("../Cartes/CarteChemin/ca18")));

            Departs.Add(new Depart(p_imgRecto: new System.Drawing.Bitmap("../Cartes/CarteChemin/cd1"), p_l_HautGauche: true, p_l_HautBas: true, p_l_HautDroite: true, p_l_BasGauche: true, p_l_BasDroite: true, p_l_GaucheDroite: true, p_couleurJoueur: "bleu"));
            Departs.Add(new Depart(p_imgRecto: new System.Drawing.Bitmap("../Cartes/CarteChemin/cd2"), p_l_HautGauche: true, p_l_HautBas: true, p_l_HautDroite: true, p_l_BasGauche: true, p_l_BasDroite: true, p_l_GaucheDroite: true, p_couleurJoueur: "vert"));

            Objectifs.Add(new CarteObjectif(p_imgRecto: new System.Drawing.Bitmap("../Cartes/CarteObjectif/co1"), p_l_GaucheDroite: true, p_l_HautDroite: true, p_l_HautGauche: true, p_Porte: new Porte("haut", "bleu"), p_Pepite: new Pepite(2, "gauche")));
            Objectifs.Add(new CarteObjectif(p_imgRecto: new System.Drawing.Bitmap("../Cartes/CarteObjectif/co2"), p_l_HautBas: true, p_l_HautGauche: true, p_l_BasGauche: true, p_Porte: new Porte("gauche", "bleu"), p_Pepite: new Pepite(1, "bas")));
            Objectifs.Add(new CarteObjectif(p_imgRecto: new System.Drawing.Bitmap("../Cartes/CarteObjectif/co3"), p_l_HautBas: true, p_gauche: true, p_droite: true, p_Pepite: new Pepite(1, "bas")));
            Objectifs.Add(new CarteObjectif(p_imgRecto: new System.Drawing.Bitmap("../Cartes/CarteObjectif/co4"), p_l_GaucheDroite: true, p_l_BasGauche: true, p_l_BasDroite: true, p_Pepite: new Pepite(3, "droite")));
            Objectifs.Add(new CarteObjectif(p_imgRecto: new System.Drawing.Bitmap("../Cartes/CarteObjectif/co5"), p_l_BasGauche: true, p_Porte: new Porte("gauche", "bleu"), p_Pepite: new Pepite(1, "bas")));
            Objectifs.Add(new CarteObjectif(p_imgRecto: new System.Drawing.Bitmap("../Cartes/CarteObjectif/co6"), p_gauche: true, p_bas: true, p_Pepite: new Pepite(3, "bas")));
            Objectifs.Add(new CarteObjectif(p_imgRecto: new System.Drawing.Bitmap("../Cartes/CarteObjectif/co7"), p_l_HautBas: true, p_l_HautDroite: true, p_l_BasDroite: true, p_Porte: new Porte("bas", "bleu"), p_Pepite: new Pepite(3, "haut")));
            Objectifs.Add(new CarteObjectif(p_imgRecto: new System.Drawing.Bitmap("../Cartes/CarteObjectif/co8"), p_l_HautBas: true, p_l_HautGauche: true, p_l_BasGauche: true, p_Porte: new Porte("bas", "vert"), p_Pepite: new Pepite(2, "haut")));
            Objectifs.Add(new CarteObjectif(p_imgRecto: new System.Drawing.Bitmap("../Cartes/CarteObjectif/co9"), p_l_BasDroite: true, p_Porte: new Porte("bas", "vert"), p_Pepite: new Pepite(1, "bas")));
            Objectifs.Add(new CarteObjectif(p_imgRecto: new System.Drawing.Bitmap("../Cartes/CarteObjectif/co10"), p_l_BasDroite: true, p_Pepite: new Pepite(2, "bas")));
            Objectifs.Add(new CarteObjectif(p_imgRecto: new System.Drawing.Bitmap("../Cartes/CarteObjectif/co11"), p_bas: true, p_droite: true, p_Pepite: new Pepite(1, "droite")));
            Objectifs.Add(new CarteObjectif(p_imgRecto: new System.Drawing.Bitmap("../Cartes/CarteObjectif/co12"), p_l_BasGauche: true, p_Pepite: new Pepite(2, "bas")));
            Objectifs.Add(new CarteObjectif(p_imgRecto: new System.Drawing.Bitmap("../Cartes/CarteObjectif/co13"), p_l_GaucheDroite: true, p_bas: true, p_haut: true, p_Pepite: new Pepite(2, "gauche")));
            Objectifs.Add(new CarteObjectif(p_imgRecto: new System.Drawing.Bitmap("../Cartes/CarteObjectif/co14"), p_haut: true, p_droite: true, p_gauche: true, p_bas: true));
            Objectifs.Add(new CarteObjectif(p_imgRecto: new System.Drawing.Bitmap("../Cartes/CarteObjectif/co15"), p_haut: true, p_gauche: true, p_droite: true));
            Objectifs.Add(new CarteObjectif(p_imgRecto: new System.Drawing.Bitmap("../Cartes/CarteObjectif/co16"), p_l_GaucheDroite: true, p_l_HautDroite: true, p_l_HautGauche: true, p_Porte: new Porte("gauche", "vert"), p_Pepite: new Pepite(1, "gauche")));
            //On ajoute toute les cartes
            //Pioche.Add();
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
