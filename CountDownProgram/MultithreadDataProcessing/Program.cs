
using System.Threading.Tasks;

if (args.Length != 2)
{
    Console.WriteLine("Please provide input file path and output file path.");
    return;
}

string inputFilePath = args[0].Trim();
string outputFilePath = args[1].Trim();

// validate file paths and file types
if (string.IsNullOrWhiteSpace(outputFilePath) || string.IsNullOrWhiteSpace(inputFilePath))
{
    Console.WriteLine("Input/Output file path cannot be empty.");
    return;
}

if (!Path.GetExtension(inputFilePath).Equals(".txt", StringComparison.OrdinalIgnoreCase) 
    || !Path.GetExtension(outputFilePath).Equals(".txt", StringComparison.OrdinalIgnoreCase))
{
    Console.WriteLine("Error: Input/Output file must be a .txt file.");
    return;
}

if (!File.Exists(inputFilePath))
{
    Console.WriteLine($"Input file not found: {inputFilePath}");
    return;
}

await ProcessFile(inputFilePath, outputFilePath); 

static async Task ProcessFile(string inputFilePath, string outputFilePath)
{
    try
    {
        var lines = await File.ReadAllLinesAsync(inputFilePath);
        var numbers = new List<int>();
        foreach (var line in lines)
        {
           if(int.TryParse(line, out int number))
            {
                numbers.Add(number);
            }
            else
            {
                Console.WriteLine($"Invalid number found in input file: {line}");
                return;
            }
        }
        IEnumerable<Task<int>> tasks = numbers.Select(n => Task.Run(() => n * n)); 
        int[] result = await Task.WhenAll(tasks);

        await File.WriteAllLinesAsync(outputFilePath, result.Select(r => r.ToString()));
        Console.WriteLine($"Results saved to {outputFilePath}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An error occurred while processing the file: {ex.Message}");
    }
}