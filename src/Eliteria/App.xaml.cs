using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Eliteria
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            EventManager.RegisterClassHandler(typeof(TextBox), UIElement.KeyDownEvent, new KeyEventHandler(TextBox_KeyDown));
            EventManager.RegisterClassHandler(typeof(TextBox), CheckBox.KeyDownEvent, new KeyEventHandler(CheckBox_KeyDown));
            UpdateAppConfig("API", "https://localhost:44377/");

        }

        void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && (sender as TextBox).AcceptsReturn == false) MoveToNextUIElement(e);
        }
        private void CheckBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                MoveToNextUIElement(e);
                if (e.Handled == true)
                {
                    CheckBox cb = (CheckBox)sender;
                    cb.IsChecked = !cb.IsChecked;
                }
            }
        }

        private void MoveToNextUIElement(KeyEventArgs e)
        {
            FocusNavigationDirection focusDirection = FocusNavigationDirection.Next;
            TraversalRequest request = new TraversalRequest(focusDirection);
            UIElement elementWithFocus = Keyboard.FocusedElement as UIElement;
            if (elementWithFocus != null)
            {
                if (elementWithFocus.MoveFocus(request)) e.Handled = true;
            }
        }
        private static void UpdateAppConfig(string key, string value)
        {


            Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            configuration.AppSettings.Settings[key].Value = value;
            configuration.Save();
            ConfigurationManager.RefreshSection("appSettings");
        }
    }
}
