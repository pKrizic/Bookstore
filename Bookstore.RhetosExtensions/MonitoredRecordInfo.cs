using Rhetos.Dsl;
using Rhetos.Dsl.DefaultConcepts;
using System.Collections.Generic;
using System.ComponentModel.Composition;

namespace Bookstore.RhetosExtensions
{
    [Export(typeof(IConceptInfo))]
    [ConceptKeyword("MonitoredRecord")]
    public class MonitorRecordInfo : IConceptInfo
    {
        [ConceptKey]
        public EntityInfo Entity { get; set; }
    }

    [Export(typeof(IConceptMacro))]
    public class MonitorRecordMacro : IConceptMacro<MonitorRecordInfo>
    {
        public IEnumerable<IConceptInfo> CreateNewConcepts(MonitorRecordInfo conceptInfo, IDslModel existingConcepts)
        {
            var newConcepts = new List<IConceptInfo>();

            newConcepts.Add(new EntityLoggingInfo { Entity = conceptInfo.Entity });

            var createdAt = new DateTimePropertyInfo { DataStructure = conceptInfo.Entity, Name = "CreatedAt" };
            newConcepts.Add(createdAt);
            newConcepts.Add(new CreationTimeInfo { Property = createdAt });


            return newConcepts;
        }
    }
}
