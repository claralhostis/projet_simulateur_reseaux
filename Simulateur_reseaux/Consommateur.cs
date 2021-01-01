using System;
using System.Collections.Generic;
using System.Text;

namespace Simulateur_reseaux
{
    abstract class Consommateur : Noeud
    {
        private string TypeDeConsommateur;
        private double _consommation;

        public string TConsommateur
        {
            get { return TypeDeConsommateur; }
            set { TypeDeConsommateur = value; }
        }

        public double Consommation
        {
            get => _consommation;
            set => _consommation = value;
        }

        public Consommateur(string name, string TypeDeConsommateur, double conso) : base(name)
        {
            this.TConsommateur = TypeDeConsommateur;
            this.Consommation = conso;
        }

        public void SuccessDistrib()
        {
            Console.WriteLine(this.Nom + " a été totalement fournie en énergie.");
        }

        public void FailDistrib()
        {
            Console.WriteLine(this.Nom + " n'a pas été totalement fournie en énergie.");
        }

    }
}
