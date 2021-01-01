using System;
using System.Collections.Generic;
using System.Text;

namespace Simulateur_reseaux
{
    class Entreprise : Consommateur
    {
      

        public Entreprise(string name, double conso) : base(name, "Entreprise",conso)
        {
        }
    }
}