using PowerHelper.Helpers;

namespace PowerHelper.ViewModel
{
    public class Plan : PropertyBase
    {
        public string Name { get; set; }
        public int AcValue
        {
            get => acValue;
            set 
            {
                if (acValue == value) return;
#if !DEBUG
                PowerCfgCli.SetCurrentAcPROCTHROTTLEMAX(value);
#endif
                SetProperty(ref acValue, value);
                AcClockSpeed = $"{((value / 100000f) * MaxClockSpeed):F2}GHz";
            }
        }
        int acValue = -1;
        public int DcValue
        {
            get => dcValue;
            set
            {
                if (dcValue == value) return;
#if !DEBUG
                PowerCfgCli.SetCurrentDcPROCTHROTTLEMAX(value);
#endif
                SetProperty(ref dcValue, value);
                DcClockSpeed = $"{((value / 100000f) * MaxClockSpeed):F2}GHz";
            }
        }
        int dcValue = -1;
        public int MaxClockSpeed { get; set; }

        public string AcClockSpeed
        { 
            get => acClockSpeed;
            set { SetProperty(ref acClockSpeed, value); }
        }
        string acClockSpeed = string.Empty;

        public string DcClockSpeed
        {
            get => dcClockSpeed;
            set { SetProperty(ref dcClockSpeed, value); }
        }
        string dcClockSpeed = string.Empty;
    }
}
