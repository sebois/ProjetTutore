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
            Pioche.Add(new CarteChemin(p_imgRecto: new System.Drawing.Bitmap("Cartes/CarteChemin/cc1.jpg"), p_l_GaucheDroite: true, p_l_HautGauche: true, p_l_HautDroite: true, p_Porte: new Porte(Position.Haut, Couleur.Vert)));
            Pioche.Add(new CarteChemin(p_imgRecto: new System.Drawing.Bitmap("Cartes/CarteChemin/cc2.jpg"), p_l_GaucheDroite: true, p_l_HautGauche: true, p_l_HautDroite: true, p_Troll: new Troll(1, Position.Droite)));
            Pioche.Add(new CarteChemin(p_imgRecto: new System.Drawing.Bitmap("Cartes/CarteChemin/cc3.jpg"), p_l_HautGauche: true));
            Pioche.Add(new CarteChemin(p_imgRecto: new System.Drawing.Bitmap("Cartes/CarteChemin/cc4.jpg"), p_l_HautDroite: true));
            Pioche.Add(new CarteChemin(p_imgRecto: new System.Drawing.Bitmap("Cartes/CarteChemin/cc5.jpg"), p_l_HautGauche: true, p_l_BasGauche: true, p_Pepite: new Pepite(1, Position.Droite)));
            Pioche.Add(new CarteChemin(p_imgRecto: new System.Drawing.Bitmap("Cartes/CarteChemin/cc6.jpg"), p_l_HautBas: true));
            Pioche.Add(new CarteChemin(p_imgRecto: new System.Drawing.Bitmap("Cartes/CarteChemin/cc7.jpg"), p_l_HautBas: true));
            Pioche.Add(new CarteChemin(p_imgRecto: new System.Drawing.Bitmap("Cartes/CarteChemin/cc8.jpg"), p_l_HautDroite: true, p_l_BasDroite: true, p_l_HautBas: true));
            Pioche.Add(new CarteChemin(p_imgRecto: new System.Drawing.Bitmap("Cartes/CarteChemin/cc9.jpg"), p_l_BasDroite: true, p_haut: true));
            Pioche.Add(new CarteChemin(p_imgRecto: new System.Drawing.Bitmap("Cartes/CarteChemin/cc10.jpg"), p_l_GaucheDroite: true, p_l_HautBas: true, p_Pepite : new Pepite(1, Position.Haut)));
            Pioche.Add(new CarteChemin(p_imgRecto: new System.Drawing.Bitmap("Cartes/CarteChemin/cc11.jpg"), p_l_HautDroite: true));
            Pioche.Add(new CarteChemin(p_imgRecto: new System.Drawing.Bitmap("Cartes/CarteChemin/cc12.jpg"), p_l_HautGauche: true, p_Echelle : new Echelle(Couleur.Bleu)));
            Pioche.Add(new CarteChemin(p_imgRecto: new System.Drawing.Bitmap("Cartes/CarteChemin/cc13.jpg"), p_l_HautBas: true, p_l_GaucheDroite: true));
            Pioche.Add(new CarteChemin(p_imgRecto: new System.Drawing.Bitmap("Cartes/CarteChemin/cc14.jpg"), p_l_GaucheDroite: true, p_l_BasGauche: true, p_l_BasDroite: true, p_Pepite : new Pepite(1, Position.Haut)));
            Pioche.Add(new CarteChemin(p_imgRecto: new System.Drawing.Bitmap("Cartes/CarteChemin/cc15.jpg"), p_l_HautBas: true));
            Pioche.Add(new CarteChemin(p_imgRecto: new System.Drawing.Bitmap("Cartes/CarteChemin/cc16.jpg"), p_l_HautBas: true, p_l_BasDroite: true, p_l_HautDroite: true, p_Porte: new Porte(Position.Haut, Couleur.Vert)));
            Pioche.Add(new CarteChemin(p_imgRecto: new System.Drawing.Bitmap("Cartes/CarteChemin/cc17.jpg"), p_l_HautGauche: true, p_l_BasDroite: true, p_Pepite: new Pepite(1, Position.Droite)));
            Pioche.Add(new CarteChemin(p_imgRecto: new System.Drawing.Bitmap("Cartes/CarteChemin/cc18.jpg"), p_l_HautBas: true, p_l_HautGauche: true, p_l_HautDroite: true, p_l_BasDroite: true, p_l_BasGauche: true, p_Troll: new Troll(1, Position.Bas)));
            Pioche.Add(new CarteChemin(p_imgRecto: new System.Drawing.Bitmap("Cartes/CarteChemin/cc19.jpg"), p_l_BasGauche: true, p_droite: true));
            Pioche.Add(new CarteChemin(p_imgRecto: new System.Drawing.Bitmap("Cartes/CarteChemin/cc20.jpg"), p_l_BasGauche: true, p_Echelle : new Echelle(Couleur.Vert)));
            Pioche.Add(new CarteChemin(p_imgRecto: new System.Drawing.Bitmap("Cartes/CarteChemin/cc21.jpg"), p_l_HautBas: true, p_droite: true));
            Pioche.Add(new CarteChemin(p_imgRecto: new System.Drawing.Bitmap("Cartes/CarteChemin/cc22.jpg"), p_l_HautGauche: true, p_l_HautBas: true, p_l_BasGauche: true, p_Troll : new Troll(1, Position.Bas)));
            Pioche.Add(new CarteChemin(p_imgRecto: new System.Drawing.Bitmap("Cartes/CarteChemin/cc23.jpg"), p_l_HautDroite: true, p_l_BasGauche: true));
            Pioche.Add(new CarteChemin(p_imgRecto: new System.Drawing.Bitmap("Cartes/CarteChemin/cc24.jpg"), p_l_HautDroite: true, p_l_HautBas: true, p_l_HautGauche: true, p_l_BasGauche: true, p_l_BasDroite: true, p_l_GaucheDroite: true, p_Porte: new Porte(Position.Droite, Couleur.Vert)));
            Pioche.Add(new CarteChemin(p_imgRecto: new System.Drawing.Bitmap("Cartes/CarteChemin/cc25.jpg"), p_l_HautDroite: true, p_l_HautGauche: true, p_Porte : new Porte(Position.Droite, Couleur.Vert)));
            Pioche.Add(new CarteChemin(p_imgRecto: new System.Drawing.Bitmap("Cartes/CarteChemin/cc26.jpg"), p_l_GaucheDroite: true, p_Pepite : new Pepite(1, Position.Bas)));
            Pioche.Add(new CarteChemin(p_imgRecto: new System.Drawing.Bitmap("Cartes/CarteChemin/cc27.jpg"), p_l_GaucheDroite: true));
            Pioche.Add(new CarteChemin(p_imgRecto: new System.Drawing.Bitmap("Cartes/CarteChemin/cc28.jpg"), p_l_GaucheDroite: true));
            Pioche.Add(new CarteChemin(p_imgRecto: new System.Drawing.Bitmap("Cartes/CarteChemin/cc29.jpg"), p_l_BasDroite: true, p_gauche: true));
            Pioche.Add(new CarteChemin(p_imgRecto: new System.Drawing.Bitmap("Cartes/CarteChemin/cc30.jpg"), p_l_HautBas: true, p_l_HautGauche: true, p_l_HautDroite: true, p_l_BasGauche: true, p_l_BasDroite: true, p_Porte : new Porte(Position.Bas, Couleur.Bleu)));
            Pioche.Add(new CarteChemin(p_imgRecto: new System.Drawing.Bitmap("Cartes/CarteChemin/cc31.jpg"), p_l_HautDroite: true, p_bas: true));
            Pioche.Add(new CarteChemin(p_imgRecto: new System.Drawing.Bitmap("Cartes/CarteChemin/cc32.jpg"), p_l_GaucheDroite: true));
            Pioche.Add(new CarteChemin(p_imgRecto: new System.Drawing.Bitmap("Cartes/CarteChemin/cc33.jpg"), p_l_GaucheDroite: true));
            Pioche.Add(new CarteChemin(p_imgRecto: new System.Drawing.Bitmap("Cartes/CarteChemin/cc34.jpg"), p_l_HautGauche: true));
            Pioche.Add(new CarteChemin(p_imgRecto: new System.Drawing.Bitmap("Cartes/CarteChemin/cd3.jpg"), p_l_HautGauche: true, p_Echelle : new Echelle(Couleur.Bleu)));
            Pioche.Add(new CarteChemin(p_imgRecto: new System.Drawing.Bitmap("Cartes/CarteChemin/cd4.jpg"), p_l_BasGauche: true, p_Echelle : new Echelle(Couleur.Vert)));

            Pioche.Add(new Reparer(p_imgRecto: new System.Drawing.Bitmap("Cartes/CarteAction/ca1.jpg"), p_outils: new List<Outils> { Outils.Pioche }));
            Pioche.Add(new OutilsBrises(p_imgRecto: new System.Drawing.Bitmap("Cartes/CarteAction/ca2.jpg"), p_outils: Outils.Pioche));
            Pioche.Add(new PlanSecret(p_imgRecto: new System.Drawing.Bitmap("Cartes/CarteAction/ca3.jpg")));
            Pioche.Add(new PlanSecret(p_imgRecto: new System.Drawing.Bitmap("Cartes/CarteAction/ca4.jpg")));
            Pioche.Add(new Cle(p_imgRecto: new System.Drawing.Bitmap("Cartes/CarteAction/ca5.jpg")));
            Pioche.Add(new Cle(p_imgRecto: new System.Drawing.Bitmap("Cartes/CarteAction/ca6.jpg")));
            Pioche.Add(new OutilsBrises(p_imgRecto: new System.Drawing.Bitmap("Cartes/CarteAction/ca7.jpg"), p_outils: Outils.Lampe));
            Pioche.Add(new OutilsBrises(p_imgRecto: new System.Drawing.Bitmap("Cartes/CarteAction/ca8.jpg"), p_outils: Outils.Pioche));
            Pioche.Add(new Reparer(p_imgRecto: new System.Drawing.Bitmap("Cartes/CarteAction/ca9.jpg"), p_outils: new List<Outils> { Outils.Chariot }));
            Pioche.Add(new OutilsBrises(p_imgRecto: new System.Drawing.Bitmap("Cartes/CarteAction/ca10.jpg"), p_outils: Outils.Chariot));
            Pioche.Add(new OutilsBrises(p_imgRecto: new System.Drawing.Bitmap("Cartes/CarteAction/ca11.jpg"), p_outils: Outils.Chariot));
            Pioche.Add(new Reparer(p_imgRecto: new System.Drawing.Bitmap("Cartes/CarteAction/ca12.jpg"), p_outils: new List<Outils> { Outils.Pioche, Outils.Chariot }));
            Pioche.Add(new Eboulement(p_imgRecto: new System.Drawing.Bitmap("Cartes/CarteAction/ca13.jpg")));
            Pioche.Add(new Reparer(p_imgRecto: new System.Drawing.Bitmap("Cartes/CarteAction/ca14.jpg"), p_outils: new List<Outils> { Outils.Chariot, Outils.Lampe }));
            Pioche.Add(new Reparer(p_imgRecto: new System.Drawing.Bitmap("Cartes/CarteAction/ca15.jpg"), p_outils: new List<Outils> { Outils.Lampe, Outils.Pioche }));
            Pioche.Add(new Reparer(p_imgRecto: new System.Drawing.Bitmap("Cartes/CarteAction/ca16.jpg"), p_outils: new List<Outils> { Outils.Lampe }));
            Pioche.Add(new OutilsBrises(p_imgRecto: new System.Drawing.Bitmap("Cartes/CarteAction/ca17.jpg"), p_outils: Outils.Lampe));
            Pioche.Add(new Eboulement(p_imgRecto: new System.Drawing.Bitmap("Cartes/CarteAction/ca18.jpg")));

            Departs.Add(new Depart(p_imgRecto: new System.Drawing.Bitmap("Cartes/CarteChemin/cd1.jpg"), p_l_HautGauche: true, p_l_HautBas: true, p_l_HautDroite: true, p_l_BasGauche: true, p_l_BasDroite: true, p_l_GaucheDroite: true, p_couleurJoueur: Couleur.Bleu));
            Departs.Add(new Depart(p_imgRecto: new System.Drawing.Bitmap("Cartes/CarteChemin/cd2.jpg"), p_l_HautGauche: true, p_l_HautBas: true, p_l_HautDroite: true, p_l_BasGauche: true, p_l_BasDroite: true, p_l_GaucheDroite: true, p_couleurJoueur: Couleur.Vert));

            Objectifs.Add(new CarteObjectif(p_imgRecto: new System.Drawing.Bitmap("Cartes/CarteObjectif/co1.jpg"), p_l_GaucheDroite: true, p_l_HautDroite: true, p_l_HautGauche: true, p_Porte: new Porte(Position.Haut, Couleur.Bleu), p_Pepite: new Pepite(2, Position.Gauche)));
            Objectifs.Add(new CarteObjectif(p_imgRecto: new System.Drawing.Bitmap("Cartes/CarteObjectif/co2.jpg"), p_l_HautBas: true, p_l_HautGauche: true, p_l_BasGauche: true, p_Porte: new Porte(Position.Gauche, Couleur.Bleu), p_Pepite: new Pepite(1, Position.Bas)));
            Objectifs.Add(new CarteObjectif(p_imgRecto: new System.Drawing.Bitmap("Cartes/CarteObjectif/co3.jpg"), p_l_HautBas: true, p_gauche: true, p_droite: true, p_Pepite: new Pepite(1, Position.Bas)));
            Objectifs.Add(new CarteObjectif(p_imgRecto: new System.Drawing.Bitmap("Cartes/CarteObjectif/co4.jpg"), p_l_GaucheDroite: true, p_l_BasGauche: true, p_l_BasDroite: true, p_Pepite: new Pepite(3, Position.Droite)));
            Objectifs.Add(new CarteObjectif(p_imgRecto: new System.Drawing.Bitmap("Cartes/CarteObjectif/co5.jpg"), p_l_BasGauche: true, p_Porte: new Porte(Position.Gauche, Couleur.Bleu), p_Pepite: new Pepite(1, Position.Bas)));
            Objectifs.Add(new CarteObjectif(p_imgRecto: new System.Drawing.Bitmap("Cartes/CarteObjectif/co6.jpg"), p_gauche: true, p_bas: true, p_Pepite: new Pepite(3, Position.Bas)));
            Objectifs.Add(new CarteObjectif(p_imgRecto: new System.Drawing.Bitmap("Cartes/CarteObjectif/co7.jpg"), p_l_HautBas: true, p_l_HautDroite: true, p_l_BasDroite: true, p_Porte: new Porte(Position.Bas, Couleur.Bleu), p_Pepite: new Pepite(3, Position.Haut)));
            Objectifs.Add(new CarteObjectif(p_imgRecto: new System.Drawing.Bitmap("Cartes/CarteObjectif/co8.jpg"), p_l_HautBas: true, p_l_HautGauche: true, p_l_BasGauche: true, p_Porte: new Porte(Position.Bas, Couleur.Vert), p_Pepite: new Pepite(2, Position.Haut)));
            Objectifs.Add(new CarteObjectif(p_imgRecto: new System.Drawing.Bitmap("Cartes/CarteObjectif/co9.jpg"), p_l_BasDroite: true, p_Porte: new Porte(Position.Bas, Couleur.Vert), p_Pepite: new Pepite(1, Position.Bas)));
            Objectifs.Add(new CarteObjectif(p_imgRecto: new System.Drawing.Bitmap("Cartes/CarteObjectif/co10.jpg"), p_l_BasDroite: true, p_Pepite: new Pepite(2, Position.Bas)));
            Objectifs.Add(new CarteObjectif(p_imgRecto: new System.Drawing.Bitmap("Cartes/CarteObjectif/co11.jpg"), p_bas: true, p_droite: true, p_Pepite: new Pepite(1, Position.Droite)));
            Objectifs.Add(new CarteObjectif(p_imgRecto: new System.Drawing.Bitmap("Cartes/CarteObjectif/co12.jpg"), p_l_BasGauche: true, p_Pepite: new Pepite(2, Position.Bas)));
            Objectifs.Add(new CarteObjectif(p_imgRecto: new System.Drawing.Bitmap("Cartes/CarteObjectif/co13.jpg"), p_l_GaucheDroite: true, p_bas: true, p_haut: true, p_Pepite: new Pepite(2, Position.Gauche)));
            Objectifs.Add(new CarteObjectif(p_imgRecto: new System.Drawing.Bitmap("Cartes/CarteObjectif/co14.jpg"), p_haut: true, p_droite: true, p_gauche: true, p_bas: true));
            Objectifs.Add(new CarteObjectif(p_imgRecto: new System.Drawing.Bitmap("Cartes/CarteObjectif/co15.jpg"), p_haut: true, p_gauche: true, p_droite: true));
            Objectifs.Add(new CarteObjectif(p_imgRecto: new System.Drawing.Bitmap("Cartes/CarteObjectif/co16.jpg"), p_l_GaucheDroite: true, p_l_HautDroite: true, p_l_HautGauche: true, p_Porte: new Porte(Position.Gauche, Couleur.Vert), p_Pepite: new Pepite(1, Position.Gauche)));
            //On ajoute toute les cartes
            //Les chemins des images sont relatifs au répertoire de l'executable
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
