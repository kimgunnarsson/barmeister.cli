using Barmeister.Cli.Commands;
using Spectre.Cli;
using System;
using System.Threading.Tasks;

namespace Barmeister.Cli
{
    class Program
    {
        public async static Task<int> Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            var app = new CommandApp();
            app.Configure(cfg =>
            {
                cfg.ValidateExamples();
                cfg.UseStrictParsing();

                cfg.AddCommand<OrderCommand>("order")
                    .WithExample(new [] { "order", "<number of beverages>" })
                    .WithExample(new [] { "order", "<number of beverages>", "--cheer" })
                    .WithExample(new [] { "order", "<number of beverages>", "--only-beer" })
                    .WithExample(new [] { "order", "<number of beverages>", "--mix-me-up" });
            });

            return await app.RunAsync(args);
        }
    }
}
