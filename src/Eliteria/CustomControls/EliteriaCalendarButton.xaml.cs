using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Eliteria.CustomControls
{
    /// <summary>
    /// Interaction logic for EliteriaCalendarButton.xaml
    /// </summary>
    public partial class EliteriaCalendarButton : UserControl
    {
        public EliteriaCalendarButton()
        {
            InitializeComponent();
            SelectedDate = null;
            BorderThickness = new Thickness(2);
        }


        public ICommand OnSelectedDateChangedCommand
        {
            get { return (ICommand)GetValue(OnSelectedDateChangedCommandProperty); }
            set { SetValue(OnSelectedDateChangedCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for OnSelectedDateChangedCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OnSelectedDateChangedCommandProperty =
            DependencyProperty.Register("OnSelectedDateChangedCommand", typeof(ICommand), typeof(EliteriaCalendarButton));



        public new Brush Background
        {
            get { return (Brush)GetValue(BackgroundProperty); }
            set { SetValue(BackgroundProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Background.  This enables animation, styling, binding, etc...
        public new static readonly DependencyProperty BackgroundProperty =
            DependencyProperty.Register("Background", typeof(Brush), typeof(EliteriaCalendarButton));



        public new Thickness BorderThickness
        {
            get { return (Thickness)GetValue(BorderThicknessProperty); }
            set { SetValue(BorderThicknessProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BorderThickness.  This enables animation, styling, binding, etc...
        public new static readonly DependencyProperty BorderThicknessProperty =
            DependencyProperty.Register("BorderThickness", typeof(Thickness), typeof(EliteriaCalendarButton));



        public DateTime? SelectedDate
        {
            get { return (DateTime?)GetValue(SelectedDateProperty); }
            set { SetValue(SelectedDateProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedDate.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedDateProperty =
            DependencyProperty.Register("SelectedDate", typeof(DateTime?), typeof(EliteriaCalendarButton));



        public DatePickerFormat SelectedDateFormat
        {
            get { return (DatePickerFormat)GetValue(SelectedDateFormatProperty); }
            set { SetValue(SelectedDateFormatProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedDateFormat.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedDateFormatProperty =
            DependencyProperty.Register("SelectedDateFormat", typeof(DatePickerFormat), typeof(EliteriaCalendarButton));

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (OnSelectedDateChangedCommand != null)
            {
                OnSelectedDateChangedCommand.Execute(null);
            }
        }
    }
}
