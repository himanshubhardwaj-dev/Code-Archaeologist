using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeArcaeologistCore.Models
{
    public sealed class CodeRelationship
    {
        public string Source { get; init; } = string.Empty;
        public string Target { get; init; } = string.Empty;
        public string Kind { get; init; } = string.Empty;
    }
}
