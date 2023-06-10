// --------------------------------------------------------------------------
// <copyright file="IsNullOrEmptyToVisibilityConverter.cs" author="Andrii Odeychuk">
//
// Copyright (c) Andrii Odeychuk. ALL RIGHTS RESERVED
// The entire contents of this file is protected by International Copyright Laws.
// </copyright>
// --------------------------------------------------------------------------

using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using OdeyTech.ProductivityKit.Extension;

namespace OdeyTech.WPF.UIElements.Converters
{
    /// <summary>
    /// A value converter that converts a text value to a <see cref="Visibility"/> value.
    /// </summary>
    public class IsNullOrEmptyToVisibilityConverter : IValueConverter
    {
        /// <summary>
        /// Converts a text value to a <see cref="Visibility"/> value.
        /// </summary>
        /// <param name="value">The text value to convert.</param>
        /// <param name="targetType">The target type of the conversion.</param>
        /// <param name="parameter">An optional parameter.</param>
        /// <param name="culture">The culture to use in the conversion.</param>
        /// <returns>The converted <see cref="Visibility"/> value.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var text = value as string;
            return text.IsNullOrEmpty() ? Visibility.Visible : Visibility.Collapsed;
        }

        /// <summary>
        /// Converts a <see cref="Visibility"/> value back to a text value.
        /// This method is not supported and will always throw a <see cref="NotSupportedException"/>.
        /// </summary>
        /// <param name="value">The <see cref="Visibility"/> value to convert back.</param>
        /// <param name="targetType">The target type of the conversion.</param>
        /// <param name="parameter">An optional parameter.</param>
        /// <param name="culture">The culture to use in the conversion.</param>
        /// <returns>Throws a <see cref="NotSupportedException"/>.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotSupportedException();
    }
}
