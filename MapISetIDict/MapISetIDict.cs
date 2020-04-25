using System;
using System.Collections.Generic;
using LanguageExt;
using static LanguageExt.Prelude;

// Implement Map for ISet<T> and IDictionary<K, T>. 

namespace MapISetIDict
{
    public static class MapISetIDict
    {
        //Map: ISet<T> -> (T->R) -> ISet<R>
        static ISet<R> Map<T, R>(this ISet<T> ts, Func<T, R> func)
        {
            var rs = new LanguageExt.HashSet<R>();
            foreach (var t in ts)
                rs.Add(func(t));
            return rs as ISet<R>;
        }
        
        //Map: IDictionary<K, T> -> (T -> R) -> Idictionary<K, R>
        static IDictionary<K, R> Map <K, T, R>
            ( this IDictionary<K, T> dict, Func<T, R> func)
        {
            var rs = new Dictionary<K, R>();
            foreach (var (key, value) in dict)
                rs[key] = func(value);
            return rs;
        }        
             
        public static void Main()
        {
        
        }
    }
}
