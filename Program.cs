/* 
This program is intended to make a passphrase based on the Diceware word list.
To do this, you first roll a six-sided dice 5 times .
The 5 numbers together corresponds to a word in the Diceware word list.
For example, '21434' corresponds to 'costa'.
You repeat this 4 to 8 times depending on the strength of the passphrase you want
The end result will be a (typically) 5 to 9 word passphrase.
You can find out more information about the Diceware Passphrase here:
https://theworld.com/~reinhold/diceware.html
*/

Console.WriteLine();
Console.WriteLine("------------------------------------");
Console.WriteLine("Welcome to the Passphrase Generator!");
Console.WriteLine("------------------------------------");
Console.WriteLine();

string? readResult;
bool validEntry = false;
int passphraseLength = 0;

do
{
    Console.WriteLine("Enter the length of the passphrase you want (Recommended to choose a length of 5 or higher for a strong password):");
    readResult = Console.ReadLine();
    validEntry = int.TryParse(readResult, out passphraseLength);
} while (validEntry == false);

Console.WriteLine($"You have chosen to generate a passphrase with {passphraseLength} words.");