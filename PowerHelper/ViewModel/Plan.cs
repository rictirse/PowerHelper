using System.Drawing;
using System.Windows.Media;

namespace PowerHelper.ViewModel
{
    public class Plan : PropertyBase
    {
        public string Name { get; set; }
        /// <summary>
        /// 電池模式下最效能百分比
        /// </summary>
        public int AcValue
        {
            get => acValue;
            set 
            {
                SetProperty(ref acValue, value);
                AcClockSpeed = $"{((value / 100000f) * MaxClockSpeed):F2}GHz";
            }
        }
        int acValue = -1;
        /// <summary>
        /// 電源模式下最效能百分比
        /// </summary>
        public int DcValue
        {
            get => dcValue;
            set
            {
                SetProperty(ref dcValue, value);
                DcClockSpeed = $"{((value / 100000f) * MaxClockSpeed):F2}GHz";
            }
        }
        int dcValue = -1;
        /// <summary>
        /// CPU最高時脈，不含Tubro boots
        /// </summary>
        public int MaxClockSpeed { get; set; }
        /// <summary>
        /// 電源模式下最高時脈
        /// </summary>
        public string AcClockSpeed
        { 
            get => acClockSpeed;
            set { SetProperty(ref acClockSpeed, value); }
        }
        string acClockSpeed = string.Empty;
        /// <summary>
        /// 電池模式下最高時脈
        /// </summary>
        public string DcClockSpeed
        {
            get => dcClockSpeed;
            set { SetProperty(ref dcClockSpeed, value); }
        }
        string dcClockSpeed = string.Empty;
        /// <summary>
        /// 右下角常駐圖示
        /// </summary>
        public DrawingImage? Icon
        {
            get => icon;
            set { SetProperty(ref icon, value); }
        }
        DrawingImage? icon = null;
    }
}
