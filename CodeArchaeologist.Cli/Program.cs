using CodeArhaeologist.CSharp;

if (args.Length != 2)
{
    Console.WriteLine("Usage:");
    Console.WriteLine("  CodeArchaeologist.Cli analyze <solution path>");
    return;
}
var command = args[0];
var solutionPath = args[1];

if (!string.Equals(command, "analyze", StringComparison.OrdinalIgnoreCase))
{
    Console.WriteLine($"Unknown Command: {command}");
    return;
}
if (!File.Exists(solutionPath))
{
    Console.WriteLine($"solution file not found: {solutionPath}");
}

var analyzer = new CShartSolutionAnalyzer();

var result = await analyzer.AnalyzeAsync(solutionPath);

Console.WriteLine();
Console.WriteLine($"Solution Name: {result.Name}");

Console.WriteLine();
Console.WriteLine("Projects:");

foreach (var project in result.Projects)
{
    Console.WriteLine($"  - {project.Name}");
}
