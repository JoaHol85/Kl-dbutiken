using System;

namespace Klädbutiken
{
    class Admin
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public Admin(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public static void AddGarment()
        {
            int number;
            Clothes garment = new Clothes();
            Console.Clear();
            int i = 1;
            Console.WriteLine(">>> LÄGG TILL KLÄDESPLAGG <<<");
            Console.WriteLine($"Typ av klädesplagg:");
            foreach (string types in ClothesProperties.Types.GetNames(typeof(ClothesProperties.Types)))
            {
                Console.WriteLine($"{i}. {types}, ");
                i++;
            }
            do
            {
                number = TryParseCheck();
            } while (number <= 0 || number > ClothesProperties.GetEnumTypesLength());
            //garment.SetType(number);
            garment.TypeOfClothes = number;
            Console.Clear();

            i = 1;
            Console.WriteLine(">>> LÄGG TILL KLÄDESPLAGG <<<");
            Console.WriteLine($"Välj storlek:");
            foreach (string sizes in ClothesProperties.ClothingSizes.GetNames(typeof(ClothesProperties.ClothingSizes)))
            {
                Console.WriteLine($"{i}. {sizes}, ");
                i++;
            }
            do
            {
                number = TryParseCheck();
            } while (number <= 0 || number > ClothesProperties.GetEnumClothingSizesLength());
            garment.Size = number;
            Console.Clear();

            i = 1;
            Console.WriteLine(">>> LÄGG TILL KLÄDESPLAGG <<<");
            Console.WriteLine($"Välj färg:");
            foreach (string color in ClothesProperties.Colors.GetNames(typeof(ClothesProperties.Colors)))
            {
                Console.WriteLine($"{i}. {color}, ");
                i++;
            }
            do
            {
                number = TryParseCheck();
            } while (number <= 0 || number > ClothesProperties.GetEnumColorLength());
            garment.Color = number;
            Console.Clear();

            Console.WriteLine(">>> LÄGG TILL KLÄDESPLAGG <<<");
            Console.Write("Ange pris på ditt klädesplagg: ");
            int price = 0;
            do
            {
                price = TryParseCheck();
                if(price < 1)
                    Console.Write("Du skrev inte in ett korrekt pris!\nAnge pris på ditt klädesplagg: ");
            } while (price < 1);
            garment.Price = price;

            Program.clothesInStore.Add(garment);

        }

        static int TryParseCheck()
        {
            int number = -1;
            bool input = false;
            while (!input)
            {
                input = int.TryParse(Console.ReadLine(), out number);
                if (!input)
                {
                    Console.WriteLine("Du skrev inte in ett tal, Försök igen.");
                }
            }
            return number;
        }


    }
}
