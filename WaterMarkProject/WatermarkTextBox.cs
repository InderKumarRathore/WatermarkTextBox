using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

// The Templated Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234235

namespace WaterMarkProject
{
    public sealed class WatermarkTextBox : TextBox
    {
        public WatermarkTextBox()
        {
            this.DefaultStyleKey = typeof(WatermarkTextBox);
            this.TextChanged += TextBoxTextChanged;
            //this.GotFocus += WatermarkTextBox_GotFocus;
            //this.LostFocus += WatermarkTextBox_LostFocus;
        }

        #region Properties

        public static DependencyProperty WatermarkProperty = DependencyProperty.Register("Watermark", typeof(string), typeof(WatermarkTextBox), new PropertyMetadata(null));
        public string Watermark
        {
            get { return (string)GetValue(WatermarkProperty); }
            set { SetValue(WatermarkProperty, value); }
        }

        public static DependencyProperty WatermarkForegroundProeperty = DependencyProperty.Register("WatermarkForeground", typeof(Brush), typeof(WatermarkTextBox), new PropertyMetadata(null));
        public Brush WatermarkForeground
        {
            get { return (Brush)GetValue(WatermarkForegroundProeperty); }
            set { SetValue(WatermarkForegroundProeperty, value); }
        }

        public static DependencyProperty WatermarkTemplateProperty = DependencyProperty.Register("WatermarkTemplate", typeof(DataTemplate), typeof(WatermarkTextBox), new PropertyMetadata(null));
        public DataTemplate WatermarkTemplate
        {
            get { return (DataTemplate)GetValue(WatermarkTemplateProperty); }
            set { SetValue(WatermarkTemplateProperty, value); }
        }

        #endregion

        #region Base Class Overrides

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            object aver = this.WatermarkForeground;
            //we need to set the initial state of the watermark
            GoToWatermarkVisualState(false);
        }

        #endregion

        #region Event Handlers

        private void TextBoxTextChanged(object sender, TextChangedEventArgs e)
        {
            GoToWatermarkVisualState(false);
            WatermarkForeground = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 255, 0, 0));
        }

        #endregion

        #region Methods

        private void GoToWatermarkVisualState(bool hasFocus = true)
        {
            //if our text is empty and our control doesn't have focus then show the watermark
            //otherwise the control eirther has text or has focus which in either case we need to hide the watermark
            if (String.IsNullOrEmpty(Text) && !hasFocus)
                GoToVisualState("WatermarkVisible"); //TODO: create constants for our magic strings
            else
                GoToVisualState("WatermarkCollapsed");
        }

        private void GoToVisualState(string stateName, bool useTransitions = true)
        {
            VisualStateManager.GoToState(this, stateName, useTransitions);
        }

        #endregion
    }
}
