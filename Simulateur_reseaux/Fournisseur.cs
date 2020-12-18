using System;
using System.Collections.Generic;
using System.Text;

namespace Simulateur_reseaux
{
    class Fournisseur : Noeud
    {

        private double _puissanceDistrib;
        private List<LigneProduction>_prod = new List<LigneProduction>();
        private List<LigneDistribution>_conso = new List<LigneDistribution>();

        public double PuissanceDistrib
        {
            get => _puissanceDistrib;
            set => _puissanceDistrib = value;
        }

        public List<LigneProduction> Prod
        {
            get => _prod;
            set => _prod = value;
        }

        public List<LigneDistribution> Conso
        {
            get => _conso;
            set => _conso = value;
        }

        public Fournisseur(string name) : base(name)
        {
            this.PuissanceDistrib = 0;
        }

        public void UpdatePuiss()
        {
            this.PuissanceDistrib = 0;
            foreach (LigneProduction line in this.Prod)
            {
                this.PuissanceDistrib += line.PuissanceMaximale;
            }
        }
    }
}
