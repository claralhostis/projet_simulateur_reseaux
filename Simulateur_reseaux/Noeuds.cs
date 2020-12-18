using System;
using System.Collections.Generic;
using System.Text;

namespace Simulateur_reseaux
{
    abstract class Noeud
    {
        public List<Arete> LigneElectrique;
        private string _nom;

        public string Nom
        {
            get => _nom;
            set => _nom = value;
        }

        public Noeud(string nom)
        {
            this.LigneElectrique = new List<Arete>();
            this.Nom = nom;
        }
        
        public void AddLine(Arete ligne)
        {
            this.LigneElectrique.Add(ligne);
        }



    }
}
