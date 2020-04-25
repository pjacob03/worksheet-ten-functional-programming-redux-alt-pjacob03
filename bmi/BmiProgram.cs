using System;


namespace bmi
{
    using static Math;

    public enum BmiOutput
    {
        Underweight,
        Healthy,
        Overweight
    }
    public static class BMI
    {
        static void Main()
        {
            Run(Read, Write);
        }

        public static void Run(Func<string, double> read, Action<BmiOutput> write)
        {
            var weight = read("weight");
            var height = read("height");
            var bmiOutput = CalcBmi(height, weight).ToBmi();

            write(bmiOutput);
        }
        public static double CalcBmi(double height, double weight)
            => Round(weight / Pow(height, 2),2);

        public static BmiOutput ToBmi(this double bmi)
            => bmi < 18.5 ? BmiOutput.Underweight
            : 25 <= bmi ? BmiOutput.Overweight
            : BmiOutput.Healthy;

        private static double Read(string input)
        {
            Console.Write($"Please enter your {input}:");
            return double.Parse(Console.ReadLine() ?? "");
        }

        private static void Write(BmiOutput bmiOutput)
            => Console.WriteLine($"You are {bmiOutput}");



    }
}
