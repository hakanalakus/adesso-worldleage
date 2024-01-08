using System;

namespace Adesso.WorldLeague.BaseEntities
{
    public interface ISoftDelete
    {
        public bool IsDeleted { get; set; }
        public DateTime? DeletionTime { get; set; }
    }
}
