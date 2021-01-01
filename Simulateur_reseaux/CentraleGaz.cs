using System;
using System.Collections.Generic;
using System.Text;

namespace Simulateur_reseaux
{
    class CentraleGaz : CentraleDeProduction
    {

        public CentraleGaz(string name, double quantCO2, bool enFonction): base(name, quantCO2, enFonction)
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
                double coef = rnd.NextDouble() * 3.5;
                QuantiteEnergieProduite *= coef;
            }
        }

        public override void UpdateCout()
        {
            CoutProduction = (QuantiteEnergieProduite * Marche.getGazPrice()) / 100; 
        }
    }
}
