using System;
using System.Collections.Generic;
using System.Text;

namespace Simulateur_reseaux
{
    class Ville : Consommateur
    {
        private double Consommation;


        public Ville (string name, double Consommation):base(name, "Ville")
        {
            this.Consommation = Consommation;
        }


        public double ConsommationVille
        {
            get { return Consommation; }
            set { Consommation = value; }
        }




    }
}
