// --------------------------------------------------------------------------
// <copyright file="NullToVisibilityConverter.cs" author="Andrii Odeychuk">
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
    /// Converts an object to a <see cref="Visibility"/> value.
    /// If the object is not null, <see cref="Visibility.Visible"/> is returned. Otherwise, <see cref="Visibility.Collapsed"/> is returned.
    /// </summary>
    [ValueConversion(typeof(object), typeof(Visibility))]
    public sealed class IsNotNullToVisibilityConverter : IValueConverter
    {
        /// <summary>
        /// Converts the specified value to a <see cref="Visibility"/> value.
        /// </summary>
        /// <param name="value">The value to convert. If this is null, <see cref="Visibility.Collapsed"/> will be returned.</param>
        /// <param name="targetType">The target type of the conversion. This is ignored.</param>
        /// <param name="parameter">Optional parameter. This is ignored.</param>
        /// <param name="culture">Culture-specific information for the conversion. This is ignored.</param>
        /// <returns>A <see cref="Visibility"/> value. If the input value is not null, <see cref="Visibility.Visible"/> is returned. Otherwise, <see cref="Visibility.Collapsed"/> is returned.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            => value == null
                ? Visibility.Collapsed
                : Visibility.Visible;

        /// <summary>
        /// Converts a <see cref="Visibility"/> value back to a object.
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
