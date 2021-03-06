﻿using System;
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

        public CentraleSolaire(string name, double quantCO2, int taille, bool enFonction) : base(name, quantCO2, enFonction)
        {
            Taille = taille;
        }


        public override void UpdateProd()
        {
            int soleil = Meteo.getSoleil();
            if (soleil > 0)
            {
                QuantiteEnergieProduite = 77 * Taille; //Prod : 77 * taille en ha * 1000 pour la conversion en m²
            }
        }
    }
}
