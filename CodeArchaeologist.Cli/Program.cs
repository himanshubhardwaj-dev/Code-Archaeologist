using CodeArhaeologist.CSharp;

if (args.Length != 2)
{
    Console.WriteLine("Usage:");
    Console.WriteLine("  CodeArchaeologist.Cli analyze <C# file path>");
    return;
}

var command = args[0];
var sourceFilePath = args[1];

if (!string.Equals(command, "analyze", StringComparison.OrdinalIgnoreCase))
{
    Console.WriteLine($"Unknown Command: {command}");
    return;
}

if (!File.Exists(sourceFilePath))
{
    Console.WriteLine($"C# file not found: {sourceFilePath}");
    return;
}

var analyzer = new CShartSolutionAnalyzer();

var result = await analyzer.AnalyzeAsync(sourceFilePath);

Console.WriteLine();
Console.WriteLine($"File: {result.Name}");