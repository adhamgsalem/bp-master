using System;
using System.ComponentModel.DataAnnotations;

namespace BPCalculator
{
    // BP categories
    public enum BPCategory
    {
        [Display(Name = "Error, Please measure again!")] None,
        [Display(Name="Low Blood Pressure")] Low,
        [Display(Name="Ideal Blood Pressure")]  Ideal,
        [Display(Name="Pre-High Blood Pressure")] PreHigh,
        [Display(Name ="High Blood Pressure")]  High
    };

    public class BloodPressure
    {
        public const int SystolicMin = 70;
        public const int SystolicMax = 190;
        public const int DiastolicMin = 40;
        public const int DiastolicMax = 100;

        [Range(SystolicMin, SystolicMax, ErrorMessage = "Invalid Systolic Value")]
        public int Systolic { get; set; }                       // mmHG

        [Range(DiastolicMin, DiastolicMax, ErrorMessage = "Invalid Diastolic Value")]
        public int Diastolic { get; set; }                      // mmHG

        // BP set of values
        //IF Systolic is less than 90 and Diastolic is less than 60 then BP is low
        public bool LowBloodPressure()
        {
            return (this.Systolic < 90 || this.Diastolic < 60);
        }

        //IF Systolic is less than 120 or euqal 90 and Diastolic is less than 80 or equal to 60 then BP is Ideal
        public bool IdealBloodPressure()
        {
            return ((this.Systolic < 120  && this.Systolic >= 90) && (this.Diastolic < 80 && this.Diastolic >= 60));
        }

         //IF Systolic is less than 140 or euqal 120 and Diastolic is less than 90 or equal to 80 then BP is PREHIGH
        public bool PreHighBloodPressure()
        {
            return ((this.Systolic < 140  && this.Systolic >= 120) && (this.Diastolic < 90 && this.Diastolic >= 80));
        }

        //IF Systolic is less than 190 or euqal 140 and Diastolic is less than 100 or equal to 90 then BP is HIGH
        public bool HighBloodPressure()
        {
            return ((this.Systolic < 190  && this.Systolic >= 140) && (this.Diastolic < 100 && this.Diastolic >= 90));
        }

        // calculate BP category
        public BPCategory Category
        {
            get
            {
                BPCategory NoValue = BPCategory.None;

                if (this.LowBloodPressure())
                {
                    return BPCategory.Low;
                }  
                
                    if (this.IdealBloodPressure())
                {
                    return BPCategory.Ideal;
                }   

                    if (this.PreHighBloodPressure())
                {
                    return BPCategory.PreHigh;
                }
                    
                    if (this.HighBloodPressure())
                {
                    return BPCategory.High;
                }

                return NoValue;
            }
        }
    }
}
