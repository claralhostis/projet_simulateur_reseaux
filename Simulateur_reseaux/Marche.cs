using System;
using System.Collections.Generic;
using System.Text;

namespace Simulateur_reseaux
{
    interface Marche
    {
        public static double getGazPrice()
        {
            Random rnd = new Random();
            return rnd.NextDouble() + 1;
        }
    }
}
