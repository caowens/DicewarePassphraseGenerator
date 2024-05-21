# DicewarePassphraseGenerator

This C# program is intended to make a passphrase based on the [Diceware word list](https://theworld.com/%7Ereinhold/diceware.wordlist.asc).
To do this, you first roll a six-sided dice 5 times .
The 5 numbers together corresponds to a word in the Diceware word list.
For example, '21434' corresponds to 'costa'.
You repeat this 4 to 8 times depending on the strength of the passphrase you want.
The end result will be a (typically) 5 to 9 word passphrase.
You can find out more information about the Diceware Passphrase [here](https://theworld.com/~reinhold/diceware.html).

## Installation & Usage
1. For using this project, you must have the [.NET SDK](https://dotnet.microsoft.com/en-us/download) installed. ([.NET 8.0](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) was used for this project).

2. Clone or download the repo: 
```sh
   git clone https://github.com/caowens/DicewarePassphraseGenerator
```
3. Open a terminal in the root directory of the project and build the application:
```sh
   dotnet build
```
4. Run the application:
```sh
   dotnet run
```

If you're having issues, make sure you're .NET version is compatible with the one used in this project. You can also try just making a new project in a new folder with the ```dotnet new``` command and then copying and pasting the code into your `Program.cs` file. Don't forget to also make sure that the `dicewareWordList.txt` file is in the same directory.