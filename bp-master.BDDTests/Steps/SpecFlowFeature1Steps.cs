using BPCalculator;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace bp_master.BDDTests.Features.BloodPressure
{
    [Binding]
    public class SpecFlowFeature1Steps
    {
        public BPCalculator.BloodPressure BP;

    [Given(@"the systolic number is (.*)")]
        public void GivenTheSystolicNumberIs(int systolic)
        {
            ScenarioContext.Current["SystolicNumber"] = systolic;
        }

        [Given(@"the diastolic number is (.*)")]
        public void GivenTheDiastolicNumberIs(int diastolic)
        {
            ScenarioContext.Current["DiastolicNumber"] = Diastolic;
        }
        
        [When(@"the we calculate category")]
        public void WhenTheWeCalculateCategory()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the result should be low")]
        public void ThenTheResultShouldBeLow()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
