using System;

namespace PushNotifications.Contracts
{
    public class Timestamp
    {
        private Timestamp() { }

        public Timestamp(DateTime dateTime)
        {
            if (ReferenceEquals(null, dateTime) == true) throw new ArgumentNullException(nameof(dateTime));
            if (dateTime.Kind != DateTimeKind.Utc) throw new ArgumentException("All timestamps should be utc!");

            FileTimeUtc = dateTime.ToFileTimeUtc();
        }

        public long FileTimeUtc { get; private set; }

        public DateTime DateTime { get { return DateTime.FromFileTimeUtc(FileTimeUtc); } }

        public static Timestamp UtcNow()
        {
            return new Timestamp(DateTime.UtcNow);
        }

        public static Timestamp JudgementDay()
        {
            return new Timestamp(DateTime.UtcNow.AddYears(100));
        }
    }
}
