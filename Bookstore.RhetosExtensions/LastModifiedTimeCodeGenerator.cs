using Rhetos.Compiler;
using Rhetos.Dom.DefaultConcepts;
using Rhetos.Extensibility;
using System.ComponentModel.Composition;

namespace Bookstore.RhetosExtensions
{
    [Export(typeof(IConceptCodeGenerator))]
    [ExportMetadata(MefProvider.Implements, typeof(LastModifiedTimeInfo))]
    public class LastModifiedTimeCodeGenerator: IConceptCodeGenerator
    {        
        public void GenerateCode(Rhetos.Dsl.IConceptInfo conceptInfo, ICodeBuilder codeBuilder)
        {
            var info = (LastModifiedTimeInfo)conceptInfo;

            string snippet =
            $@"{{ 
                var now = SqlUtility.GetDatabaseTime(_executionContext.SqlExecuter);
                foreach (var newItem in insertedNew)
                    if(newItem.{info.Property.Name} == null)
                        newItem.{info.Property.Name} = now;
            }}
            ";

            codeBuilder.InsertCode(snippet, WritableOrmDataStructureCodeGenerator.InitializationTag, info.Property.DataStructure);
        }
    }
}
