using System;
using System.Collections.Generic;
using System.Text;

namespace Simulateur_reseaux
{
    abstract class Consommateur : Noeud
    {
        private string TypeDeConsommateur;

        public Consommateur(string name, string TypeDeConsommateur) : base(name)
        {
            this.TConsommateur = TypeDeConsommateur;
        }

        public string TConsommateur
        {
            get { return TypeDeConsommateur; }
            set { TypeDeConsommateur = value; }
        }


    }
}
