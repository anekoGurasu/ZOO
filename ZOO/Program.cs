using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ZOO
{
    /// <summary>
    /// Program který simuluje ZOO
    /// @author Kristýna Trávníčková
    /// </summary>
    internal class Program
    {
        //Cesta k souboru
        public static string path = @"";
        //List zvirat
        public static List<Zvire> zvirata = new List<Zvire>();

        // Hlavní metoda programu
        static void Main(string[] args)
        {
            NactiSoubor(path);
            Menu();
            Console.ReadKey();
        }

        //menu programu
        public static void Menu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Evidence zvířat v zoo\n");
                Console.WriteLine("1. Vypis zvířat");
                Console.WriteLine("2. Přidat zvíře");
                Console.WriteLine("3. Upravit zvíře");
                Console.WriteLine("4. Smazat zvíře");
                Console.WriteLine("5. Ukončit program");
                Console.WriteLine("\nZvolte možnost [1-5]:");

                try
                {
                    int volba = int.Parse(Console.ReadLine());

                    if (volba > 0 && volba < 6)
                    {
                        switch (volba)
                        {
                            case 1:
                                Vypis();
                                Console.WriteLine("\nStiskněte libovolnou klávesu...");
                                Console.ReadLine();
                                break;
                            case 2:
                                PridejZvire();;
                                break;
                            case 3:
                                UpravZvire();
                                break;
                            case 4:
                                SmazZvire();
                                break;
                            case 5:
                                Environment.Exit(0);
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Nesprávný formát, zkuste to znovu.");
                        Console.ReadKey(true);
                    }
                }
                catch (Exception ex){Console.WriteLine("Nesprávný formát, zkuste to znovu.");}
            }
        }

        /// <summary>
        /// Nacte urceny soubor a precte vsechny jeho radky.
        /// slova rozdeli podle carek do pole bunky a pote se postupne priradi k promennym.
        /// nakonec se do listu "zvirata" postupne pridaji instance tridy Zvire s parametry "druh", "vaha", "pohlavi" a "vek"
        /// </summary>
        /// <param name="path">Cesta k souboru</param>
        public static void NactiSoubor(string path)
        {
            zvirata.Clear();
            FileStream fs = new FileStream(path, FileMode.OpenOrCreate);

            try
            {
                using (StreamReader streamReader = new StreamReader(fs))
                {
                    string line;

                    while ((line=streamReader.ReadLine())!=null)
                    {
                        string[] bunky = line.Split(',');
                        
                        string druh = bunky[0];
                        int vaha = int.Parse(bunky[1]);
                        string pohlavi = bunky[2];
                        int vek = int.Parse(bunky[3]);

                        zvirata.Add(new Zvire(druh,vaha,pohlavi, vek));
                    }
                }
            }
            catch (Exception ex)
            {
                //uzavreni cesty
                Console.WriteLine(ex.ToString());
                fs.Close();
                fs.Dispose();
            }
            finally
            {
                //uzavreni cesty
                fs.Close();
                fs.Dispose();
            }
        }
        /// <summary>
        /// Vypis zvirat.
        /// </summary>
        public static void Vypis()
        {
            Console.Clear();
            Console.WriteLine("Seznam zvířat:\n");
            for(int i = 0; i < zvirata.Count; i++) 
            {
                Console.WriteLine((i+1) +". " + zvirata[i].Druh+", "+ zvirata[i].Vaha+ "kg, "+ zvirata[i].Pohlavi + ", " + zvirata[i].Vek + " let");
            }
        }

        /// <summary>
        /// Prida radku do souboru.
        /// </summary>
        /// <param name="text">radka textu</param>
        public static void Add(string text)
        {
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(text);
            }
        }

        /// <summary>
        /// Vymaze veskery text ze souboru
        /// </summary>
        public static void Del()
        {
            FileStream fileStream = File.Open(path, FileMode.OpenOrCreate);

            fileStream.SetLength(0);
            fileStream.Close();
        }

        /// <summary>
        /// vymaze veskery text a pote postupne prida zvirata
        /// </summary>
        public static void Nahrada()
        {
            Del();
            for (int i = 0; i < zvirata.Count; i++)
            {
                string radek = zvirata[i].Druh + "," + zvirata[i].Vaha + "," + zvirata[i].Pohlavi + "," + zvirata[i].Vek;
                Add(radek);
            }
        }

        /// <summary>
        /// Prida zvire
        /// </summary>
        public static void PridejZvire()
        {
            Console.Clear();
            Console.WriteLine("Přidání zvířete:\n\n");

            string druh;
            int vaha;
            string pohlavi;
            int vek;

            try
            {
                while (true)
                {
                    Console.Write("Druh: ");
                    druh = Console.ReadLine();
                    if (!druh.Contains(" ") || druh.Length < 0)
                    {
                        Console.WriteLine("Druh musí obsahovat rodové i druhové jméno.");
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
                while (true) {
                    Console.Write("Váha [kg]: ");
                    vaha = int.Parse(Console.ReadLine());
                    if (vaha < 0)
                    {
                        Console.WriteLine("Váha nesmí být záporná.");
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
                while (true) {
                    Console.Write("Pohlavi [Samec/Samice]: ");
                    pohlavi = Console.ReadLine();
                    if (!String.Equals("samec", pohlavi.ToLower()) && !String.Equals("samice", pohlavi.ToLower()))
                    {
                        Console.WriteLine("Špatný formát vstupu. [Samec, Samice]");
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
                while (true)
                {
                    Console.Write("Věk [roky]: ");
                    vek = int.Parse(Console.ReadLine());
                    if (vek < 0)
                    {
                        Console.WriteLine("Věk nesmí být záporný.");
                        continue;
                    }
                    else
                    {
                        break;
                    } 
                }

                string radek = druh + "," + vaha.ToString() + "," + pohlavi + "," + vek.ToString();
                Add(radek);
                
                NactiSoubor(path);

                Console.WriteLine("Zvíře přidáno...");
                Console.WriteLine("\nStiskněte libovolnou klávesu...");
                Console.ReadLine();
            }
            catch (Exception ex) { Console.WriteLine("Neplatný vstup."); }
               
        }

        /// <summary>
        /// Smaze zvire
        /// </summary>
        public static void SmazZvire()
        {
            Vypis();
            Console.WriteLine("\nSmazání zvířete:\n");
            Console.WriteLine("Zvolte index zvířete, které chcete smazat. Pokud se chcete vrátit, stiskněte 'x'.");
            string volba1;
            do {
                volba1 = Console.ReadLine();

                if ((volba1.ToLower() != "x" && !volba1.All(char.IsDigit)) || (int.Parse(volba1) < 1 || int.Parse(volba1) > zvirata.Count))
                {
                    Console.WriteLine("Neplatný vstup.");
                }
                else
                {
                    int line = int.Parse(volba1)-1;

                    zvirata.Remove(zvirata[line]);
                    Nahrada();
                    Console.WriteLine("Zvíře smazáno.");
                    Console.WriteLine("\nStiskněte libovolnou klávesu...");
                }
            } while (volba1.ToLower() != "x");
        }

        /// <summary>
        /// Zkontrolu, zda uzivatel zada "A" nebo "N".
        /// Pokud uzivatel zada "A", program zkontroluje, zda je vstup validni.
        /// </summary>
        /// <param name="valueType">Nazev typu, ktery je kontrolovany</param>
        /// <param name="line">cislo radku</param>
        public static void KontrolaYN(string valueType,int line)
        {
            char YN;
            do { 
                Console.WriteLine("\nChcete upravit '"+ valueType+"' zvířete [A/N]");
                YN = Console.ReadKey().KeyChar;

                if (YN == 'a')
                {
                    Console.Write("\nZadejte " + valueType + ": ");

                    // KontrolaValidity vrátí true, pokud je úspěšná, jinak false
                    if (!KontrolaValidity(valueType, line))
                    {
                        Console.WriteLine("\nÚprava nebyla provedena.");
                    }
                    else
                    {
                        Console.WriteLine("Upraveno");
                        break;
                    }
                }
                else if (YN != 'n' && YN != 'a') { Console.WriteLine("\nNeplatný vstup."); }
            } while (YN != 'n');
        }

        /// <summary>
        /// Zkontroluje, zda je vstup validni.
        /// </summary>
        /// <param name="valueType">Nazev typu, ktery je kontrolovany</param>
        /// <param name="line">Cislo radku</param>
        /// <returns></returns>
        public static bool KontrolaValidity(string valueType, int line)
        {
            if (valueType.Equals("Druh"))
            {
                string druh = Console.ReadLine();
                if (!druh.Contains(" ") || druh.Length == 0 || druh.Any(char.IsDigit))
                {
                    Console.WriteLine("Druh musí obsahovat jak rodové, tak druhové jméno oddělené mezerou.");
                    return false; // Pokud kontrola není úspěšná, vrátíme false
                }
                else
                {
                    zvirata[line].Druh = druh;
                    return true; // Pokud je úprava provedena úspěšně, vrátíme true
                }
            }
            else if (valueType.Equals("Váha"))
            {
                int vaha = int.Parse(Console.ReadLine());
                if (vaha < 0)
                {
                    Console.WriteLine("Váha nesmí být záporná");
                    return false; // Pokud kontrola není úspěšná, vrátíme false
                }
                else
                {
                    zvirata[line].Vaha = vaha;
                    return true; // Pokud je úprava provedena úspěšně, vrátíme true
                }
            }
            else if (valueType.Equals("Pohlaví"))
            {
                string pohlavi = Console.ReadLine();
                if (!String.Equals("samec", pohlavi.ToLower()) && !String.Equals("samice", pohlavi.ToLower()))
                {
                    Console.WriteLine("Špatný formát vstupu. [Samec, Samice]");
                    return false; // Pokud kontrola není úspěšná, vrátíme false
                }
                else
                {
                    zvirata[line].Pohlavi = pohlavi;
                    return true; // Pokud je úprava provedena úspěšně, vrátíme true

                }
            }
            else if (valueType.Equals("Věk"))
            {
                int vek = int.Parse(Console.ReadLine());
                if (vek < 0)
                {
                    Console.WriteLine("Věk nesmí být záporný");
                    return false; // Pokud kontrola není úspěšná, vrátíme false
                }
                else
                {
                    zvirata[line].Vek = vek;
                    return true; // Pokud je úprava provedena úspěšně, vrátíme true
                }
            }
            return false;
        }

        /// <summary>
        /// Upravi zvire
        /// </summary>
        public static void UpravZvire()
        {
            Vypis();
            Console.WriteLine("\nÚprava zvířete:\n");
            Console.WriteLine("Zvolte index zvířete, které chcete smazat. Pokud se chcete vrátit, stiskněte 'x'.");
            string volba1;

            try {
                do
                {
                    volba1 = Console.ReadLine();

                    if ((volba1.ToLower() != "x" && !volba1.All(char.IsDigit)) || (int.Parse(volba1) < 1 || int.Parse(volba1) > zvirata.Count))
                    {
                        Console.WriteLine("Neplatný vstup.");
                    }
                    else
                    {
                        int line = int.Parse(volba1) - 1;

                        KontrolaYN("Druh", line);
                        KontrolaYN("Váha", line);
                        KontrolaYN("Pohlaví", line);
                        KontrolaYN("Věk", line);

                        Nahrada();
                        Console.WriteLine("\nStiskněte libovolnou klávesu...");
                    }
                } while (volba1.ToLower() != "x");
            }catch (Exception e) { Console.WriteLine("Neplatný vstup"); }
        }
    }
}
