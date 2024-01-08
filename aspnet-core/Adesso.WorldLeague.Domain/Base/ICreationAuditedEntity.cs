using System;

namespace Adesso.WorldLeague.BaseEntities
{
    public interface ICreationAuditedEntity
    {
        public DateTime CreationTime { get; set; }
    }
}
