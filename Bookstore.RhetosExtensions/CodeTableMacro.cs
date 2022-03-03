using Rhetos.Dsl;
using Rhetos.Dsl.DefaultConcepts;
using System.Collections.Generic;
using System.ComponentModel.Composition;

namespace Bookstore.RhetosExtensions
{
    [Export(typeof(IConceptMacro))]
    public class CodeTableMacro : IConceptMacro<CodeTableInfo>
    {
        public IEnumerable<IConceptInfo> CreateNewConcepts(CodeTableInfo conceptInfo, IDslModel existingConcepts)
        {
            var newConcepts = new List<IConceptInfo>();

            return newConcepts;
        }
    }
}
