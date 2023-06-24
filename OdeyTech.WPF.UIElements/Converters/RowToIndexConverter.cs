// --------------------------------------------------------------------------
// <copyright file="RowToIndexConverter.cs" author="Andrii Odeychuk">
//
// Copyright (c) Andrii Odeychuk. ALL RIGHTS RESERVED
// The entire contents of this file is protected by International Copyright Laws.
// </copyright>
// --------------------------------------------------------------------------

using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace OdeyTech.WPF.UIElements.Converters
{
    /// <summary>
    /// Represents a converter that finds the index of a row in a DataGrid.
    /// </summary>
    public class RowToIndexConverter : IValueConverter
    {
        /// <summary>
        /// Converts a DataGridRow object to its corresponding index in the DataGrid.
        /// </summary>
        /// <param name="value">The DataGridRow to find the index of.</param>
        /// <param name="targetType">The type of the binding target property. This parameter will not be used.</param>
        /// <param name="parameter">The converter parameter to use. This parameter will not be used.</param>
        /// <param name="culture">The culture to use in the converter. This parameter will not be used.</param>
        /// <returns>The 1-based index of the row in the DataGrid, or null if the row is not in the DataGrid.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DataGridRow item)
            {
                DataGrid grid = FindVisualParent<DataGrid>(item);
                if (grid != null)
                {
                    var index = grid.ItemContainerGenerator.IndexFromContainer(item);
                    return index < 0 ? null : index + 1;
                }
            }

            return null;
        }

        /// <summary>
        /// Finds the first parent of the specified DependencyObject that is of the specified type.
        /// </summary>
        /// <typeparam name="T">The type of the parent to find.</typeparam>
        /// <param name="child">The starting element in the parent lookup. If the element is the desired type, the lookup stops.</param>
        /// <returns>The first parent element that is of the specified type, or null if no such element is found.</returns>
        private static T FindVisualParent<T>(DependencyObject child) where T : DependencyObject
        {
            while (child is not null and not T)
            {
                child = VisualTreeHelper.GetParent(child);
            }

            return child as T;
        }

        /// <summary>
        /// ConvertBack is not implemented for RowToIndexConverter.
        /// This method is not supported and will always throw a <see cref="NotSupportedException"/>.
        /// </summary>
        /// <exception cref="NotSupportedException">Thrown when the method is invoked.</exception>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotSupportedException();
    }
}
