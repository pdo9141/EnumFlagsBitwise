using System;

namespace EnumFlagsBitwise
{
    class Program
    {
        static void Main(string[] args)
        {
            // Monday    = 0001
            // Tuesday   = 0010
            // Wednesday = 0100
            // use OR operator (|) to add Monday, Tuesday, Wednesday to days set, 0111
            var days = Weekdays.Monday | Weekdays.Tuesday | Weekdays.Wednesday;
            Console.WriteLine("days: {0}", days);
            Console.WriteLine("days: {0}", Convert.ToInt64(days));

            // use AND operator (&)
            bool isTuesdayInSet = (days & Weekdays.Tuesday) == Weekdays.Tuesday;
            Console.WriteLine("isTuesdayInSet: {0}", isTuesdayInSet);

            // use XOR operator (^) to remove Tuesday, doesn't matter if Tuesday is not in set
            days ^= Weekdays.Tuesday;

            isTuesdayInSet = days.HasFlag(Weekdays.Tuesday); // same as above, introduced in 4.0
            Console.WriteLine("isTuesdayInSet: {0}", isTuesdayInSet);

            bool isMondayWednesdayInSet = (days & (Weekdays.Monday | Weekdays.Wednesday)) == (Weekdays.Monday | Weekdays.Wednesday);
            Console.WriteLine("isMondayWednesdayInSet: {0}", isMondayWednesdayInSet);
            Console.WriteLine("isMondayWednesdayInSet: {0}", days.HasFlag(Weekdays.Monday | Weekdays.Wednesday));

            var mondayAndTuesday = (Weekdays)3; // sum of Monday and Tuesday
            Console.WriteLine("mondayAndTuesday: {0}", mondayAndTuesday);
            
            Console.Read();
        }
    }

    // only 64 possible fields for long, not including Workdays, Weekends, All
    [Flags]
    public enum Weekdays : long
    {
        None = 0,           //00000001
        Monday = 1,         //00000010
        Tuesday = 2,        //00000100
        Wednesday = 4,      //00001000
        Thursday = 8,       //00010000
        Friday = 16,        //00100000
        Saturday = 32,      //01000000
        Sunday = 64,        //10000000
        Workdays = Monday | Tuesday | Wednesday | Thursday | Friday,
        Weekend = Saturday | Sunday,
        All = Workdays | Weekend
    }

    // easier if you use left shit operator (<<)
    [Flags]
    public enum WeekdaysShift : long
    {
        None = 0,
        Monday = 1 << 0,
        Tuesday = 1 << 1,
        Wednesday = 1 << 2,
        Thursday = 1 << 3,
        Friday = 1 << 4,
        Saturday = 1 << 5,
        Sunday = 1 << 6,
        Workdays = Monday | Tuesday | Wednesday | Thursday | Friday,
        Weekend = Saturday | Sunday,
        All = Workdays | Weekend
    }

    [Flags]
    public enum Roles : long
    {
        None = 0,
        Guest = 1 << 0,
        User = 1 << 1,
        Operations = 1 << 2,
        Admin = 1 << 3,
        SuperAdmin = 1 << 4
    }
}
