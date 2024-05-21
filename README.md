# DicewarePassphraseGenerator

This C# program is intended to make a passphrase based on the [Diceware word list](https://theworld.com/%7Ereinhold/diceware.wordlist.asc).
To do this, you first roll a six-sided dice 5 times .
The 5 numbers together corresponds to a word in the Diceware word list.
For example, '21434' corresponds to 'costa'.
You repeat this 4 to 8 times depending on the strength of the passphrase you want.
The end result will be a (typically) 5 to 9 word passphrase.
You can find out more information about the Diceware Passphrase [here](https://theworld.com/~reinhold/diceware.html).