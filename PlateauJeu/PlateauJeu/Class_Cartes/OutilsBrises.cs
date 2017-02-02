using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlateauJeu.Class_Cartes
{
    class OutilsBrises : Action
    {
        private List<Outils> m_outils;

        public OutilsBrises(List<Outils> type)
        {
            foreach (Outils outil in type)
                m_outils.Add(outil);
        }


    }
}
