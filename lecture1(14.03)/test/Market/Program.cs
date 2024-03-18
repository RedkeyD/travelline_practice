class Program
{
    static void Main()
    {
        string productPrompt = "Введите название продукта: ";
        string countPrompt = "Введите количество продукта: ";
        string userPrompt = "Введите ваше имя:  ";
        string addressPrompt = "Введите адресс доставки: ";

        bool isComplete = false;

        while ( !isComplete )
        {
            string productName = GetUserInput( productPrompt );
            int productCount = GetIntegerInput( countPrompt );
            string userName = GetUserInput( userPrompt );
            string userAddress = GetUserInput( addressPrompt );

            Console.WriteLine( ConfirmOrder( userName, productCount, productName, userAddress ) );
            string answer = Console.ReadLine();

            if ( string.IsNullOrWhiteSpace( answer ) )
                isComplete = true;
        }

        Console.WriteLine( "Заказ был успешно оформлен!" );
    }

    static string GetUserInput( string prompt )
    {
        string input = null;
        bool validInput = false;

        do
        {
            Console.WriteLine( prompt );
            try
            {
                input = Console.ReadLine();
                validInput = !string.IsNullOrWhiteSpace( input );
                if ( !validInput )
                    throw new Exception( "Данные не могут быть пустыми." );
            }
            catch ( Exception ex )
            {
                Console.WriteLine( $"Ошибка: {ex.Message}" );
            }
        } while ( !validInput );

        return input;
    }

    static int GetIntegerInput( string prompt )
    {
        int input = 0;
        bool validInput = false;

        do
        {
            Console.WriteLine( prompt );
            try
            {
                input = int.Parse( Console.ReadLine() );
                validInput = true;
            }
            catch ( FormatException )
            {
                Console.WriteLine( "Ошибка вывода данных" );
            }
            catch ( Exception ex )
            {
                Console.WriteLine( $"Ошибка: {ex.Message}" );
            }
        } while ( !validInput );

        return input;
    }
    static string ConfirmOrder( string name, int count, string nameProduct, string adress )
    {
        return $"Здраствуйте, {name} вы заказали {count} {nameProduct} на адресс {adress}, все верно?";
    }
}
