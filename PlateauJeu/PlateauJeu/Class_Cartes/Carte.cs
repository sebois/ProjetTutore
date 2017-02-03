using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlateauJeu.Class_Cartes
{
    abstract class Carte
    {
        protected string m_type;
        protected System.Drawing.Bitmap m_imgRecto;

        public Carte(System.Drawing.Bitmap p_imgRecto)
        {
            m_imgRecto = p_imgRecto;
        }
    }
}
