using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using CodeArcaeologistCore.Models;

namespace CodeArhaeologist.CSharp
{
    public sealed class CShartSolutionAnalyzer
    {
        public async Task<AnalysisResult> AnalyzeAsync(string sourceFilePath)
        {
            var sourceCode = await File.ReadAllTextAsync(sourceFilePath);

            var syntaxTree = CSharpSyntaxTree.ParseText(sourceCode);

            var syntaxRoot = await syntaxTree.GetRootAsync();

            Console.WriteLine($"Syntax Tree Type: {syntaxTree.GetType().Name}");
            Console.WriteLine($"Root Type: {syntaxRoot.GetType().Name}");

            return new AnalysisResult
            {
                Name = sourceFilePath
            };
        }
    }
}
