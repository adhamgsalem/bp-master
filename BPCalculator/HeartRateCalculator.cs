using System;
using System.ComponentModel.DataAnnotations;

namespace BPCalculator
{
    // BP categories
    public enum HRCategory
    {
        [Display(Name = "Error! Please measure again")] None,
        [Display(Name = "Low Heart Rate")] LowHR,
        [Display(Name = "Ideal Heart Rate")] Average,
        [Display(Name = "High Heart Rate")] Poor
    };

    public class HeartRateCalculator
    {

        public const int HearRateMin = 30;
        public const int HearRateMax = 110;

        [Range(HearRateMin, HearRateMax, ErrorMessage = "Invalid Heart Rate Value")]
        public int HeartRate { get; set; }

        //HR Values
        //
        public bool LowHeartRate()
        {
            return (this.HeartRate < 40);
        }

        //
        public bool AverageHeartRate()
        {
            return (this.HeartRate >= 40 && this.HeartRate < 70);
        }

        //
        public bool PoorHeartRate()
        {
            return (this.HeartRate >= 70 && this.HeartRate < 100);
        }

        // calculate BP category
        public HRCategory Category
        {
            get
            {
                HRCategory NoValue = HRCategory.None;

                if (this.LowHeartRate())
                {
                    return HRCategory.LowHR;
                }

                if (this.AverageHeartRate())
                {
                    return HRCategory.Average;
                }

                if (this.PoorHeartRate())
                {
                    return HRCategory.Poor;
                }

                return NoValue;
            }
        }
    }
}
