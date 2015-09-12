using System;
using System.Runtime.Serialization;

namespace Com.Framework.Data
{
    [DataContract]
    public class Hours : Entity
    {
        [DataMember]
        public int HoursID { get; set; }

        [DataMember]
        public int DayOfWeek { get; set; }

        [DataMember]
        public TimeSpan From { get; set; }

        [DataMember]
        public TimeSpan To { get; set; }

        [DataMember]
        public float Duration => (float)(To - From).TotalHours;

        public Hours()
        {

        }

        public Hours(int startHour, int startMinute, int durationHour, int durationMinute, DayOfWeek dayOfWeek)
        {
            From = new TimeSpan(0, startHour, startMinute);
            To = From.Add(new TimeSpan(0, durationHour, durationMinute));
            DayOfWeek = (int)dayOfWeek;
        }
    }
}