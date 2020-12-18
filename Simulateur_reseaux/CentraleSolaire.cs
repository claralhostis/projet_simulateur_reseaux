using System;
using System.Collections.Generic;
using System.Text;

namespace Simulateur_reseaux
{
    class CentraleSolaire : CentraleDeProduction
    {
        private int _taille; //en ha

        public int Taille
        {
            get => _taille;
            set => _taille = value;
        }

        public CentraleSolaire(string name, double couts, double quantCO2, int taille) : base(name, couts, quantCO2)
        {
            Taille = taille;
        }


        public override void UpdateProd(int meteo)
        {
            if (meteo > 0)
            {
                QuantiteEnergieProduite = 77 * Taille * 1000; //Prod : 77 * taille en ha * 1000 pour la conversion en m²
            }
        }
    }
}
