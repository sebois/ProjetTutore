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

        public Reparer(List<Outils> type)
        {
            foreach (Outils outil in type)
                m_outils.Add(outil);
        }
    }
}
