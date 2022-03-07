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
            var code = new ShortStringPropertyInfo { DataStructure = conceptInfo.Entity, Name = "Code" };
            newConcepts.Add(code);
            newConcepts.Add(new AutoCodePropertyInfo { Property = code });

            var name = new ShortStringPropertyInfo { DataStructure = conceptInfo.Entity, Name = "Name" };
            newConcepts.Add(name);
            newConcepts.Add(new RequiredPropertyInfo { Property = name });


            return newConcepts;
        }
    }
}
