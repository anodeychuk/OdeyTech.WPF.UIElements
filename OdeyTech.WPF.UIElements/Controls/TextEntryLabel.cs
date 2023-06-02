// --------------------------------------------------------------------------
// <copyright file="TextEntryLabel.cs" author="Andrii Odeychuk">
//
// Copyright (c) Andrii Odeychuk. ALL RIGHTS RESERVED
// The entire contents of this file is protected by International Copyright Laws.
// </copyright>
// --------------------------------------------------------------------------

using System.Windows;
using System.Windows.Controls;

namespace OdeyTech.WPF.UIElements.Controls
{
  /// <summary>
  /// A custom control that combines a label and a TextBox for user input.
  /// </summary>
  public class TextEntryLabel : Control
  {
    /// <summary>
    /// The label text to display.
    /// </summary>
    public static readonly DependencyProperty LabelTextProperty =
        DependencyProperty.Register("LabelText", typeof(string), typeof(TextEntryLabel));

    /// <summary>
    /// The text entered by the user.
    /// </summary>
    ///
    public static readonly DependencyProperty TextProperty =
        DependencyProperty.Register(
          "Text",
          typeof(string),
          typeof(TextEntryLabel),
          new FrameworkPropertyMetadata(
            string.Empty,
            FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

    /// <summary>
    /// The width of the label portion of the control.
    /// </summary>
    public static readonly DependencyProperty LabelWidthProperty =
        DependencyProperty.Register("LabelWidth", typeof(GridLength), typeof(TextEntryLabel), new FrameworkPropertyMetadata(new GridLength(1, GridUnitType.Star)));

    /// <summary>
    /// The width of the TextBox portion of the control.
    /// </summary>
    public static readonly DependencyProperty TextBoxWidthProperty =
        DependencyProperty.Register("TextBoxWidth", typeof(GridLength), typeof(TextEntryLabel), new FrameworkPropertyMetadata(new GridLength(1, GridUnitType.Star)));

    /// <summary>
    /// The hint text to display in the TextBox.
    /// </summary>
    public static readonly DependencyProperty TextHintProperty =
        DependencyProperty.Register("TextHint", typeof(string), typeof(TextEntryLabel), new FrameworkPropertyMetadata(string.Empty));

    /// <summary>
    /// Gets or sets the label text to display.
    /// </summary>
    public string LabelText
    {
      get => (string)GetValue(LabelTextProperty);
      set => SetValue(LabelTextProperty, value);
    }

    /// <summary>
    /// Gets or sets the text entered by the user.
    /// </summary>
    public string Text
    {
      get => (string)GetValue(TextProperty);
      set => SetValue(TextProperty, value);
    }

    /// <summary>
    /// Gets or sets the width of the label portion of the control.
    /// </summary>
    public GridLength LabelWidth
    {
      get => (GridLength)GetValue(LabelWidthProperty);
      set => SetValue(LabelWidthProperty, value);
    }

    /// <summary>
    /// Gets or sets the width of the TextBox portion of the control.
    /// </summary>
    public GridLength TextBoxWidth
    {
      get => (GridLength)GetValue(TextBoxWidthProperty);
      set => SetValue(TextBoxWidthProperty, value);
    }

    /// <summary>
    /// Gets or sets the hint text to display in the TextBox.
    /// </summary>
    public string TextHint
    {
      get => (string)GetValue(TextHintProperty);
      set => SetValue(TextHintProperty, value);
    }

    /// <summary>
    /// Static constructor for the TextEntryLabel control.
    /// </summary>
    static TextEntryLabel()
    {
      DefaultStyleKeyProperty.OverrideMetadata(typeof(TextEntryLabel), new FrameworkPropertyMetadata(typeof(TextEntryLabel)));
    }
  }
}