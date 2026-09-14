using CodeArcaeologistCore.Models;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CodeArhaeologist.CSharp
{
    public sealed class CShartSolutionAnalyzer
    {
        public async Task<AnalysisResult> AnalyzeAsync(string sourceFilePath)
        {
            var sourceCode = await File.ReadAllTextAsync(sourceFilePath);

            var syntaxTree = CSharpSyntaxTree.ParseText(sourceCode);

            var syntaxRoot = await syntaxTree.GetRootAsync();

            var classes = syntaxRoot.DescendantNodes().OfType<ClassDeclarationSyntax>().ToList();

            var interfaces = syntaxRoot.DescendantNodes().OfType<InterfaceDeclarationSyntax>().ToList();

            var types = new List<CodeType>();

            foreach (var classDeclaration in classes)
            {
                types.Add(new CodeType
                {
                    Name = classDeclaration.Identifier.Text,
                    Kind = "Class"
                });
            }

            foreach (var interfaceDeclaration in interfaces)
            {
                types.Add(new CodeType
                {
                    Name = interfaceDeclaration.Identifier.Text,
                    Kind = "Interface"
                });
            }

            var project = new CodeProject
            {
                Name = Path.GetFileNameWithoutExtension(sourceFilePath),
                FilePath = sourceFilePath,
                Types = types
            };

            return new AnalysisResult
            {
                Name = sourceFilePath,
                Projects = new[] { project }
            };
        }
    }
}
