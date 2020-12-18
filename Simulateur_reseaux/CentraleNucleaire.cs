using System;
using System.Collections.Generic;
using System.Text;

namespace Simulateur_reseaux
{
    class CentraleNucleaire : CentraleDeProduction
    {
        public CentraleNucleaire(string name, double couts, double quantCO2) : base(name, couts, quantCO2)
        { 
        }

        public override void UpdateProd()
        {
            QuantiteEnergieProduite = (QuantiteEnergieProduite < 6000) ? QuantiteEnergieProduite += 250 : QuantiteEnergieProduite;
        }
    }
}
