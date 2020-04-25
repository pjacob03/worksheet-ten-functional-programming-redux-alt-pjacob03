using System;
using LanguageExt;
using static LanguageExt.Prelude;

        // Write a generic function that takes a string and parses it as a value of an enum. It
        // should be usable as follows:
        // Enum.Parse<DayOfWeek>("Friday") // => Some(DayOfWeek.Friday)
        // Enum.Parse<DayOfWeek>("Freeday") // => None

namespace StringParse
{
    public static class StringParse
    {
        private static Option<T> Parse<T>(this string s) where T : struct
            => Enum.TryParse(s, out T t) ? Some(t) : None;
        static void Main()
        {
            Console.WriteLine("Friday".Parse<DayOfWeek>());
            Console.WriteLine("Freeday".Parse<DayOfWeek>());
        }
    }
}
