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

        public Reparer(System.Drawing.Bitmap p_imgRecto, List<Outils> type) : base(p_imgRecto)
        {
            foreach (Outils outil in type)
                m_outils.Add(outil);
        }
    }
}
