using System;

class Calculator
{
    static void Main()
    {
        Console.Title = "Jonas's lommeregner";

        while (true)
        {
            Console.Clear();
            DisplayCalculator();

            // Vis menu
            DisplayMenu();

            // Hent brugerens valg
            int choice = GetUserChoice();

            // Hvis brugeren vælger 5, så luk programmet
            if (choice == 5)
            {
                Console.WriteLine("\nLukker lommeregner. Hav en god dag!");
                break;
            }

            // Udfør den valgte operation og vis resultatet
            double result = PerformOperation(choice);
            Console.WriteLine($"\nResultat: {result}");

            // Vent på brugerens input, før du går tilbage til menuen
            Console.WriteLine("\nTryk på en tast for at fortsætte...");
            Console.ReadKey();
        }
    }

    static void DisplayCalculator()
    {
        Console.WriteLine(" ===============================");
        Console.WriteLine("|                               |");
        Console.WriteLine("|      Jonas's Lommeregner      |");
        Console.WriteLine("|                               |");
        Console.WriteLine(" ===============================");
    }

    // Metode til at vise menu
    static void DisplayMenu()
    {
        Console.WriteLine("|-------------------------------|");
        Console.WriteLine("|          1. Plus              |");
        Console.WriteLine("|-------------------------------|");
        Console.WriteLine("|          2. Minus             |");
        Console.WriteLine("|-------------------------------|");
        Console.WriteLine("|          3. Gange             |");
        Console.WriteLine("|-------------------------------|");
        Console.WriteLine("|          4. Dividere          |");
        Console.WriteLine("|-------------------------------|");
        Console.WriteLine("|          5. Luk Program       |");
        Console.WriteLine("|-------------------------------|");
    }

    // Metode til at hente brugerens valg
    static int GetUserChoice()
    {
        Console.Write("| Indtast dit valg (1-5): ");
        int choice;

        // Sikrer at brugeren indtaster et gyldigt valg
        while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 5)
        {
            Console.WriteLine("| Tastet forkert! Venligst indtast et tal imellem 1 og 5.");
            Console.Write("| Indtast dit valg (1-5): ");
        }

        return choice;
    }

    // Metode til at udføre den valgte operation
    static double PerformOperation(int choice)
    {
        // Hent de to tal, som operationen skal udføres på
        double[,] operands = GetOperands();

        // Udfør den valgte operation baseret på brugerens valg
        switch (choice)
        {
            case 1:
                return operands[0, 0] + operands[0, 1];
            case 2:
                return operands[0, 0] - operands[0, 1];
            case 3:
                return operands[0, 0] * operands[0, 1];
            case 4:
                // Undgå division med nul
                if (operands[0, 1] != 0)
                {
                    return operands[0, 0] / operands[0, 1];
                }
                else
                {
                    Console.WriteLine("| FEJL: Dividerer med nul.");
                    return double.NaN;
                }
            default:
                Console.WriteLine("| Ugyldigt valg. Prøv venligst igen.");
                return double.NaN;
        }
    }

    // Metode til at hente de to tal, som operationen skal udføres på
    static double[,] GetOperands()
    {
        double[,] operands = new double[1, 2];

        // Indtast det første tal
        Console.Write("| Indtast det første tal: ");
        while (!double.TryParse(Console.ReadLine(), out operands[0, 0]))
        {
            Console.WriteLine("| Ugyldig værdi! Venligst indtast en gyldig værdi.");
            Console.Write("| Indtast det første tal: ");
        }

        // Indtast det andet tal
        Console.Write("| Indtast det andet tal: ");
        while (!double.TryParse(Console.ReadLine(), out operands[0, 1]))
        {
            Console.WriteLine("| Ugyldig værdi! Venligst indtast en gyldig værdi.");
            Console.Write("| Indtast det andet tal: ");
        }

        return operands;

    }
}
