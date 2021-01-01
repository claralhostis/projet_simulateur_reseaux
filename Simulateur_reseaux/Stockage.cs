using System;
using System.Collections.Generic;
using System.Text;

namespace Simulateur_reseaux
{
    class Stockage
    {
        private double _eStock;
        private double _eMax;

        public double EStock
        {
            get => _eStock;
            set => _eStock = value;
        }

        public double EMax
        {
            get => _eMax;
            set => _eMax=value;
        }

        public Stockage(double emax)
        {
            this.EMax = emax;
            this.EStock = 0;
        }

        public void AddToStock(double val)
        {
            if (EStock + val > EMax)
            {
                this.EStock=5000;
            }
            else
            {
                EStock += val;
            }
            
        }
    }
}
