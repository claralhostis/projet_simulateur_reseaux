﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Simulateur_reseaux
{
    abstract class CentraleDeProduction : Noeud
    {
        private double _coutProduction;
        private double _quantiteCO2;
        private double _quantiteEnergieProduite;
        private bool _running;

        public double CoutProduction
        {
            get => _coutProduction;
            set => _coutProduction = value;
        }
        public double QuantiteCO2
        {
            get => _quantiteCO2;
            set => _quantiteCO2 = value;
        }

        public double QuantiteEnergieProduite
        {
            get => _quantiteEnergieProduite;
            set => _quantiteEnergieProduite = value;
        }

        public bool Running
        {
            get => _running;
            set => _running = value;
        }

        public CentraleDeProduction(string name, double qteCo, bool enFonction) : base(name)
        {
            this.CoutProduction = 0;
            this.QuantiteCO2 = qteCo;
            this.QuantiteEnergieProduite = 0;
            this.Running = enFonction;
        }

        public void Shutdown()
        {
            this.Running = false;
            this.QuantiteEnergieProduite = 0;
        }

        public void Ignition()
        {
            this.Running = true;
        }


        public virtual void UpdateProd()
        {
        }

        public virtual void UpdateCout()
        {
        }
    }

}
