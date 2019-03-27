using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace RGmobile.Helpers
{
    /// <summary>
    /// Make sure value entered in the Entry box is a number
    /// </summary>
    public class NumericValidationBehavior : Behavior<Entry>
    {
        protected override void OnAttachedTo(Entry entry)
        {
            entry.TextChanged += OnEntryTextChanged;
            base.OnAttachedTo(entry);
        }

        protected override void OnDetachingFrom(Entry entry)
        {
            entry.TextChanged -= OnEntryTextChanged;
            base.OnDetachingFrom(entry);
        }

        protected virtual void OnEntryTextChanged(object sender, TextChangedEventArgs args)
        {
            if (string.IsNullOrWhiteSpace(args.NewTextValue))
            {
                ((Entry)sender).Text = "0";
                return;
            }

            // Make sure all characters are numbers
            bool isValid = int.TryParse(args.NewTextValue, out int result);

            ((Entry)sender).Text = isValid ? args.NewTextValue : args.OldTextValue; 
        }
    }
}
