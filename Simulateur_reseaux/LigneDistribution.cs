using System;
using System.Collections.Generic;
using System.Text;

namespace Simulateur_reseaux
{
    class LigneDistribution : Arete
    {
        private Fournisseur _fourni;
        private Consommateur _conso;

        public Fournisseur Fourni
        {
            get => _fourni;
            set => _fourni = value;
        }

        public Consommateur Conso
        {
            get => _conso;
            set => _conso = value;
        }

        public LigneDistribution(Fournisseur fourni, Consommateur conso): base()
        {
            this.Conso = conso;
            this.Fourni = fourni;
            this.PuissanceMaximale = fourni.PuissanceDistrib;
        }
    }
}
