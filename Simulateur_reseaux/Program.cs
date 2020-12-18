using System;
using System.Collections.Generic;


namespace Simulateur_reseaux
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Initialisation de la simulation ");

            List<LigneProduction> prodLines  = new List<LigneProduction>();

            CentraleGaz gaz = new CentraleGaz("Gaz", 100, 23);
            ParcEolien eol = new ParcEolien("Eolienne", 100, 23);
            CentraleNucleaire nucl = new CentraleNucleaire("Nucleaire", 100, 23);
            CentraleSolaire sol = new CentraleSolaire("Solaire", 100, 23, 13);

            Fournisseur edf = new Fournisseur("EDF");

            LigneProduction gazEdf = new LigneProduction(gaz, edf);
            LigneProduction eolEdf = new LigneProduction(eol, edf);
            LigneProduction nuclEdf = new LigneProduction(nucl, edf);
            LigneProduction solEdf = new LigneProduction(sol, edf);

            edf.Prod.Add(gazEdf);
            edf.Prod.Add(eolEdf);
            edf.Prod.Add(nuclEdf);
            edf.Prod.Add(solEdf);

            prodLines.Add(gazEdf);
            prodLines.Add(eolEdf);
            prodLines.Add(nuclEdf);
            prodLines.Add(solEdf);

            foreach (LigneProduction line in prodLines)
            {
                line.Show();
                if (line.Prod is ParcEolien)
                {
                    line.Prod.UpdateProd(45);
                } else if (line.Prod is CentraleSolaire)
                {
                    line.Prod.UpdateProd(1);
                } else
                {
                    line.Prod.UpdateProd();
                }
                line.UpdateEnergieLine();
                line.Show();
            }

            Console.WriteLine(edf.PuissanceDistrib);
            edf.UpdatePuiss();
            Console.WriteLine(edf.PuissanceDistrib);

            //ajouter les consomateurs
            //Les lier au fournisseur
            //Gérer la simulation

        }
    }
}
