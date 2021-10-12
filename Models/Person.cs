using System;

namespace Models
{
    public class Person
    {
        public long Id { get; set; }
        public Guid Identifier { get; set; } = Guid.NewGuid();
        public string Given { get; set; }
        public string Initials { get; set; }
        public string Family { get; set; }
        public DateTimeOffset Born { get; set; }

        public TimeSpan Age(DateTimeOffset? asOf = null)
        {
            if (asOf is null) asOf = DateTimeOffset.UtcNow;

            return new TimeSpan(asOf.Value.Ticks - Born.Ticks);

        }
    }
}
