// --------------------------------------------------------------------------
// <copyright file="GridIndexConverter.cs" author="Andrii Odeychuk">
//
// Copyright (c) Andrii Odeychuk. ALL RIGHTS RESERVED
// The entire contents of this file is protected by International Copyright Laws.
// </copyright>
// --------------------------------------------------------------------------

using System;
using System.Globalization;
using System.Windows.Data;

namespace OdeyTech.WPF.UIElements.Converters
{
    /// <summary>
    /// A value converter that increments or decrements an integer value by 1.
    /// Mainly used for displaying zero-based index values in a more human-readable format.
    /// </summary>
    [ValueConversion(typeof(int), typeof(int))]
    public class GridIndexConverter : IValueConverter
    {
        /// <summary>
        /// Increments the given integer value by 1.
        /// </summary>
        /// <param name="value">The input value as an integer.</param>
        /// <param name="targetType">The type of the binding target property (not used).</param>
        /// <param name="parameter">An optional parameter (not used).</param>
        /// <param name="culture">The culture to use in the converter (not used).</param>
        /// <returns>The incremented value as an integer.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => (int)value + 1;

        /// <summary>
        /// Decrements the given integer value by 1.
        /// </summary>
        /// <param name="value">The input value as an integer.</param>
        /// <param name="targetType">The type of the binding target property (not used).</param>
        /// <param name="parameter">An optional parameter (not used).</param>
        /// <param name="culture">The culture to use in the converter (not used).</param>
        /// <returns>The decremented value as an integer.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => (int)value - 1;
    }
}
