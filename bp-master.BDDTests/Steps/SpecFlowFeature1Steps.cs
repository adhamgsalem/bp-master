using BPCalculator;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace bp_master.BDDTests.Features.BloodPressure
{
    [Binding]
    public class SpecFlowFeature1Steps
    {
        public BPCalculator.BloodPressure BP;
        private int systolic;
        private int diastolic;
        

        [Given(@"the systolic number is (.*)")]
        public void GivenTheSystolicNumberIs(int systolic)
        {
            this.systolic = systolic;
        }

        [Given(@"the diastolic number is (.*)")]
        public void GivenTheDiastolicNumberIs(int diastolic)
        {
            this.diastolic = diastolic;
        }
        
        [Then(@"the cateogry should be low")]
        public void ThenTheResultShouldBeLow()
        {
            BP = new BPCalculator.BloodPressure() { Systolic = systolic, Diastolic = diastolic };
            Assert.AreEqual(BPCalculator.BPCategory.Crisis, BP.Category);
        }
    }
}
