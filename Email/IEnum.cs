using System;
using System.Collections.Generic;
using LanguageExt;
using static LanguageExt.Prelude;

    //Write a Lookup function that will take an IEnumerable and a predicate, and return the first element in the IEnumerable that matches the predicate, or None if no matching element is found.Write its signature in arrow notation:
    //bool isOdd(int i) => i % 2 == 1;
    //new List<int>().Lookup(isOdd)     // => None
    //new List<int> { 1 }.Lookup(isOdd) // => Some(1)

namespace IEnum
{
    public static class IEnum
    {
        public static Option<T> Lookup<T> (this IEnumerable<T> ts, Func<T,bool> pred)
        {
            foreach (T t in ts) 
                if (pred(t)) 
                    return Some(t);
                return None;
        }
        public static void Main()
        {
            static bool isOdd(int i) => i % 2 == 1;
            Console.WriteLine(new List<int>().Lookup(isOdd));     // => None
            Console.WriteLine(new List<int> { 1 }.Lookup(isOdd)); // => Some(1));
        }
    }
}

// Take a look at the extension methods defined on IEnumerable inSystem.LINQ.Enumerable.
// Which ones could potentially return nothing, or throw some
// kind of not-found exception, and would therefore be good candidates for
// returning an Option<T> instead?
