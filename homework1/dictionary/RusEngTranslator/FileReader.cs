public class FileReader
{
    public void ReadFile( string filePath,
                         Dictionary<string, string> englishToRussianDictionary,
                         Dictionary<string, string> russianToEnglishDictionary )
    {
        try
        {
            // Check if the file exists
            if ( !File.Exists( filePath ) )
            {
                Console.WriteLine( "File not found." );
                return;
            }

            // Read all lines from the file
            string[] lines = File.ReadAllLines( filePath );

            foreach ( string line in lines )
            {
                string[] parts = line.Split( ':' );
                if ( parts.Length == 2 )
                {
                    string englishWord = parts[ 0 ].Trim();
                    string russianWord = parts[ 1 ].Trim();

                    // Populate English to Russian dictionary
                    englishToRussianDictionary[ englishWord ] = russianWord;

                    // Populate Russian to English dictionary
                    russianToEnglishDictionary[ russianWord ] = englishWord;
                }
            }
        }
        catch ( Exception ex )
        {
            Console.WriteLine( $"Error reading file: {ex.Message}" );
        }
    }
}

