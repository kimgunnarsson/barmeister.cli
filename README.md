# :beer: Barmeister.Cli

A _stupid_ example of a command line application using [Spectre.Cli](https://github.com/spectresystems/spectre.cli).

## What it does

- It returns number of ordered beverages (preferably beers).
- You can mix your order up with wine, whiskey, drinks and cocktails!
- Sometimes the bartender get a complimentary beer on you (it's OK; you can afford it)!
- Sometimes the bartender denies you without reason and send you on your way home. Just like real life.


## Usages

```
dotnet run order <number of beverages>
dotnet run order <number of beverages> --cheer
dotnet run order <number of beverages> --only-beer
dotnet run order <number of beverages> --mix-me-up
```

Example:
```
dotnet run order 10 --mix-me-up

Pouring 10 different beverages:

🍷🍹🍹🍸🥃🍹🍷🍺🍺🍸

Pouring one for the bartender: 🍺. Thanks!
```

## Dependencies

- [Spectre.Cli](https://github.com/spectresystems/spectre.cli)

