using BPCalculator;
using System;
using Xunit;


namespace bp_master.Tests.BloodPressure  
{
    public class UnitTest1
    {
        public BPCalculator.BloodPressure BP;

        [Theory]
        [InlineData(71, 41)]
        [InlineData(89, 59)]
        [InlineData(80, 55)]
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
        public void TestIdealCategpry(int systolic, int diastolic)
        {
            BP = new BPCalculator.BloodPressure() { Systolic = systolic, Diastolic = diastolic };
            Assert.Equal(BPCalculator.BPCategory.Ideal, BP.Category);
        }

        [Theory]
        [InlineData(139, 81)]
        [InlineData(130, 80)]
        [InlineData(121, 89)]
        public void TestPreCategpry(int systolic, int diastolic)
        {
            BP = new BPCalculator.BloodPressure() { Systolic = systolic, Diastolic = diastolic };
            Assert.Equal(BPCalculator.BPCategory.PreHigh, BP.Category);
        }

        [Theory]
        [InlineData(180, 99)]
        [InlineData(170, 95)]
        [InlineData(160, 91)]
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

    }
}
