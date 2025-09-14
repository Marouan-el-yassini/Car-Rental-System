
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;

namespace Location_de_Voiture_System
{
    class Program
    {
        abstract class Voiture
        {
            public string model { get; set; }
            public Guid id { get; set; }
            public double Price { get; set; }

            public Voiture(string model, Guid id, double price)
            {
                this.model = model;
                this.id = id;
                Price = price;
            }

            abstract public void Info();
            abstract public double PrixTotal(int nbj,double reduction);
        }
        class Berlin : Voiture
        {
            public string mark { get; set; }
            public Berlin(string model, Guid id, double price,string mark) : base(model, id, price)
            {
                this.mark = mark;
            }
            public override void Info()
            {
                Console.WriteLine($"La voiture choisi est :{model}---{mark}---{id}---{Price}DH");
            }
            public override double PrixTotal(int nbj, double reduction) {
                return nbj * 300*(1-reduction/100);
            }

        }
        class Suv : Voiture
        {
            public string mark { get; set; }
            public Suv(string model, Guid id, double price, string mark) : base(model, id, price)
            {
                this.mark = mark;
            }
            public override void Info()
            {
                Console.WriteLine($"La voiture choisi est :{model}---{mark}---{id}---{Price}DH");
            }
            public override double PrixTotal(int nbj, double reduction)
            {
                return nbj * 200*(1-reduction/100);
            }
        }
        class Client
        {
            public string name { get; set; }
            public Guid id { get; set; }
            public int _age;
            public int Age
            {
                set
                {
                    if (value < 18)
                    {
                        Console.WriteLine("Impossible Vous n'avez pas de permis");
                        System.Environment.Exit(0);
                    }
                    else
                    {
                        _age = value;
                    }
                }
                get { return _age; }

            }
            public bool EstClient { get; set; }
            public double red { get; set; }
            
            public Client(string name, Guid id,int Age, bool EstClient)
            {
                this.name = name;
                this.id = id;
                this.Age = Age;
                this.id=id;
                this.EstClient = EstClient;
            }
            public void Info()
            {
                Console.WriteLine($"Infos:{name}---{id}---{Age}ans--{EstClient}");
            }

            public double Reduction()
            {
                if (EstClient == true && Age > 25)
                {
                    red = 50;
                }
                else if (EstClient == true && Age <= 25)
                {
                    red = 30;
                }
                else
                {
                    red = 0;
                }
                return red;
            }

        }
        class Payment : Client
        {
            public int nbj { get; set; }
            public Payment(string name, Guid id,int Age, bool EstClient, int nbj) : base(name, id,Age, EstClient)
            {
                this.nbj = nbj;
            }
            public double Total(Voiture v)
            {
                double total=v.PrixTotal(nbj,Reduction());
                return total;
            }
            public void InfoPayment(Voiture v)
            {
                Console.WriteLine($"Le montant total a payer est de :{Total(v)}");
            }

        }
        static void Main(string[] args)
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔══════════════════════════════════╗");
            Console.WriteLine("║      🛒 Location de Voiture      ║");
            Console.WriteLine("╚══════════════════════════════════╝");
            Console.ResetColor();

            Console.Write("\n👉 Entrez votre nom : ");
            string Name = Console.ReadLine();

            Console.Write("👉 Êtes-vous notre client (true/false) ? ");
            bool EstClient = Convert.ToBoolean(Console.ReadLine());

            Console.Write("👉 Entrez votre âge : ");
            int age = Convert.ToInt32(Console.ReadLine());

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n✅ Merci pour vos informations, traitement en cours...\n");
            Console.ResetColor();

            Client c = new Client(Name, Guid.NewGuid(), age, EstClient);

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("╔══════════════════════════════════╗");
            Console.WriteLine("║          Informations Client     ║");
            Console.WriteLine("╚══════════════════════════════════╝");
            Console.ResetColor();

            Console.WriteLine($"Nom       : {c.name}");
            Console.WriteLine($"ID        : {c.id}");
            Console.WriteLine($"Âge       : {c.Age} ans");
            Console.WriteLine($"EstClient : {c.EstClient}");
            Console.WriteLine($"Réduction : {c.Reduction()}%\n");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Veuillez choisir votre type de voiture : SUV ou BERLIN");
            Console.ResetColor();
            string choix = Console.ReadLine().ToUpper();

            switch (choix)
            {
                case "SUV":
                    List<string> suv = new List<string>() { "Nissan", "Toyota", "Ford", "Honda", "Jeep" };
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\nListe des SUV disponibles :");
                    Console.ResetColor();
                    for (int i = 0; i < suv.Count; i++)
                        Console.WriteLine($"{i + 1} - {suv[i]}");

                    Console.Write("\nVotre choix (nom) : ");
                    string modelSuv = Console.ReadLine();
                    Suv s = new Suv(modelSuv, Guid.NewGuid(), 200, "SUV");

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n✅ Voiture choisie :");
                    s.Info();
                    Console.ResetColor();

                    Console.WriteLine("\n======================================");
                    Console.Write("Veuillez entrer le nombre de jours de location : ");
                    int nbjSuv = Convert.ToInt32(Console.ReadLine());

                    Payment pSuv = new Payment(Name, Guid.NewGuid(), age, EstClient, nbjSuv);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\n╔══════════════════════════════════╗");
                    Console.WriteLine("║          Détails Paiement        ║");
                    Console.WriteLine("╚══════════════════════════════════╝");
                    Console.ResetColor();
                    pSuv.InfoPayment(s);
                    break;

                case "BERLIN":
                    List<string> berlin = new List<string>() { "BMW", "Mercedes", "Audi", "Lexus", "Volvo" };
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\nListe des BERLIN disponibles :");
                    Console.ResetColor();
                    for (int i = 0; i < berlin.Count; i++)
                        Console.WriteLine($"{i + 1} - {berlin[i]}");

                    Console.Write("\nVotre choix (nom) : ");
                    string modelBerlin = Console.ReadLine();
                    Berlin b = new Berlin(modelBerlin, Guid.NewGuid(), 300, "BERLIN");

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n✅ Voiture choisie :");
                    b.Info();
                    Console.ResetColor();

                    Console.WriteLine("\n======================================");
                    Console.Write("Veuillez entrer le nombre de jours de location : ");
                    int nbjBerlin = Convert.ToInt32(Console.ReadLine());

                    Payment pBerlin = new Payment(Name, Guid.NewGuid(), age, EstClient, nbjBerlin);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\n╔══════════════════════════════════╗");
                    Console.WriteLine("║          Détails Paiement        ║");
                    Console.WriteLine("╚══════════════════════════════════╝");
                    Console.ResetColor();
                    pBerlin.InfoPayment(b);
                    break;

                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("❌ Choix invalide, veuillez choisir SUV ou BERLIN");
                    Console.ResetColor();
                    break;
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n======================================");
            Console.WriteLine("Merci d'avoir utilisé notre service ! 🚗");
            Console.WriteLine("======================================");
            Console.ResetColor();
        }

    }
}
