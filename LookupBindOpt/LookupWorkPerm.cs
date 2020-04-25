using System;
using System.Collections.Generic;
using System.Linq;
using LanguageExt;
using static LanguageExt.Prelude;

//Use Bind and an Option-returning Lookup function
//to implement GetWorkPermit, shown below. Then augment your 
//implementation so that the function returns None if the work permit has expired.

//Use Bind to implement AverageYearsWorkedAtTheCompany, shown below
//only employees who have left the company should be included):

namespace LookupWorkPerm
{
    public static class LookupWorkPerm
    {
        public struct WorkPermit
        {
            public string Number { get; set; }
            public DateTime Expiry { get; set; }
            public bool Valid { get; set; }
        }

        public class Employee
        {
            public string Id { get; set; }
            public Option<WorkPermit> WorkPermit { get; set; }
            public DateTime JoinedOn { get; }
            public Option<DateTime> LeftOn { get; }
        }

        
        private static Option<T> Lookup<K, T> (this IDictionary<K, T> dict, K key)
        {
            return dict.ContainsKey(key) ? Some(dict[key]) : None;
        }

        public static Option<WorkPermit> GetWorkPermit(Dictionary<string, Employee> people, string employeeId)
        {
            return people.Lookup(employeeId).Bind(p=>p.WorkPermit);
        }

        //Then augment your
        //implementation so that the function returns None if the work permit has expired

        public static Option<WorkPermit> GetWorkPermitValid(Dictionary<string, Employee> people, string employeeId)
             => people.Lookup(employeeId).Bind(p => p.WorkPermit).Where(NotExpired);
        public static Func<WorkPermit, bool> NotExpired => permit
            => permit.Expiry > DateTime.Now.Date;

        public static double AverageYearsWorkedAtTheCompany(List<Employee> people)
             => people.Bind(p => p.LeftOn.Map(leftOn => YearsBetween(p.JoinedOn, leftOn))).Average();

        static double YearsBetween(DateTime start, DateTime end)
            => (end - start).Days / 365d;
        static void Main()
        {
            
        }
    }
}
