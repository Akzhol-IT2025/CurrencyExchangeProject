// See https://aka.ms/new-console-template for more information
using System;
using CurrencyExchangeBackend;

class Program
{
    static void Main(string[] args)
    {
        ICurrencyService service = new CurrencyService();
        string userId = "student";

        while (true)
        {
            Console.WriteLine("\n=== Currency Exchange Console ===");
            Console.WriteLine("1. Create Account");
            Console.WriteLine("2. Top Up PLN");
            Console.WriteLine("3. Check Balance");
            Console.WriteLine("4. Get Exchange Rate");
            Console.WriteLine("5. Buy Currency");
            Console.WriteLine("6. Exit");
            Console.Write("Choose option: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter user ID: ");
                    userId = Console.ReadLine();
                    Console.WriteLine(service.CreateAccount(userId));
                    break;

                case "2":
                    Console.Write("Enter amount in PLN to top up: ");
                    if (double.TryParse(Console.ReadLine(), out double topUpAmount))
                        Console.WriteLine(service.TopUp(userId, topUpAmount));
                    else
                        Console.WriteLine("Invalid amount.");
                    break;

                case "3":
                    Console.WriteLine(service.GetBalance(userId));
                    break;

                case "4":
                    Console.Write("Enter currency code (e.g. USD, EUR): ");
                    string code = Console.ReadLine();
                    double rate = service.GetExchangeRate(code);
                    if (rate > 0)
                        Console.WriteLine($"Exchange rate {code}/PLN: {rate}");
                    else
                        Console.WriteLine("Failed to fetch exchange rate.");
                    break;

                case "5":
                    Console.Write("Currency code to buy (e.g. USD): ");
                    string buyCode = Console.ReadLine();
                    Console.Write("Amount in PLN to spend: ");
                    if (double.TryParse(Console.ReadLine(), out double amountPln))
                        Console.WriteLine(service.BuyCurrency(userId, buyCode, amountPln));
                    else
                        Console.WriteLine("Invalid amount.");
                    break;

                case "6":
                    Console.WriteLine("Exiting...");
                    return;

                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }
}