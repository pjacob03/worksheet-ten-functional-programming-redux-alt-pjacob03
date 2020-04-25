using NUnit.Framework;
using bmi;


namespace bmiTests
{
    public class BmiTests
    {
        [TestCase(1.80, 77, ExpectedResult = 23.77)]
        [TestCase(1.60, 77, ExpectedResult = 30.08)]
        public double CalcBmi(double height, double weight)
            => BMI.CalcBmi(height, weight);

        [TestCase(23.77, ExpectedResult = BmiOutput.Healthy)]
        [TestCase(30.08, ExpectedResult = BmiOutput.Overweight)]
        public BmiOutput ToBmiRange(double bmi) => bmi.ToBmi();

        [TestCase(1.80, 77, ExpectedResult = BmiOutput.Healthy)]
        [TestCase(1.60, 77, ExpectedResult = BmiOutput.Overweight)]
        public BmiOutput ReadBmi(double height, double weight)
        {
            var result = default(BmiOutput);
            double Read(string s) => s == "height" ? height : weight;
            void Write(BmiOutput r) => result = r;

            BMI.Run(Read, Write);
            return result;
        }
    }
}