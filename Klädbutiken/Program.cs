using System;
using System.Collections.Generic;

/*  
HELT KLART!!:::  

Admin:
Kan logga in - ja
kan lägga till kläder utan fel - ja

BUTIKEN:
se lista - ja
lägga i varukorg - ja
kassa och betala
få kvitto
*/

namespace Klädbutiken
{
    class Program
    {
        public static string menuChoice;
        public static bool inStore = false;
        public static List<Clothes> clothesInStore = new List<Clothes>();
        public static List<Clothes> shoppingCart = new List<Clothes>();
        public static Admin admin1 = new Admin("Joakim", "Holm");
        static void Main(string[] args)
        {

            //ShowClothesList();

            StartMenu();

        }

        static void LoginAsAdmin(Admin admin)
        {
            bool Login = false;
            do
            {
                Console.WriteLine("> > > LOGGA IN SOM ADMIN < < <");
                Console.Write("Användarnamn: ");
                string username = Console.ReadLine();
                Console.Write("Lösenord: ");
                string password = Console.ReadLine();

                if (username == admin.Username && password == admin.Password)
                {
                    EnterAdmin();
                    Login = true;
                }
                else
                {
                    Console.WriteLine("Användarnamnet eller lösenordet var felaktigt...");
                    Console.WriteLine("Tryck på 'N' om du vill gå tillbaka till startmenyn.");
                    string input = Console.ReadLine().ToUpper();
                    if (input == "N")
                        Login = true;
                    Console.Clear();
                }
            } while (!Login);
        }

        static void StartMenu()
        {
            bool endProgram = false;
            do
            {
                Console.Write($"> > > > > STARTMENY < < < < <\n" +
                              $"1. Logga in som admin\n" +
                              $"2. Köp kläder\n" +
                              $"0. Avsluta programmet\n" +
                              $"Ditt val: ");
                menuChoice = Console.ReadLine();
                switch (menuChoice)
                {
                    case "1":
                        Console.Clear();
                        LoginAsAdmin(admin1);
                        break;
                    case "2":
                        Console.Clear();
                        EnterStore();
                        Console.Clear();
                        break;
                    case "0":
                        endProgram = true;
                        break;
                    default:
                        Console.WriteLine($"Du angav '{menuChoice}', vilket är ett inkorrekt val...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            } while (!endProgram);
        }

        static void EnterStore()
        {
            bool goBack = false;
            do
            {
                Console.WriteLine("< < < < BUTIKEN > > > >\n" +
                                  "1. Lista kläder\n" +
                                  "5. Gå till kassan\n" +
                                  "0. Gå tillbaka till startmenyn");
                string menuChoice = Console.ReadLine();
                switch (menuChoice)
                {
                    case "1":
                        ShowClothesList();
                        break;
                    case "5":
                        Checkout();
                        break;
                    case "0":
                        goBack = true;
                        break;
                    default:
                        Console.WriteLine($"Du angav '{menuChoice}' vilket är ett inkorrekt val...");
                        Console.Clear();
                        break;
                }
            } while (!goBack);
        }

        private static void Checkout()
        {
            int sum = 0;
            foreach (Clothes item in shoppingCart)
            {
                sum += item.Price;
            }
            Console.WriteLine("Har du handlat klart? (J/N)");
            ConsoleKeyInfo keyInput = Console.ReadKey(true);
            if (keyInput.Key == ConsoleKey.J)
            {
                Console.Clear();
                Console.WriteLine($"> > > KVITTO < < <\n");
                foreach (Clothes item in shoppingCart)
                {
                    Console.WriteLine(Enum.GetName(typeof(ClothesProperties.Types), item.TypeOfClothes) + " - " + Enum.GetName(typeof(ClothesProperties.ClothingSizes), item.Size) + " - " + Enum.GetName(typeof(ClothesProperties.Colors), item.Color) + " - " + item.Price + "kr");
                }
                Console.WriteLine($"\nSumma: {sum}\n" +
                                    $"Tack för ditt köp, välommen åter!");
                shoppingCart.Clear();
                Environment.Exit(0);

            }
            else
                Console.Clear();
        }

        static void EnterAdmin()
        {
            bool goBack = false;
            while (!goBack)
            {
                Console.Clear();
                Console.WriteLine("< < < < ADMIN > > > >\n" +
                                  "1. Lägg till klädesplagg\n" +
                                  "0. Gå tillbaka till startmenyn");
                Console.Write("Ditt val: ");
                string menuChoice = Console.ReadLine();
                switch (menuChoice)
                {
                    case "1":
                        Admin.AddGarment();
                        break;
                    case "0":
                        goBack = true;
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine($"Du angav '{menuChoice}' vilket är ett inkorrekt val...");
                        break;
                }
            }
        }

        static void ShowClothesList()
        {
            bool shopping = true;
            Console.Clear();
            int index = 0;
            while (shopping)
            {
                int i = 0;
                Console.WriteLine("> > > KLÄDER < < <\n");
                try
                {
                    foreach (Clothes clothes in clothesInStore)
                    {
                        if (i == index)
                        {
                            Console.BackgroundColor = ConsoleColor.Gray;
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                        Console.WriteLine(Enum.GetName(typeof(ClothesProperties.Types), clothes.TypeOfClothes) + " - " + Enum.GetName(typeof(ClothesProperties.ClothingSizes), clothes.Size) + " - " + Enum.GetName(typeof(ClothesProperties.Colors), clothes.Color) + " - " + clothes.Price + "kr");
                        Console.ResetColor();
                        i++;
                    }
                    Console.WriteLine("\nVälj kläder i listan (a,z) och lägg dom i din varukorg med ENTER.");
                    Console.WriteLine("För att gå tillbaka till huvudmenyn och kassan tryck på 'Q'.\n");

                    if (shoppingCart.Count > 0)
                    {
                        int sum = 0;
                        foreach (Clothes item in shoppingCart)
                        {
                            Console.WriteLine(Enum.GetName(typeof(ClothesProperties.Types), item.TypeOfClothes) + " - " + Enum.GetName(typeof(ClothesProperties.ClothingSizes), item.Size) + " - " + Enum.GetName(typeof(ClothesProperties.Colors), item.Color) + " - " + item.Price + "kr");
                            sum += item.Price;
                        }
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine($"Summa: {sum}");
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    ConsoleKeyInfo keyInput = Console.ReadKey(true);

                    if (keyInput.Key == ConsoleKey.A)
                    {
                        index--;
                        if (index < 0)
                            index = 0;
                    }
                    if (keyInput.Key == ConsoleKey.Z)
                    {
                        index++;
                        if (index > clothesInStore.Count - 1)
                            index = clothesInStore.Count - 1;
                    }

                    if (keyInput.Key == ConsoleKey.Enter)
                    {
                        shoppingCart.Add(clothesInStore[index]);
                        clothesInStore.RemoveAt(index);
                        index = 0;
                    }
                    if (keyInput.Key == ConsoleKey.Q)
                    {
                        shopping = false;
                    }
                }
                catch
                {
                    Console.WriteLine("Det blev ett fel, tryck på valfri tangent för att fortsätta...");
                    Console.ReadKey(true);
                }
                Console.Clear();
            }
        }
    }
}
