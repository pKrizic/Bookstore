using Rhetos.Dsl;
using Rhetos.Dsl.DefaultConcepts;
using System.ComponentModel.Composition;

namespace Bookstore.RhetosExtensions
{
    [Export(typeof(IConceptInfo))]
    [ConceptKeyword("LastModifiedTime")]
    public class LastModifiedTimeInfo : IConceptInfo
    {
        [ConceptKey]
        public DateTimePropertyInfo Property { get; set; }
    }
}
