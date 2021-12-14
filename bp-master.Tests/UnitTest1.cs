using BPCalculator;
using System;
using Xunit;


namespace bp_master.Tests.BloodPressure
{
    public class UnitTest1
    {
        public BPCalculator.BloodPressure BP;
        public BPCalculator.HeartRateCalculator HR;

        [Theory]
        [InlineData(71, 41)]
        [InlineData(89, 59)]
        [InlineData(80, 55)]
        [InlineData(70, 40)]
        [InlineData(80, 59)]
        [InlineData(89, 50)]
        public void TestLowCategpry(int systolic, int diastolic)
        {
            BP = new BPCalculator.BloodPressure() { Systolic = systolic, Diastolic = diastolic };
            Assert.Equal(BPCalculator.BPCategory.Low, BP.Category);
        }
        
        [Theory]
        [InlineData(119, 70)]
        [InlineData(115, 75)]
        [InlineData(110, 65)]
        [InlineData(100, 78)]
        [InlineData(109, 75)]
        [InlineData(105, 60)]
        [InlineData(90, 75)]
        [InlineData(110, 70)]
        [InlineData(80, 65)]
        public void TestIdealCategpry(int systolic, int diastolic)
        {
            BP = new BPCalculator.BloodPressure() { Systolic = systolic, Diastolic = diastolic };
            Assert.Equal(BPCalculator.BPCategory.Ideal, BP.Category);
        }

        [Theory]
        [InlineData(139, 81)]
        [InlineData(130, 80)]
        [InlineData(121, 89)]
        [InlineData(130, 70)]
        [InlineData(120, 89)]
        [InlineData(100, 85)]
        public void TestPreCategpry(int systolic, int diastolic)
        {
            BP = new BPCalculator.BloodPressure() { Systolic = systolic, Diastolic = diastolic };
            Assert.Equal(BPCalculator.BPCategory.PreHigh, BP.Category);
        }

        [Theory]
        [InlineData(180, 99)]
        [InlineData(170, 95)]
        [InlineData(160, 91)]
        [InlineData(150, 90)]
        [InlineData(140, 40)]
        [InlineData(95, 90)]
        public void TestHighCategpry(int systolic, int diastolic)
        {
            BP = new BPCalculator.BloodPressure() { Systolic = systolic, Diastolic = diastolic };
            Assert.Equal(BPCalculator.BPCategory.High, BP.Category);
        }

        [Theory]
        [InlineData(200, 101)]
        [InlineData(210, 105)]
        [InlineData(219, 110)]
        public void TestCrisisCategpry(int systolic, int diastolic)
        {
            BP = new BPCalculator.BloodPressure() { Systolic = systolic, Diastolic = diastolic };
            Assert.Equal(BPCalculator.BPCategory.Crisis, BP.Category);
        }

        [Theory]
        [InlineData(200, 60)]
        public void TestInvalidCategpry(int systolic, int diastolic)
        {
            BP = new BPCalculator.BloodPressure() { Systolic = systolic, Diastolic = diastolic };
            Assert.Equal(BPCalculator.BPCategory.None, BP.Category);
        }

        [Theory]
        [InlineData(39)]
        [InlineData(35)]
        [InlineData(31)]
        public void TestLowRate(int heartRate)
        {
            HR = new BPCalculator.HeartRateCalculator() { HeartRate = heartRate };
            Assert.Equal(BPCalculator.HRCategory.LowHR, HR.Category);
        }

        [Theory]
        [InlineData(40)]
        [InlineData(50)]
        [InlineData(65)]
        public void TestAverageRate(int heartRate)
        {
            HR = new BPCalculator.HeartRateCalculator() { HeartRate = heartRate };
            Assert.Equal(BPCalculator.HRCategory.Average, HR.Category);
        }

        [Theory]
        [InlineData(70)]
        [InlineData(80)]
        [InlineData(90)]
        public void TestPoorRate(int heartRate)
        {
            HR = new BPCalculator.HeartRateCalculator() { HeartRate = heartRate };
            Assert.Equal(BPCalculator.HRCategory.Poor, HR.Category);
        }

        [Theory]
        [InlineData(90000)]
        public void TestInvalidRate(int heartRate)
        {
            HR = new BPCalculator.HeartRateCalculator() { HeartRate = heartRate };
            Assert.Equal(BPCalculator.HRCategory.None, HRCategory.None );
        }
    }
}
