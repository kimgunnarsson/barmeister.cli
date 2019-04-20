using Spectre.Cli;
using System.ComponentModel;

namespace Barmeister.Cli.Commands
{
    public sealed class OrderSettings : CommandSettings
    {
        [CommandArgument(0, "<number of beverages>")]
        [Description("The number of beverages to serve")]
        public int OrderCount { get; set;}

        [CommandOption("--cheer")]
        [Description("If you want the bartender to explicit cheer you and your beverages")]
        public bool CheerMe {get; set;}

        [CommandOption("--only-beer")]
        [Description("Include only beers in your order")]
        public bool OnlyBeer {get; set;}

        [CommandOption("--mix-me-up")]
        [Description("Mix up order with drinks and whiskey")]
        public bool MixOrderUp {get; set;}

        public override ValidationResult Validate()
        {
            if (OrderCount == 0)
            {
                return ValidationResult.Error("A zero-based order can not be handled.");
            }

            if (OnlyBeer && MixOrderUp)
            {
                return ValidationResult.Error("Both --only-beer and --mix-me-up have been specified. Only one can be defined.");
            }

            return base.Validate();
        }
    }
}