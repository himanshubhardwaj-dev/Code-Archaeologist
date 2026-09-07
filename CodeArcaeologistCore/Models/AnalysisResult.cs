using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeArcaeologistCore.Models
{
    public sealed class AnalysisResult
    {
        public string Name { get; init; } = string.Empty;
        public IReadOnlyCollection<CodeProject> Projects { get; init; } = Array.Empty<CodeProject>();
    }
}
