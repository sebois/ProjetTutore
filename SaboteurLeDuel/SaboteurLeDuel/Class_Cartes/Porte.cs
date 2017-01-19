using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SaboteurLeDuel.Class_Cartes
{
    class Porte : CarteChemin
    {
        private String position;
        private Byte joueur;
        private Boolean ouvert;

        public Porte(Boolean hb, Boolean gd, Boolean hg, Boolean hd, Boolean bg, Boolean bd, String pos, Byte j) : base(hb, gd, hg, hd, bg, bd, false)
        {
            position = pos;
            joueur = j;
            ouvert = false;
        }

        public Boolean ouvrir()
        {
            if (ouvert == false)
            {
                ouvert = true;
                return true;            
            }
            MessageBox.Show("La porte est déjà ouverte", "ERREUR :", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;              
        }
    }
}
