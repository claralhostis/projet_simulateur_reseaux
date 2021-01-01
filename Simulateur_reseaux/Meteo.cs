using System;
using System.Collections.Generic;
using System.Text;

namespace Simulateur_reseaux
{
    interface Meteo
    {
        public static int getSoleil()
        {
            Random rnd = new Random(); 
            return rnd.Next(0,2);
        }

        public static int getVent()
        {
            Random rnd = new Random();
            return rnd.Next(10, 100);
        }
    }
}
