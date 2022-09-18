using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace PowerHelper.Control
{
    public partial class NumericUpDown : System.Windows.Controls.Control
    {
        private TextBox? NUDTextBox;
        private RepeatButton? NUDButtonUP;
        private RepeatButton? NUDButtonDown;

        public readonly static DependencyProperty MaxValueProperty;
        public readonly static DependencyProperty MinValueProperty;
        public readonly static DependencyProperty ValueProperty;
        public readonly static DependencyProperty MaxLengthProperty;

        static NumericUpDown()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NumericUpDown), new FrameworkPropertyMetadata(typeof(NumericUpDown)));

            MaxValueProperty = DependencyProperty.Register("MaxValue", typeof(int), typeof(NumericUpDown), new FrameworkPropertyMetadata(int.MaxValue));
            MinValueProperty = DependencyProperty.Register("MinValue", typeof(int), typeof(NumericUpDown), new FrameworkPropertyMetadata(int.MinValue));
            ValueProperty = DependencyProperty.Register("Value", typeof(int), typeof(NumericUpDown), new FrameworkPropertyMetadata(0));
            MaxLengthProperty = DependencyProperty.Register("MaxLength", typeof(int), typeof(NumericUpDown), new FrameworkPropertyMetadata(int.MaxValue));

        }

        public int MaxValue
        {
            get => (int)GetValue(MaxValueProperty);
            set => SetValue(MaxValueProperty, value);
        }

        public int MinValue
        {
            get => (int)GetValue(MinValueProperty);
            set => SetValue(MinValueProperty, value);
        }

        public int Value
        {
            get => (int)GetValue(ValueProperty);
            set
            {
                if (value > MaxValue || value < MinValue) return;
                SetValue(ValueProperty, value);
            }
        }

        public int MaxLength
        {
            get => (int)GetValue(MaxLengthProperty);
            set { SetValue(MaxLengthProperty, value); }
        }

        public override void OnApplyTemplate()
        {
            NUDTextBox = Template.FindName("NUDTextBox", this) as TextBox;
            NUDButtonUP = Template.FindName("NUDButtonUP", this) as RepeatButton;
            NUDButtonDown = Template.FindName("NUDButtonDown", this) as RepeatButton;

            if (NUDTextBox != null)
            {
                NUDTextBox.PreviewMouseWheel += NUDTextBox_MouseWheel;
                NUDTextBox.PreviewKeyDown += NUDTextBox_KeyDown;
            }
            if (NUDButtonUP != null)
                NUDButtonUP.Click += NUDButtonUP_Click;
            if (NUDButtonDown != null)
                NUDButtonDown.Click += NUDButtonDown_Click;
        }

        private void NUDTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Left:
                case Key.Down:
                    Value--;
                    break;
                case Key.Up:
                case Key.Right:
                    Value++;
                    break;
                case Key.Home:
                    Value = MaxValue;
                    break;
                case Key.End:
                    Value = MinValue;
                    break;
                case Key.PageUp:
                    Value += 10;
                    break;
                case Key.PageDown:
                    Value -= 10;
                    break;
                default:
                    break;
            }
        }

        private void NUDTextBox_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (e.Delta > 0)
                Value++;
            else if (e.Delta < 0)
                Value--;
        }

        private void NUDButtonUP_Click(object sender, RoutedEventArgs e)
            => Value++;

        private void NUDButtonDown_Click(object sender, RoutedEventArgs e)
            => Value--;

    }
}
