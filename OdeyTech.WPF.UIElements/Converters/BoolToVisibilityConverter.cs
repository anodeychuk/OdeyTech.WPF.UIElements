// --------------------------------------------------------------------------
// <copyright file="BoolToVisibilityConverter.cs" author="Andrii Odeychuk">
//
// Copyright (c) Andrii Odeychuk. ALL RIGHTS RESERVED
// The entire contents of this file is protected by International Copyright Laws.
// </copyright>
// --------------------------------------------------------------------------

using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace OdeyTech.WPF.UIElements.Converters
{
    /// <summary>
    /// A value converter that converts a boolean value to a <see cref="Visibility"/> value.
    /// </summary>
    [ValueConversion(typeof(bool), typeof(Visibility))]
    public sealed class BoolToVisibilityConverter : IValueConverter
    {
        private readonly Visibility trueValue = Visibility.Visible;
        private readonly Visibility falseValue = Visibility.Collapsed;

        /// <summary>
        /// Converts a boolean value to a <see cref="Visibility"/> value.
        /// </summary>
        /// <param name="value">The boolean value to convert.</param>
        /// <param name="targetType">The target type of the conversion.</param>
        /// <param name="parameter">An optional parameter.</param>
        /// <param name="culture">The culture to use in the conversion.</param>
        /// <returns>The converted <see cref="Visibility"/> value.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            => value is not bool ? null : (bool)value ? this.trueValue : this.falseValue;

        /// <summary>
        /// Converts a <see cref="Visibility"/> value back to a boolean value.
        /// </summary>
        /// <param name="value">The <see cref="Visibility"/> value to convert back.</param>
        /// <param name="targetType">The target type of the conversion.</param>
        /// <param name="parameter">An optional parameter.</param>
        /// <param name="culture">The culture to use in the conversion.</param>
        /// <returns>The converted boolean value.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => Equals(value, this.trueValue) ? true : Equals(value, this.falseValue) ? false : null;
    }
}
