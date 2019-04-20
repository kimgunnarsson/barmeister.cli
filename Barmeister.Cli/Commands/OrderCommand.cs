using Spectre.Cli;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Barmeister.Cli.Commands
{
    public sealed class OrderCommand : AsyncCommand<OrderSettings>
    {
        private static Random RandomGenerator = new Random();

        private const string Wine = "🍷";
        private const string Cocktail = "🍸";
        private const string Drink = "🍹";
        private const string Beer = "🍺";
        private const string Whiskey ="🥃";

        private List<string> NonBeerBeverages = new List<string>()
        {
            Wine, Cocktail, Drink, Whiskey
        };

        public override Task<int> ExecuteAsync(CommandContext context, OrderSettings settings)
        {
            Handle(settings);
            return Task.FromResult(0);
        }

        private void Handle(OrderSettings settings)
        {   
            var shouldCutYouOff = RandomGenerator.Next(100) < 5;
            if (shouldCutYouOff)
            {
                Console.WriteLine("Sorry, can't serve you. You are probably too drunk.");
                Console.WriteLine("Go home.");
                return;
            }

            if (settings.OrderCount > 20)
            {
                Console.WriteLine("Whoah! Your order is quite large. Please leave some for the rest of us!");
                return;
            }

            if (settings.MixOrderUp)
            {
                Console.Write($"Pouring {settings.OrderCount} different beverages:\n\n");

                for(var i = 0; i < settings.OrderCount; i++)
                {
                    var rnd = RandomGenerator.Next(10);
                    if(rnd < NonBeerBeverages.Count)
                    {
                        Console.Write(NonBeerBeverages[rnd]);
                    } else
                    {
                        Console.Write(Beer);
                    }

                    System.Threading.Thread.Sleep(200);
                }
            }

            if (settings.OnlyBeer || !settings.MixOrderUp)
            {
                Console.Write($"Pouring {settings.OrderCount} beers:\n\n");
                System.Threading.Thread.Sleep(200);

                for(var i = 0; i < settings.OrderCount; i++)
                {
                    Console.Write(Beer);
                    System.Threading.Thread.Sleep(200);
                }
            }

            var bartenderChance = RandomGenerator.Next(100) < 70;
            if(bartenderChance)
            {
                Console.WriteLine($"\n\nPouring one for the bartender: {Beer}. Thanks!");
            }

            var cheerChance = RandomGenerator.Next(100) < 20;
            if (settings.CheerMe || cheerChance)
            {
                Console.WriteLine("\nCheers! 🍻");
            }
        }
    }
}
