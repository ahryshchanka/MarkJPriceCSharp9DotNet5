using static System.Console;

// RunTimesTable();
// RunCardinalToOrdinal();
RunFactorial();

// ------------------------------------------------------------------
static void TimesTable(byte number)
{
    WriteLine($"This is the {number} times table:");

    for (int row = 1; row <= 12; row++)
    {
        WriteLine($"{row} x {number} = {row * number}");
    }
    WriteLine();
}
static void RunTimesTable()
{
    bool isNumber;
    do
    {
        Write("Enter a number between 0 and 255: ");
        isNumber = byte.TryParse(ReadLine(), out byte number);
        if (isNumber)
        {
            TimesTable(number);
        }
        else
        {
            WriteLine("You did not enter a valid number!");
        }
    } while (isNumber);
}
// ------------------------------------------------------------------
static string CardinalToOrdinal(int number)
{
    switch (number)
    {
        case 11:
        case 12:
        case 13:
            return $"{number}th";
        default:
            int lastDigitNumber = number % 10;
            string suffix = lastDigitNumber switch
            {
                1 => "st",
                2 => "nd",
                3 => "rd",
                _ => "th"
            };
            return $"{number}{suffix}";
    }
}
static void RunCardinalToOrdinal()
{
    for (int number = 1; number <= 100; number++)
    {
        Write($"{CardinalToOrdinal(number)} ");
    }
    WriteLine();
}
// ------------------------------------------------------------------
static int Factorial(int number)
{
    return number switch
    {
        var x when x < 1 => 0,
        var x when x == 1 => 1,
        _ => number * Factorial(number - 1)
    };
}
static void RunFactorial()
{
    for (var i = 1; i < 15; i++)
    {
        WriteLine($"{i}! = {Factorial(i):N0}");
    }
}