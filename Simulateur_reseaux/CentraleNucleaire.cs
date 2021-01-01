using System;
using System.Collections.Generic;
using System.Text;

namespace Simulateur_reseaux
{
    class CentraleNucleaire : CentraleDeProduction
    {
        private bool _full;
        public bool Full
        {
            get => _full;
            set => _full = value;
        }
        public CentraleNucleaire(string name, double quantCO2, bool enFonction) : base(name, quantCO2, enFonction)
        {
            this.Full = false;
        }

        public override void UpdateProd()
        {
            if (Full != true)
            {
                if (QuantiteEnergieProduite < 6000)
                {
                    QuantiteEnergieProduite += 250;
                }
                else if (QuantiteEnergieProduite == 6000)
                {
                    Full = true;
                }
            }
        }
    }
}
