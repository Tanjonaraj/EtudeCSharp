using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Livre
{
    public string Titre { get; set; }
    public string Auteur { get; set; }
    public int AnneePublication { get; set; }
    public bool EstEmprunte { get; set; } = false; //Etat de l'emprunt

    public Livre(string titre, string auteur, int anneePublication)
    {
        Titre = titre;
        Auteur = auteur;
        AnneePublication = anneePublication;
    }

    public override string ToString()
    {
        return ($"{Titre} - {Auteur} - {AnneePublication}");
    }
}

//Classe principal au programme
class Program
{
    static List<Livre> bibliotheque = new List<Livre>();

    static void Main(string[] args)
    {
        Console.WriteLine("Bienvenue dans la gestion de Bibliotheque!");
        ChargerBibliotheque();

        bool continuer = true;
        while (continuer)
        {
            Console.WriteLine("\nMenu : ");
            Console.WriteLine("1.Afficher la liste des livres");
            Console.WriteLine("2.Ajouter un livre des livres");
            Console.WriteLine("3.Supprimer un livre");
            Console.WriteLine("4.Rechercher un livre");
            Console.WriteLine("5.Enregistrer et quitter");
            Console.WriteLine("Entrer votre choix : ");

            string choix = Console.ReadLine();

            switch (choix)
            {
                case "1":
                    AfficherLivre();
                    break;
                case "2":
                    AjouterLivre();
                    break;
                case "3":
                    SupprimerLivre();
                    break;
                case "4":
                    RechercherLivre();
                    break;
                case "5":
                    EnregistrerEtQuitter();
                    continuer = false;
                    break;
                default:
                    Console.WriteLine("Choix Invalide lesy bain ah!!");
                    break;
            }
        }
    }

    static void ChargerBibliotheque()
    {
        try
        {
            string[] lignes = File.ReadAllLines("bibliotheque.txt");
            foreach (var ligne in lignes)
            {
                string[] champs = ligne.Split(';');
                string titre = champs[0];
                string auteur = champs[1];
                int anneePublication = Convert.ToInt32(champs[2]);
                Livre livre = new Livre(titre, auteur, anneePublication);
                bibliotheque.Add(livre);
            }
            Console.WriteLine("Biblio charge avec succes !");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Aucune Fichier de bibliotheque trouvee. Creation d'un nouveau fichier.");
        }
    }
    static void AfficherLivre()
    {
        Console.WriteLine("\nListe des livres : ");
        int nombreLivres = bibliotheque.Count;
        if (nombreLivres == 0)
        {
            Console.WriteLine("Il n'existe pas de Livre en ce moment !!");
        }
        else
        {
            foreach (var livre in bibliotheque)
            {
                Console.WriteLine(livre);
            }
        }
    }
    static void AjouterLivre()
    {
        Console.WriteLine("\nAjouter un nouveau Livre : ");
        Console.Write("Titre : ");
        string titre = Console.ReadLine();
        Console.Write("Auteur : ");
        string auteur = Console.ReadLine();
        Console.Write("Annee de publication : ");
        int anneePublication = Convert.ToInt32(Console.ReadLine());

        Livre nouveauLivre = new Livre(titre, auteur, anneePublication);
        bibliotheque.Add(nouveauLivre);
        Console.WriteLine("Livre bien ajouter!!");
    }
    static void EnregistrerEtQuitter()
    {
        using (StreamWriter writer = new StreamWriter("bibliotheque.txt"))
        {
            foreach (var livre in bibliotheque)
            {
                writer.WriteLine($"{livre.Titre};{livre.Auteur};{livre.AnneePublication}");
            }
            Console.WriteLine("Bibliotheque enregistrer avec succes !!");
        }
    }
    static void SupprimerLivre()
    {
        Console.WriteLine("\nSuppression d'un Livre : ");
        Console.Write("Titre du livre a supprimer : ");
        string titre = Console.ReadLine();
        Livre livreASupprimer = bibliotheque.Find(l => l.Titre.Equals(titre, StringComparison.OrdinalIgnoreCase));
        if (livreASupprimer != null)
        {
            bibliotheque.Remove(livreASupprimer);
            Console.WriteLine("Livre supprimer avec success ! ");
        }
        else
        {
            Console.WriteLine("Livre non Trouver !!!");
        }
    }
    static void RechercherLivre()
    {
        Console.WriteLine("\nRecherche d'un livre : ");
        Console.Write("Entrer le titre, l'auteur ou l'annee de publication du livre : ");
        string recherche = Console.ReadLine();
        List<Livre> resultatsRecherche = bibliotheque.Where(l => l.Titre.Contains(recherche, StringComparison.OrdinalIgnoreCase) || l.Auteur.Contains(recherche, StringComparison.OrdinalIgnoreCase)
        || l.AnneePublication.ToString().Contains(recherche))
        .ToList();
        if (resultatsRecherche.Any())
        {
            Console.WriteLine("\n Resultat de la recherche : ");

            foreach (var livre in resultatsRecherche)
            {
                Console.WriteLine(livre);
            }
        }
        else
        {
            Console.WriteLine("Aucun livre trouvee !! ");
        }
    }
    static void EmprunterLivre()
    {
        Console.WriteLine("Titre du livre a emprunter : ");
        string titre = Console.ReadLine();
        Livre livreEmprunt = bibliotheque.FirstOrDefault(l => l.Titre.Equals(titre, StringComparison.OrdinalIgnoreCase));

        if (livreEmprunt != null)
        {
            if (!livreEmprunt.EstEmprunte)
            {
                livreEmprunt.EstEmprunte = true;
                Console.WriteLine("Livre emprunter avec succes !!");
            }
            else
            {
                Console.WriteLine("Ce livre est deja emprunte !");
            }
        }
        else
        {
            Console.WriteLine("Livre Non trouve !");
        }
    }

    static void RetournerLivre()
    {
        Console.Write("Titre du livre a retourner : ");
        string titre = Console.ReadLine();
        Livre livreRetour = bibliotheque.FirstOrDefault(l => l.Titre.Equals(titre, StringComparison.OrdinalIgnoreCase));

        if (livreRetour != null)
        {
            if (!livreRetour.EstEmprunte)
            {
                livreRetour.EstEmprunte = false;
                Console.WriteLine("Livre retourner avec succes !!");
            }
            else
            {
                Console.WriteLine("Ce livre n'est pas emprunte !");
            }
        }
        else
        {
            Console.WriteLine("Livre Non trouve !");
        }
    }
}

