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

// Get passphrase length from user
do
{
    Console.WriteLine("Decide how many words you want in your passphrase. A five word passphrase provides a level of security much higher than the simple passwords most people use. Diceware recommends a minimum of six words for use with GPG, wireless security and file encryption programs. A seven, eight or nine word passphrase is recommended for high value uses such as whole disk encryption, BitCoin, and the like. For more information, see the Diceware FAQ: https://theworld.com/%7Ereinhold/dicewarefaq.html#howlong \n");
    Console.WriteLine("Enter the length of the passphrase you want:");
    readResult = Console.ReadLine();
    validEntry = int.TryParse(readResult, out passphraseLength);
} while (validEntry == false);

Console.WriteLine($"You have chosen to generate a passphrase with {passphraseLength} words.");

// Generate passcodes

int[,] passphraseCodes = new int[passphraseLength, 5];
Random dice = new Random();

for (int i = 0; i < passphraseLength; i++)
{
    for (int j = 0; j < 5; j++)
    {
        int roll = dice.Next(1, 7);
        passphraseCodes[i,j] = roll;
    }
}

Console.WriteLine("\nHere are the codes:\n");
// Print passphrases codes
for (int i = 0; i < passphraseLength; i++)
{
    for (int j = 0; j < 5; j++)
    {
        Console.Write(passphraseCodes[i,j]);
    }
    Console.WriteLine();
}