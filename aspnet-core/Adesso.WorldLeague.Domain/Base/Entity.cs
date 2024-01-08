using System;

namespace Adesso.WorldLeague.BaseEntities
{
    public class Entity : IEntity<Guid>
    {
        public Guid Id { get; set; }
    }
}
