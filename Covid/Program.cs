using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Covid
{
    class Virus {
        public string naziv { get; set; }
        public double CFR { get; set; }
        public double R0 { get; set; }

        public double broj_umrlih (double CFR) { 
            double RIP;
            RIP = ((double)CFR * 1000) / 100;
            return RIP;
        }

        public double brZarazenih10(double stopa_sirenja) {
            double ukupno = 1;
            for (int i = 1; i < 10; i++) {
                ukupno = ukupno + Math.Pow(stopa_sirenja, i);
            }
            return ukupno+1;
        }
        
    
    }

    class Program
    {
        static void Main(string[] args)
        {

            List<Virus> virusi = new List<Virus>();

            Console.Write("Unesite broj virusa: ");
            int n = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < n; i++) {
                Virus v = new Virus();

                Console.WriteLine("\nPodaci za " + (i + 1) + ". virus: ");
                Console.WriteLine("---------------------------------");
                Console.Write("Naziv virusa: ");
                v.naziv = Console.ReadLine();
                Console.Write("Stopa smrtnosti (%): ");
                v.CFR = Convert.ToDouble(Console.ReadLine());
                Console.Write("Brzina širenja: ");
                v.R0 = Convert.ToDouble(Console.ReadLine());

                virusi.Add(v);

            }

            Console.WriteLine("\nPodaci o virusima: ");
            Console.WriteLine("==================================");
            foreach (Virus v in virusi) {
                Console.WriteLine("Virus: " + v.naziv + " " + 
                                  "\nBroj umrlih na 1000 zaraženih: " + v.broj_umrlih(v.CFR) +
                                  "\nBroj zaraženih 10. dan: " + Math.Round(v.brZarazenih10(v.R0), 2) + "\n");
            }

      
            Console.ReadKey();
        }
    }
}
