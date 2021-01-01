using System;
using System.Collections.Generic;
using System.Text;

namespace Simulateur_reseaux
{
    abstract class Arete
    {
        public double PuissanceMaximale;

        public Arete()
        {
            this.PuissanceMaximale = 0;
        }

        public virtual void UpdateEnergieLine()
        {
        }
    }
}
