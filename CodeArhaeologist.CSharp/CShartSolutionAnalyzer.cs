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
                var method = classDeclaration.Members.OfType<MethodDeclarationSyntax>().Select(method => method.Identifier.Text).ToList();

                types.Add(new CodeType
                {
                    Name = classDeclaration.Identifier.Text,
                    Kind = "Class",
                    Methods = method
                });
            }

            foreach (var interfaceDeclaration in interfaces)
            {
                var method = interfaceDeclaration.Members.OfType<MethodDeclarationSyntax>().Select(method => method.Identifier.Text).ToList();

                types.Add(new CodeType
                {
                    Name = interfaceDeclaration.Identifier.Text,
                    Kind = "Interface",
                    Methods = method
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
