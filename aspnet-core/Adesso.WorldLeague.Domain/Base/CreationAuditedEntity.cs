using System;

namespace Adesso.WorldLeague.BaseEntities
{
    public class CreationAuditedEntity<T>:Entity,ICreationAuditedEntity
    {
        public DateTime CreationTime { get; set; }
    }
}
