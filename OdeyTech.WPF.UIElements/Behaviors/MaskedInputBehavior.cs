// --------------------------------------------------------------------------
// <copyright file="MaskedInputBehavior.cs" author="Andrii Odeychuk">
//
// Copyright (c) Andrii Odeychuk. ALL RIGHTS RESERVED
// The entire contents of this file is protected by International Copyright Laws.
// </copyright>
// --------------------------------------------------------------------------

using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.Xaml.Behaviors;
using OdeyTech.ProductivityKit.Extension;

namespace OdeyTech.WPF.UIElements.Behaviors
{
    /// <summary>
    /// A behavior that provides masked input functionality for TextBox controls.
    /// </summary>
    public class MaskedInputBehavior : Behavior<TextBox>
    {
        private string regexPattern;

        /// <summary>
        /// The mask pattern to apply for the input.
        /// </summary>
        public static readonly DependencyProperty MaskProperty =
            DependencyProperty.Register("Mask", typeof(string), typeof(MaskedInputBehavior), new FrameworkPropertyMetadata(string.Empty));

        /// <summary>
        /// Gets or sets the mask pattern to apply for the input.
        /// </summary>
        public string Mask
        {
            get => (string)GetValue(MaskProperty);
            set => SetValue(MaskProperty, value);
        }

        private string RegexPattern
        {
            get
            {
                if (this.regexPattern.IsNullOrEmpty())
                {
                    var sb = new StringBuilder("^");

                    foreach (var maskChar in Mask)
                    {
                        if (maskChar == '0')
                        {
                            sb.Append("\\d");
                        }
                        else
                        {
                            sb.Append(Regex.Escape(maskChar.ToString()));
                        }
                    }

                    sb.Append("$");
                    this.regexPattern = sb.ToString();
                }

                return this.regexPattern;
            }
        }

        /// <summary>
        /// Executes when the behavior is attached to the TextBox.
        /// </summary>
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.PreviewKeyDown += OnPreviewKeyDown;
            AssociatedObject.PreviewTextInput += OnPreviewTextInput;
            DataObject.AddPastingHandler(AssociatedObject, OnPaste);
        }

        /// <summary>
        /// Executes when the behavior is detached from the TextBox.
        /// </summary>
        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.PreviewKeyDown -= OnPreviewKeyDown;
            AssociatedObject.PreviewTextInput -= OnPreviewTextInput;
            DataObject.RemovePastingHandler(AssociatedObject, OnPaste);
        }

        /// <summary>
        /// Executes when a new character is being previewed for input.
        /// </summary>
        private void OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var txtSender = sender as TextBox;
            var caretPos = txtSender.CaretIndex;
            var preInputText = txtSender.Text;
            var fullText = txtSender.Text.Insert(caretPos, e.Text);
            fullText = FormatText(fullText);

            if (!IsValid(fullText))
            {
                e.Handled = true;
                return;
            }

            txtSender.Text = fullText;
            var postInputText = ApplyMask(fullText, false);
            txtSender.CaretIndex = caretPos + (postInputText.Length - preInputText.Length);
            e.Handled = true;
        }

        /// <summary>
        /// Executes when a key is pressed while the TextBox has focus.
        /// </summary>
        private void OnPreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Back)
            {
                var txtSender = sender as TextBox;
                var caretPos = txtSender.CaretIndex;
                var preInputText = txtSender.Text;

                if (caretPos > 0)
                {
                    var fullText = txtSender.Text.Remove(caretPos - 1, 1);
                    txtSender.Text = FormatText(fullText);
                    var postInputText = ApplyMask(fullText, false);
                    txtSender.CaretIndex = caretPos - (preInputText.Length - postInputText.Length);
                }

                e.Handled = true;
            }
        }

        /// <summary>
        /// Executes when text is being pasted into the TextBox.
        /// </summary>
        private void OnPaste(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(string)))
            {
                var pastedText = (string)e.DataObject.GetData(typeof(string));
                var txtBox = sender as TextBox;
                var caretPos = txtBox.CaretIndex;
                var preInputText = txtBox.Text;
                var fullText = txtBox.Text.Insert(caretPos, pastedText);
                fullText = FormatText(fullText);

                if (!IsValid(fullText))
                {
                    e.CancelCommand();
                }
                else
                {
                    txtBox.Text = fullText;
                    var postInputText = ApplyMask(fullText, false);
                    txtBox.CaretIndex = caretPos + (postInputText.Length - preInputText.Length);
                    e.CancelCommand();
                }
            }
            else
            {
                e.CancelCommand();
            }
        }

        /// <summary>
        /// Determines if the input string is valid based on the mask pattern.
        /// </summary>
        private bool IsValid(string str)
        {
            var regex = new Regex(RegexPattern);

            // If the string matches the mask, it's valid
            if (regex.IsMatch(str))
            {
                return true;
            }

            // If the string doesn't match the mask, it may still be a valid in-progress input
            return regex.IsMatch(ApplyMask(str));
        }

        /// <summary>
        /// Applies the mask pattern to the input string.
        /// </summary>
        private string ApplyMask(string input, bool isRefill = true)
        {
            var output = new StringBuilder(Mask.Length);
            var inputIndex = 0;

            for (var i = 0; i < Mask.Length; i++)
            {
                if (Mask[i] == '0')
                {
                    if (inputIndex >= input.Length)
                    {
                        if (!isRefill)
                        {
                            return output.ToString();
                        }

                        output.Append("0");
                        continue;
                    }

                    if (input[inputIndex].IsDigit())
                    {
                        output.Append(input[inputIndex]);
                        inputIndex++;
                    }
                    else
                    {
                        return output.ToString();
                    }
                }
                else
                {
                    if (input.Length > 1 && inputIndex < input.Length)
                    {
                        if (input[inputIndex] != Mask[i])
                        {
                            return output.ToString();
                        }

                        inputIndex++;
                    }

                    output.Append(Mask[i]);
                }
            }

            // Append any remaining characters from the input
            if (inputIndex < input.Length)
            {
                output.Append(input.Substring(inputIndex));
            }

            return output.ToString();
        }

        /// <summary>
        /// Formats the input text according to the mask pattern.
        /// </summary>
        private string FormatText(string text)
        {
            var numericText = new string(text.Where(char.IsDigit).ToArray());
            var formattedText = new StringBuilder();
            var numericIndex = 0;

            foreach (var maskChar in Mask)
            {
                if (numericIndex >= numericText.Length)
                {
                    break;
                }

                if (maskChar == '0')
                {
                    formattedText.Append(numericText[numericIndex]);
                    numericIndex++;
                }
                else
                {
                    formattedText.Append(maskChar);
                }
            }

            return formattedText.ToString();
        }
    }
}
