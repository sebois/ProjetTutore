using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlateauJeu.Class_Cartes
{
    class Troll
    {
        private byte m_prix;
        private Position m_pos;
        private bool m_ouvert;

        public Troll(byte p_prix, Position p_pos)
        {
            m_prix = p_prix;
            m_pos = p_pos;
            m_ouvert = false;
        }
    }
}
