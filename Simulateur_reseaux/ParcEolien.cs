using System;
using System.Collections.Generic;
using System.Text;

namespace Simulateur_reseaux
{
    class ParcEolien : CentraleDeProduction
    {
        public ParcEolien(string name, double couts, double quantCO2) : base(name, couts, quantCO2)
        {
        }

        public override void UpdateProd(int meteo)
        {
            if (meteo>15 && meteo < 90)
            {
                QuantiteEnergieProduite = 0.37 * (90 * Math.PI) * (meteo * 1000 / 3600); //W.s-1
            }
        }
    }
}
