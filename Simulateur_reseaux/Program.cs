using System;
using System.Collections.Generic;
using System.Timers;

namespace Simulateur_reseaux
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Initialisation de la simulation ");

            List<LigneProduction> prodLines = new List<LigneProduction>();
            List<LigneDistribution> distribLines = new List<LigneDistribution>();


            //Init Producteurs
            CentraleGaz gaz = new CentraleGaz("Gaz", 23, false);
            ParcEolien eol = new ParcEolien("Eolienne", 23, true);
            CentraleNucleaire nucl = new CentraleNucleaire("Nucleaire", 23, true);
            CentraleSolaire sol = new CentraleSolaire("Solaire", 23, 13, true);

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

            //Init villes
            Ville kernilis = new Ville("Kernilis", 987);
            Ville brest = new Ville("Brest", 1253);

            LigneDistribution kerEdf = new LigneDistribution(edf, kernilis);
            LigneDistribution breEdf = new LigneDistribution(edf, brest);

            distribLines.Add(kerEdf);
            distribLines.Add(breEdf);

            edf.Conso.Add(kerEdf);
            edf.Conso.Add(breEdf);

            //Stockage 
            Stockage stock = new Stockage(5000);

            Console.WriteLine("\nAppuyez sur espace pour lancer la simulation");
            bool tryIt = false;
            while (tryIt == false)
            {
                if (Console.ReadKey().Key.ToString() != "")
                {
                    tryIt = true;
                }
            }

            //Minuteur 
            while (true)
            {
                var deb = DateTime.Now;
                bool run = true;
                UpdateConsos();
                while (run == true)
                {
                    var fin = DateTime.Now;
                    TimeSpan interv = fin - deb;
                    if (interv.TotalMilliseconds > 2000) 
                    {
                        run = false;
                    }
                }
                Console.WriteLine("Fin");
            }


            void UpdateConsos()
            {

                Console.Clear();
                //Ajouter test pour centrale nucléaire
                foreach (LigneProduction line in prodLines)
                {
                    if (line.Prod.Running == true)
                    {
                        line.Prod.UpdateProd();
                        line.UpdateEnergieLine();
                        
                        if (line.Prod is CentraleGaz)
                        {
                            line.Prod.UpdateCout();
                        }
                        line.Show();
                    }
                }

                edf.UpdatePuiss();

                Console.WriteLine("\nProduction totale : " + edf.PuissanceDistrib + "\n");

                foreach (LigneDistribution line in distribLines)
                {
                    line.UpdateEnergieLine();
                }

                bool puissanceManquante = false;

                foreach (LigneDistribution conso in edf.Conso)
                {
                    if (edf.PuissanceDistrib >= conso.PuissanceMaximale)
                    {
                        edf.PuissanceDistrib -= conso.PuissanceMaximale;
                        conso.Conso.SuccessDistrib();
                    }
                    else
                    {
                        if (stock.EStock > 0 && stock.EStock > conso.PuissanceMaximale)
                        {
                            stock.EStock -= conso.PuissanceMaximale;
                            conso.Conso.SuccessDistrib();
                        }
                        else
                        {
                            puissanceManquante = true;
                            conso.Conso.FailDistrib();
                        }
                    }
                }

                Console.WriteLine("\nPuissance restante : " + edf.PuissanceDistrib + "\n");

                if (puissanceManquante == true)
                {
                    bool done = false;
                    foreach (LigneProduction line in prodLines)
                    {   
                        if (line.Prod.Running == false && done == false)
                        {
                            line.Prod.Ignition();
                            done = true;
                        }
                    }
                }
                else if (edf.PuissanceDistrib >= 2000)
                {
                    Random rnd = new Random();
                    List<CentraleDeProduction> onLines = new List<CentraleDeProduction>();
                    foreach (LigneProduction line in prodLines)
                    {
                        if (line.Prod.Running == true)
                        {
                            onLines.Add(line.Prod);
                        }
                    }
                    if (onLines.Count > 1)
                    {
                        int index = rnd.Next(0, onLines.Count);
                        onLines[index].Shutdown();
                    }
                    stock.AddToStock(edf.PuissanceDistrib);
                }
                else
                {
                    stock.AddToStock(edf.PuissanceDistrib);
                }

                foreach (LigneProduction line in prodLines)
                {
                    if (line.Prod.Running == true)
                    {
                        Console.WriteLine("La centrale de production "+line.Prod.Nom+" est allumée");
                    } 
                    else
                    {
                        Console.WriteLine("La centrale de production " + line.Prod.Nom + " est éteinte");
                    }
                    
                }

                Console.WriteLine("Il reste " + stock.EStock + " stockée");
            }
        }
    }
}
