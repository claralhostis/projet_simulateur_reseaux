using System;
using System.Collections.Generic;
using System.Text;

namespace Simulateur_reseaux
{
    class Entreprise : Consommateur
    {
        private double _consommation;

        public double Consommation
        {
            get { return _consommation; }
            set { _consommation = value; }
        }


        public Entreprise(string name, double conso) : base(name, "Entreprise")
        {
            this.Consommation = conso;
        }


     





    }
}