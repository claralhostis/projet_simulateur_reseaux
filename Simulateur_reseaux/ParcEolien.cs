using System;
using System.Collections.Generic;
using System.Text;

namespace Simulateur_reseaux
{
    class ParcEolien : CentraleDeProduction
    {
        public ParcEolien(string name, double quantCO2, bool enFonction) : base(name, quantCO2, enFonction)
        {
        }

        public override void UpdateProd()
        {
            int vent = Meteo.getVent();
            if (vent>15 && vent< 90)
            {
                QuantiteEnergieProduite = 0.37 * (90 * Math.PI) * (vent * 1000 / 3600); //W.s-1
            }
        }
    }
}
