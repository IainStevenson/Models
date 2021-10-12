using System;

namespace Models
{
    public class Person
    {
        public string Given { get; set; }
        public string Initials { get; set; }
        public string Family { get; set; }
        public DateTimeOffset Born { get; set; }

        public TimeSpan Age(DateTimeOffset? asOf = null)
        {
            if (asOf is null) _ = DateTimeOffset.UtcNow;

            return new TimeSpan(DateTimeOffset.UtcNow.Ticks - Born.Ticks);

        }
    }
}
