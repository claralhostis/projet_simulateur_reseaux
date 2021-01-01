using System;
using System.Collections.Generic;
using System.Text;

namespace Simulateur_reseaux
{
    class Vendeur : Consommateur
    {
        public Vendeur(string name, double Consommation) : base(name, "Vendeur", Consommation)
        {
        }

    }
}
