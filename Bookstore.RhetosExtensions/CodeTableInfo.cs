using Rhetos.Dsl;
using Rhetos.Dsl.DefaultConcepts;
using System.ComponentModel.Composition;

namespace Bookstore.RhetosExtensions
{
    [Export(typeof(IConceptInfo))]
    [ConceptKeyword("CodeTable")]
    public class CodeTableInfo : IConceptInfo
    {
        [ConceptKey]
        public ShortStringPropertyInfo Code { get; set; }

        [ConceptKey]
        public RequiredPropertyInfo Name { get; set; }
    }
}
