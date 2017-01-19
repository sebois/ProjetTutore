using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaboteurLeDuel
{
    class CarteChemin : Carte
    {
        private int id;
        private Boolean l_HautBas;
        private Boolean l_GaucheDroite;
        private Boolean l_HautGauche;
        private Boolean l_HautDroite;
        private Boolean l_BasGauche;
        private Boolean l_BasDroite;
        private Boolean haut;
        private Boolean bas;
        private Boolean droite;
        private Boolean gauche;

        private Boolean objectif;

        public CarteChemin(Boolean hb, Boolean gd, Boolean hg, Boolean hd, Boolean bg, Boolean bd, Boolean obj)
        {
            #region initialisation
            l_BasDroite = bd;
            l_BasGauche = bg;
            l_GaucheDroite = gd;
            l_HautBas = hb;
            l_HautDroite = hd;
            l_HautGauche = hg;

            objectif = obj;
            #endregion

            #region Calcul_Acces
            if (l_BasDroite || l_BasGauche || l_HautBas)
            {
                bas = true;
            }
            else
            {
                bas = false;
            }

            if (l_BasGauche || l_HautGauche || l_GaucheDroite)
            {
                gauche = true;
            }
            else
            {
                gauche = false;
            }

            if (l_HautDroite || l_HautGauche || l_HautBas)
            {
                haut = true;
            }
            else
            {
                haut = false;
            }

            if (l_BasDroite || l_GaucheDroite || l_HautDroite)
            {
                droite = true;
            }
            else
            {
                droite = false;
            }
#endregion
        }

        public void Rotation()
        {
            #region Rotation180
            Boolean tampon;

            tampon = l_BasDroite;
            l_BasDroite = l_HautGauche;
            l_HautGauche = tampon;

            tampon = l_BasGauche;
            l_BasGauche = l_HautDroite;
            l_HautDroite = tampon;

            tampon = haut;
            haut = bas;
            bas = tampon;

            tampon = gauche;
            gauche = droite;
            droite = tampon;
            #endregion

        }

        public void placer(int x, int y)
        {
            new Exception("CarteChemin placer : non implémenter");
        }

        public void retirer()
        {
            new Exception("CarteChemin retirer : non implémenter");
        }

        public Boolean verifPlacement(int x, int y)
        {
            new Exception("CarteChemin verifPlacement : non implémenter");
            return false;
        }
        
    }
}
