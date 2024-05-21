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
bool validEntry;
int wordsAmount;

// Get passphrase length from user
do
{
    Console.WriteLine("Decide how many words you want in your passphrase. A five word passphrase provides a level of security much higher than the simple passwords most people use. Diceware recommends a minimum of six words for use with GPG, wireless security and file encryption programs. A seven, eight or nine word passphrase is recommended for high value uses such as whole disk encryption, BitCoin, and the like. For more information, see the Diceware FAQ: https://theworld.com/%7Ereinhold/dicewarefaq.html#howlong \n");
    Console.WriteLine("Enter the length of the passphrase you want:");
    readResult = Console.ReadLine();
    validEntry = int.TryParse(readResult, out wordsAmount);
} while (validEntry == false);

Console.WriteLine($"You have chosen to generate a passphrase with {wordsAmount} words.\n");

// Generate passcodes
string[] passWords = new string[wordsAmount];
Random dice = new Random();
for (int i = 0; i < wordsAmount; i++)
{
    string code = "";
    for (int j = 0; j < 5; j++)
    {
        int roll = dice.Next(1, 7);
        code += roll.ToString();
    }
    passWords[i] = GetWord(code);
    Console.WriteLine($"{code} => {passWords[i]}");
}

// Give user option to insert a special character
validEntry = false;
do
{
    Console.WriteLine("\nWould you like your passphrase to include a special character? (Y/N): ");
    readResult = Console.ReadLine();
    if (readResult != null)
    {
        if (readResult.ToLower() == "y")
        {
            InsertSpecialCharacter(passWords);
            validEntry = true;
        }
        else if (readResult.ToLower() == "n")
        {
            validEntry = true;
        }
        else
        {
            Console.WriteLine("That is not a valid input. Please enter y or n.");
        }
    }
} while (validEntry == false);

string passPhrase = string.Join("", passWords);
Console.WriteLine($"\nYour passphrase is: {passPhrase}");

static string GetWord(string passphraseCode)
{
    // Get corresponding word from the word list
    StreamReader reader = File.OpenText("dicewareWordList.txt");
    string? line;
    while ((line = reader.ReadLine()) != null)
    {
        string[] items = line.Split('\t');
        string code = items[0];
        string word = items[1];

        if (code == passphraseCode)
        {
            return word;
        }
    }

    return "";
}

// Insert a random special character in a random place in a random word in the passphrase
void InsertSpecialCharacter(string[] passWords)
{
    char[,] specialCharacters = {{'~', '!', '#', '$', '%', '^'},
                                {'&', '*', '(', ')', '-', '='},
                                {'+', '[', ']', '\\', '{', '}'},
                                {':', ';', '"', '\'', '<', '>'},
                                {'?', '/', '0', '1', '2', '3'},
                                {'4', '5', '6', '7', '8', '9'}};

    // Get random special character
    int specRow = dice.Next(0, 6);
    int specCol = dice.Next(0, 6);
    char specialChar = specialCharacters[specRow, specCol];

    Console.WriteLine($"Special character => {specialChar}");
    
    // Insert special character in random place in passphrase
    int wordIndex = dice.Next(1, passWords.Length);
    string word = passWords[wordIndex];
    int insertionIndex = dice.Next(1, word.Length);
    string newWord = word.Substring(0, insertionIndex) + specialChar + word.Substring(insertionIndex);

    passWords[wordIndex] = newWord;
}