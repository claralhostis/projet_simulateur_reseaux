using System;
using System.Collections.Generic;
using System.Text;

namespace Simulateur_reseaux
{
    class Vendeur : Consommateur

    {
        public double Consommation;


        public Vendeur(string name, double Consommation) : base(name, "Vendeur")
        {
            this.Consommation = Consommation;
        }


        public double ConsommationVendeur
        {
            get { return Consommation; }
            set { Consommation = value; }
        }
    }
}
