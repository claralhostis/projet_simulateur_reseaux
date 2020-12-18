using System;
using System.Collections.Generic;
using System.Text;

namespace Simulateur_reseaux
{
    class LigneProduction : Arete
    {
        private CentraleDeProduction _prod;
        private Fournisseur _fourni;

        public CentraleDeProduction Prod
        {
            get => _prod;
            set => _prod = value;
        }

        public Fournisseur Fourni
        {
            get => _fourni;
            set => _fourni = value;
        }

        public LigneProduction(CentraleDeProduction prod, Fournisseur fourni) : base()
        {
            this.Prod = prod;
            this.Fourni = fourni;
            this.PuissanceMaximale = prod.QuantiteEnergieProduite;
        }

        public void UpdateEnergieLine()
        {
            this.PuissanceMaximale = this.Prod.QuantiteEnergieProduite;
        }

        public void Show()
        {
            Console.WriteLine("Centrale de production : " + this.Prod.Nom + " | Fournisseur : " + this.Fourni.Nom + " | Energie prduite et transportée : " + this.PuissanceMaximale);
        }

    }
}
