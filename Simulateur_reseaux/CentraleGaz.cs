using System;
using System.Collections.Generic;
using System.Text;

namespace Simulateur_reseaux
{
    class CentraleGaz : CentraleDeProduction
    {

        public CentraleGaz(string name, double couts, double quantCO2): base(name, couts, quantCO2)
        {
        }
        public override void UpdateProd()
        {
            Random rnd = new Random();
            if (QuantiteEnergieProduite == 0)
            {
                QuantiteEnergieProduite = rnd.Next(1000, 4000);
            } 
            else
            {
                double coef = rnd.NextDouble() * 2;
                QuantiteEnergieProduite *= coef;
            }
        }
    }
}
