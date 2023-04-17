using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time
{
    public class Time
    {
        private int hours;
        private int minutes;
        private int seconds;

        public Time(int h, int m, int s)
        {
            hours = h;
            minutes = m;
            seconds = s;
        }

        public static Time operator +(Time t1, Time t2)
        {
            int totalSeconds = t1.seconds + t2.seconds;
            int additionalMinutes = totalSeconds / 60;
            totalSeconds = totalSeconds % 60;

            int totalMinutes = t1.minutes + t2.minutes + additionalMinutes;
            int additionalHours = totalMinutes / 60;
            totalMinutes = totalMinutes % 60;

            int totalHours = t1.hours + t2.hours + additionalHours;

            return new Time(totalHours, totalMinutes, totalSeconds);
        }

        public static Time operator -(Time t1, Time t2)
        {
            int totalSeconds = t1.seconds - t2.seconds;
            int additionalMinutes = 0;

            if (totalSeconds < 0)
            {
                totalSeconds += 60;
                additionalMinutes = 1;
            }

            int totalMinutes = t1.minutes - t2.minutes - additionalMinutes;
            int additionalHours = 0;

            if (totalMinutes < 0)
            {
                totalMinutes += 60;
                additionalHours = 1;
            }

            int totalHours = t1.hours - t2.hours - additionalHours;

            if (totalHours < 0)
            {
                totalHours += 24;
            }

            return new Time(totalHours, totalMinutes, totalSeconds);
        }

        public static bool operator ==(Time t1, Time t2)
        {
            return t1.hours == t2.hours && t1.minutes == t2.minutes && t1.seconds == t2.seconds;
        }

        public static bool operator !=(Time t1, Time t2)
        {
            return !(t1 == t2);
        }

        public static bool operator >(Time t1, Time t2)
        {
            if (t1.hours > t2.hours)
            {
                return true;
            }
            else if (t1.hours < t2.hours)
            {
                return false;
            }
            else // t1.hours == t2.hours
            {
                if (t1.minutes > t2.minutes)
                {
                    return true;
                }
                else if (t1.minutes < t2.minutes)
                {
                    return false;
                }
                else // t1.minutes == t2.minutes
                {
                    return t1.seconds > t2.seconds;
                }
            }
        }

        public static bool operator <(Time t1, Time t2)
        {
            return !(t1 == t2) && !(t1 > t2);
        }

        public static bool operator >=(Time t1, Time t2)
        {
            return t1 == t2 && t1 > t2;
        }

        public static bool operator <=(Time t1, Time t2)
        {
            return t1 == t2 && t1 < t2;
        }

        public static Time operator ++(Time t)
        {
            return t + new Time(0, 0, 1);
        }

        public static Time operator --(Time t)
        {
            return t - new Time(0, 0, 1);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Time t = (Time)obj;
            return this == t;
        }
        public override int GetHashCode()
        {
            return hours.GetHashCode() ^ minutes.GetHashCode() ^ seconds.GetHashCode();
        }
    }

}
