using System;
using System.Collections.Generic;
using LanguageExt;
using static LanguageExt.Prelude;

//Implement Map for Option and IEnumerable in terms of Bind and Return.

namespace MapOptIEnum
{
    public static class MapOptIEnum
    {

        public static Option<R> Map<T, R>(this Option<T> opt, Func<T, R> func)
            => opt.Bind(t => Some(func(t)));

        public static IEnumerable<R> Map<T, R>(this IEnumerable<T> ts, Func<T,R> func)
        
            => ts.Bind(t => List(func(t)));

        static void Main()
        {
       
        }
    }
}
