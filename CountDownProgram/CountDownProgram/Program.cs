
// check input arguments are 2 numbers.
if (args.Length < 2)
{
    Console.WriteLine("Please provide two integer arguments.");
    return;
}   

if(!int.TryParse(args[0], out int value) || !int.TryParse(args[1], out int divider))
{
    Console.WriteLine("Both arguments must be integers.");
    return;
}

// edge case 
if (value < 0 || divider < 0)
{
    Console.WriteLine("Negative inputs are not allowed.");
    return;
}

if (value < 2)
{
    Console.WriteLine("First argument is invalid. Must between 2 and 1000"); 
    return;
}

if(value > 1000)
{
    Console.WriteLine("First argument is invalid. Must between 2 and 1000");
    return;
}

if (divider == 0)
{
    Console.WriteLine("Division by zero error. Second argument cannot be zero.");
    return; 
}

if(divider > value)
{
    Console.WriteLine("Second argument cannot greater than first argument.");
    return;
}

if(value % divider != 0)
{
    Console.WriteLine("First argument must be divisible by second argument.");
    return;
}

CountDown(value, divider);

static void CountDown(int value, int divider)
{
    try
    {
        for (int i = value; i > 0; i--)
        {
            if (i % divider == 0)
            {
                Console.WriteLine(i);
            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An error occurred: {ex.Message}");
    }
}