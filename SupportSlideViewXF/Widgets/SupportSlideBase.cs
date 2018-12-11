using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace SupportSlideViewXF.Widgets
{
    public enum IndicatorPosition
    {
        Top, Bottom
    }

    public abstract class SupportSlideBase : View
    {
        public static readonly BindableProperty ShowIndicatorsProperty = BindableProperty.Create("ShowIndicators", typeof(bool), typeof(SupportSlideBase), true);
        public bool ShowIndicators
        {
            get { return (bool)GetValue(ShowIndicatorsProperty); }
            set { SetValue(ShowIndicatorsProperty, value); }
        }

        public static readonly BindableProperty TintColorProperty = BindableProperty.Create("TintColor", typeof(Color), typeof(SupportSlideBase), Color.Gray);
        public Color TintColor
        {
            get { return (Color)GetValue(TintColorProperty); }
            set { SetValue(TintColorProperty, value); }
        }

        public static readonly BindableProperty CurrentColorProperty = BindableProperty.Create("CurrentColor", typeof(Color), typeof(SupportSlideBase), Color.Purple);
        public Color CurrentColor
        {
            get { return (Color)GetValue(CurrentColorProperty); }
            set { SetValue(CurrentColorProperty, value); }
        }

        public static readonly BindableProperty ShowArrowsProperty = BindableProperty.Create("ShowArrows", typeof(bool), typeof(SupportSlideBase), false);
        public bool ShowArrows
        {
            get { return (bool)GetValue(ShowArrowsProperty); }
            set { SetValue(ShowArrowsProperty, value); }
        }

        public static readonly BindableProperty IndicatorsPositionProperty = BindableProperty.Create("IndicatorsPosition", typeof(IndicatorPosition), typeof(SupportSlideBase), IndicatorPosition.Bottom);
        public IndicatorPosition IndicatorsPosition
        {
            get { return (IndicatorPosition)GetValue(IndicatorsPositionProperty); }
            set { SetValue(IndicatorsPositionProperty, value); }
        }

        public static readonly BindableProperty CurrentPageIndexProperty = BindableProperty.Create("CurrentPageIndex", typeof(int), typeof(SupportSlideBase), 0);
        public int CurrentPageIndex
        {
            get { return (int)GetValue(CurrentPageIndexProperty); }
            set { SetValue(CurrentPageIndexProperty, value); }
        }


        /*
         * PUBLIC COMMANDS
         */
        public static readonly BindableProperty OnPageChangedCommandCommandProperty = BindableProperty.Create("OnPageChangedCommand", typeof(ICommand), typeof(SupportSlideBase), null);
        public ICommand OnPageChangedCommand
        {
            get { return (ICommand)GetValue(OnPageChangedCommandCommandProperty); }
            set { SetValue(OnPageChangedCommandCommandProperty, value); }
        }

        /*
         * PUBLIC EVENTS
         */
        public event EventHandler<int> OnPageChanged;


        /*
         * PUBLIC ACTION
         */
        public void SendOnPageChanged(int position)
        {
            OnPageChanged?.Invoke(this, position);
            OnPageChangedCommand?.Execute(position);
        }
    }
}
