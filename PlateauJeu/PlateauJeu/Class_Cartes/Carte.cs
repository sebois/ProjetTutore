using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlateauJeu.Class_Cartes
{
    abstract class Carte
    {
        protected Types m_type;
        protected System.Drawing.Bitmap m_imgRecto;

        public Carte(System.Drawing.Bitmap p_imgRecto)
        {
            m_imgRecto = p_imgRecto;
        }

        public Bitmap ImgRecto
        {
            get
            {
                return m_imgRecto;
            }

            set
            {
                m_imgRecto = value;
            }
        }
    }
}
