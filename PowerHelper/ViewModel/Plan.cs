using PowerHelper.Helpers;

namespace PowerHelper.ViewModel
{
    public class Plan : PropertyBase
    {
        public string Name { get; set; }
        public int AcValue
        {
            get => acValue;
            set { SetProperty(ref acValue, value); }
        }
        int acValue = 100;
        public int DcValue
        {
            get => dcValue;
            set 
            {
                if (dcValue == value) return;
                //PowerCfgCli.SetCurrentPowerCfgDcPROCTHROTTLEMAX(value);
                SetProperty(ref dcValue, value);
            }
        }
        int dcValue = 100;
    }
}
