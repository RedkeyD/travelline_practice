FileReader fileReader = new FileReader();
Dictionary<string, string> englishToRussianDictionary = new Dictionary<string, string>();
Dictionary<string, string> russianToEnglishDictionary = new Dictionary<string, string>();

// File path
string filePath = "WordsTranslations.txt";

string errorMessage;
bool exit = false;

// Initialize dictionaries
fileReader.ReadFile( filePath, englishToRussianDictionary, russianToEnglishDictionary );
InputValidator inputValidator = new InputValidator( englishToRussianDictionary, russianToEnglishDictionary );

while ( !exit ) 
{
    Console.WriteLine( "Enter a word to translate (Type exit to leave a program): " );
    string wordToTranslate = Console.ReadLine().Trim().ToLower();

    if ( wordToTranslate == "exit" )
    {
        string farewellWords = "Bye, have a good day";
        Console.WriteLine(farewellWords );
        break;
    }

    // Validate user input
    if ( inputValidator.ValidateInput( wordToTranslate, out errorMessage ) )
    {
        // Perform translation based on user input
        if ( englishToRussianDictionary.ContainsKey( wordToTranslate ) )
        {
            string russianTranslation = englishToRussianDictionary[ wordToTranslate ];
            Console.WriteLine( $"{wordToTranslate} in Russian is {russianTranslation}" );
        }
        else if ( russianToEnglishDictionary.ContainsKey( wordToTranslate ) )
        {
            string englishTranslation = russianToEnglishDictionary[ wordToTranslate ];
            Console.WriteLine( $"{wordToTranslate} in English is {englishTranslation}" );
        }
    }

    //// Handle input errors
    else
    {
        Console.WriteLine( errorMessage );
    }
}



