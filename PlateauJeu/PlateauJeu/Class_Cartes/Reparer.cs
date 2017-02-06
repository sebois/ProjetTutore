using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlateauJeu.Class_Cartes
{
    class Reparer : Action
    {
        private List<Outils> m_outils;

        public Reparer(System.Drawing.Bitmap p_imgRecto, List<Outils> p_outils) : base(p_imgRecto)
        {
            foreach (Outils outil in p_outils)
                m_outils.Add(outil);
        }
    }
}
