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
            Console.WriteLine("Nouvelle arrete entre le fournisseur " + Fourni.Nom + " et le producteur " + Prod.Nom);
        }

        public override void UpdateEnergieLine()
        {
            this.PuissanceMaximale = this.Prod.QuantiteEnergieProduite;
        }

        public void Show()
        {
            Console.WriteLine("Centrale de production : " + this.Prod.Nom + " | Energie transportée : " + this.PuissanceMaximale + " | Cout : " + this.Prod.CoutProduction);
        }

    }
}
