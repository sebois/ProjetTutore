using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlateauJeu.Class_Cartes
{
    class Porte
    {
        private Position m_pos;
        private Couleur m_couleurJoueur;
        private bool m_ouvert;

        public Porte(Position p_pos, Couleur p_couleurJoueur)
        {
            m_pos = p_pos;
            m_couleurJoueur = p_couleurJoueur;
            m_ouvert = false;
        }

        public bool ouvrir()
        {
            if (m_ouvert == false)
            {
                m_ouvert = true;
                return true;            
            }
            MessageBox.Show("La porte est déjà ouverte", "ERREUR :", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;              
        }
    }
}
