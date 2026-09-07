using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.MSBuild;
using CodeArcaeologistCore.Models;

namespace CodeArhaeologist.CSharp
{
    public sealed class CShartSolutionAnalyzer
    {
        public async Task<AnalysisResult> AnalyzeAsync(string solutionPath)
        {
            using var workspace = MSBuildWorkspace.Create();
            var solution = await workspace.OpenSolutionAsync(solutionPath);

            var project = solution.Projects.Select(project => new CodeProject
            {
                Name = project.Name,
                FilePath = project.FilePath ?? string.Empty
            }).ToList();

            return new AnalysisResult
            {
                Name = solution.FilePath ?? solutionPath,
                Projects = project
            };

        }
    }
}
