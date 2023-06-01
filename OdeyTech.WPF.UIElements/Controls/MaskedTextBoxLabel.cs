// --------------------------------------------------------------------------
// <copyright file="MaskedTextBoxLabel.cs" author="Andrii Odeychuk">
//
// Copyright (c) Andrii Odeychuk. ALL RIGHTS RESERVED
// The entire contents of this file is protected by International Copyright Laws.
// </copyright>
// --------------------------------------------------------------------------

using System.Windows;

namespace OdeyTech.WPF.UIElements.Controls
{
  /// <summary>
  /// A custom control that combines a label and a masked TextBox for user input.
  /// </summary>
  public class MaskedTextBoxLabel : TextEntryLabel
  {
    /// <summary>
    /// The mask pattern to apply for the input.
    /// </summary>
    public static readonly DependencyProperty MaskProperty =
        DependencyProperty.Register("Mask", typeof(string), typeof(MaskedTextBoxLabel), new FrameworkPropertyMetadata(string.Empty));

    /// <summary>
    /// Gets or sets the mask pattern to apply for the input.
    /// </summary>
    public string Mask
    {
      get => (string)GetValue(MaskProperty);
      set => SetValue(MaskProperty, value);
    }
  }
}